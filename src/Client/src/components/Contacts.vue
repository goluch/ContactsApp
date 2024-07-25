<template>
    <div v-if="this.$store.state.contactsMode" class="content">
        <h2>Contacts:</h2>
        <vue-good-table :columns="columns" :rows="this.$store.state.contactsList">
            <template #table-row="props">
                <span v-if="props.column.field == 'action'">
                    <button v-on:click="showContactDetails(props.row.forename)"
                            class="btn btn-primary">
                        Show details
                    </button>
                    <br />
                    <button v-if="this.$store.state.loggedIn" v-on:click="addContact(props.row.forename)"
                            class="btn btn-primary mt-2">
                        Add
                    </button>
                    <button v-if="this.$store.state.loggedIn" v-on:click="editContact(props.row.forename)"
                            class="btn btn-primary mt-2">
                        Edit
                    </button>
                    <button v-if="this.$store.state.loggedIn" v-on:click="deleteContact(props.row.forename)"
                            class="btn btn-primary mt-2">
                        Delete
                    </button>
                </span>
            </template>
        </vue-good-table>
    </div>
</template>

<script lang="ts">
    import { ref } from 'vue'
    import { VueGoodTable } from 'vue-good-table-next'
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
                { label: 'Action', field: 'action', sortable: false },
            ]);
 
            return {
                columns,
            };
        },
        methods: {
            showContactDetails(forename) {
               //this.selectedStopName = stopDesc;
               this.$store.commit('setLoading', true)
               this.$store.commit('setAllDisplaysNull')
               //fetch('stopinfo/' + stopID)
               //    .then(r => r.json())
               //    .then(json => {
               //        this.$store.commit('setStopInfo', json);
               //        this.$store.commit('setLoading', false);
                       return;
               //    });
            },
        }

    }
</script>

<style scoped>

</style>