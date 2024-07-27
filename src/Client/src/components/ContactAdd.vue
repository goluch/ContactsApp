<template>
    <div v-if="this.$store.state.contactAdd" class="content">
        <h3>Add contact</h3>
        <form @submit.prevent="addContact">
            <div class="mb-3">
                <label for="forename">Forename:</label>
                <input type="text" class="form-control" v-model="forename" required>
            </div>
            <div class="mb-3">
                <label for="surname">Surname:</label>
                <input type="text" class="form-control" v-model="surnameForm" required>
            </div>
            <div class="mb-3">
                <label for="email">Email:</label>
                <input type="email" class="form-control" v-model="email" required>
            </div>
            <div class="mb-3">
                <label for="password">Password:</label>
                <input type="password" class="form-control" v-model="password" required>
            </div>
            <div class="mb-3">
                <label for="categoryName">Category:</label>
                <input type="text" class="form-control" v-model="categoryName" required>
            </div>
            <div class="mb-3">
                <label for="subcategoryName">Subcategory:</label>
                <input type="text" class="form-control" v-model="subcategoryName" required>
            </div>
            <div class="mb-3">
                <label for="phoneNumber">Phone Number:</label>
                <input type="text" class="form-control" v-model="phoneNumber" required>
            </div>
            <div class="mb-3">
                <label for="birthDate">Birth Date:</label>
                <input type="date" class="form-control" v-model="birthDate" required>
            </div>
            <button type="submit" class="btn btn-primary">Add Contact</button>
        </form>
    </div>
</template>

<script lang="ts">
    export default {
        data(): Contact {
            return {
                forename: '',
                surname: '',
                email: '',
                password: '',
                category: {
                    id: 0,
                    categoryName: '',
                    subcategoryName: '',
                },
                phoneNumber: '',
                birthDate: null,
            };
        },
        methods: {
            addContact() {
                this.$store.commit('setLoading', true);
                this.$store.commit('setAllDisplaysNull');

                //Contact newContact = this.useremail;

                //this.Contact = null; //wyczyœciæ formukarz po wys³aniu
                fetch('CreateContact', {
                    method: 'POST',
                    headers: {'Content-Type':'application/json'},
                    body: JSON.stringify({
                        id: 0,
                        forename: forename,
                        surname: surnameForm,
                        email: email,
                        password: password,
                        category: {
                            id: 0,
                            categoryName: categoryName,
                            subcategoryName: subcategoryName
                        },
                        phoneNumber: phoneNumber,
                        birthDate: birthDate
                        }), 
                    })
                    .then(response => {
                    this.$store.commit('setLoading', false);
                    if (!response.ok) {
                        this.$store.commit('setMsg', 'Failed to add contact.');
                        return response.json();
                    }
                    else
                    {
                        this.$store.commit('setMsg', "Contact added successfully.");
                        return response.json();
                    }
                })
                .then(json => {
                    this.$store.commit('setLoading', false);
                    this.$store.commit('addMsg', ', JSON responce: ' + JSON.stringify(json));
                })
            },
        }
    }
</script>