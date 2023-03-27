<template>
  <div>
    <span>Страницы: [1] 2 3 4 5 6 7 8 9 ... 457 458 459</span>
    <div class="main-panel">
      <div class="book" v-for="book in books" :key="book">
        <div class="outside-block">
          <span>Books name alll</span>
          <div class="rating">★ ★ ★</div>
          <div class="inside-block">
            <div><img src="../../public/book.jpg" /></div>
            <div class="inside-block__info">
              <label>Author: Name</label>
              <label>Date: 2005</label>
              <label>Dop. information: asjfh jasfh</label>

              <div class="discription">Discription: lalalalallaaaaa aaaaaaalalalalala aaaaaaaaaaaa aaaalllllllllllllll llllaaaaaaaaaaaaaaaaaaaaalllllllllllll</div>
            </div>
          </div>
        </div>
      </div>
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
export default class Books extends Vue {
  msg!: string;
  public books = [1, 2, 3, 4, 5, 6, 7, 8, 9];
}
</script>
  
  <style scoped lang="scss">
  .main-panel{
    display: flex;
  flex-wrap: wrap;
  }
.book {
   max-width: 620px; margin-right: 1.5%;
  .outside-block {
   
    box-shadow: 6px 6px 16px 0 rgba(68, 86, 108, 0.1),
      -8px -8px 12px 0 rgba(255, 255, 255, 0.7) !important;
    border-radius: 5px;

    width: 95%;
    background: white;
    display: flex;
    flex-wrap: wrap;
    padding: 2.5%;
    margin-top: 2.5%;
    
    .rating {
      width: 10%;
      padding: auto;
    }
    span {
      width: 90%;
      font-size: 18px;
    }
    .inside-block {
      width: 100%;
      display: flex;
      background-color: #f8fafb;
      border-radius: 5px;
      align-items: center;
      padding: 5px;
      &__info {
        padding-left: 10px;
        width: 60%;
        display: flex;
        flex-direction: column;
        // flex-wrap: wrap;
        label{
            width: 100%;
            margin: 2px 0;
        }
        .discription{
            width: 100%;
            overflow-wrap: break-word;

        }
      }
    }
  }
}
</style>
  