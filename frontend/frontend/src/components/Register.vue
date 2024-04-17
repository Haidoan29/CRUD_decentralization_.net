<template>
  <div id="app">
    <form form @submit.prevent="register" action="action_page.php" class="register" style="border:1px solid #ccc">
      <div class="container">
        <h1>Sign Up</h1>
        <hr>
        <label for="username"><b>username</b></label>
        <input type="text" id="username" v-model="registerForm.username" required>
        <label for="email"><b>Email</b></label>
        <input type="text" id="username" v-model="registerForm.email" required>

        <label for="psw"><b>Password</b></label>
        <input type="password" id="password" v-model="registerForm.password" required pattern=".{6,}"
          title="Mật khẩu phải chứa ít nhất 6 ký tự">


        <label for="psw-repeat"><b>Repeat Password</b></label>
        <input type="password" id="retypePassword" v-model="registerForm.retypePassword" required>
        <div>
          <span v-if="passwordMismatch" class="error-message">Mật khẩu và mật khẩu nhập lại không khớp.</span>
        </div>

        <label>
          <input type="checkbox" checked="checked" name="remember" style="margin-bottom:15px"> Remember me
        </label>

        <div class="clearfix">

          <button type="button" class="cancelbtn">Cancel</button>
          <button type="submit" class="signupbtn">Đăng Ký</button>
          <router-link to="/login">Đăng nhập</router-link>|
        </div>
      </div>
    </form>
  </div>
</template>
<script>
import axios from 'axios';

export default {
  name: 'Login_Register',
  props: {
    msg: String
  },

  data() {
    return {
      registerForm: {
        username: '',
        password: '',
        email: '',
        retypePassword: '' // Thêm trường retypePassword vào form data
      },
      token: '', // Lưu trữ token sau khi đăng nhập thành công
      passwordMismatch: false // Thêm passwordMismatch vào data để kiểm tra mật khẩu nhập lại
    }
  },
  methods: {
    async register() {
      // Kiểm tra xem mật khẩu và mật khẩu nhập lại có khớp nhau không
      if (this.registerForm.password !== this.registerForm.retypePassword) {
        // Nếu mật khẩu không khớp, hiển thị thông báo lỗi
        this.passwordMismatch = true;
        return;
      }

      try {
        var url = `${process.env.VUE_APP_BASE_URL}Auth/Register`;
        //'https://localhost:7074/api/Auth/Register?role=CUSTOMER'
        const response = await axios.post(url, {

          username: this.registerForm.username,
          email: this.registerForm.email,
          password: this.registerForm.password,
          Role: 'CUSTOMER' // Thêm trường Role với giá trị 'CUSTOMER'
        });
        console.log(response.data);

        this.$router.push('/login');
      } catch (error) {
        console.error('Đăng ký không thành công:', error.response ? error.response.data : error.message);
      }
    },

    // login() {
    //   var url = "https://localhost:7074/api/Auth/Login";
    //   axios.post(url).then(response => {
    //     console.log(response);
    //   }).catch(error => {
    //     console.error('Đã xảy ra lỗi khi tải dữ liệu:', error);
    //   })
    // },

  },
  created() {
    //debugger
    console.log('Component created');
    this.titlePage = "Component Setting in created";
    //this.loadData();
  }
}

</script>
<style scoped>
/* .error-message {
  color: red;
} */
@import url('/public/register.css');
</style>