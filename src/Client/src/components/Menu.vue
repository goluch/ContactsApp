<template>
    <div class="sidebar">
        <a v-on:click="fetchContacts">Contacts list</a>
    </div>
</template>

<script>
    export default {
        methods: {
            fetchUsers() {
                //this.$store.commit('setLoading', true);
                //this.$store.commit('setAllDisplaysNull');
                fetch('/api/Contacts/GetContacts')
                    .then(r => r.json())
                    .then(json => {
                        //this.$store.commit('setUsersList', json);
                        //this.$store.commit('setLoading', false);
                        return;
                    });
            }
        }
    }
</script>
