using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Request
{
    public class BuscarVueloModel : IBuscarVuelo
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int cantidadPasajeros { get; set; }
    }
}
