<template>
  <v-container>
    <v-card class="mx-auto" color="#363636">
      <v-row align="center" justify="center">
        <v-col cols="12" md="8">
          <v-spacer></v-spacer>
          <v-autocomplete
            v-model="select"
            :loading="loading"
            :items="destinos"
            :search-input.sync="search"
            append-icon="mdi-magnify"
            cache-items
            flat
            hide-no-data
            hide-details
            label="Ej: Sillicon Valley"
            class="hidden-sm-and-down"
            solo-inverted
          ></v-autocomplete>
        </v-col>
      </v-row>
      <v-row align="center" justify="center">
        <v-col cols="12" md="2">
          <v-menu
            ref="menuEntrada"
            v-model="menuEntrada"
            :close-on-content-click="false"
            :return-value.sync="fechaEntrada"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                v-model="fechaEntrada"
                label="Entrada"
                prepend-icon="mdi-bunk-bed"
                readonly
                v-on="on"
              ></v-text-field>
            </template>
            <v-date-picker v-model="fechaEntrada" no-title scrollable locale="es">
              <v-spacer></v-spacer>
              <v-btn text color="primary" @click="menuEntrada = false">Cancelar</v-btn>
              <v-btn text color="primary" @click="$refs.menuEntrada.save(fechaEntrada)">OK</v-btn>
            </v-date-picker>
          </v-menu>
        </v-col>
        <v-col cols="12" md="2">
          <v-menu
            ref="menuSalida"
            v-model="menuSalida"
            :close-on-content-click="false"
            :return-value.sync="fechaSalida"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                v-model="fechaSalida"
                label="Salida"
                prepend-icon="mdi-bunk-bed"
                readonly
                v-on="on"
              ></v-text-field>
            </template>
            <v-date-picker v-model="fechaSalida" no-title scrollable locale="es">
              <v-spacer></v-spacer>
              <v-btn text color="primary" @click="menuSalida = false">Cancelar</v-btn>
              <v-btn text color="primary" @click="$refs.menuSalida.save(fechaSalida)">OK</v-btn>
            </v-date-picker>
          </v-menu>
        </v-col>
        <v-col cols="12" md="2">
          <v-select :items="personas" label="Personas" dense outlined v-model="selectPersona"></v-select>
        </v-col>
        <v-col cols="12" md="2">
          <v-btn rounded color="primary" dark large @click="buscar">
            <v-icon left>mdi-magnify</v-icon>Buscar hoteles
          </v-btn>
        </v-col>
      </v-row>
    </v-card>
  </v-container>
</template>

<script>
const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "default",
  middleware: 'authenticated',
  data: () => ({
    loading: false,
    search: null,
    select: null, //Elemento seleccionado
    destinos: [],
    locations: [],
    personas: [1,2,3,4,5,6],
    selectPersona: 1,
    menuEntrada: false,
    menuSalida: false,
    fechaEntrada: new Date().toISOString().substr(0, 10),
    fechaSalida: new Date().toISOString().substr(0, 10),
  }),
   async mounted() {
    let destinos = await this.$axios.get(
      process.env.BASE_URL + "/locations.json"
    );
    this.locations = destinos.data;
    this.destinos = this.locations.map(x => x.city);
  },
  methods: {
    buscar() {
      let destino = this.locations.find(x => x.city == this.select);
      this.$router.push(`/hoteles/buscar?destino=${destino.code}&entrada=${this.fechaEntrada}&salida=${this.fechaSalida}&personas=${this.selectPersona}`)
    }
  }
};
</script>
