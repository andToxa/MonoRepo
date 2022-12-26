import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/pages/HomePage.vue'
import ErrorPage from '@/pages/ErrorPage.vue'
import NotFound from '@/pages/NotFoundPage.vue'

Vue.use(VueRouter)

let router = new VueRouter({
    mode: 'history',
    routes: [
        {
            path: '/',
            component: Home
        },
        {
            path: '/error',
            component: ErrorPage
        },
        {
            path: '*',
            component: NotFound
        }
    ]
})

export default router

