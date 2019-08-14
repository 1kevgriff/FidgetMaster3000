<template>
  <div>
    <v-card>
      <v-card-title>Fidget Types</v-card-title>
      <v-card-text>
        <v-data-table :items="fidgetTypes" :headers="headers">
          <template v-slot:item.designedDate="{item}">{{item.designedDate | datetime}}</template>
          <template v-slot:item.isBouncing="{item}">
            <v-chip v-if="item.isBouncing" class="ma-2" color="green" text-color="white">
              <v-icon>check</v-icon>
            </v-chip>
          </template>
          <template v-slot:item.isSpinning="{item}">
            <v-chip v-if="item.isSpinning" class="ma-2" color="green" text-color="white">
              <v-icon>check</v-icon>
            </v-chip>
          </template>
          <template v-slot:item.isFlying="{item}">
            <v-chip v-if="item.isFlying" class="ma-2" color="green" text-color="white">
              <v-icon>check</v-icon>
            </v-chip>
          </template>
          <template v-slot:item.actions="{item}">
            <v-icon small class="mr-2" @click="editItem(item)">edit</v-icon>
            <v-icon small @click="deleteItem(item)">delete</v-icon>
          </template>
        </v-data-table>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" @click="isTypeDialogOpen = true">New Type</v-btn>
      </v-card-actions>
    </v-card>
    <v-dialog v-model="isTypeDialogOpen" max-width="500" persistent>
      <v-card>
        <v-card-title>Edit Type</v-card-title>
        <v-card-text>
          <v-text-field v-model="editTypeObject.typeName" label="Type Name"></v-text-field>
          <v-checkbox v-model="editTypeObject.isSpinning" label="Spins?"></v-checkbox>
          <v-checkbox v-model="editTypeObject.isBouncing" label="Bounces?"></v-checkbox>
          <v-checkbox v-model="editTypeObject.isFlying" label="Flys?"></v-checkbox>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="darken-1" text @click="closeDialog">Cancel</v-btn>
          <v-btn color="primary darken-1" @click="saveItem">OK</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-dialog v-model="isConfirmationDialogOpen">
      <v-card>
        <v-card-title>Delete Fidget?</v-card-title>
        <v-card-text>Are you sure you want to delete {{editTypeObject.typeName}}?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="darken-1" text @click="isConfirmationDialogOpen = false">No</v-btn>
          <v-btn color="primary darken-1" @click="confirmDeleteItem">Yes</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-snackbar v-model="showSnackbar">{{deleteFidgetError}}</v-snackbar>
  </div>
</template>
<script>
import { mapState, mapActions } from "vuex";
import { setTimeout } from "timers";
export default {
  data() {
    return {
      isTypeDialogOpen: false,
      isConfirmationDialogOpen: false,
      headers: [
        {
          text: "Type",
          value: "typeName"
        },
        {
          text: "Designed On",
          value: "designedDate"
        },
        {
          text: "Spins?",
          value: "isSpinning"
        },
        {
          text: "Bounces?",
          value: "isBouncing"
        },
        {
          text: "Flys?",
          value: "isFlying"
        },
        {
          text: "Actions",
          value: "actions"
        }
      ],
      editTypeIndex: -1,
      editTypeObject: {
        typeName: "",
        isSpinning: false,
        isBouncing: false,
        isFlying: false
      },
      defaultTypeObject: {
        typeName: "",
        isSpinning: false,
        isBouncing: false,
        isFlying: false
      }
    };
  },
  computed: {
    ...mapState({
      fidgetTypes: state => state.fidgetTypes,
      deleteFidgetError: state => state.error.deleteFidget,
      showSnackbar: state => state.snackbar.showDeleteFidgetError
    })
  },
  methods: {
    ...mapActions(["loadFidgetTypes", "saveFidgetType", "deleteFidgetType"]),
    editItem(item) {
      this.editTypeIndex = this.fidgetTypes.indexOf(item);
      this.editTypeObject = Object.assign({}, item);
      this.isTypeDialogOpen = true;
    },
    deleteItem(item) {
      this.isConfirmationDialogOpen = true;
      this.editTypeIndex = this.fidgetTypes.indexOf(item);
      this.editTypeObject = Object.assign({}, item);
    },
    confirmDeleteItem() {
      this.deleteFidgetType(this.editTypeObject);
      this.isConfirmationDialogOpen = false;
      this.closeDialog();
    },
    saveItem() {
      this.saveFidgetType(this.editTypeObject);
      this.closeDialog();
    },
    closeDialog() {
      this.isTypeDialogOpen = false;
      setTimeout(() => {
        this.editTypeObject = Object.assign({}, this.defaultTypeObject);
        this.editTypeIndex = -1;
      }, 300);
    }
  },
  created() {
    this.loadFidgetTypes();
  }
};
</script>