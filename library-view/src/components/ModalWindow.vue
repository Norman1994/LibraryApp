<template >
  <div class="backdrop">
    <div
      class="modalWindow"
      :style="{ width: width + 'px', height: height + 'px' }"
    >
      <div class="modalWindow__title">
        <div class="modalWindow__title_tabs" v-if="Array.isArray(title)">
          <div
            v-for="(titl, index) in title"
            :key="index"
            :class="{ selected: flag == index }"
            @click="
              () => {
                flag = index;
                $emit('tab', titl);
              }
            "
          >
            {{ titl }}
          </div>
        </div>
        <div class="modalWindow__title_only" v-else>{{ title }}</div>
        <button
          class="modalWindow__title__close-button"
          @click="$emit('close')"
        >
          &times;
        </button>
      </div>
      <div
        class="modalWindow__body"
        :class="{ modalWindow__body_only: !hasFooterSlot() }"
      >
        <slot name="body"></slot>
      </div>
      <div class="modalWindow__button" v-if="hasFooterSlot()">
        <slot name="button"></slot>
      </div>
    </div>
  </div>
</template>
  
  <script lang="ts">
import { Options, Vue } from "vue-class-component";
@Options({
  props: {
    title: String,
    width: Number,
    height: Number,
  },
})
class ModalWindow extends Vue {
  // @Prop() readonly title?: string | string[];
  // @Prop() readonly width?: number;
  // @Prop() readonly height?: number;

  hasFooterSlot() {
    return !!this.$slots.button;
  }
  public flag = 0;
  created() {
    console.log(this);
  }
}

export default ModalWindow;
</script>
  
  <style scoped lang="scss">
.modalWindow {
  box-shadow: 0px 1px 12px rgba(0, 0, 0, 0.4);
  position: absolute;
  z-index: 999;
  overflow: hidden;
  font-weight: 400;
  opacity: 1;
  &__title {
    display: flex;
    background-color:#627b9b ;
    text-align: center;
    font-size: 1rem;
    height: 30px;
    color: #e8eef2;
    vertical-align: top;
    &_only {
      padding-top: 5px;
      width: calc(100% - 10px);
      height: 20px;
    }
    &_tabs {
      width: calc(100% - 10px);
      display: flex;

      .selected {
        background-color: var(--color-additional-darck);
      }
      div {
        padding: 5px 15px;
        height: 20px;
        align-items: center;
        cursor: pointer;
        &:hover {
          background: #59504b91;
        }
      }
    }
    &__close-button {
      font-size: 20px;
      line-height: 3px;
      color: white;
      opacity: 0.5;
      font-weight: 600;
      box-shadow: none;
      margin: 0;
      background: none;
      border: none;
      cursor: pointer;
    }
    &__close-button:hover {
      opacity: 0.95;
    }
    &__close-button:active {
      transform: translateY(0);
    }
  }
  &__body {
    overflow: hidden;
    overflow-y: auto;
    height: calc(100% - 75px);
    background-color: white;
    text-align: left;
    padding: 5px;
    &_only {
      height: calc(100% - 40px);
    }
  }
  &__button {
    width: 100%;
    height: 35px;
    display: flex;
    flex-direction: row-reverse;
    background-color: white;
    
  }
}
</style>