<template>
  <div class="container-fluid mt-4">
    <h1 class="h1">Chores</h1>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-row>
      <b-col>
        <table class="table table-striped">
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>&nbsp;</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="chore in chores" :key="chore.choreID">
              <td>{{ chore.choreID }}</td>
              <td>{{ chore.choreName }}</td>
              <td class="text-right">
                <a href="#" @click.prevent="updateChore(chore)">Edit</a> -
                <a href="#" @click.prevent="deleteChore(chore.choreID)"
                  >Delete</a
                >
              </td>
            </tr>
          </tbody>
        </table>
      </b-col>
      <b-col lg="3">
        <b-card
          :title="
            model.choreID ? 'Edit Chore ID#' + model.choreID : 'New Chore'
          "
        >
          <form @submit.prevent="createChore">
            <b-form-group label="Chore Name">
              <b-form-input
                type="text"
                v-model="model.choreName"
              ></b-form-input>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save Record</b-btn>
            </div>
          </form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import api from "@/ChoreApiService";

export default {
  data() {
    return {
      loading: false,
      chores: [],
      model: {}
    };
  },
  async created() {
    this.getAll();
  },
  methods: {
    async getAll() {
      this.loading = true;
      console.log(this.chores);
      console.log(this.model);
      try {
        this.chores = await api.getAll();
      } finally {
        this.loading = false;
      }
    },
    async updateChore(chore) {
      // We use Object.assign() to create a new (separate) instance
      this.model = Object.assign({}, chore);
    },
    async createChore() {
      const isUpdate = !!this.model.choreID;

      if (isUpdate) {
        await api.update(this.model.choreID, this.model);
      } else {
        await api.create(this.model);
      }

      // Clear the data inside of the form
      this.model = {};

      await this.getAll();
    },
    async deleteChore(choreID) {
      let request = await api.delete(choreID);
      if (request === "success") {
        this.model = {};
        await this.getAll();
      }
    }
  }
};
</script>
