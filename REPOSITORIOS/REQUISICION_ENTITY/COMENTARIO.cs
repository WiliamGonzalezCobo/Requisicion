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
    
    public partial class COMENTARIO
    {
        public int COD_COMENTARIO { get; set; }
        public Nullable<int> COD_REQUISICION { get; set; }
        public Nullable<int> COD_ESTADO_REQUISICION { get; set; }
        public string COMENTARIO_AUTORIZACION { get; set; }
        public string OBSERVACIONES { get; set; }
        public Nullable<int> COD_ROL { get; set; }
        public Nullable<int> COD_USUARIO { get; set; }
        public string USARIO_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
    
        public virtual REQUISICION REQUISICION { get; set; }
        public virtual ROL ROL { get; set; }
    }
}
