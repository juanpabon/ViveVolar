using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViveVolar.WebApi.DTOs
{
    public class VueloDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        public DateTime FechaLlegada { get; set; }
        [Required]
        public int CantidadSillas { get; set; }
        [Required]
        public string CiudadOrigen { get; set; }
        [Required]
        public string CiudadDestino { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public string TipoVuelo { get; set; }
    }
}
