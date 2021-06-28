using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViveVolar.WebApi.DTOs
{
    public class BuscarReservaDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string CodigoReserva { get; set; }
    }
}
