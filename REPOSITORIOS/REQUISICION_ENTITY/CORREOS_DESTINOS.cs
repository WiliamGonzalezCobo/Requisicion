//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace REPOSITORIOS.REQUISICION_ENTITY
{
    using System;
    using System.Collections.Generic;
    
    public partial class CORREOS_DESTINOS
    {
        public decimal COD_CORREO_DESTINO { get; set; }
        public decimal COD_CORREO { get; set; }
        public string CORREO { get; set; }
        public decimal ESTADO { get; set; }
        public string COD_USUARIO_CREA { get; set; }
        public System.DateTime FECHA_CREA { get; set; }
        public string COD_USUARIO_MODIFICA { get; set; }
        public System.DateTime FECHA_MODIFICA { get; set; }
    
        public virtual CORREOS CORREOS { get; set; }
    }
}