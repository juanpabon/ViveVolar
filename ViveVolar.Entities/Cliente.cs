using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Entities
{
    public class Cliente : Entity
    {
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string TipoIdentificacion { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Identificacion { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Telefono { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Direccion { get; set; }
        public Reserva Reserva { get; set; } 
    }
}
