<script setup>
import Navbar from './components/Navbar.vue';


</script>


<template>
  <header>
    <Navbar />
  </header>
  <main>
    <!-- <div class="container-fluid">
      <div class="row head-img align-items-center">
        <div class="col-12 ">
          <p class="align-content-center text-center text-light fw-bold fs-1 text-shadow">ALL SPICE</p>
          <p class="align-content-center text-center fs-4 text-light text-shadow">When Your Hear Your Enemies</p>
        </div>
      </div>
      <div class="row align-items-center justify-content-center jusify-content-between">
        <div
          class="col-4 d-flex justify-content-between align-items-centerborder text-green bg-dark-subtle p-3 the-click-options fs-4">
          <span>Home</span>
          <span>My Recipes</span>
          <span>Favorite</span>
        </div>
      </div>
    </div> -->
    <RouterView />






  </main>
  <footer class=" text-center">
    Made with <i class="mdi mdi-heart text-pink"></i> by CodeWorks
  </footer>
</template>

<style lang="scss">
.head-img {
  background-image: url(https://images.unsplash.com/photo-1580116270858-8a0d62b15426?q=80&w=1988&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  min-width: 100%;
  min-height: 40dvh;
  background-position: center;
  background-size: cover;
}

.text-shadow {
  text-shadow: 2px 2px 3px black;
}

.the-click-options {
  position: relative;
  top: -35px;
  left: 18px;

}
</style>
