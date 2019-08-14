import Vue from 'vue';
import Vuex from 'vuex';

import fidgetTypeActions from "./store/actions/fidgetTypes";
import fidgetTypeMutations from "./store/mutations/fidgetTypes";

import fidgetActions from "./store/actions/fidgets";
import fidgetMutations from "./store/mutations/fidgets";

import loginActions from "./store/actions/login";
import loginMutations from "./store/mutations/login";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    fidgetTypes: [],
    fidgets: [],
    loginError: ""
  },
  mutations: {
    ...fidgetTypeMutations,
    ...fidgetMutations,
    ...loginMutations
  },
  actions: {
    ...fidgetTypeActions,
    ...fidgetActions,
    ...loginActions
  }
})
