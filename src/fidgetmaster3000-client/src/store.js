import Vue from 'vue';
import Vuex from 'vuex';

import fidgetTypeActions from "./store/actions/fidgetTypes";
import fidgetTypeMutations from "./store/mutations/fidgetTypes";


Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    fidgetTypes: []
  },
  mutations: {
    ...fidgetTypeMutations
  },
  actions: {
    ...fidgetTypeActions
  }
})
