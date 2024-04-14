import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue';
import CreateView from '../views/CreateView.vue';
import InfoView from '../views/InfoView.vue';
import EditView from '../views/EditView.vue';
import DeleteView from '../views/DeleteView.vue';

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/edit/:id/:name',
    name: 'edit',
    component: EditView
  },
  {
    path: '/delete/:id/:name',
    name: 'delete',
    component: DeleteView,
  },
  {
    path: '/create',
    name: 'create',
    component: CreateView
  },
  {
    path: '/info/:id/',
    name: 'info',
    component: InfoView
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
