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

const quizTitle: Ref<string> = ref('')
const questions: Ref<string[]> = ref(Array(10).fill(''))
const answers: Ref<string[]> = ref(Array(10).fill(''))

function clear(): void {
  // Reset the values of the variables if needed
  quizTitle.value = ''
  questions.value = Array(10).fill('')
  answers.value = Array(10).fill('')
}

function createQuiz(): void {
  // Access the values in the variables as needed
  console.log('Quiz Title:', quizTitle.value)
  console.log('Questions:', questions.value)
  console.log('Answers:', answers.value)

  const deck = new Deck()
  deck.deckId = Math.random().toString()
  deck.title = quizTitle.value
  deck.cards = []

  for (let j = 0; j < 10; j++) {
    const card = new Card()
    card.cardId = Math.random().toString()
    card.question = questions.value[j]
    card.answer = answers.value[j]
    deck.cards.push(card)
  }

  //Axios call to put deck into db

  // Use the created deck object as needed
  console.log('Created Deck:', deck)
}
</script>
