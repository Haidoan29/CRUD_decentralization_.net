<template>
    <div id="login">

        <form> <!-- Thêm kết nối sự kiện submit -->
            <h1>Đây là trang ResetPassword</h1>
            <input type="text" id="loginUsername" required placeholder="verification codes">
            <input type="password" id="loginPassword" required placeholder="Password">
            <input type="password" id="loginPassword" required placeholder="retypePassword">
            <button type="submit">Sign in</button>
            <a href="/register" @click="goToRegister">Đăng ký</a>
            <a href="/forgotpassword" @click="goToForgotpassword">quên mật khẩu</a>
        </form>
    </div>
</template>

<script>
//import axios from 'axios';
export default {
    name: 'ResetPassword',
}
</script>