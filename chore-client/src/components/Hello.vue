<template>
  <div class="hello">
    <h1>{{ title }}</h1>
    <h2>Do your Chores</h2>
  </div>
</template>

<script>
export default {
  data() {
    return {
      title: "Chore Tracker Application"
    };
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
h1,
h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #35495e;
}
</style>
