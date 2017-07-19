using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callcenter.Model
{
    class Departamento
    {
        [Key] public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public Funcionario Supervisor { get; set; }
        public Cargo Cargo { get; set; }
        public DateTime Horario { get; set; }

    }
}
