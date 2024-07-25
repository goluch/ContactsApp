<template>
    <app-menu/>
    <main class="main">
        <div data-cy="msg" v-if="this.$store.state.msg" class="alert alert-secondary" role="alert">
            {{ this.$store.state.msg }}
        </div>

        <div v-if="this.$store.state.loading" class="alert alert-info" role="alert">
            Processing... Please wait.
        </div>
        <Contacts msg="See your contacts" />
        <app-registr />
        <app-login />
        <app-contacts/>
    </main>
</template>

<script lang="ts">
    import { useToast } from "vue-toastification";
    import { defineComponent } from 'vue';
</script>


<style scoped>
    .main {
        margin-left: 200px;
        font-size: 20px;
        padding: 0px 10px;
        color: black;
    }

</style>
