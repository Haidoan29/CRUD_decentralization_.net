<template>
  <!-- <nav>
    <router-link to="/register">Đăng ký</router-link> |
    <router-link to="/login">Đăng nhập</router-link>
  </nav> -->
  <div>
    <h1>Xin chào các bạn </h1>
  </div>
  <router-view />
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
