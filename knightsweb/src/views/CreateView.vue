<template>
  <div class="create-main-container">
    <BackButton />
    <h1 class="create-main-title">
      Criar Cavaleiro
    </h1>
    <div class="create-box-container">
      <div class="create-list-container">
        <h1 class="create-list-title">
          Criar Cavaleiro
        </h1>
        <ul v-if="knightInfo">
          <li>
            <strong>Nome:</strong>
            <input
              v-model="knightInfo.name"
              placeholder="Type Knight name"
            />
          </li>
          <li>
            <strong>Atributos:</strong>
            <ul v-if="knightInfo.attributes">
              <li>
                <strong>Força:</strong>
                <input
                  v-model="knightInfo.attributes.strength"
                  placeholder="Type Knight strength"
                  type="number"
                />
              </li>
              <li>
                <strong>Destreza:</strong>
                <input
                  v-model="knightInfo.attributes.dexterity"
                  placeholder="Type Knight dexterity"
                  type="number"
                />
              </li>
              <li>
                <strong>Constituição:</strong>
                <input
                  v-model="knightInfo.attributes.constitution"
                  placeholder="Type Knight constitution"
                  type="number"
                />
              </li>
              <li>
                <strong>Inteligência:</strong>
                <input
                  v-model="knightInfo.attributes.intelligence"
                  placeholder="Type Knight intelligence"
                  type="number"
                />
              </li>
              <li>
                <strong>Sabedoria:</strong>
                <input
                  v-model="knightInfo.attributes.wisdom"
                  placeholder="Type Knight wisdom"
                  type="number"
                />
              </li>
              <li>
                <strong>Carisma:</strong>
                <input
                  v-model="knightInfo.attributes.charisma"
                  placeholder="Type Knight charisma"
                  type="number"
                />
              </li>
            </ul>
          </li>
          <li>
            <strong>Apelido:</strong>
            <input
              v-model="knightInfo.nickname"
              placeholder="Type Knight nickname"
            />
          </li>
          <li>
            <strong>Aniversario:</strong>
            <input
              id="dateInput"
              v-model="knightInfo.birthday"
              type="date"
              :max="maxDate"
            />
          </li>
          <li>
            <strong>Atributo Chave:</strong>
            <select
              id="attrSelect"
              v-model="knightInfo.keyAttribute"
            >
              <option value="">
                -- Selecione um Atributo --
              </option>
              <option
                v-for="item in attrOptions"
                :key="item"
                :value="item"
              >
                {{ translateAttribute(item) }}
              </option>
            </select>
          </li>
        </ul>
        <CustomButton
          label="Salvar Cavaleiro"
          :on-click="createNewKnight"
        />
      </div>
      <div class="create-weapons-container">
        <h1 class="create-weapons-title">
          Adicionar Arma
        </h1>
        <div class="create-weapons-input-container">
          <ul>
            <li>
              <strong>Nome:</strong>
              <input
                v-model="currentWeapon.name"
                placeholder="Weapon name"
              />
            </li>
            <li>
              <strong>Modo:</strong>
              <input
                v-model="currentWeapon.mod"
                placeholder="Mod"
                type="number"
              />
            </li>
            <li>
              <strong>Ataque:</strong>
              <select
                id="attrSelectWeapon"
                v-model="currentWeapon.attr"
              >
                <option value="">
                  -- Select an Attr --
                </option>
                <option
                  v-for="item in attrOptions"
                  :key="item"
                  :value="item"
                >
                  {{ translateAttribute(item) }}
                </option>
              </select>
            </li>
            <li>
              <input
                id="checkbox"
                v-model="currentWeapon.equipped"
                type="checkbox"
              />
              <label for="checkbox">Equipped</label>
            </li>
          </ul>
          <CustomButton
            label="Adicionar Arma"
            :on-click="handleAddWeapon"
          />
        </div>
        <div class="create-weapons-list-container">
          <h1 class="create-weapons-title">
            Lista de armas
          </h1>
          <ul v-if="knightInfo.weapons && knightInfo.weapons.length > 0">
            <WeaponCard
              v-for="item in knightInfo.weapons"
              :key="item.name"
              :name="item.name"
              :mod="item.mod"
              :attribute="item.attr"
              :is-equipped="item.equipped"
            />
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import BackButton from "../components/BackButton.vue";
import CustomButton from "../components/CustomButton.vue";
import WeaponCard from "../components/WeaponCard.vue";
import { useToast } from 'vue-toast-notification';
import { createKnight } from "../api/knights.api";

