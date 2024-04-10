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
        <input type="password" id="password" v-model="registerForm.password" required pattern=".{6,}"
          title="Mật khẩu phải chứa ít nhất 6 ký tự">
      </div>
      <div>
        <label for="retypePassword">Nhập lại mật khẩu:</label>
        <input type="password" id="retypePassword" v-model="registerForm.retypePassword" required>
      </div>
      <div>
        <span v-if="passwordMismatch" class="error-message">Mật khẩu và mật khẩu nhập lại không khớp.</span>
      </div>

      <nav>
        <router-link to="/login">Đăng nhập</router-link>|
        <button type="submit">Đăng Ký</button>

      </nav>
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
        retypePassword: '' // Thêm trường retypePassword vào form data
      },
      loginForm: {
        username: '',
        password: ''
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
        const response = await axios.post('https://localhost:7074/api/Auth/Register?role=CUSTOMER', {
          username: this.registerForm.username,
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
<style>
.error-message {
  color: red;
}
</style>