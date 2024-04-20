<template>
    <header>
        <Headers />
    </header>
    <div class="home">
        <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
        <Dashboard />
        <!-- msg="Welcome to Your Vue.js App" -->
    </div>
    <footer>
        <Footer />
    </footer>
</template>

<script>
// @ is an alias to /src
import Dashboard from '@/components/admin/Dashboard.vue';
import Headers from '@/components/admin/Header.vue'; // Corrected the component name
import Footer from '@/components/admin/Footer.vue';  // Corrected the component name

export default {
    name: 'EmployeeCustomer',
    components: {
        Headers,  // Corrected the component name
        Footer,
        Dashboard,

    }
}
</script>
