<template>
    <div v-if="this.$store.state.contactDetails" class="content">
        <h3>Contact {{ contact.forename }} {{ contact.surname }} details:</h3>
        <p><em>Email:</em> {{ contact.email }}</p>
        <p><em>Password:</em> {{ contact.password }}</p>
        <p><em>Category:</em> {{ contact.category.categoryName }}</p>
        <p><em>Subcategory:</em> {{ contact.category.subcategoryName }}</p>
        <p><em>Phone Number:</em> {{ contact.phoneNumber }}</p>
        <p><em>Birth Date:</em> {{ contact.birthDate }}</p>
    </div>
</template>

<script>
    export default {
        props: ['contact'],
    }
</script>