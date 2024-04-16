<template>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Forgotpassword />
        <!--msg="Welcome to Your Vue.js App"-->
    </div>
</template>

<script>
// @ is an alias to /src
import Forgotpassword from '@/components/Forgotpassword.vue'

export default {
    name: 'HomePage',
    components: {
        Forgotpassword
    }
}
</script>