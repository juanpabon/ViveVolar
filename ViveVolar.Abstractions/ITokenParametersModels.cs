﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface ITokenParametersModels
    {
        string Login { get; set; }
        string PasswordHash { get; set; }
        int Id { get; set; }
    }
}
