//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba_doublevpartners_ENL.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public Nullable<long> Identificador { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public Nullable<System.DateTime> Fecha_de_creacion { get; set; }
    
        public virtual Personas Personas { get; set; }
    }
}
