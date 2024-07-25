import './assets/main.css'

import { createApp } from 'vue'
import { store, key } from './store'
import { useToast } from 'vue-toastification'
const toast = useToast()
import 'vue-toastification/dist/index.css'

import App from './App.vue'

import Menu from '@/components/Menu.vue'
import RegistrForm from '@/components/RegistrForm.vue'
import LoginForm from '@/components/LoginForm.vue'
import Contacts from '@/components/Contacts.vue'

const app = createApp(App)

app.component('app-menu', Menu)
app.component('app-registr', RegistrForm)
app.component('app-login', LoginForm)
app.component('app-contacts', Contacts)

app.use(store, key)
app.use(toast)

app.mount('#app')