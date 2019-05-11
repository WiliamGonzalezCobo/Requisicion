namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONFIGURACIONES.TIPOS_CORREOS")]
    public partial class TIPOS_CORREOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPOS_CORREOS()
        {
            CORREOS = new HashSet<CORREOS>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_TIPO_CORREO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTADO { get; set; }

        [Required]
        [StringLength(128)]
        public string COD_USUARIO_CREA { get; set; }

        public DateTime FECHA_CREA { get; set; }

        [Required]
        [StringLength(128)]
        public string COD_USUARIO_MODIFICA { get; set; }

        public DateTime FECHA_MODIFICA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CORREOS> CORREOS { get; set; }
    }
}
