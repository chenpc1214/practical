<template>
  <h1>Post from User-{{ userId }}</h1>
  <ol>
    <li v-for="post in posts" :key="post.id">
      <h3>{{ post.title }}</h3>
      <p>{{ post.body }}</p>
    </li>
  </ol>
</template>

<script>
export default {
  data() {
    return {
      posts: [],
    };
  },
  computed: {
    userId() {
      return this.$route.params.userId;
    },
  },
  methods: {
    async fetchUserPosts(id) {
      return await fetch(
        "https://jsonplaceholder.typicode.com/posts?userId=" + this.userId
      ).then((response) => response.json());
    },
  },
  async created() {
    this.posts = await this.fetchUserPosts(this.userId);
  },
};
</script>