import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify';
import moment from "moment";

Vue.config.productionTip = false;

Vue.filter('datetime', function (value) {
  if (!value) return '';
  
  return moment(value).format("MMMM Do YYYY");
})

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
