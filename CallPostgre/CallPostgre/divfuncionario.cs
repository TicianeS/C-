//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CallPostgre
{
    using System;
    using System.Collections.Generic;
    
    public partial class divfuncionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public divfuncionario()
        {
            this.pretensoes = new HashSet<pretensoes>();
        }
    
        public int funcionario_id { get; set; }
        public int divisao_id { get; set; }
        public int supervisor_id { get; set; }
        public string cidade { get; set; }
        public Nullable<bool> ativo { get; set; }
        public string alterado { get; set; }
        public System.DateTime cadastro { get; set; }
        public int id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pretensoes> pretensoes { get; set; }
        public virtual Divisao divisoes { get; set; }
        public virtual funcionarios funcionarios { get; set; }
        public virtual funcionarios funcionarios1 { get; set; }
    }
}
