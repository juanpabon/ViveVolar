using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Entities
{
    public class Reserva:Entity
    {
        [Required]
        public DateTime FechaReserva { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Estado { get; set; }
        [Required]
        public double PrecioReserva { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string CodigoReserva { get; set; }
        [Required]
        public DateTime FechaPago { get; set; }
        [Required]
        public int VueloId { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public Vuelo Vuelo { get; set; }
        public Cliente Cliente { get; set; }
    }
}
