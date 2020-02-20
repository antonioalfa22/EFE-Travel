﻿using REST.Collector.Client;
using REST.Collector.Client.Model;
using REST.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Collector.Server.Adapters
{
    public class AmadeusVuelosAdapter : IVuelosCollector
    {
        private AmadeusEndPoint amadeusEndPoint;
        public AmadeusVuelosAdapter()
        {
            this.amadeusEndPoint = new AmadeusEndPoint();
        }

        public Vuelo amadeusVueloToVuelo(AmadeusVuelo amv)
        {
            return new Vuelo
            {
                Origen = "Madrid", // Llamar a get Locations
                Destino = "Barcelona", // Llamar a get Locations
                FechaSalida = amv.DepartureTime,
                FechaLlegada = amv.ArrivalTime,
                Personas = amv.Persons,
                Precio = amv.Price,
                Aerolinea = amv.AirlineCode // Llamar a get Locations
            };
        }

        public List<Vuelo> GetVuelosIda(string origin, string destination, string departuredate, string adults)
        {
            List<AmadeusVuelo> amadeusVuelos = amadeusEndPoint.GetVuelosIda(origin, destination, departuredate, adults);
            List<Vuelo> vuelos = new List<Vuelo>();
            amadeusVuelos.ForEach(amv => vuelos.Add(amadeusVueloToVuelo(amv)));
            return vuelos;
        }

        public List<Vuelo> GetVuelosIdaVuelta(string origin, string destination, string departuredate, string returnDate, string adults)
        {
            List<AmadeusVuelo> amadeusVuelos = amadeusEndPoint.GetVuelosIdaVuelta(origin, destination, departuredate, returnDate, adults);
            List<Vuelo> vuelos = new List<Vuelo>();
            amadeusVuelos.ForEach(amv => vuelos.Add(amadeusVueloToVuelo(amv)));
            return vuelos;
        }
    }
}
