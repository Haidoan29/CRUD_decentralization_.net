<template>
    <div id="login">
        <form @submit.prevent="login"> <!-- Thêm kết nối sự kiện submit -->
            <h1>Sign In</h1>
            <input type="text" id="loginUsername" v-model="loginForm.username" required placeholder="Username">
            <input type="password" id="loginPassword" v-model="loginForm.password" required placeholder="Password">
            <button type="submit">Sign in</button>
            <a href="/register" @click="goToRegister">Đăng ký</a>
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

        }
    },
    methods: {
        async login() {
            try {
                var url = `${process.env.VUE_APP_BASE_URL}Auth/Login`;


                const response = await axios.post(url, {
                    username: this.loginForm.username,
                    password: this.loginForm.password
                });

                // Kiểm tra kết quả từ phản hồi
                if (response.status === 200) {
                    console.log('Đăng nhập thành công:', response.data);
                    // Lưu token vào local storage để sử dụng trong các yêu cầu tiếp theo
                    localStorage.setItem('token', response.data.token);

                    // Chuyển hướng người dùng đến trang khác
                    // Chuyển hướng người dùng đến trang khác
                    this.$router.push('/').then(() => {
                        // Load lại trang sau khi chuyển hướng
                        window.location.reload();
                    });
                    // // Load lại trang sau khi chuyển hướng
                    // this.$router.go(0);
                } else {
                    console.error('Đăng nhập không thành công:', response.data);
                    // Hiển thị thông báo lỗi cho người dùng
                }
            } catch (error) {
                console.error('Đã xảy ra lỗi khi đăng nhập:', error);
                // Hiển thị thông báo lỗi cho người dùng
            }
        },
        goToRegister() {
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
@import url('/public/login.css');
</style>
