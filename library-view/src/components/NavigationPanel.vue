<template>
  <aside>
    <!-- :class="{ 'aside-closed': menuClosed }" -->
    <header class="header">
      <img src="../../public/library.svg" />
    </header>
    <div class="navigation">
      <ul class="navigation__menu">
        <li
          ref="reguser"
          class="navigation__menu-item"
          @click="Active('reguser')"
        >
          <!-- <img src="../../public/user.svg" /> -->
          Вход и Регистрация
          <div class="authorization">
            <input type="text" placeholder="Логин" class="authorization__login">
            <input type="Password" placeholder="Пароль" class="authorization__pasword">
            <span>Забыл пароль</span>
            <span>Войти</span>
            <!-- <button>Войти</button> -->
            <button>Зарегистрироваться</button>
          </div>
        </li>
        <li ref="book" class="navigation__menu-item active" @click="Active('book')">
          <router-link to="">Книги</router-link>
        </li>
        <li ref="author" class="navigation__menu-item" @click="Active('author')">
          <router-link to="">Авторы</router-link>
        </li>
        <li ref="prizes" class="navigation__menu-item" @click="Active('prizes')">
          <router-link to="">Награды, премии</router-link>
        </li>
        <li ref="recomend" class="navigation__menu-item" @click="Active('recomend')">
          <router-link to="">Рекомендации</router-link>
        </li>

        <li ref="rating" class="navigation__menu-item" @click="Active('rating')">
          <router-link to="">Рейтенги</router-link>
        </li>
        <li ref="users" class="navigation__menu-item" @click="Active('users')">
          <router-link to="">Посетители</router-link>
        </li>
        <li ref="forum" class="navigation__menu-item" @click="Active('forum')">
          <router-link to="">Форум</router-link>
        </li>
      </ul>
    </div>
  </aside>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
export default class NavigationPanel extends Vue {
  Active(idli: string): void {
    const a = this.$el.querySelector(".active");
    if (a) a.classList.remove("active");
    (this.$refs[idli] as HTMLElement).classList.add("active");
  }
}
</script>

<style lang="scss">
.aside-closed {
  left: -281px;
}
aside {
  position: fixed;
  left: 0;
  width: 280px;
  border-right: 1px solid #e8eef2;
  transition: left 1s;
  background: white;
  height: 100%;
  .header {
    // align-items: center !important;
    img {
      height: 75px;
      margin: 10px 38px;
    }
  }
  .navigation {
    height: calc(100% - 75px);
    padding-bottom: 35px;
    &__menu {
      padding: 0;
      margin: 0;
      margin-top: 20px;
      list-style: none;
      .active {
        background-color: #f8fafb;
        border: 4px solid;
        border-color: #f8fafb;
        border-left-color: #3d6a95 !important;
        .authorization{
            display: block;}
      }
      &-item {
        // height: 40px;
        width: 100%;
        display: flex;
        flex-wrap: wrap;
        align-items: center;
        padding-left: 20px;
        font-size: 18px;
        padding: 1rem 0.5rem 1rem 0.875rem;
        a {
          text-decoration: none;
          color: #44566c;
        }
        img {
          height: 20px;
          margin: 5px;
          opacity: 0.6;
        }
        .authorization{
            height: 130px;
            display: none;
            width: 85%;
            input{
                background: white;
                height: 25px;
                margin: 5px 0;
                width: 100%;
                border: 1px solid #e8eef2;
            }
            button{
                margin: 10px 1%;
                padding: 3px 10px;
                border: 1px solid  #3d6a95;
                // border: none;
    background: #627b9b;
    color: white;
    width: 98%;
            }
            span{
                font-size: small;
                float: right;
                padding: 0 5px;color:#3d6a95;
                cursor: pointer;
                &:hover{
                    text-decoration: underline;
                }
            }
        }
      }
    }
  }
}
</style>
