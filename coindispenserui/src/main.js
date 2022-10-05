import Vue from 'vue'
import App from './App.vue'
import { BootstrapVue } from 'bootstrap-vue'


import 'bootstrap-vue/dist/bootstrap-vue.css'
import router from './router'

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue)
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
