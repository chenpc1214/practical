<template>
  <h1>User: {{ userId }} - {{ userInfo?.name }}</h1>
  <div>username: @{{ userInfo.username }}</div>
  <div>email: {{ userInfo.email }}</div>
  <div>phone: {{ userInfo.phone }}</div>
  <hr />

  Show
  <router-link :to="`/users/${userId}/posts`">
    /users/{{ userId }}/posts
  </router-link>

  <hr />

  <router-view></router-view>
</template>

<script>
export default {
  data() {
    return {
      userInfo: {},
    };
  },
  computed: {
    userId() {
      return this.$route.params.userId;
    },
  },
  watch: {
    userId: async function (val) {
      this.userInfo = await this.fetchUserInfo(val);
    },
  },
  methods: {
    async fetchUserInfo(id) {
      return await fetch("https://jsonplaceholder.typicode.com/users/" + id)
        .then((response) => response.json())
        .then((json) => json);
    },
  },
  async created() {
    this.userInfo = await this.fetchUserInfo(this.userId);
  },
};
</script>