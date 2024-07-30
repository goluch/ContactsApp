<template>
    <div v-if="this.$store.state.contactDelete" class="content">
        <h3>Contact {{ contact.forename }} {{ contact.surname }} details:</h3>
        <p><em>Email:</em> {{ contact.email }}</p>
        <p><em>Password:</em> {{ contact.password }}</p>
        <p><em>Category:</em> {{ contact.category.categoryItemValue.categoryName }}</p>
        <p><em>Subcategory:</em> {{ contact.category.subcategoryName }}</p>
        <p><em>Phone Number:</em> {{ contact.phoneNumber }}</p>
        <p><em>Birth Date:</em> {{ contact.birthDate }}</p>
        <button v-on:click="deleteContact" class="btn btn-danger">Delete contact</button>
    </div>
</template>

<script setup lang="ts">
    const props = defineProps({
        contact: Contact
    })
</script>

<script lang="ts">
    import { Contact, Category } from "../common/types";

    export default {
        methods: {
            deleteContact() {
                this.$store.commit('setLoading', true);
                this.$store.commit('setAllDisplaysNull');
                fetch(`DeleteContact/${this.contact.id}`, {
                    method: 'DELETE',
                    headers: { 'Content-Type': 'application/json' },
                })
                    .then(response => {
                        this.$store.commit('setLoading', false);
                        if (!response.ok) {
                            this.$store.commit('setMsg', 'Failed to delete contact.');
                            return;
                        }
                        else {
                            this.$store.commit('setMsg', "Contact changes deleted successfully.");
                            return;
                        }
                    })
            },
        }
    }
</script>