using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Domain.Services;

namespace ViveVolar.Application
{
     public class VueloApplication : IVueloApplication
    {
        private IVueloService _vueloServicio;
        public VueloApplication(IVueloService vueloServicio)
        {
            _vueloServicio = vueloServicio;

        }
        public async Task<bool> Crear(IVuelo vuelo)
        {
            return await _vueloServicio.Crear(vuelo);
        }

        public async Task<List<IVuelosDisponibles>> BuscarVuelos(IBuscarVuelo buscarVuelo)
        {
            return await _vueloServicio.BuscarVuelos(buscarVuelo);
        }
        public async Task<bool> ValidarVuelo(int Id)
        {
            return await _vueloServicio.ValidarVuelo(Id);
        }

        public async Task<bool> RestarDisponibilidad(int Id, int cantidad)
        {
            return await _vueloServicio.RestarDisponibilidad(Id,cantidad);
        }
    }
}
