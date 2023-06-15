<template>
  <v-app>
    <span class="bg"></span>
    <v-app-bar :elevation="3">
      <template v-slot>
        <v-app-bar-title>
          <RouterLink to="/">
            <v-icon icon="mdi-alpha-q-box" color="black"></v-icon>
            QuizApp
          </RouterLink>
        </v-app-bar-title>
        <v-spacer></v-spacer>

        <v-btn>
          <span v-if="!signInService.isSignedIn" @click="signIn">Not signed in</span>
          <span v-else>{{ signInService.token.userName }}</span>
        </v-btn>

        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-hamburger" v-bind="props"></v-btn>
          </template>

          <v-list width="200">
            <v-list-item>
              <RouterLink :to="{ name: 'profile' }"> Profile </RouterLink>
            </v-list-item>
            <v-list-item>
              <v-list-item-title v-if="signInService.isSignedIn" @click="signInService.signOut()">
                Sign Out
              </v-list-item-title>
              <v-list-item-title v-if="!signInService.isSignedIn" @click="signIn">
                Sign In
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>

    <v-main>
      <SignInDialog v-model="showSignInDialog"> </SignInDialog>
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
//import { useTheme } from 'vuetify/lib/framework.mjs'
import { inject, reactive, ref } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'
import { Services } from './scripts/services'
//import ActiveUser from './components/ActiveUser.vue'
import type { SignInService } from './scripts/signInService'
import SignInDialog from './components/SignInDialog.vue'
import { watch } from 'vue'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)

const signInService = inject(Services.SignInService) as SignInService
const showSignInDialog = ref(false)

function signIn() {
  showSignInDialog.value = true
}
</script>
