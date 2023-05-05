<template>
  <div class="chosen-book">
    <div class="top-panel">
      <div class="back" style="width: 10%">↩</div>
      <div class="rating">★ ★ ★</div>
    </div>
    <img class="chosen-book__cover" src="../../public/book.jpg" />
    <div class="chosen-book__shot-information ">
        <!-- white-block -->
      <span>Books name alll</span>

      <label class="chosen-book__shot-information__title">Author: </label
      ><label class="chosen-book__shot-information__info">Name</label>
      <label class="chosen-book__shot-information__title">Date: </label
      ><label class="chosen-book__shot-information__info">2005</label>
      <label class="chosen-book__shot-information__title">Page:</label
      ><label class="chosen-book__shot-information__info"> 208</label>

      <label class="chosen-book__shot-information__title"> Discription: </label
      ><label class="chosen-book__shot-information__info"
        >Пронесшийся над Канзасом ураган принес в Волшебную страну Фею
        Убивающего домика — девочку Элли, да не одну, а прямо вместе с домиком и
        песиком Тотошкой. Но как же ей теперь вернуться домой?! В этом может
        помочь только один человек – волшебник Гудвин, Великий и Ужасный. По
        Дороге из Желтого Кирпича Элли с Тотошкой отправляются в путь, чтобы
        подружиться с пугалом Страшилой без ума, Железным Дровосеком без сердца
        и Трусливым Львом. Все вместе они придут в Изумрудный Город и обретут
        то, что необходимо каждому из них.</label
      >
    </div>
    <div></div>
    <div class="chosen-book__summary white-block">
        <label>Краткое содержание</label><div>
       В далёком Канзасе живёт девочка Элли. У неё простые мечты,
      позавтракать сладким пряником и надеть новые туфельки. В свободное время
      девочка играет с собачкой Тотошкой Злая колдунья Гингема наколдовала
      ураган, который унёс Элли в страну Живунов.Чтобы вернуться домой, девочке
      нужно исполнить желания трёх существ. По жёлтой кирпичной дороге Элли
      вместе с Тотошкой пошла искать волшебника. Присев отдохнуть, обнаружила
      соломенное чучело, которое умело разговаривать. Странное существо звали
      Страшила. Страшила мечтал получить мозги. Друзья вместе пошли в Изумрудный
      город. В зарослях деревьев нашли заржавевшего Дровосека. Смазав ему
      шарниры, вчетвером двинулись искать Великого Гудвина. Железный Дровосек
      признался, что хочет сердце. На пути к волшебнику Людоед чуть не съел
      Элли, но Страшила и Дровосек спасли девочку. В лесу путешественники
      повстречали Трусливого Льва и вместе продолжили путь. У ворот Изумрудного
      города стражник заставил одеть зелёные очки. За то, что Элли вернётся в
      Канзас, Великий и Ужасный потребовал освободить мигунов от Бастинды. Злая
      волшебница насылала на них волков, ворон, пчёл. В этой схватке друзья
      победили. Летучие Обезьяны одержали верх над друзьями. Предводитель
      схватил Элли, но увидел у неё серебряные башмачки и привёл во дворец
      Бастинды. Злая волшебница нагружала Элли непосильной работой, но однажды,
      девочка облила её водой и Бастинда испарилась. Компания вернулась в
      Изумрудный Город. Тотошка разоблачил волшебника. Им оказался обыкновенный
      человек, который обманывал подданных. Желания друзей исполнились.
      Преодолевая препятствия и помогая Элли, Страшила стал умным, Дровосек
      добрым, а Лев храбрым. Вернуться в Канзас Элли с Тотошкой помогли
      серебряные башмачки. Повесть учит доброте и сопереживанию, никогда не
      предавать друзей, смотреть на мир без очков, открытыми глазами. Мечты
      сбываются, если веришь Источник: Краткое содержание Волшебник Изумрудного
      города Волкова за 2 минуты пересказ сюжета</div>
      <label>Развернуть ⇩</label>
    </div>
  <div style="grid-area: editions;padding: 10px;"> Существует множество изданий 
    сказки, и их тексты зачастую не совпадают. 
    Книга многократно перерабатывалась автором, и если ранние версии представляют 
    собой перевод сказки Баума с добавлением 
    и заменой некоторых эпизодов, то в поздних и образы персонажей,
     и объяснения событий значительно изменены, что создаёт свою, заметно
      отличающуюся от Оз атмосферу Волшебной страны. Издание 1939 года — ближе всего к оригинальному тексту Баума.</div>  
    <div class="chosen-book__edition white-block">
        <span>Издание</span>
      <div style="margin: 10px auto;
    width: 30%; min-width: 300px;
}" v-for="m in msg" :key="m">
        <div class="chosen-book__edition-contaner">
        <img
          class="chosen-book__edition-cover"
          src="../../public/book.jpg"
        /><label class="chosen-book__shot-information__title"
          >Год издания: </label
        ><label class="chosen-book__shot-information__info">2005</label
        ><label class="chosen-book__shot-information__title"
          >Издательство: </label
        ><br /><label style="grid-area: edition"
          >Манн, Иванов и Фербер: Издательство «МИФ»</label
        ></div>
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
export default class ChosenBook extends Vue {
  msg = [1, 2, 3, 4,5];
book = {};
  created() {
    console.log( this.$route.query.id)
    axios
      .get("./books/GetById?id=" + this.$route.query.id)
      .then((response) => {
        console.log(response);
         this.book = response.data;
      })
      .catch((error) => {
        alert("Возникла ошибка: " + error);
      });
  }
}

