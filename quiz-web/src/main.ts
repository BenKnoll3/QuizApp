import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import Axios from 'axios'

//Check if the app is running on localhost
if (window.location.hostname === `localhost` || window.location.hostname === `127.0.0.1`) {
  Axios.defaults.baseURL = `https://localhost:7108/`
} else {
  Axios.defaults.baseURL = `https://quizapp2023.azurewebsites.net/`
}

const vuetify = createVuetify({
  components,
  directives
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
