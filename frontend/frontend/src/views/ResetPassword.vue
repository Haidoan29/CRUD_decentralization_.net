<template>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <ResetPassword />
        <!--msg="Welcome to Your Vue.js App"-->
    </div>
</template>

<script>
// @ is an alias to /src
import ResetPassword from '@/components/ResetPassword.vue';

export default {
    name: 'HomeView',
    components: {
        ResetPassword
    }
}
</script>