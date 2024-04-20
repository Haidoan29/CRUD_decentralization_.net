<template>
    <header>
        <Heders />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Forgotpassword />
        <!--msg="Welcome to Your Vue.js App"-->
    </div>
    <footer>
        <Footer />
    </footer>
</template>

<script>
// @ is an alias to /src
import Forgotpassword from '@/components/Forgotpassword.vue'
import Heders from '@/components/heder.vue'
import Footer from '@/components/footer.vue'

export default {
    name: 'HomePage',
    components: {
        Forgotpassword,
        Heders,
        Footer
    }
}
</script>