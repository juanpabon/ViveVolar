using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface ICliente
    {
        int Id { get; set; }
        string Nombre { get; set; }
        string TipoIdentificacion { get; set; }
        string Identificacion { get; set; }
        string Email { get; set; }
        string Telefono { get; set; }
        string Direccion { get; set; }
    }
}
