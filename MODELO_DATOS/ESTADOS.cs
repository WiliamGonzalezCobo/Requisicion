namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RETIROS.ESTADOS")]
    public partial class ESTADOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADOS()
        {
            RETIROS = new HashSet<RETIROS>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_ESTADO_RETIRO { get; set; }

        [Required]
        [StringLength(100)]
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
        public virtual ICollection<RETIROS> RETIROS { get; set; }
    }
}
