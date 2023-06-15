<template>
  <div>
    <h2>Random Quizzes</h2>
    <v-row>
      <v-col v-for="(deck, deckIndex) in Decks" :key="deckIndex" cols="12" sm="6" md="4" lg="3">
        <v-card>
          <v-card-title>Title: {{ deck.deckName }}</v-card-title>
          <v-card-text>Number of Questions: {{ deck.cards.length }} </v-card-text>
          <v-card-actions>
            <v-btn :to="{ name: 'quiz', query: { myString: deck.deckId } }">Take quiz</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'
import { Card } from '@/scripts/card'
import { Deck } from '@/scripts/deck'
import { useRouter } from 'vue-router'

const Decks = ref<Deck[]>([])

//Axios call to get decks
Axios.get(`/Deck/GetManyDecks`).then((result) => {
  console.log(result.data)
  Decks.value = result.data as Deck[]
})
</script>
