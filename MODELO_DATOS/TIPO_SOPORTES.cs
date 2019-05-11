namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REFERENCIAS.TIPO_SOPORTES")]
    public partial class TIPO_SOPORTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_SOPORTES()
        {
            CAUSA_RETIROS_TIPO_SOPORTES = new HashSet<CAUSA_RETIROS_TIPO_SOPORTES>();
            SOPORTES = new HashSet<SOPORTES>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_TIPO_SOPORTE { get; set; }

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
        public virtual ICollection<CAUSA_RETIROS_TIPO_SOPORTES> CAUSA_RETIROS_TIPO_SOPORTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOPORTES> SOPORTES { get; set; }
    }
}
