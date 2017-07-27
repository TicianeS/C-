using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callcenter.Model
{
    class Escala
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime Data { get; set; }
        public Ausencia Ausencia { get; set; }

    }
}
