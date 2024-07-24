<template>
    <div class="sidebar">
        <a v-on:click="fetchContacts">Contacts list</a>
        <a v-if="!$store.state.loggedIn" v-on:click="loginTrigger" data-cy="cy-login">Login</a>
        <hr />
        <a v-if="$store.state.loggedIn" v-on:click="logout" data-cy="cy-logout">Logout</a>
    </div>
</template>

<script>
    import { useStore } from 'vuex'
    import { key } from './store'

    export default {
        methods: {
            // setup () {
            //    const store = useStore(key)
            //    store.state.loggedIn
            //}
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

<style scoped>
    .sidebar {
        height: 100%;
        width: 200px;
        position: fixed;
        top: 0;
        left: 0;
        z-index: 1;
        background-color: #111;
        overflow-x: hidden;
        padding-top: 20px;
    }

        .sidebar a {
            padding: 6px 8px 6px 16px;
            text-decoration: none;
            font-size: 20px;
            color: #818181;
            display: block;
            border: none;
            background: none;
            width: 100%;
            text-align: left;
            cursor: pointer;
            outline: none;
        }

            .sidebar a:hover {
                color: #f1f1f1;
            }

        .sidebar hr {
            background-color: white;
            color: white;
            height: 10px;
        }

    .active {
        background-color: green;
        color: white;
    }

    .active {
        background-color: green;
        color: white;
    }
</style>