const $toast = useToast();

export default {
  name: "CreateView",
  components: {
    BackButton,
    WeaponCard,
    CustomButton
  },
  data() {
    return {
      maxDate: new Date().toISOString().split('T')[0],
      knightInfo: {
        name: "",
        nickname: "",
        birthday: "",
        keyAttribute: "",
        attributes: {
          strength: 0,
          dexterity: 0,
          constitution: 0,
          intelligence: 0,
          wisdom: 0,
          charisma: 0,
        },
        weapons: [],
      },
      attrOptions: [
        "strength",
        "dexterity",
        "constitution",
        "intelligence",
        "wisdom",
        "charisma",
      ],
      currentWeapon: {
        name: "",
        mod: 0,
        attr: "",
        equipped: false,
      },
    };
  },
  methods: {
    redirectToHome() {
      this.$router.push({
        name: "home",
        key: "$route.fullPath",
      });
    },
      async createNewKnight() {
      if(this.knightInfo.name === "" || this.knightInfo.keyAttribute === "" || this.knightInfo.birthday === ""){
        $toast.open({message: 'Empty fields', type: 'error' ,duration: 2000,position: 'top-right'});
        return;
      }
      
      this.knightInfo.hero = false;
      this.knightInfo.id = Math.floor(Math.random() * 1000000).toString();

      await createKnight(this.knightInfo);

      $toast.open({message: 'Knight added',duration: 2000,position: 'top-right'});
      this.redirectToHome();
    },
    handleAddWeapon() {
      if (this.currentWeapon.name !== "" && this.currentWeapon.attr !== "") {
        this.knightInfo.weapons = [
          ...this.knightInfo.weapons,
          this.currentWeapon,
        ];
        this.currentWeapon = {
          name: "",
          mod: 0,
          attr: "",
          equipped: false,
        };
      }else{
        $toast.open({message: 'Empty fields', type: 'error' ,duration: 2000,position: 'top-right'});
      }
    },
    translateAttribute(attributeKey) {
      const attributes = {
        strength: "Strength",
        dexterity: "Dexterity",
        constitution: "Constitution",
        intelligence: "Intelligence",
        wisdom: "Wisdom",
        charisma: "Charisma",
      };

      return attributes[attributeKey] || "";
    },
  },
};
</script>

<style>
.create-main-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  height: 100vh;
}

.create-list-container,
.create-weapons-container {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  padding: 24px;
  height: 85vh;
  border: 3px solid #333;
  background: #fff8e5;
  border-radius: 8px;
}

.create-list-container {
  width: 50vw;
}

.create-list-title,
.create-weapons-title {
  font-size: 32px;
  margin: 16px 0;
}

.create-list-container {
  margin-right: 50px;
}

.create-weapons-container {
  width: 30vw;
}

.create-list-container li {
  display: grid;
  grid-template-columns: 1fr 2fr;
  margin: 12px 0;
  line-height: 24px;
}

.create-list-container li strong {
  font-size: 24px;
  line-height: 24px;
}
.create-list-container li p {
  font-size: 18px;
  line-height: 24px;
}

.create-weapons-input-container {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  border: 3px solid #333;
  border-radius: 8px;
  padding: 16px;
  width: 100%;
}

.create-weapons-input-container ul li {
  display: grid;
  grid-template-columns: 1fr 2fr;
  margin-bottom: 16px;
}

.create-weapons-list-container {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  overflow: auto;
}

.create-weapons-list-container ul {
  overflow: auto;
}

.create-main-title {
  font-size: 54px;
  margin: 16px 0;
  height: 64px;
  color: #fff8e5;
}

.create-box-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 5%;
}
</style>
