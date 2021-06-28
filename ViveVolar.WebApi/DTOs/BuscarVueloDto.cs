using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViveVolar.WebApi.DTOs
{
    public class BuscarVueloDto
    {
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public string Origen { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public int cantidadPasajeros { get; set; }
    }
}
