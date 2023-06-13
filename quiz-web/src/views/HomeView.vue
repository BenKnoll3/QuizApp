<template>
  <div>
    <h2>Random Quizzes</h2>
    <v-row>
      <v-col v-for="(deck, deckIndex) in Decks" :key="deckIndex" cols="12" sm="6" md="4" lg="3">
        <v-card>
          <v-card-title>{{ deck.title }}</v-card-title>
          <v-card-text>Number of Questions: {{ deck.cards.length }}</v-card-text>
          <v-card-actions>
            <v-btn :to="{ name: 'quiz' }">Take quiz</v-btn>
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

for (let i = 0; i < 10; i++) {
  const deck = new Deck()
  deck.deckId = `Deck${i + 1}`
  deck.title = `Deck ${i + 1}`
  deck.cards = []

  for (let j = 0; j < 10; j++) {
    const card = new Card()
    card.cardId = Math.random().toString()
    card.question = `Deck ${i + 1} - Dummy Question ${j + 1}`
    card.answer = `Deck ${i + 1} - Dummy Answer ${j + 1}`
    deck.cards.push(card)
  }

  Decks.value.push(deck)
}

console.log(Decks)

//Axios call to get decks
</script>
