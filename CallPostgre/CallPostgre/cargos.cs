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
    
    public partial class cargos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cargos()
        {
            this.funcionarios = new HashSet<funcionarios>();
            this.vagas = new HashSet<vagas>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
        public string alterado { get; set; }
        public System.DateTime cadastro { get; set; }
        public Nullable<bool> ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcionarios> funcionarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vagas> vagas { get; set; }
    }
}
