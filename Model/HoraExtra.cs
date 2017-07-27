using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callcenter.Model
{
    class HoraExtra
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horas { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

    }
}
