using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Domain.Models
{
    public class TokenParametersModels : ITokenParametersModels
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int Id { get; set; }
    }
}
