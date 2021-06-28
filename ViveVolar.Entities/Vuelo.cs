using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ViveVolar.Abstractions;

namespace ViveVolar.Entities
{
    public class Vuelo : Entity
    {
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        public DateTime FechaLlegada { get; set; }
        [Required]
        public int CantidadSillas { get; set; }
        [Required]
        public int SillasDisponibles { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CiudadOrigen { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CiudadDestino { get; set; }
        [Required]
        public double Precio { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string TipoVuelo { get; set; }
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
        
    }
}
