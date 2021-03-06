//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EgresadosU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Programas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Programas()
        {
            this.Egresados = new HashSet<Egresados>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdInstitucion { get; set; }
        public Nullable<int> IdNivelFormacion { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Snies { get; set; }
        public Nullable<int> Semestres { get; set; }
        public Nullable<int> Creditos { get; set; }
    
        public virtual Instituciones Instituciones { get; set; }
        public virtual NivelesFormación NivelesFormación { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egresados> Egresados { get; set; }
    }
}
