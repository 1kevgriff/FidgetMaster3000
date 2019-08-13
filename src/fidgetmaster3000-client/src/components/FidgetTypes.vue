<template>
  <div>
    <h1>Types</h1>
  </div>
</template>
<script>
import { mapState, mapActions } from "vuex";
export default {
  data() {
    return {};
  },
  computed: {
    ...mapState({
      fidgetTypes: state => state.fidgetTypes
    })
  },
  methods: {
      ...mapActions(["loadFidgetTypes"])
  },
  created(){
      this.loadFidgetTypes();
  }
};
</script>