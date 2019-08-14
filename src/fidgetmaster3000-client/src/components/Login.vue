<template>
  <v-layout align-center justify-center>
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-card-title>Login to FidgetMaster 3000</v-card-title>
        <v-card-text>
          <v-form>
            <v-text-field
              prepend-icon="person"
              name="login"
              label="User Name"
              type="text"
              v-model="userName"
              v-on:keyup.enter="goLogin"
            ></v-text-field>
            <v-text-field
              id="password"
              prepend-icon="lock"
              name="password"
              label="Password"
              type="password"
              v-model="password"
              v-on:keyup.enter="goLogin"
            ></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" @click="goLogin">Login</v-btn>
        </v-card-actions>
        <v-alert type="error" :value="error != ''">{{error}}</v-alert>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import { mapActions, mapState } from "vuex";

export default {
  data() {
    return {
      userName: "",
      password: ""
    };
  },
  computed: {
    ...mapState({
      error: state => state.loginError
    })
  },
  methods: {
    ...mapActions(["login"]),
    goLogin() {
      this.login({ userName: this.userName, password: this.password });
    }
  }
};
</script>