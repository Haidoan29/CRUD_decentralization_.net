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

        <h2>Đăng Nhập</h2>
        <form @submit.prevent="login">
            <div>
                <label for="loginUsername">Tên đăng nhập:</label>
                <input type="text" id="loginUsername" v-model="loginForm.username" required>
            </div>
            <div>
                <label for="loginPassword">Mật khẩu:</label>
                <input type="password" id="loginPassword" v-model="loginForm.password" required>
            </div>
            <button type="submit">Đăng Nhập</button>
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
                // Hiển thị thông báo thành công cho người dùng
            } catch (error) {
                console.error('Đăng ký không thành công:', error.response.data);
                // Hiển thị thông báo lỗi cho người dùng
            }
        },
        async login() {
            try {
                const response = await axios.post('https://localhost:7074/api/Auth/Login', {
                    username: this.loginForm.username,
                    password: this.loginForm.password
                });

                // Kiểm tra kết quả từ phản hồi
                if (response.status === 200) {
                    console.log('Đăng nhập thành công:', response.data);
                    // Lưu token vào local storage để sử dụng trong các yêu cầu tiếp theo
                    localStorage.setItem('token', response.data.token);
                    // Chuyển hướng người dùng đến  trang khác

                    this.$router.push('/');
                } else {
                    console.error('Đăng nhập không thành công:', response.data);
                    // Hiển thị thông báo lỗi cho người dùng
                }
            } catch (error) {
                console.error('Đã xảy ra lỗi khi đăng nhập:', error);
                // Hiển thị thông báo lỗi cho người dùng
            }
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
        // this.loadData();
    }
}

</script>