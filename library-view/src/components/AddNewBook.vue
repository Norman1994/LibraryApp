<template >
  <ModalWindow :title="'Создать папку'" :height="800" :width="600">
    <template #body>
      <label>Название:</label><input /> <label>Автор:</label
      ><select></select>
      <label>Год написания:</label><input /> <label>Количество страниц:</label
      ><input /> <label>Аннотация:</label><textarea />
      <label>Краткое содиржание:</label><textarea />
      <label>Описание изданий:</label>
      <div class="edition"><button class="edition__block">
        <div class="edition__block__add">+</div>
        Добавить издание
      </button>
      <div class="edition__block"><input placeholder="Название издания"/> <input placeholder="Издательство"/> <input placeholder="Номер издания"/> <input type="file"/></div>
    </div>
      
    </template>
    <template #button>
      <button @click="$emit('close')">Отмена</button>
      <button v-on:click="Add()">Добавить</button>
    </template>
  </ModalWindow>
</template>
  
  <script lang="ts">
import { Options, Vue } from "vue-class-component";
import ModalWindow from "./ModalWindow.vue";

@Options({
  props: {
    msg: String,
  },
  components: {
    ModalWindow,
  },
})
export default class HelloWorld extends Vue {
  msg!: string;
  Add() {
    console.log("aaa");
  }
  created() {
    console.log("asdyhseryaa");
  }
}
</script>
  
  <style lang="scss" scoped>
.modalWindow {
  top: calc(50% - 400px);
  left: calc(50% - 300px);
}
.modalWindow__button button {
  background: #627b9b;
  width: 100px;
  margin: 5px;
  border: 2px;
  //   color: #e8eef2;
}
label {
  display: inline-block;
  width: 165px;
  margin: 10px 5px;
}
input {
  width: calc(100% - 190px);
  height: 25px;
  border-bottom: 1px solid #e8eef2;
}
select {
  width: calc(100% - 185px);
  height: 30px;
  border-bottom: 1px solid #e8eef2;
}
textarea {
  width: 95%;
  margin: 0 2.5%;
  height: 100px;
  resize: vertical;
  //   width: 100%;
}

.edition {
    display: flex;
  &__block {
    margin: 5px;
    width: 30%;
    height: 100px;
    background-color: #f8fafb;
    border: none;
    border-radius: 7px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    color: #627b9b;
    transition: background 0.2s ease;
    &:hover {
      cursor: pointer;
      border: 1px solid #e8eef2;
    }
    &:active {
      background-color: #e8eef2;
      
    }
    input{
        width:  90%;
        margin: 5px 5%;
        // background: white;
        &::-webkit-input-placeholder { color: #ced2d4 }
    }
    &__add {
      width: 40px;
      height: 40px;
      border-radius: 30px;
      background: none;
      color: #627b9b;
      border: 2px solid #627b9b;
      font-size: 2rem;
      padding: 5px;
      margin-bottom: 5px;
      display: flex;
      align-items: center;
      justify-content: center;
    }
  }
}
</style>
  