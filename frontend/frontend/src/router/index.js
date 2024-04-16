import { createRouter, createWebHistory } from 'vue-router'
import Register from '../views/Register.vue'
import Home from '../views/HomePage.vue'
import Forgotpassword from '../views/ForgotpasswordView.vue'

const routes = [
  {
    path: '/register',
    name: 'Register',
    component: Register
  },
  {
    path: '/login',
    name: 'Login',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('../views/login.vue')
  },
  {
    path: '/forgotpassword',
    name: 'Forgotpassword',
    component: Forgotpassword
  },
  {
    path: '/',
    name: 'HomePage',
    component: Home,
    meta: { requiresAuth: true } // Thêm meta data để chỉ định rằng trang cần đăng nhập
  },
]


const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})
router.beforeEach((to, from, next) => {
  // Kiểm tra meta data của trang
  if (to.meta.requiresAuth && to.path !== '/login') {
    const token = localStorage.getItem('token');
    if (!token) {
      // Chưa đăng nhập, chuyển hướng đến trang đăng nhập
      next('/login');
    } else {
      // Đã đăng nhập, cho phép truy cập vào trang
      next();
    }
  } else {
    // Trang không yêu cầu đăng nhập, cho phép truy cập
    next();
  }

});

export default router
