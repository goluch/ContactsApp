<script setup lang="ts">
    import { ref } from 'vue'
</script>

<template>
    <div v-if="$store.state.loginMode">
        <h2>Login:</h2>
        <form @submit.prevent="login">
            <div class="mb-3">
                <label for="useremail">User email:</label>
                <input data-cy="useremail" type="text" class="form-control" v-model="useremail" required/>
            </div>
            <div class="mb-3">
                <label for="password">Password:</label>
                <input data-cy="password" type="password" class="form-control" v-model="password" required/>
            </div>
            <button data-cy="submit" type="submit" class="btn btn-primary">Login</button>
        </form>
    </div>
</template>

<script lang="ts">
    export default {
        data() {
            return {
                useremail: '',
                password: '',
            };
        },
        methods: {
            login() {
                this.$store.commit('setLoading', true);
                this.$store.commit('setAllDisplaysNull');

                let email = this.useremail;
                let passwd = this.password;

                this.useremail = null;
                this.password = null;

                fetch('login', {
                    method: 'POST',
                    headers: {'Content-Type':'application/json'},
                    body: JSON.stringify({       
                        email: email.toLowerCase(),      
                        password: passwd,
                        twoFactorCode: "",
                        twoFactorRecoveryCode: ""
                        }), 
                    })
                .then(response => {
                    this.$store.commit('setLoading', false);
                    if (!response.ok) {
                        this.$store.commit('setMsg', 'Failed to login ' + email);
                        return response.json();
                    }
                    else
                    {
                        this.$store.commit('setMsg', 'Login succeed for ' + email);
                        return response.json();
                    }
                })
                .then(json => {
                    this.$store.commit('setloggedIn', json);
                    this.$store.commit('setLoading', false);
                    this.$store.commit('addMsg', ', JSON responce: ' + JSON.stringify(json));
                })
            }
        }
    }
</script>