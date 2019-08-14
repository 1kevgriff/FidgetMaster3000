import Vue from 'vue';
import Router from 'vue-router';
import { requireAuth } from "./store/actions/auth";
import Home from './components/Home';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    { path: '/login', name: "login", component: () => import("./components/Login") },

    { path: '/', name: 'home', component: Home, beforeEnter: requireAuth },
    { path: '/fidget/types', name: "fidgetTypes", component: () => import("./components/FidgetTypes"), beforeEnter: requireAuth },
    { path: '/fidgets', name: "fidgetList", component: () => import("./components/FidgetList"), beforeEnter: requireAuth },
    { path: '/fidgets/:id', name: "fidgetDetails", component: () => import("./components/FidgetDetails"), beforeEnter: requireAuth },
    { path: '/fidgets/:id/approve', name: "fidgetApproval", component: () => import("./components/FidgetApproval"), beforeEnter: requireAuth },
  ]
})
