<template>
    <div v-if="this.$store.state.contactsMode" class="content">
        <h2>Contacts:</h2>
        <vue-good-table :columns="columns" :rows="this.$store.state.contactsList">
            <template #table-row="props">
                <span v-if="props.column.field == 'action'">
                    <button v-on:click="showContactDetails(props.row.originalIndex)"
                            class="btn btn-primary">
                        Show details
                    </button>
                    <button v-if="this.$store.state.loggedIn" v-on:click="showContactEdit(props.row.originalIndex)"
                            class="btn btn-warning">
                        Edit
                    </button>
                    <button v-if="this.$store.state.loggedIn" v-on:click="showContactDelete(props.row.originalIndex)"
                            class="btn btn-danger">
                        Delete
                    </button>
                </span>
            </template>
        </vue-good-table>
        <button v-if="this.$store.state.loggedIn" v-on:click="showContactAdd()"
                class="btn btn-success">
            Add new
        </button>
    </div>
    <app-contacts-add />
    <app-contacts-details v-bind:contact="selectedContact" />
    <app-contacts-edit v-bind:contact="selectedContact" />
    <app-contacts-delete v-bind:contact="selectedContact" />
</template>

<script lang="ts">
    import { ref } from 'vue'
    import { VueGoodTable } from 'vue-good-table-next'
    import 'vue-good-table-next/dist/vue-good-table-next.css'
    export default {
        components: {
            VueGoodTable,
        },
        data() {
            return {
                selectedContact: null,
            };
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
            showContactDetails(id) {
                this.selectedContact = this.$store.state.contactsList[id];
                this.$store.commit('setAllDisplaysNull')
                this.$store.commit('setContactsDetails', true)
                return
            },
            showContactAdd() {
                this.$store.commit('setAllDisplaysNull')
                this.$store.commit('setContactsAdd', true)
                return
            },
            showContactEdit(id) {
                this.selectedContact = this.$store.state.contactsList[id];
                this.$store.commit('setAllDisplaysNull')
                this.$store.commit('setContactsEdit', true)
                return
            },
            showContactDelete(id) {
                this.selectedContact = this.$store.state.contactsList[id];
                this.$store.commit('setAllDisplaysNull')
                this.$store.commit('setContactsDelete', true)
                return
            },
        }
    }
</script>

<style scoped>

</style>