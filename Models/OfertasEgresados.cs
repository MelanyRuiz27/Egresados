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
    
    public partial class OfertasEgresados
    {
        public int Id { get; set; }
        public Nullable<int> IdOfertaLaboral { get; set; }
        public Nullable<int> IdEgresado { get; set; }
    
        public virtual Egresados Egresados { get; set; }
        public virtual OfertasLaborales OfertasLaborales { get; set; }
    }
}
