using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface IBuscarVuelo
    {
        DateTime FechaInicio { get; set; }
        DateTime FechaFin { get; set; }
        string Origen { get; set; }
        string Destino { get; set; }
        int cantidadPasajeros { get; set; }
    }
}
