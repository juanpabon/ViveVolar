using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Entities
{
    public class User : Entity
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Login { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Sal { get; set; }
    }
}
