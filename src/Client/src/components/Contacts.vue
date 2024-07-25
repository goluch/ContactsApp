<template>
    <div v-if="this.$store.state.contactsMode" class="content">
        <h2>Contacts:</h2>
        <vue-good-table :columns="columns" :rows="this.$store.state.contactsList">
            <template #table-row="props">
            </template>
        </vue-good-table>
    </div>
</template>

<script lang="ts">
    import { ref } from 'vue';
    import { VueGoodTable } from 'vue-good-table-next';
    import 'vue-good-table-next/dist/vue-good-table-next.css'
    export default {
        props: ['Forename'],
 
        components: {
            VueGoodTable,
        },
 
        setup() {
            const columns = ref([
                { label: 'Forename', field: 'forename' },
                { label: 'Surname', field: 'surname' },
            ]);
 
            return {
                columns,
            };
        }
    }
</script>

<style scoped>

</style>