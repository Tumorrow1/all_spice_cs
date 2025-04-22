<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';

const recipe = computed(() => AppState.activeRecipe)
</script>


<template>


  <div class="modal" id="recipeModal" tabindex="-1">
    <div class="modal-dialog modal-lg">
      <div v-if="recipe" class="modal-content">
        <div class="modal-body">
          <div class="container">
            <div class="row">
              <div class="col-6">
                <div><img :src="recipe.img" alt="" class="modal-img"></div>
              </div>
              <div class="col-6">
                <span class="d-flex">
                  <h5 class="modal-title">{{ recipe.title }}</h5>
                  <span class="ms-3 bg-shaq-pink ">{{ recipe.category }}</span>
                </span>
                <div>{{ recipe.creator_id }}</div>
                <p>{{ recipe.instructions }}</p>
                <span>{{ recipe.createdAt }}</span>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </div>
  </div>







</template>


<style lang="scss" scoped>
.modal-img {
  height: 40dvh;
  width: 35dvh;

}

.bg-shaq-pink {
  background: #f576e68c;
}
</style>