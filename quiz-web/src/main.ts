import './assets/main.css'

import { createApp, reactive } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

import './assets/main.css'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import Axios from 'axios'
import { Services } from './scripts/services'
import { SignInService } from './scripts/signInService'

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

const signInService = reactive(SignInService.instance)
app.provide(Services.SignInService, signInService)

app.use(vuetify)

app.use(router)

app.mount('#app')
