<template>
    <div id="login">
        <form @submit.prevent="singin"> <!-- Thêm kết nối sự kiện submit -->
            <h1>Sign In</h1>
            <input type="text" id="loginUsername" v-model="loginForm.username" required placeholder="Username">
            <input type="password" id="loginPassword" v-model="loginForm.password" required placeholder="Password">
            <!-- <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p> -->
            <button type="submit">Sign in</button>
            <a href="/register" @click="goToRegister">Đăng ký</a>
            <a href="/forgotpassword" @click="goToForgotpassword">quên mật khẩu</a>
            <p :key="errorKey" v-if="errorMessage" class="error-message">{{ errorMessage }}</p>

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
            // registerForm: {
            //     username: '',
            //     password: ''
            // },
            loginForm: {
                username: '',
                password: ''
            },
            token: '', // Lưu trữ token sau khi đăng nhập thành công
            errorMessage: '', // Thêm biến này để lưu trữ thông báo lỗi
            errorKey: 0 // Thêm key để cập nhật DOM

        }
    },
    methods: {
        async singin() {
            try {
                var url = `${process.env.VUE_APP_BASE_URL}Auth/Login`;

                const response = await axios.post(url, {
                    username: this.loginForm.username,
                    password: this.loginForm.password
                });
                console.log(response.data.role);
                // Kiểm tra kết quả từ phản hồi
                if (response.status === 200 && response.data.token && response.data.role === 'ADMIN') {
                    console.log('Đăng nhập thành công:', response.data);

                    // Lưu token vào local storage để sử dụng trong các yêu cầu tiếp theo
                    localStorage.setItem('token', response.data.token);

                    // Chuyển hướng người dùng đến trang admin
                    this.$router.push('/admin').then(() => {
                        // Load lại trang sau khi chuyển hướng
                        // window.location.reload();
                        // console.log('Đăng nhập thành công:', response.data);
                    });
                } else {
                    console.error('Đăng nhập không thành công:', response.data);
                    this.errorMessage = 'Tài khoản hoặc mật khẩu không đúng hoặc không có quyền truy cập. Vui lòng thử lại.';
                    this.errorKey++; // Cập nhật key để cập nhật DOM
                }
            } catch (error) {
                console.error('Đã xảy ra lỗi khi đăng nhập:', error);
                this.errorMessage = 'Đã xảy ra lỗi khi đăng nhập. Vui lòng thử lại.';
                this.errorKey++; // Cập nhật key để cập nhật DOM
            }
        },


        goToRegister() {
            // Chuyển hướng đến trang đăng ký
            this.$router.push('/register');
            // Load lại trang
            this.$router.go(0);
        },
        goToForgotpassword() {
            // Chuyển hướng đến trang đăng ký
            this.$router.push('/register');
            // Load lại trang
            this.$router.go(0);
        }
        // login() {
        //     var url = "https://localhost:7074/api/Auth/Login";
        //     axios.post(url).then(response => {
        //         console.log(response);

        //     }).catch(error => {
        //         console.error('Đã xảy ra lỗi khi tải dữ liệu:', error);
        //     })
        // },
    },
    created() {
        //debugger
        console.log('Component created');
        this.titlePage = "Component Setting in created";
        //this.login();
    }
}
</script>
<style scoped>
/* @import url('/public/login.css'); */
</style>
