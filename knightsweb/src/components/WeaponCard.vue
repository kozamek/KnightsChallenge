<template>
    <div class="weapon-card-main-container">
        <ul>
            <li>
                <strong>Name:</strong>
                <p>{{ name }}</p>
            </li>
            <li>
                <strong>Mod:</strong>
                <p>{{ mod }}</p>
            </li>
            <li>
                <strong>Attr:</strong>
                <p>{{ translateAttribute(attribute) }}</p>
            </li>
            <li>
                <strong>Equipped:</strong>
                <p>{{ isEquipped ? 'Yes': 'No' }}</p>
            </li>
        </ul>
    </div>
</template>

<script>


export default {
  props: {
    name: {
      type: String,
      required: true,
    },
    mod: {
      type: Number,
      required: true,
    },
    attribute: {
      type: String,
      required: true,
    },
    isEquipped: {
      type: Boolean,
      required: true,
    },
  },
  methods: {
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
  }

};
</script>

<style>
    /* Estilos opcionais para posicionar o ícone no meio do botão */
    .weapon-card-main-container {
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        justify-content: flex-start;
        padding: 8px;
        background: #fff;
        outline: none;
        border: 3px solid #333;
        border-radius: 8px;
        cursor: pointer;
        font-size: 24px;
        width: 100%;
        margin-bottom: 16px;
    }

        .weapon-card-main-container ul li {
            display: grid;
            grid-template-columns: 2fr 3fr;
            margin-bottom: 8px;
        }

            .weapon-card-main-container ul li strong {
                font-size: 28px;
                line-height: 28px;
            }

            .weapon-card-main-container ul li p {
                font-size: 24px;
                line-height: 30px;
            }
</style>
