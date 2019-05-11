namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RETIROS.RETIROS")]
    public partial class RETIROS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RETIROS()
        {
            SOPORTES = new HashSet<SOPORTES>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_RETIRO { get; set; }

        [Required]
        [StringLength(50)]
        public string NUMERO_DOCUMENTO { get; set; }

        [Required]
        [StringLength(200)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string USUARIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_CARGO { get; set; }

        [Required]
        [StringLength(80)]
        public string NOMBRE_CARGO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_CAUSA_RETIRO { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_CAUSA_RETIRO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_RETIRO { get; set; }

        public bool GENERA_VACANTE { get; set; }

        [Required]
        public string COMENTARIOS { get; set; }

        public bool APROBADO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_ESTADO_RETIRO { get; set; }

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

        public virtual ESTADOS ESTADOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOPORTES> SOPORTES { get; set; }
    }
}
