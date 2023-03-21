<template>
  <!-- <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
  </nav>
  <router-view/> -->
  <div class="library">
    <div class="left-panel"></div>
    <div class="library__main-panel"></div>
  </div>
</template>

<style lang="scss">
.library {
  height: 100vh;
  width: 100%;
  // background: #2c3e50;
  grid-template-rows: 100px 100px 1fr 1fr 100px;
  grid-template-columns: 12% 12% 32% 32% 12%;
  // grid-template-areas:  'navigate navigate'
  // 'left1 main'
  // 'left2 main'
  // 'left3 main1';
  display: grid;
  .left-panel{
    grid-area: left1;
    min-width: 200px;
  }
  &__main-panel {
    grid-area: main;
    background: url("../public/bookefon.jpg") no-repeat;
    background-size: cover;
  }
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
