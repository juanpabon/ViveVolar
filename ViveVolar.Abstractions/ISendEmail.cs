using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveVolar.Abstractions
{
    public interface ISendEmail
    {
        bool Send(string To, string Subject, string Mensaje, bool IsBodyHtml);
    }
}
