using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViveVolar.WebApi.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double PrecioReserva { get; set; }
        [Required]
        public int VueloId { get; set; }
        [Required]
        public ClienteDTO CLiente { get; set; }
    }
    public class ClienteDTO
    {
        [Required]
        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
