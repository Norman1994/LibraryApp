<template>
  <div>
    <span>Страницы: [1] 2 3 4 5 6 7 8 9 ... 457 458 459</span>
    <div class="main-panel">
      <div class="book" v-for="book in books" :key="book">
        <div class="outside-block">
          <span>Books name alll</span>
          <div class="rating">★ ★ ★</div>
          <div class="inside-block">
            <img src="../../public/book.jpg" />
            <div class="inside-block__shot-info">
              <label>Author: Name</label>
              <label>Date: 2005</label>
              <label>Dop. information: asjfh jasfh</label>
            </div>
            <div class="inside-block__discription">
              Discription: lalalalallaaaaa aaaaaaalalalalala aaaaaaaaaaaa
              aaaalllllllllllllll llllaaaaaaaaaaaaaaaaaaaaalllllllllllll
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
  
  <script lang="ts">
import { Options, Vue } from "vue-class-component";
import axios from "axios";
@Options({
  props: {
    msg: String,
  },
})
export default class Books extends Vue {
  msg!: string;
  public books = [1, 2, 3, 4, 5, 6, 7, 8, 9];

  created() {
    axios
      .get("./books")
      .then((response) => {
        console.log(response);
        // this.templateFolders = response.data[0];
      })
      .catch((error) => {
        alert("Возникла ошибка: " + error);
      });
  }
}
</script>
  
  <style scoped lang="scss">
.main-panel {
  display: flex;
  flex-direction: column;
  width: 100%;
  @media screen and (min-width: 1280px) {
    flex-wrap: wrap;
    flex-direction: row;
  }
}
.book {
  max-width: 1200px;
  margin-top: 10px;
  @media screen and (min-width: 1280px) {
    width: 600px;
    margin: 5px auto;
  }
  .outside-block {
    box-shadow: 6px 6px 16px 0 rgba(68, 86, 108, 0.1),
      -8px -8px 12px 0 rgba(255, 255, 255, 0.7) !important;
    border-radius: 5px;

    width: 95%;
    background: white;
    display: flex;
    flex-wrap: wrap;
    padding: 2.5%;
    // margin-top: 2.5%;

    .rating {
      width: 20%;
      padding: auto;
      text-align: right;
    }
    span {
      width: 80%;
      font-size: 18px;
    }
    .inside-block {
      width: 100%;
      display: grid;
      grid-template-columns: 90px 1fr ;
      grid-template-rows: 80px 50px;
      grid-template-areas: 'img shot' 'img discription';
      
      @media screen and (max-width: 768px) {
        // flex-direction: column;
        grid-template-columns: 90px 1fr ;
      grid-template-rows: 130px 1fr;
      grid-template-areas: 'img shot' 'discription discription';
      }
      background-color: #f8fafb;
      border-radius: 5px;
      align-items: center;
      padding: 5px;
      img {
        height: 120px;
        grid-area: img;
      }
      &__discription{
width: 100%;
          overflow-wrap: break-word;
          grid-area: discription;
      }
      &__shot-info {
        grid-area: shot;
        width: 60%;
        display: flex;
        flex-direction: column;
        // flex-wrap: wrap;
        label {
          width: 100%;
          margin: 2px 0;
        }
      }
    }
  }
}
</style>
  