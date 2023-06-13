<template>
  <v-text-field label="Title of quiz"></v-text-field>
  <v-card>
    <v-text-field v-model="q1" label="Question 1"></v-text-field>
    <v-text-field v-model="a1" label="Answer 1"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q2" label="Question 2"></v-text-field>
    <v-text-field v-model="a2" label="Answer 2"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q3" label="Question 3"></v-text-field>
    <v-text-field v-model="a3" label="Answer 3"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q4" label="Question 4"></v-text-field>
    <v-text-field v-model="a4" label="Answer 4"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q5" label="Question 5"></v-text-field>
    <v-text-field v-model="a5" label="Answer 5"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q6" label="Question 6"></v-text-field>
    <v-text-field v-model="a6" label="Answer 6"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q7" label="Question 7"></v-text-field>
    <v-text-field v-model="a7" label="Answer 7"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q8" label="Question 8"></v-text-field>
    <v-text-field v-model="a8" label="Answer 8"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q9" label="Question 9"></v-text-field>
    <v-text-field v-model="a9" label="Answer 9"></v-text-field>
  </v-card>
  <v-card>
    <v-text-field v-model="q10" label="Question 10"></v-text-field>
    <v-text-field v-model="a10" label="Answer 10"></v-text-field>
  </v-card>
  <v-btn>Cancel</v-btn>
  <v-btn>Create quiz</v-btn>
</template>

<script setup lang="ts">
import { watch } from 'vue'
import { inject, ref } from 'vue'

const props = defineProps<{
  modelValue: boolean
}>()

watch(
  () => props.modelValue,
  (value) => {
    if (value) {
      a1.value = ''
      a2.value = ''
      a3.value = ''
      a4.value = ''
      a5.value = ''
      a6.value = ''
      a7.value = ''
      a8.value = ''
      a9.value = ''
      a10.value = ''
      q1.value = ''
      q2.value = ''
      q3.value = ''
      q4.value = ''
      q5.value = ''
      q6.value = ''
      q7.value = ''
      q8.value = ''
      q9.value = ''
      q10.value = ''
    }
  }
)

const q1 = ref('')
const q2 = ref('')
const q3 = ref('')
const q4 = ref('')
const q5 = ref('')
const q6 = ref('')
const q7 = ref('')
const q8 = ref('')
const q9 = ref('')
const q10 = ref('')
const a1 = ref('')
const a2 = ref('')
const a3 = ref('')
const a4 = ref('')
const a5 = ref('')
const a6 = ref('')
const a7 = ref('')
const a8 = ref('')
const a9 = ref('')
const a10 = ref('')
</script>
