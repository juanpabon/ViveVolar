using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IVueloApplication : IValidarVuelo
    {
        Task<bool> Crear(IVuelo vuelo);
        Task<List<IVuelosDisponibles>> BuscarVuelos(IBuscarVuelo buscarVuelo);
    }
}
