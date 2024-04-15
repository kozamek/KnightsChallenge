<!-- ItemListComponent.vue -->
<template>
    <ul class="item-list-ul">
        <li key="header"
            class="item-list-header">
            <div>Name</div>
            <div>Age</div>
            <div>Weapons</div>
            <div>Attr</div>
            <div>Atack</div>
            <div>Exp</div>
            <div>Actions</div>
        </li>
        <li v-for="item in itemList"
            :key="item.name">
            <div>{{ item.name }}</div>
            <div>{{ calculateAge(item.birthday) }}</div>
            <div>{{ item.weapons.length }}</div>
            <div>{{ translateAttribute(item.keyAttribute) }}</div>
            <div>
                {{
          getAttack(item)
                }}
            </div>
            <div>{{ calculateXPValue(item.birthday) }}</div>
            <div class="item-list-icon-buttons-container">
                <IconButton :id="`info-button-${item.id}`"
                            icon="eye"
                            helper="See Knight's info'"
                            :on-click="() => redirectToInfo(item)" />

                <IconButton v-if="item.hero === false"
                            :id="`edit-button-${item.id}`"
                            icon="pen-to-square"
                            helper="Edit Knight"
                            :on-click="() => redirectToEdit(item)" />

                <IconButton v-if="item.hero === false"
                            :id="`delete-button-${item.id}`"
                            icon="trash"
                            helper="Delete Knight"
                            :on-click="() => redirectToDelete(item)" />
            </div>
        </li>
    </ul>
</template>

<script>
import IconButton from "./IconButton.vue";

export default {
  components: {
    IconButton,
  },
  props: {
    itemList: {
      type: Array,
      required: true,
    },
  },
  data() {
    return {
      isModalVisible: false,
    };
  },
  methods: {
    formatDate(date) {
      return new Date(date).toLocaleDateString();
    },
    calculateAge(birthday) {
      const [day, month, year] = birthday.split('/');
      const formattedBirthday = `${year}-${month}-${day}`;
      const birthDate = new Date(formattedBirthday);
      const today = new Date();
      let age = today.getFullYear() - birthDate.getFullYear();
      const monthDiff = today.getMonth() - birthDate.getMonth();
      if (
        monthDiff < 0 ||
        (monthDiff === 0 && today.getDate() < birthDate.getDate())
      ) {
        age--;
      }
      return age;
    },
    calculateXPValue(birthday) {
      const age = this.calculateAge(birthday);
      const xp = Math.floor((age - 7) * Math.pow(22, 1.45));
      return xp > 0 ? xp : 0;
    },
    getModFromAtributte(value) {
      const modRanges = {
        8: -2,
        10: -1,
        12: 0,
        15: 1,
        18: 2,
        20: 3,
      };

      for (const rangeValue in modRanges) {
        if (value <= rangeValue) {
          return modRanges[rangeValue];
        }
      }

      return 0;
    },
    getModFromEquippedWeapons(weapons) {
      const equippedWeapon = weapons.find((weapon) => weapon.equipped === true);
      return equippedWeapon ? equippedWeapon.mod : 0;
    },
    redirectToDelete(item) {
      this.$router.push({
        name: "delete",
        params: { id: item.id, name: item.name },
        key: "$route.fullPath",
      });
    },
    redirectToInfo(item) {
      this.$router.push({
        name: "info",
        params: { id: item.id },
        key: "$route.fullPath",
      });
    },
    redirectToEdit(item) {
      this.$router.push({
        name: "edit",
        params: { id: item.id, name: item.name },
        key: "$route.fullPath",
      });
    },
    getAttack(item){
      const attack = 10 +
          this.getModFromAtributte(item.attributes[item.keyAttribute]) +
          this.getModFromEquippedWeapons(item.weapons)
      return attack > 0 ? attack : 0;
    },
    translateAttribute(attributeKey) {
      const attributes = {
        strength: "Força",
        dexterity: "Destreza",
        constitution: "Vigor",
        intelligence: "Inteligência",
        wisdom: "Sabedoria",
        charisma: "Carisma",
      };

      return attributes[attributeKey] || "";
    },
  },
};
</script>

<style>
    .item-list-ul li {
        display: flex;
        background-color: #fff8e5;
    }

        .item-list-ul li:nth-child(even) {
            background: #ffdc73;
        }

        .item-list-ul li div {
            display: flex;
            align-items: center;
            justify-content: center;
            width: 148px;
            height: 48px;
            border: 2px #333 solid;
            border-collapse: separate;
        }

    .item-list-icon-buttons-container {
        width: 148px;
        border: 2px #333 solid;
        border-collapse: separate;
    }

    .item-list-header div {
        font-size: 24px;
    }
</style>
