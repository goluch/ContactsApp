import './assets/main.css'

import { createApp } from 'vue'
import { store, key } from './store'
import { useToast } from 'vue-toastification'
const toast = useToast()
import 'vue-toastification/dist/index.css'

import App from './App.vue'

import Menu from '@/components/Menu.vue'
import RegistrForm from '@/components/RegisterForm.vue'
import LoginForm from '@/components/LoginForm.vue'
import Contacts from '@/components/Contacts.vue'
import ContactDetails from '@/components/ContactDetails.vue'
import ContactAdd from '@/components/ContactAdd.vue'
import ContactEdit from '@/components/ContactEdit.vue'
import ContactDelete from '@/components/ContactDelete.vue'

const app = createApp(App)

app.component('app-menu', Menu)
app.component('app-registr', RegistrForm)
app.component('app-login', LoginForm)
app.component('app-contacts', Contacts)
app.component('app-contacts-details', ContactDetails)
app.component('app-contacts-add', ContactAdd)
app.component('app-contacts-edit', ContactEdit)
app.component('app-contacts-delete', ContactDelete)

app.use(store, key)
app.use(toast)

app.mount('#app')