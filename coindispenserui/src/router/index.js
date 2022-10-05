import Vue from 'vue'
import VueRouter from 'vue-router'
import CoinDispenser from '../views/CoinDispenser.vue'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/register',
    name: 'Register',
    component: Register
  },
  {
    path: '/coindispenser',
    name: 'CoinDispenser',
    component: CoinDispenser,
    beforeEnter: (to, from, next) => {
     
      if(JSON.parse(localStorage.getItem("token")) != null )
      {
        next();
      }
      else{
        next('/');
      }
   
    },
  },
]

const router = new VueRouter({
  mode: 'history',
  routes,
});
export default router
