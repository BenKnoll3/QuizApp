<template>
  <main>
    <div v-if="currentDeck">
      <h2>{{ currentDeck.title }}</h2>
      <v-card v-for="card in currentDeck.cards" :key="card.cardId">
        <v-card-title>{{ card.question }}</v-card-title>
        <v-card-actions>
          <v-btn @click="showAnswer(card)">Show Answer</v-btn>
        </v-card-actions>
        <v-card-text v-if="card.showAnswer">{{ card.answer }}</v-card-text>
      </v-card>
    </div>
    <v-btn to="/profile">Go back to Profile</v-btn>
  </main>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { Deck } from '@/scripts/deck'
import { Card } from '@/scripts/card'
import Axios from 'axios'
import { useRoute } from 'vue-router'

const route = useRoute()
const myString = route.query.myString as string
console.log(myString)

//const currentDeck = ref<Deck | null>(null)

//Axios call to get deck user clicked on
const currentDeck = ref<Deck | null>(null)

Axios.get('/Deck', {
  params: {
    deckId: myString
  }
})
  .then((result) => {
    currentDeck.value = result.data as Deck
    // Use the currentDeck as needed
    console.log(currentDeck)
  })
  .catch((error) => {
    console.error('Error:', error)
  })

// Sample deck data
/*
const deck = new Deck()
deck.title = 'Sample Deck'
deck.cards = [
  { cardId: '1', question: 'Question 1', answer: 'Answer 1', showAnswer: false },
  { cardId: '2', question: 'Question 2', answer: 'Answer 2', showAnswer: false },
  { cardId: '3', question: 'Question 3', answer: 'Answer 3', showAnswer: false }
]
*/

function showAnswer(card: Card): void {
  card.showAnswer = true
}
</script>
