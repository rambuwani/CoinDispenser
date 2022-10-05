<template>
    <div class="login-page">
   
     <div class="wallpaper-register"></div>

     <div class="container">
        <div class="row">
           <div class="col-lg-4 col-md-6 col-sm-8 mx-auto">
              <div class="card login" v-bind:class="{ error: emptyFields }">
                 <h1>Sign Up</h1>
                 <form class="form-group">
                    <input 
                    ref="username"
                        v-model="form.userName" 
                        type="text" 
                        class="form-control" 
                        placeholder="Username" 
                        required>
                    <input 
                        ref="password"
                        v-model="form.password" 
                        type="password" 
                        class="form-control" 
                        placeholder="Password" 
                        required>
                        <b-button v-on:click="onSubmit"  variant="dark">Register</b-button>

               
                 </form>
              </div>

            
           </div>
        </div>

     </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
   name: 'Register',

   data() {
       return {
           data: null,

    form :{
  userName: "",
  password: ""
    },
     emptyFields: false
  
           
       };
   },

   methods: {
    onSubmit() {
      let usernameValid = this.$refs.username.value
      let passwordValid =this.$refs.password.value
      if (usernameValid === "" || passwordValid == "") {
        
        alert("Username and Password must not be empty")
    } else {
            axios.post(`${process.env.VUE_APP_API_BASE_URL}/api/Account/Register`,this.form)
          .then(res=>{
            console.log(res);
                this.$router.push('/');
        
          })
          .catch(err=>{
            console.log(err);
          });
    
        }
     },
     

   },
};
</script>
<style scoped>
.card {
  padding: 20px;
}
  input {
     margin-bottom: 20px;
  }

.login-page {
  align-items: center;
  display: flex;
  height: 100vh;
}
  .wallpaper-login {
     background: url(https://images.pexels.com/photos/32237/pexels-photo.jpg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260)
        no-repeat center center;
     background-size: cover;
     height: 100%;
     position: absolute;
     width: 100%;
  }

  .wallpaper-register {
     background: url(https://images.pexels.com/photos/533671/pexels-photo-533671.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260)
        no-repeat center center;
     background-size: cover;
     height: 100%;
     position: absolute;
     width: 100%;
     z-index: -1;
  }

  h1 {
     margin-bottom: 1.5rem;
  }


.error {
  animation-name: errorShake;
  animation-duration: 0.3s;
}


</style>

