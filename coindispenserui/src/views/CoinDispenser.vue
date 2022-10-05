<template>
   <div>
 <Nav/>
  <b-jumbotron header="Coin Dispenser"  class="text-center">
    <h3  class="pb-4" >Select available coins:</h3>
    <b-form-group v-slot="{ ariaDescribedby }">
      <b-form-checkbox-group
      ref="coin"
        id="checkbox-group-1"
        v-model="form.coins"
        :options="data"
        :aria-describedby="ariaDescribedby"
        name="flavour-1"
      ></b-form-checkbox-group>
    </b-form-group>
    <b-form-input 
      ref="number"
        v-model="form.amount" 
        type="number" 
        placeholder="Enter your amount"
        min="0"
        ></b-form-input>
    <b-button class="mt-5 mb-3"  variant="primary" v-on:click="submit()">Submit</b-button>
  <div  v-show="responsesData">
    <table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Coin</th>
      <th scope="col">Quantity</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="(response, index) in responsesData"
       :key="index">
      <td>{{ response.coin }}</td>
      <td>{{ response.number }}</td>
    </tr>
    
  </tbody>
</table>
    
  </div>
  </b-jumbotron>
</div>
  </template>
  
  <script>

import axios from 'axios';
import Nav from '../components/Nav.vue';


  export default {
    name: 'CoinDispenser',
    components:{
    Nav
},
    data () {
    return {
      data:[null],
      form: {
        coins: [],
        amount:null,
        },
        responsesData:null,
    }
  },
  created() {
   
    let tokenBearer = `Bearer ${JSON.parse(localStorage.getItem("token"))}`;
    
    axios.get(`${process.env.VUE_APP_API_BASE_URL}/api/Dispenser/GetCoins`, 
      { headers: {"Authorization" : ` ${tokenBearer}`} })
    .then(response => {
      this.data = response.data.result;
    })
    .catch(e => {
      this.errors.push(e)
    })
  },
  methods: {
        submit(){
          let numberValid =this.$refs.number.value;
  if(!numberValid){
      alert("Please insert amount")
  }
  else{
          const config = {
    headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }
    };
            axios.post(`${process.env.VUE_APP_API_BASE_URL}/api/Dispenser/PostCoins`, this.form,config)
            .then(response => {
              this.responsesData = response.data.result.combination
            })
            .catch(error => {
              this.errorMessage = error.message;
              console.error("There was an error!", error);
        });
        }
      }
      }
}
  </script>
  
  <style scoped>
  
  </style>