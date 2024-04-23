<template>
    <nav>
        <!-- <router-link to="/register">Đăng ký</router-link> | -->
        <!-- <router-link to="/login">Đăng nhập</router-link> -->
        <button @click="logout">Logout</button>
    </nav>
    <div class="home">
        <h1>Welcome to Home Page</h1>
        <p>This is a simple home page built with Vue 3.</p>
    </div>
</template>

<script>
export default {
    methods: {
        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
            window.location.reload();
        }
    }
};
</script>

<style scoped>
.home {
    text-align: center;
    margin-top: 50px;
}
</style>
