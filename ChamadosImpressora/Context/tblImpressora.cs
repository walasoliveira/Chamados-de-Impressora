//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChamadosImpressora.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblImpressora
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblImpressora()
        {
            this.tblLocacao = new HashSet<tblLocacao>();
            this.tblRegistroChamados = new HashSet<tblRegistroChamados>();
        }
    
        public int ID_Impressora { get; set; }
        public string Modelo { get; set; }
        public Nullable<System.DateTime> DataDeCadastro { get; set; }
        public Nullable<System.DateTime> DataUltimaAlteracao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblLocacao> tblLocacao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRegistroChamados> tblRegistroChamados { get; set; }
    }
}