</script>
  
  <style scoped lang="scss">
.chosen-book {
  display: grid;

  grid-template-columns: 260px 1fr;
//   grid-template-rows: 30px 400px 1fr 1fr;

  grid-template-areas: "top-panel top-panel" "img  shot " "summary summary"  "editions editions" "edition edition";
  @media screen and (max-width: 900px) {
    grid-template-columns: 1fr;
    // grid-template-rows: auto; //30px 400px 1fr 1fr;

    grid-template-areas: "top-panel" "img" "shot" "summary" "editions" "edition";
  }
  &__cover {
    width: 250px;
    margin: auto;
  }
  &__summary {
    grid-area: summary;
    width: calc(100% - 20px) ;
    padding: 10px;
    label{
        display: block;
        width: 100%;
        text-align: center;
        height: 20px;
        font-size: large;
        padding: 5px;
    }
    div{
        // border-top:3px solid #f8fafb;
        // border-bottom:3px solid #f8fafb;
        font-size: small;
        background: #f8fafb;
        border-radius: 5px;
        padding: 10px 5px;
        max-height: 300px;
        overflow: hidden;
    }
  }
  &__shot-information {
    padding: 10px;
    display: flex;
    flex-wrap: wrap;
    span {
      width: 100%;
      font-size: larger;
      padding: 10px 0;
      margin: 10px 0;
      @media screen and (max-width: 900px) {
        text-align: center;
      }
    }
    &__title {
      width: 100px;
    }
    &__info {
      width: calc(100% - 100px);
    }
  }
  &__edition {
    grid-area: edition;
    display: flex;
    flex-wrap: wrap;
    width: 100%;
    height: 100%;
    span{
        // display: block;
        width: 100%;
        text-align: center;
        // height: 20px;
        font-size: large;
        padding-top: 10px;
    }
   
    &-contaner {
      border-radius: 5px;
      background: #f8fafb;
      margin: 10px auto;
      padding: 10px 5px;
      width: 300px;
      font-size: small;
      display: grid;
      grid-template-columns: 90px 90px 1fr;
      grid-template-rows: 30px 20px 1fr;

      grid-template-areas: "img  title-year year" "img title-edition edition1" "img edition edition";
    }
    &-cover {
      grid-area: img;
      height: 120px;
      margin: auto 5px;
    }
  }
}
.top-panel {
  grid-area: top-panel;
  display: flex;
  .rating {
    text-align: right;
    width: 90%;
  }
  .back {
    font-size: x-large;
    font-weight: bold;
  }
}
</style>
  