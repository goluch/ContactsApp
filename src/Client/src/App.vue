<script setup lang="ts">
import HelloWorld from './components/Contacts.vue'
</script>

<template>
    <!--<header>
        <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />
    </header>-->
    <app-menu/>
    <main>
        <div class="wrapper">
            <HelloWorld msg="See your contacts" />
        </div>
    </main>
</template>

<script lang="ts">
    import { useToast } from "vue-toastification";
    import { defineComponent } from 'vue';
    export default defineComponent({
        setup() {
            const toast = useToast()
            return { toast }
        },
        data() {
            return {
                darkMode: false,
            }
        },

        methods: {
            toggleMode() {
                this.darkMode = !this.darkMode;
                this.toast(this.darkMode ? "Dark mode enabled" : "Light mode enabled", {
                    position: "top-right",
                    timeout: 5000,
                    closeOnClick: true,
                    pauseOnFocusLoss: true,
                    pauseOnHover: true,
                    draggable: true,
                    draggablePercent: 0.6,
                    showCloseButtonOnHover: false,
                    hideProgressBar: true,
                    closeButton: "button",
                    icon: "fas fa-rocket",
                    rtl: false
                });
            },
        }
    })
</script>


<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
