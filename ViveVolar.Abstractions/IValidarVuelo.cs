using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IValidarVuelo
    {
        Task<bool> ValidarVuelo(int Id);
        Task<bool> RestarDisponibilidad(int Id, int cantidad);
    }
}
