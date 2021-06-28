using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Domain.Response;
using ViveVolar.Entities;
using ViveVolar.Repository;

namespace ViveVolar.Domain.Services
{
    public class VueloService : IVueloService
    {
        private IVueloRepository _vueloRepository;
        public VueloService(IVueloRepository vueloRepository)
        {
            _vueloRepository = vueloRepository;
            
        }
        public async Task<bool> Crear(IVuelo vuelo)
        {
            Vuelo _vuelo = new();
            _vuelo.CantidadSillas = vuelo.CantidadSillas;
            _vuelo.CiudadDestino = vuelo.CiudadDestino;
            _vuelo.CiudadOrigen = vuelo.CiudadOrigen;
            _vuelo.FechaLlegada = vuelo.FechaLlegada;
            _vuelo.FechaSalida = vuelo.FechaSalida;
            _vuelo.Id = vuelo.Id;
            _vuelo.Precio = vuelo.Precio;
            _vuelo.SillasDisponibles = vuelo.CantidadSillas;
            _vuelo.TipoVuelo = vuelo.TipoVuelo;
            return await _vueloRepository.Crear(_vuelo);
        }
        public async Task<List<IVuelosDisponibles>> BuscarVuelos(IBuscarVuelo buscarVuelo)
        {
            var vuelosDisponibles=await _vueloRepository.BuscarVuelos(buscarVuelo);
            List<IVuelosDisponibles> result = new ();

            foreach (var vuelo in vuelosDisponibles)
            {
                IVuelosDisponibles v = new VuelosDisponibles();
                v.CantidadSillas = vuelo.CantidadSillas;
                v.CiudadDestino = vuelo.CiudadDestino;
                v.CiudadOrigen = vuelo.CiudadOrigen;
                v.FechaLlegada = vuelo.FechaLlegada;
                v.FechaSalida = vuelo.FechaSalida;
                v.Id = vuelo.Id;
                v.Precio = vuelo.Precio;
                v.SillasDisponibles = vuelo.SillasDisponibles;
                v.TipoVuelo = vuelo.TipoVuelo;
                result.Add(v);
            }
            return result;
        }
        public async Task<bool> ValidarVuelo(int Id)
        {
            return await _vueloRepository.ValidarVuelo(Id);
        }
        public async Task<bool> RestarDisponibilidad(int Id, int cantidad)
        {
            return await _vueloRepository.RestarDisponibilidad(Id, cantidad);
        }
    }
}
