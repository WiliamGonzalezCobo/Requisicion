namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONFIGURACIONES.COREEOS")]
    public partial class COREEOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COREEOS()
        {
            CORREOS_DESTINOS = new HashSet<CORREOS_DESTINOS>();
            PLANTILLAS_CORREOS = new HashSet<PLANTILLAS_CORREOS>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_CORREO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_TIPO_CORREO { get; set; }

        [Required]
        [StringLength(100)]
        public string SERVIDOR_SMTP { get; set; }

        [Required]
        [StringLength(100)]
        public string CUENTA_CORREO { get; set; }

        [Required]
        [StringLength(100)]
        public string CUENTA { get; set; }

        [Required]
        [StringLength(100)]
        public string SALTO { get; set; }

        [Required]
        [StringLength(100)]
        public string IV { get; set; }

        [Required]
        [StringLength(100)]
        public string CONTRASENA { get; set; }

        public bool ES_HTML { get; set; }

        public bool USA_SSL { get; set; }

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

        public virtual TIPOS_CORREOS TIPOS_CORREOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CORREOS_DESTINOS> CORREOS_DESTINOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLANTILLAS_CORREOS> PLANTILLAS_CORREOS { get; set; }
    }
}
