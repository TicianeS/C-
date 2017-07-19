using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callcenter.Model
{
    class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Funcionario Funcionario { get; set; }
        public string Tipo { get; set; }
    }
}
