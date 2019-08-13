<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title class="headline text-uppercase">
        <span>FIDGETPRO</span>
        <span class="font-weight-light">FIDGETMASTER 3000</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn text :to="{ name: 'home'}">Home</v-btn>
      <v-btn text :to="{ name: 'fidgetTypes'}">Fidget Types</v-btn>
      <v-btn text :to="{ name: 'fidgetList'}">Fidgets</v-btn>
    </v-app-bar>

    <v-content>
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: "App",
  components: {},
  data: () => ({})
};
</script>
