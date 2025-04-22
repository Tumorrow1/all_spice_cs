<script setup>
import { Recipe } from '@/models/Recipe.js';
import { recipesService } from '@/services/RecipesService.js';



defineProps({
  recipe: { type: Recipe, required: true }
})

function setActiveRecipe(recipe) {
  recipesService.setActiveRecipe(recipe)
}

</script>


<template>
  <div class="card text-bg-dark" @click="setActiveRecipe(recipe)" data-bs-toggle="modal" data-bs-target="#recipeModal">
    <img :src="recipe.img" class="card-img images" alt="...">
    <div class="card-img-overlay justify-content-between d-flex align-items-start">
      <span class="bg-shaq-pink">{{ recipe.category }} </span>
      <span><i class="mdi mdi-heart"></i></span>
    </div>
    <div class="justify-content-between text-shadow flex-column d-flex"></div>
    <h5 class="card-title bg-shaq-pink mb-0">{{ recipe.title }}</h5>
  </div>

</template>


<style lang="scss" scoped>
.images {
  height: 30dvh;
}

.bg-shaq-pink {
  background: #f576e68c;
}
</style>