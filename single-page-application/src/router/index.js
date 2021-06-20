import { NotFound } from 'http-errors'
import { createRouter, createWebHistory } from 'vue-router'
import User from '../views/User.vue'
import Post from "../views/Post.vue";

const routes = [
  {
    path: "/users/:userId",
    name: "user",
    component: User,
  },
  {
    path: "/users/:userId/posts",
    name:Post,
    component:Post
  },

  // {
  //   path:'/:pathMatch(.*)*',
  //   name:'NotFound',
  //   component:NotFound
  // }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
