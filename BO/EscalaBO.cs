using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Callcenter.View;
using Callcenter.Model;
using Callcenter.DAO;

namespace Callcenter.BO
{
    class EscalaBO
    {
        public static string CalcularPercentualEscala(int totalFunc, int totalEsc)
        {  
            return ((float)((float)totalEsc / (float)totalFunc) * 100).ToString();
        }
    }
}
