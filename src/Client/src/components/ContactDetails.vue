<template>
    <div v-if="this.$store.state.contactDetails" class="content">
        <h2>Contact details</h2>
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
                <tr>
                    <td>{{ contact.forename }}</td>
                    <td>{{ contact.surname }}</td>
                    <td>{{ contact.email }}</td>
                    <td>{{ contact.password }}</td>
                    <td>{{ contact.category.categoryName }}</td>
                    <td>{{ contact.category.subcategoryName }}</td>
                    <td>{{ contact.phoneNumber }}</td>
                    <td>{{ contact.birthDate }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        props: ['contact'],
    }
</script>