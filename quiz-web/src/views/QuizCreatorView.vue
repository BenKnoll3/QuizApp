<template>
  <v-text-field v-model="quizTitle" label="Title of quiz"></v-text-field>

  <!-- Repeat for each question -->
  <v-card v-for="i in 10" :key="i">
    <v-text-field v-model="questions[i - 1]" :label="'Question ' + i"></v-text-field>
    <v-text-field v-model="answers[i - 1]" :label="'Answer ' + i"></v-text-field>
  </v-card>

  <v-btn @click="$router.push({ name: 'profile' })">Cancel</v-btn>

  <v-btn @click="clear">Clear</v-btn>
  <v-btn @click="createQuiz">Create quiz</v-btn>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import type { Ref } from 'vue'
import { Card } from '@/scripts/card'
import { Deck } from '@/scripts/deck'
import Axios from 'axios'

const quizTitle: Ref<string> = ref('')
const questions: Ref<string[]> = ref(Array(10).fill(''))
const answers: Ref<string[]> = ref(Array(10).fill(''))

function clear(): void {
  // Reset the values of the variables if needed
  quizTitle.value = ''
  questions.value = Array(10).fill('')
  answers.value = Array(10).fill('')
}

function createQuiz() {
  const deck = new Deck()
  deck.title = quizTitle.value
  deck.cards = []
  let deckBuilder = ''
  let cardBuilder = ''
  //Deck and Card to store ids for building purposes

  let cardData = null
  //Create a new deck and assign it to the logged in user
  Axios.post(`/Deck`, deck.title, {
    headers: { 'Content-Type': 'application/json' }
  })
    .then((response) => {
      const deckData = response.data
      //console.log(deckData)
      deckBuilder = deckData.deckId
      console.log(deckBuilder)
    })
    .then(() => {
      for (let j = 0; j < 10; j++) {
        if (questions.value[j] !== '' && answers.value[j] !== '') {
          const card = new Card()
          card.question = questions.value[j]
          card.answer = answers.value[j]

          //deck.cards.push(card)
          Axios.post(`/Card`, {
            Question: card.question,
            Answer: card.answer
          })
            .then((response) => {
              cardData = response.data
              cardBuilder = cardData.cardId
              console.log(cardBuilder)
            })
            .then(() =>
              Axios.post(`/Deck/AddCardToDeck`, {
                DeckId: deckBuilder,
                CardId: cardBuilder
              })
            )
          console.log(deckBuilder)
          console.log(cardBuilder)
          //Add new card to deck which takes deckId and cardID
        }
      }
    })
}
</script>
