<!-- <template>
    <h1>Đây là trang quên mật khẩu</h1>

    <div class="card text-center containers" style="width: 300px;">
        <div class="card-header h5 text-white bg-primary">Password Reset</div>
        <div class="card-body px-5">
            <form @submit.prevent="submitForm">
                <label for="email">Email:</label>
                <input type="email" v-model="email" required>
                <button type="submit">Gửi yêu cầu</button>
            </form>
            <div class="d-flex justify-content-between mt-4">
                <a class="" href="/login">Login</a>
                <a class="" href="/register">Register</a>
            </div>
        </div>
    </div>


</template> -->
<template>
    <div class="bg-primary">
        <div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                <main>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header">
                                        <h3 class="text-center font-weight-light my-4">Password Recovery</h3>
                                    </div>
                                    <div class="card-body">
                                        <div v-if="!showCodeInput && !showPasswordInput" class="small mb-3 text-muted">
                                            Enter your email address and we will send you a link to reset your password.
                                        </div>
                                        <div v-if="showCodeInput && !showPasswordInput" class="small mb-3 text-muted">
                                            Enter the confirmation code sent to your email.</div>
                                        <div v-if="showPasswordInput" class="small mb-3 text-muted">Enter your new
                                            password.</div>
                                        <form @submit.prevent="submitForm">
                                            <div v-if="!showCodeInput && !showPasswordInput" class="form-floating mb-3">
                                                <input class="form-control" id="inputEmail" type="email" v-model="email"
                                                    placeholder="name@example.com" />
                                                <label for="inputEmail">Email address</label>
                                            </div>
                                            <div v-if="showCodeInput && !showPasswordInput" class="form-floating mb-3">
                                                <input class="form-control" id="inputCode" type="text" v-model="code"
                                                    placeholder="Confirmation code" />
                                                <label for="inputCode">Confirmation Code</label>
                                            </div>
                                            <div v-if="showPasswordInput" class="form-floating mb-3">
                                                <input class="form-control" id="inputPassword" type="password"
                                                    v-model="newPassword" placeholder="New Password" />
                                                <label for="inputPassword">New Password</label>
                                            </div>
                                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                                <router-link v-if="showCodeInput || showPasswordInput" class="small"
                                                    to="/login">Return to login</router-link>
                                                <button type="submit"
                                                    class="btn btn-primary">{{ showCodeInput ? 'Confirm Code' : 'Reset Password' }}</button>
                                            </div>
                                        </form>
                                    </div>
                                    <div class="card-footer text-center py-3">
                                        <div class="small"><a href="register.html">Need an account? Sign up!</a></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>

        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    name: 'ForgotPassword',
    data() {
        return {
            email: '',
            code: '',
            newPassword: '',
            showCodeInput: false,
            showPasswordInput: false
        };
    },
    methods: {
        async submitForm() {
            try {
                if (!this.showCodeInput && !this.showPasswordInput) {
                    var url = `${process.env.VUE_APP_BASE_URL}ForgotPassword/forgotpassword`;
                    await axios.post(url, { email: this.email });
                    this.showCodeInput = true;
                    alert('Email reset password đã được gửi.');
                } else if (this.showCodeInput && !this.showPasswordInput) {
                    var confirmUrl = `${process.env.VUE_APP_BASE_URL}ForgotPassword/confirmcode`;
                    await axios.post(confirmUrl, { email: this.email, code: this.code });
                    this.showPasswordInput = true;
                } else {
                    var resetUrl = `${process.env.VUE_APP_BASE_URL}ForgotPassword/resetpassword`;
                    await axios.post(resetUrl, { email: this.email, newPassword: this.newPassword });
                    this.$router.push('/login');
                    alert('Đặt lại mật khẩu thành công.');
                }
            } catch (error) {
                console.error('Lỗi:', error);
                alert('Đã có lỗi xảy ra. Vui lòng thử lại sau.');
            }
        },
    },
};
</script>

<style scoped>
/* .containers {
    margin: 0 auto;
    width: 100%;
    max-width: 400px;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
} */
@import '@/assets/css/style.css';
</style>
