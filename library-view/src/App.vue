<template>
  <div class="layout">
    <NavigationPanel :class="{ 'aside-closed': menuClosed }"></NavigationPanel>
    <main :class="{ 'menu-see': !menuClosed }">
      <header class="header">
        <div class="container row">
          <div class="list-img" @click="menuClosed = !menuClosed">
            <img src="../public/menu.svg" />
          </div>
          <div class="search-form">
            <button class="search-form__button">
              <img src="../public/search.svg" /></button
            ><input class="search-form__input" placeholder="Найти" />
          </div>
        </div>
      </header>
      <div class="wrapper">
        <div class="content">
          <router-view></router-view>
        </div>
      </div>
      <div :class="{ blackout: !menuClosed }" @click="menuClosed = true"></div>
    </main>
  </div>
</template>
<script lang="ts">
import NavigationPanel from "./components/NavigationPanel.vue";
import { Options, Vue } from "vue-class-component";

@Options({
  components: {
    NavigationPanel,
  },
})
export default class App extends Vue {
  public menuClosed = true;
}
</script>

<style lang="scss">
html,
body {
  height: 100%;
  background-color: #ffffff;
  font-family: "Rubik", sans-serif;
  color: #44566c;
  margin: 0;
}
input {
  background-color: #f8fafb;
  border: none;
  color: #627b9b;
}
.row {
  display: flex;
  // flex-wrap: wrap;
  margin-right: -15px;
  margin-left: -15px;
  align-items: center;
  height: 100%;
}
.header {
  height: 75px;
  padding-left: 1.5rem;
  padding-right: 1.5rem;
}

.container {
  width: 100%;
  padding-left: 15px;
  margin-right: auto;
  margin-left: auto;
  @media screen and (max-width: 768px) {
    max-width: 720px;
    padding-left: 0 !important;
  }
}
///////////////////////////////////////
/// //////////////////////////////////
/// ////////////////////////////////

.menu-see {
  @media (max-width: 992px) {
    position: relative;
    z-index: 7;
    // background-color: #0000007a !important;
  }
  margin-left: 280px;
}
.blackout {
  @media (max-width: 992px) {
    position: absolute;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    content: "";
    background-color: rgba(0, 0, 0, 0.6);
  }
}
main {
  transition: margin-left 1s;
  overflow-x: hidden;
  .header {
    border-bottom: 1px solid #e8eef2;
    padding-bottom: 8px;
    .search-form {
      height: 38px;
      margin-left: 20px;
      display: flex;
      &__button {
        background-color: #f8fafb;
        border: none;
        color: #627b9b;
        img {
          width: 16px;
          padding: 0 7px;
        }
      }
      &__input {
        padding: 0.375rem 0.75rem;
        font-size: 1rem;
        font-weight: 400;
        line-height: 1.5;
        display: block;
      }
    }
  }
  .wrapper {
    background-color: #f8fafb;
    padding: 4.2rem 1.5rem;
    .content {
      max-width: 1280px;
      // min-width: 720px;
      margin: 0 auto;
    }
  }
}
</style>
