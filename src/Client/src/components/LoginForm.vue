<script setup>
    import { ref } from 'vue'
</script>

<template>
    <div v-if="$store.state.loginMode">
        <h2>Login:</h2>
        <form @submit.prevent="login">
            <div class="mb-3">
                <label for="username">Username:</label>
                <input data-cy="username" type="text" class="form-control" v-model="username" required>
            </div>
            <label for="password">Password:</label>
            <input data-cy="password" type="password" class="form-control" :value="modelValue"
                   @input="$emit('update:modelValue', $event.target.value)" required>

            <button data-cy="submit" type="submit" class="btn btn-primary">Login</button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                username: '',
                password: '',
            };
        },
        methods: {
            login() {
                this.$store.commit('setLoading', true);
                this.$store.commit('setAllDisplaysNull');

                const url = `login?login=${this.username}&password=${this.password}`;
                let username = this.username;

                this.username = null;
                this.password = null;

                fetch(url, {
                    method: 'POST',
                })
                    .then(response => {
                        this.$store.commit('setLoading', false);
                        if (!response.ok) {
                            this.$store.commit('setMsg', "Failed to login "+ username);
                            return;
                        }

                        return response.json();
                    })
                    .then(json => {
                        this.$store.commit('setLoggedIn', json);
                        this.$store.commit('setLoading', false);

                        if (!this.$store.state.msg)
                            this.$store.commit('setMsg', json);
                    })
            }
        }
    }
</script>