using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IVueloService
    {
        Task<bool> Crear(IVuelo vuelo);
        Task<List<IVuelosDisponibles>> BuscarVuelos(IBuscarVuelo buscarVuelo);
        Task<bool> ValidarVuelo(int Id);
        Task<bool> RestarDisponibilidad(int Id, int cantidad);
    }
}
