<template>
  <div class="about">
    <h1>This is an about page</h1>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>

<script setup lang="ts">
import Axios from 'axios'

Axios.get(`/WeatherForecast`)
  .then((res) => {
    console.log(res.data)
  })
  .catch((err) => {
    console.log(err)
  })
</script>
