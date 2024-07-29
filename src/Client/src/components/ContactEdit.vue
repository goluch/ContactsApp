<template>
    <div v-if="this.$store.state.contactEdit" class="content">
        <h3>Add contact</h3>
        <form @submit.prevent="editContact">
            <div class="mb-3">
                <label>Forename:</label>
                <input type="text" class="form-control" v-model="contact.forename" required>
            </div>
            <div class="mb-3">
                <label>Surname:</label>
                <input type="text" class="form-control" v-model="contact.surname" required>
            </div>
            <div class="mb-3">
                <label>Email:</label>
                <input type="email" class="form-control" v-model="contact.email" required>
            </div>
            <div class="mb-3">
                <label>Password:</label>
                <input type="password" class="form-control" v-model="contact.password" required>
            </div>
            <div class="mb-3">
                <label>Category:</label>
                <select class="form-control" v-model="contact.category.categoryItemValue" @change="adjustSubcategory" required>
                    <option v-for="item in this.$store.state.suportedCategoriesList" :value="item">{{ item.categoryName }}</option>
                </select>
            </div>
            <div class="mb-3">
                <label v-if="showSubcategoryLabel">Subcategory:</label>
                <input v-if="showSubcategoryInput" type="text" class="form-control" v-model="contact.category.subcategoryName" required>
                <select v-if="showSubcategorySelect" class="form-control" v-model="contact.category.subcategoryName" required>
                    <option v-for="item in this.$store.state.suportedBusinessSubcategoriesList" :value="item">{{ item }}</option>
                </select>

            </div>
            <div class="mb-3">
                <label>Phone Number:</label>
                <input type="tel" class="form-control" v-model="contact.phoneNumber" required>
            </div>
            <div class="mb-3">
                <label>Birth Date:</label>
                <input type="date" class="form-control" v-model="contact.birthDate" required>
            </div>
            <button type="submit" class="btn btn-primary">Add Contact</button>
        </form>
    </div>
</template>

<script lang="ts">
    import { Contact, Category } from "../common/types";

    export default {
        data() {
            return {
                showSubcategoryLabel: false,
                showSubcategoryInput: false,
                showSubcategorySelect: false,
                newContact: new Contact,
            };
        },
        props: ['contact'],
        methods: {
            isSubcategorySelectDisabled() {
                return false;
            },
            adjustSubcategory(e) {
                switch (this.newContact.category.categoryItemValue.allowedSubcategories) {
                    case 'Any':
                        this.showSubcategoryLabel = true;
                        this.showSubcategoryInput = true;
                        this.showSubcategorySelect = false;
                        break;
                    case 'Restricted':
                        this.showSubcategoryLabel = true;
                        this.showSubcategoryInput = false;
                        this.showSubcategorySelect = true;
                        break;
                    case 'None':
                        this.showSubcategoryLabel = false;
                        this.showSubcategoryInput = false;
                        this.showSubcategorySelect = false;
                        break;
                }
            },
            editContact() {
                this.$store.commit('setLoading', true);
                this.$store.commit('setAllDisplaysNull');
                fetch('CreateContact', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(this.newContact),
                })
                    .then(response => {
                        this.$store.commit('setLoading', false);
                        if (!response.ok) {
                            this.$store.commit('setMsg', 'Failed to add contact.');
                            return;
                        }
                        else {
                            this.$store.commit('setMsg', "Contact added successfully.");
                            return;
                        }
                    })
            },
        }
    }
</script>