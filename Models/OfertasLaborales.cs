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
    
    public partial class OfertasLaborales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfertasLaborales()
        {
            this.OfertasEgresados = new HashSet<OfertasEgresados>();
        }
    
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public string Actividades { get; set; }
        public string Perfil { get; set; }
        public Nullable<decimal> Salario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfertasEgresados> OfertasEgresados { get; set; }
    }
}
