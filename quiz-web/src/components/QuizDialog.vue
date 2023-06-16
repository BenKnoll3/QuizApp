<template>
  <div>
    <!-- Deck List -->
    <v-row>
      <v-col v-for="(deck, deckIndex) in Decks" :key="deckIndex" cols="12" sm="6" md="4" lg="3">
        <v-card @click="showCardDialog(deck)">
          <v-card-title>{{ deck.deckName }}</v-card-title>
          <v-card-text>Number of Questions: {{ deck.cards.length }}</v-card-text>
          <v-card-actions>
            <v-btn color="primary">Take quiz</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>

    <!-- Card Dialog -->
    <v-dialog v-model="cardDialogVisible">
      <v-card>
        <v-card-title>{{ currentCard?.question }}</v-card-title>
        <!-- Updated line -->
        <v-card-text>{{ showAnswer ? currentCard?.answer : '' }}</v-card-text>
        <!-- Updated line -->
        <v-card-actions>
          <v-btn @click="toggleAnswer">Show Answer</v-btn>
          <v-btn @click="nextCard">Next Card</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { Card } from '@/scripts/card'
import { Deck } from '@/scripts/deck'
import { useRouter } from 'vue-router'

const Decks = ref<Deck[]>([])
const cardDialogVisible = ref(false)
const currentDeck = ref<Deck | null>(null)
const currentCardIndex = ref(0)
const showAnswer = ref(false)
const currentCard = ref<Card | null>(null)

// ... Dummy data and Axios call initialization ...

// Show the card dialog and set the current deck
function showCardDialog(deck: Deck): void {
  currentDeck.value = deck
  currentCardIndex.value = 0
  showAnswer.value = false
  currentCard.value = getCurrentCard()
  cardDialogVisible.value = true
}

// Get the current card based on the current card index
function getCurrentCard(): Card | null {
  if (currentDeck.value) {
    const cards = currentDeck.value.cards
    if (currentCardIndex.value >= 0 && currentCardIndex.value < cards.length) {
      return cards[currentCardIndex.value]
    }
  }
  return null
}

// Toggle between showing the question and the answer
function toggleAnswer(): void {
  showAnswer.value = !showAnswer.value
}

// Move to the next card
function nextCard(): void {
  if (currentDeck.value) {
    const cards = currentDeck.value.cards
    if (currentCardIndex.value < cards.length - 1) {
      currentCardIndex.value++
      showAnswer.value = false
      currentCard.value = getCurrentCard()
    } else {
      // Reached the end of the cards, close the dialog
      cardDialogVisible.value = false
    }
  }
}
</script>
