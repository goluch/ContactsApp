<template>
    <div v-if="this.$store.state.contactAdd" class="content">
        <h3>Add contact</h3>
        <form @submit.prevent="addContact">
            <div class="mb-3">
                <label for="Contact.forename">Forename:</label>
                <input type="text" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Contact.surname">Surname:</label>
                <input type="text" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Contact.email">Email:</label>
                <input type="email" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Contact.password">Password:</label>
                <input type="password" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Contact.category.categoryName">Category:</label>
                <input type="text" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Contact.category.subcategoryName">Subcategory:</label>
                <input type="text" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Contact.phoneNumber">Phone Number:</label>
                <input type="text" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Contact.birthDate">Birth Date:</label>
                <input type="date" class="form-control" required>
            </div>
            <button type="submit" class="btn btn-primary">Add User</button>
        </form>
    </div>
</template>

<script lang="ts">

    interface Category {
        id: int;
        categoryName: string;
        subcategoryName: string;
    }
    

    interface Contact {
        forename: string;
        surname: string;
        email: string;
        password: string;
        category: Category;
        phoneNumber: string;
        birthDate: date;
    }

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

                //this.Contact = null;
                fetch('CreateContact', {
                    method: 'POST',
                    headers: {'Content-Type':'application/json'},
                    body: JSON.stringify({       
                        Contact: Contact
                        }), 
                    })
                    .then(response => {
                        this.$store.commit('setLoading', false);
                        if (!response.ok) {
                            this.$store.commit('setMsg', "Failed to add contact.");
                            return;
                        }

                        this.$store.commit('setMsg', "Contact added successfully.");
                        return;
                    })
            },
        }
    }
</script>