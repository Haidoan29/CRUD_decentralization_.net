import { createRouter, createWebHistory } from 'vue-router'
import Register from '@/views/Register.vue'
import Home from '@/views/HomePage.vue'
import Forgotpassword from '@/views/ForgotpasswordView.vue'
import ResetPassword from '@/views/ResetPassword.vue'
import Employee from '@/views/admin/employee.vue'
import Product from '@/views/admin/Product.vue'
import Dashboard from '@/views/admin/Dashboard.vue'
import Customer from '@/views/admin/Customer.vue'
import Order from '@/views/admin/Order.vue'

const routes = [
  {
    path: '/register',
    name: 'Register',
    component: Register
  },
  {
    path: '/ResetPassword',
    name: 'ResetPassword',
    component: ResetPassword
  },

  {
    path: '/login',
    name: 'Login',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('@/views/login.vue')
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
  {
    path: '/admin/employee',
    name: 'EmployeeStaff',
    component: Employee
  },
  {
    path: '/admin/product',
    name: 'ProductList',
    component: Product
  },
  {
    path: '/admin/dashboard',
    name: 'DashBoard',
    component: Dashboard
  },
  {
    path: '/admin/customer',
    name: 'customer',
    component: Customer
  },
  {
    path: '/admin/order',
    name: 'OrderManagement',
    component: Order
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
