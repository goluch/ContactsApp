import './assets/main.css'

import { createApp } from 'vue'
import { store, key } from './components/store'
import App from './App.vue'
import Menu from '@/components/Menu.vue'

const app = createApp(App)

app.component('app-menu', Menu)

app.use(store, key)

app.mount('#app')