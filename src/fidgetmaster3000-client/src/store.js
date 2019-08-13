import Vue from 'vue';
import Vuex from 'vuex';

import fidgetTypeActions from "./store/actions/fidgetTypes";
import fidgetTypeMutations from "./store/mutations/fidgetTypes";

import fidgetActions from "./store/actions/fidgets";
import fidgetMutations from "./store/mutations/fidgets";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    fidgetTypes: [],
    fidgets: []
  },
  mutations: {
    ...fidgetTypeMutations,
    ...fidgetMutations
  },
  actions: {
    ...fidgetTypeActions,
    ...fidgetActions
  }
})
