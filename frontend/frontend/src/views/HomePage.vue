<template>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <HommePage />
        <!--msg="Welcome to Your Vue.js App"-->
    </div>
</template>

<script>
// @ is an alias to /src
import HommePage from '@/components/HomePage.vue'

export default {
    name: 'HomePage',
    components: {
        HommePage
    }
}
</script>