<template>
  <div id="app">
    <h2>Đăng Ký</h2>
    <form @submit.prevent="register">
      <div>
        <label for="username">Tên đăng nhập:</label>
        <input type="text" id="username" v-model="registerForm.username" required>
      </div>
      <div>
        <label for="password">Mật khẩu:</label>
        <input type="password" id="password" v-model="registerForm.password" required>
      </div>
      <button type="submit">Đăng Ký</button>
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
        password: ''
      },
      loginForm: {
        username: '',
        password: ''
      },
      token: '' // Lưu trữ token sau khi đăng nhập thành công
    }
  },
  methods: {
    async register() {
      try {
        const response = await axios.post('https://localhost:7074/api/Auth/Register?role=CUSTOMER', {
          username: this.registerForm.username,
          password: this.registerForm.password
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