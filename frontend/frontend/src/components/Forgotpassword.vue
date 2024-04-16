<template>
    <h1>Đây là trang quên mật khẩu</h1>

    <div class="card text-center containers" style="width: 300px;">
        <div class="card-header h5 text-white bg-primary">Password Reset</div>
        <div class="card-body px-5">
            <p class="card-text py-2">
                Enter your email address and we'll send you an email with instructions to reset your password.
            </p>
            <div data-mdb-input-init class="form-outline">
                <input type="email" id="typeEmail" class="form-control my-3" />
                <label class="form-label" for="typeEmail">Email input</label>
            </div>
            <a href="#" data-mdb-button-init data-mdb-ripple-init class="btn btn-primary w-100">Reset password</a>
            <div class="d-flex justify-content-between mt-4">
                <a class="" href="/login">Login</a>
                <a class="" href="/register">Register</a>
            </div>
        </div>
    </div>


</template>

<script>
export default {
    name: 'ForgotPassword',
    methods: {
        // logout() {
        //     // Xử lý đăng xuất ở đây
        //     // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
        //     localStorage.removeItem('token');
        //     this.$router.push('/login');
        //     window.location.reload();
        // }
    }
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
