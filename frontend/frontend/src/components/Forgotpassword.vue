<template>
    <h1>Đây là trang quên mật khẩu</h1>

    <div class="card text-center containers" style="width: 300px;">
        <div class="card-header h5 text-white bg-primary">Password Reset</div>
        <div class="card-body px-5">
            <form @submit.prevent="submitForm">
                <label for="email">Email:</label>
                <input type="email" v-model="email" required>
                <button type="submit">Gửi yêu cầu</button>
            </form>
            <!-- <div data-mdb-input-init class="form-outline">
                <input type="email" id="typeEmail" class="form-control my-3" />
                <label class="form-label" for="typeEmail">Email input</label>
            </div>
            <a href="#" data-mdb-button-init data-mdb-ripple-init class="btn btn-primary w-100">Reset password</a> -->
            <div class="d-flex justify-content-between mt-4">
                <a class="" href="/login">Login</a>
                <a class="" href="/register">Register</a>
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
        };
    },
    methods: {
        async submitForm() {
            try {
                var url = `${process.env.VUE_APP_BASE_URL}ForgotPassword/forgotpassword`;

                await axios.post(url, { email: this.email });
                alert('Email reset password đã được gửi.');
            } catch (error) {
                console.error('Lỗi:', error);
                alert('Đã có lỗi xảy ra. Vui lòng thử lại sau.');
            }
        },
    },
};
</script>

<style scoped>
.containers {
    margin: 0 auto;
    width: 100%;
    max-width: 400px;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}
</style>
