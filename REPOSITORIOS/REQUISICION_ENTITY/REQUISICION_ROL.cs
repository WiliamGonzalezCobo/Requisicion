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
    
    public partial class REQUISICION_ROL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REQUISICION_ROL()
        {
            this.REQUISICION_COMENTARIO = new HashSet<REQUISICION_COMENTARIO>();
            this.REQUISICION_MENU_ROL = new HashSet<REQUISICION_MENU_ROL>();
        }
    
        public int COD_ROL { get; set; }
        public string NOMBRE { get; set; }
        public string USUARIO_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICACION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUISICION_COMENTARIO> REQUISICION_COMENTARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUISICION_MENU_ROL> REQUISICION_MENU_ROL { get; set; }
    }
}
