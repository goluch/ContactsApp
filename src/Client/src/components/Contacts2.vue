<template>
    <div class="contacts-component">
        <h1>Contacts</h1>

        <div v-if="loading" class="loading">
            Data unavailable, please check your internet connection then refresh.
        </div>

        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Forename</th>
                        <th>Surname</th>
                        <th>Email</th>
                        <th>Password</th>
                        <th>Category</th>
                        <th>Subcategory</th>
                        <th>Phone Number</th>
                        <th>Birth Date</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="contact in post" :key="contacts.date">
                        <td>{{ contact.forename }}</td>
                        <td>{{ contact.surname }}</td>
                        <td>{{ contact.email }}</td>
                        <td>{{ contact.password }}</td>
                        <td>{{ contact.category }}</td>
                        <td>{{ contact.subcategory }}</td>
                        <td>{{ contact.phoneNumber }}</td>
                        <td>{{ contact.birthDate }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    type Contacts = {
        forename: string,
        surname: string,
        email: string,
        password: string,
        category: string,
        subcategory: string,
        phoneNumber: string,
        password: birthDate
    }[];

    interface Data {
        loading: boolean,
        post: null | Contacts
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.post = null;
                this.loading = true;

                fetch('api/contacts/GetContactsWithPagination')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as Contacts;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>

<style scoped>
th {
    font-weight: bold;
}

th, td {
    padding-left: .5rem;
    padding-right: .5rem;
}

.contacts-component {
    text-align: center;
}

table {
    margin-left: auto;
    margin-right: auto;
}
</style>