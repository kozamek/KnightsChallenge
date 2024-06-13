<template>
  <div class="delete-main-container">
    <BackButton />
    <h1 class="delete-main-title">
      Deletar Cavaleiro
    </h1>
    <div class="delete-dialog-box">
      <h1 class="delete-dialog-box-text">
        {{ `Really want to delete Knight ${currentName}?` }}
      </h1>
      <div class="delete-dialog-box-buttons">
        <CustomButton
          :secondary="true"
          label="Cancel"
          :on-click="redirectToHome"
        />
        <CustomButton
          label="Delete"
          :on-click="deleteCurrentKnight"
        />
      </div>
    </div>
  </div>
</template>

<script>
import BackButton from "../components/BackButton.vue";
import CustomButton from "../components/CustomButton.vue";
import { useToast } from 'vue-toast-notification';
import { deleteKnight } from "../api/knights.api";

const $toast = useToast();

export default {
  name: "DeleteView",
  components: {
    BackButton,
    CustomButton,
  },
  data() {
    return {
      currentId: 0,
      currentName: ''
    }
  },
  created(){
    this.currentId= this.$route.params.id, 
    this.currentName= this.$route.params.name
  },
  methods: {
    redirectToHome() {
      this.$router.push({
        name: "home",
        key: "$route.fullPath",
      });
    },
    async deleteCurrentKnight() {
      await deleteKnight(this.currentId);
      $toast.open({message: 'Knights becomes heroes',duration: 2000,position: 'top-right'});
      this.redirectToHome();
    },
  }
};
</script>

<style>
.delete-dialog-box-text {
  font-size: 24px;
}

.delete-main-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  
}

.delete-dialog-box {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  padding: 32px;
  background: #fff8e5;
  border: 3px solid #333;
  border-radius: 8px;
  font-size: 24px;
  width: 300px;
  height: 300px;
  margin-bottom: auto;
}

.delete-dialog-box-buttons {
  margin-top: auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.delete-main-title{
  font-size: 54px;
  margin: 16px 0;
  margin-bottom: auto;
  color: #fff8e5;
}
</style>