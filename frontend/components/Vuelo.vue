<template>
  <v-card class="mx-auto">
          <v-img
            class="white--text align-end"
            height="200px"
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
          >
            <v-card-title>{{vuelo.origen}} - {{vuelo.destino}}</v-card-title>
          </v-img>

          <v-card-subtitle class="pb-0">Salida {{vuelo.fechaSalida}} - Llegada {{vuelo.fechaLlegada}}</v-card-subtitle>

          <v-card-text class="text--primary">
            <div>Compañia: {{vuelo.aerolinea}}</div>

            <div>Precio: {{vuelo.precio}}€</div>
          </v-card-text>

          <v-card-actions>
            <v-btn color="orange" text>Ver más</v-btn>

            <v-btn color="orange" text>Ir a la reserva</v-btn>
          </v-card-actions>
        </v-card>
</template>

<script>
export default {
  props: ['vuelo']
}
</script>
