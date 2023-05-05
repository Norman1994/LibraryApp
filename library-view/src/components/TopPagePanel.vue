<template>
  <div class="abc">
    <div>
      <span>Страницы: 1 2 ... 48 49</span>
    </div>
    <div><span>Показывать по: 20 40 60</span></div>
    <div>
      <select>
        <option>Рейтинг ↑</option>
        <option>Рейтинг ↑</option>
        <option>Название А-Я</option>
        <option>Название Я-А</option>
        <option>Автор А-Я</option>
        <option>Автор Я-А</option>
      </select>
    </div>
    <div>
      <button>
        <!-- <img
          src="data:image/svg+xml,%3Csvg%20width%3D%2216%22%20height%3D%2216%22%20fill%3D%22none%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%3E%3Cpath%20fill-rule%3D%22evenodd%22%20clip-rule%3D%22evenodd%22%20d%3D%22M6.5%204a1.5%201.5%200%201%201-3%200%201.5%201.5%200%200%201%203%200Zm1.459.5a3%203%200%200%201-5.918%200H.75a.75.75%200%200%201%200-1.5h1.42a3.001%203.001%200%200%201%205.66%200h7.42a.75.75%200%200%201%200%201.5H7.959Zm5.87%205.5h1.421a.75.75%200%200%201%200%201.5h-1.291a3%203%200%200%201-5.918%200H.75a.75.75%200%200%201%200-1.5h7.42a3.001%203.001%200%200%201%205.66%200ZM12.5%2011a1.5%201.5%200%201%201-3%200%201.5%201.5%200%200%201%203%200Z%22%20fill%3D%22%23000%22%2F%3E%3C%2Fsvg%3E"
        /> -->
        Задать параметры
      </button>
    </div>
  </div>
</template>
  
  <script lang="ts">
import { Options, Vue } from "vue-class-component";

@Options({
  props: {
    msg: String,
  },
})
export default class TopPagePanel extends Vue {
  msg!: string;
}
</script>
  
  <style scoped lang="scss">
.abc {
  color: #627b9b;
  width: calc(100% - 40px);
  padding: 5px 20px;
  margin: 0 auto;
  display: grid;
  font-size: small;
  justify-items: center;
  align-items: center;
  button {
    width: 150px;
    background: white;
    border: 1px solid #627b9b;
    border-radius: 2px;
    color: #44566c;
    cursor: pointer;
    box-shadow: 5px 3px 4px #e8eef2;
    &:active {
      transform: translateY(2px);
    }
    // background-image:
    // background-repeat: no-repeat;
    // background-position: center;
    // background-size: contain;
    // content: '';
  }
  select {
    background: white;
    border: 1px solid #e8eef2;
    border-radius: 2px;
    color: #44566c;
    font-size: small;
    width: 140px;
    &:focus-visible {
      outline: 1px solid black !important;
    }
  }
  span {
    // width: 215px;
  }
  div {
    width: 150px;
    padding: 2px 0;
  }
  grid-template-columns: 1fr 1fr 1fr 1fr;
  @media screen and (max-width: 700px) {
    grid-template-columns: 1fr 1fr;
    grid-template-rows: 1fr 1fr;

    //   justify-items: left;
  }
  @media screen and (max-width: 400px) {
    // grid-template-columns: 1fr;
    // grid-template-rows: 1fr 1fr 1fr 1fr;
    padding: 5px;
  }
}
</style>