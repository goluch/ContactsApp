<template>
    <div class="sidebar">
        <a v-if="!$store.state.loggedIn" v-on:click="registerTrigger" data-cy="cy-login">Register</a>
        <a v-if="!$store.state.loggedIn" v-on:click="loginTrigger" data-cy="cy-login">Login</a>
        <a v-on:click="fetchContacts">Contacts list</a>
        <hr />
        <a v-if="$store.state.loggedIn" v-on:click="logout" data-cy="cy-logout">Logout</a>
    </div>
</template>

<script lang="ts">
    import { useStore } from 'vuex'
    import { key } from '../store'

    export default {
        methods: {
            setup () {
                const store = useStore(key)
                store.state.loggedIn
            },
            fetchContacts() {
                this.$store.commit('setLoading', true)
                this.$store.commit('setAllDisplaysNull')
                fetch('GetContacts')
                    .then(r => r.json())
                    .then(json => {
                        this.$store.commit('setContactsList', json)
                        this.$store.commit('setLoading', false)
                        return;
                    })
            },
            registerTrigger() {
                this.$store.commit('setAllDisplaysNull')
                this.$store.commit('setRegistrationMode', true)
            },
            loginTrigger() {
               this.$store.commit('setAllDisplaysNull')
               this.$store.commit('setLoginMode', true)
            },
            logout() {
               this.$store.commit('setAllDisplaysNull')
               this.$store.commit('setLoggedIn', false)
            },
            getFormattedDate() {
                const today = new Date();
                const year = today.getFullYear();
                let month = today.getMonth() + 1;
                let day = today.getDate();

                month = month < 10 ? `0${month}` : month;
                day = day < 10 ? `0${day}` : day;

                return `${year}-${month}-${day}`;
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
</style>