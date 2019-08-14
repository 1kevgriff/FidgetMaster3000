<template>
  <div>
    <v-card>
      <v-card-title>Fidgets</v-card-title>
      <v-card-text>
        <v-data-table :items="fidgets" :headers="headers">
          <template v-slot:item.actions="{item}">
            <v-icon small class="mr-2" @click="editItem(item)">edit</v-icon>
            <v-icon small @click="deleteItem(item)">delete</v-icon>
          </template>
        </v-data-table>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" @click="isDialogOpen = true">New Fidget</v-btn>
      </v-card-actions>
    </v-card>
    <v-dialog v-model="isDialogOpen" max-width="500" persistent>
      <v-card>
        <v-card-title>Edit Fidget</v-card-title>
        <v-card-text>
          <v-text-field v-model="editObject.name" label="Fidget Name"></v-text-field>
          <v-select v-model="editObject.color" :items="colors" item-text="text" item-value="value"></v-select>
          <v-select v-model="editObject.typeId" :items="fidgetTypes" item-text="typeName" item-value="id"></v-select>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="darken-1" text @click="closeDialog">Cancel</v-btn>
          <v-btn color="primary darken-1" @click="saveItem">OK</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import { mapState, mapActions } from "vuex";
import { setTimeout } from "timers";
export default {
  data() {
    return {
      isDialogOpen: false,
      colors: [
        { text: "Blue", value: "Blue" },
        { text: "Green", value: "Green" },
        { text: "Yellow", value: "Yellow" },
        { text: "Purple", value: "Purple" }
      ],
      headers: [
        {
          text: "Name",
          value: "name"
        },
        {
          text: "Color",
          value: "color"
        },
        {
          text: "Type",
          value: "type.typeName"
        },
        {
          text: "Actions",
          value: "actions"
        }
      ],
      editIndex: -1,
      editObject: {
        name: "",
        color: "Blue",
        typeId: -1
      },
      defaultObject: {
        name: "",
        color: "Blue",
        typeId: -1
      }
    };
  },
  computed: {
    ...mapState({
      fidgetTypes: state => state.fidgetTypes,
      fidgets: state => state.fidgets
    })
  },
  methods: {
    ...mapActions(["loadFidgetTypes", "loadFidgets", "saveFidgetType", "saveFidget"]),
    editItem(item) {
      this.editIndex = this.fidgets.indexOf(item);
      this.editObject = Object.assign({}, item);
      this.isDialogOpen = true;
    },
    deleteItem(item) {},
    saveItem() {
      this.saveFidget(this.editObject);
      this.closeDialog();
    },
    closeDialog() {
      this.isDialogOpen = false;
      setTimeout(() => {
        this.editObject = Object.assign({}, this.defaultObject);
        this.editIndex = -1;
      }, 300);
    }
  },
  created() {
    this.loadFidgetTypes();
    this.loadFidgets();
  }
};
</script>