<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Customer />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>
    <footer>
        <Footer></Footer>
    </footer>
</template>

<script>
// @ is an alias to /src
import Customer from '@/components/admin/Customer.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name
import Footer from '@/components/admin/Footer.vue';  // Corrected the component name

export default {
    name: 'EmployeeCustomer',
    components: {
        Customer,
        Headers,  // Corrected the component name
        Footer
    }
}
</script>
