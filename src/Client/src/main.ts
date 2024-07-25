import './assets/main.css'

import { createApp } from 'vue'
import { store, key } from './store'
import Toast from 'vue-toastification'
import 'vue-toastification/dist/index.css'

import App from './App.vue'

import Menu from '@/components/Menu.vue'
import LoginForm from '@/components/LoginForm.vue'

const app = createApp(App)

app.component('app-menu', Menu)
app.component('app-login', LoginForm)

app.use(store, key)

app.mount('#app')