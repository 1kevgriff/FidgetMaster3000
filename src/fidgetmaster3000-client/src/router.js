import Vue from 'vue';
import Router from 'vue-router';

import Home from './components/Home';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/', // localhost:8080/
      name: 'home',
      component: Home
    },
    { path: '/login', name: "login", component: () => import ("./components/Login")},
    { path: '/fidget/types', name: "fidgetTypes", component: () => import("./components/FidgetTypes") },
    { path: '/fidgets', name: "fidgetList", component: () => import("./components/FidgetList") },
    { path: '/fidgets/:id', name: "fidgetDetails", component: () => import("./components/FidgetDetails") },
    { path: '/fidgets/:id/approve', name: "fidgetApproval", component: () => import("./components/FidgetApproval") },
  ]
})
