<template>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Login_Register />
        <!--msg="Welcome to Your Vue.js App"-->
    </div>
</template>

<script>
// @ is an alias to /src
import Login_Register from '@/components/Login_Register.vue'

export default {
    name: 'HomeView',
    components: {
        Login_Register
    }
}
</script>