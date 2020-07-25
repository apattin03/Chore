import Vue from "vue";
import Router from "vue-router";
import ChoreRecords from "@/components/ChoreRecords";
import Hello from "@/components/Hello";

Vue.use(Router);
let router = new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "Hello",
      component: Hello
    },
    {
      path: "/chore-records",
      name: "ChoreRecords",
      component: ChoreRecords
    }
  ]
});
export default router;
