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
    
    public partial class Soportes
    {
        public int Id { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<int> IdEstadoSoportes { get; set; }
        public string Soporte { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual Personas Personas { get; set; }
    }
}
