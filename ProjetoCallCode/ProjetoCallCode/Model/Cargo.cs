using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCallCode.Model
{
    [Table("cargos", Schema = "public")]
    class Cargo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("alterado")]
        public string Alterado { get; set; }

        [Column("cadastro")]
        public DateTime Cadastro { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
