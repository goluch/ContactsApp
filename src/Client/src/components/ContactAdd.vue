<template>
    <div v-if="this.$store.state.contactAdd" class="content">
        <h3>Add contact</h3>
        <form @submit.prevent="addContact">
            <div class="mb-3">
                <label>Forename:</label>
                <input type="text" class="form-control" v-model="newContact.forename" required>
            </div>
            <div class="mb-3">
                <label>Surname:</label>
                <input type="text" class="form-control" v-model="newContact.surnameForm" required>
            </div>
            <div class="mb-3">
                <label>Email:</label>
                <input type="email" class="form-control" v-model="newContact.email" required>
            </div>
            <div class="mb-3">
                <label>Password:</label>
                <input type="password" class="form-control" v-model="newContact.password" required>
            </div>
            <div class="mb-3">
                <label>Category:</label>
                <select class="form-control" v-model="newContact.category.categoryName" required>
                    <option v-for="(item, index) in this.$store.state.suportedCategoriesList" :value="item.value" :key="index">{{ item }}</option>
                </select>
            </div>
            <div class="mb-3">
                <label>Subcategory:</label>
                <input type="text" class="form-control" v-model="newContact.category.subcategoryName" required>
            </div>
            <div class="mb-3">
                <label>Phone Number:</label>
                <input type="text" class="form-control" v-model="newContact.phoneNumber" required>
            </div>
            <div class="mb-3">
                <label>Birth Date:</label>
                <input type="date" class="form-control" v-model="newContact.birthDate" required>
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
            newContact: new Contact,
            categories: [],
            selectedCategory: null,
        };
    },
    methods: {
        addContact() {
            this.$store.commit('setLoading', true);
            this.$store.commit('setAllDisplaysNull');
            fetch('CreateContact', {
                method: 'POST',
                headers: {'Content-Type':'application/json'},
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