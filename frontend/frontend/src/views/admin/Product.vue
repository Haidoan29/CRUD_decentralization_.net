<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Product />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>
    <footer>
        <Footer />
    </footer>
</template>

<script>
// @ is an alias to /src
import Product from '@/components/admin/Product.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name
import Footer from '@/components/admin/Footer.vue';  // Corrected the component name

export default {
    name: 'ProductList',
    components: {
        Product,
        Headers,  // Corrected the component name
        Footer
    }
}
</script>
