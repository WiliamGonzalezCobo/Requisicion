namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RETIROS.SOPORTES")]
    public partial class SOPORTES
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_SOPORTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_RETIRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_TIPO_SOPORTE { get; set; }

        public string RUTA_SOPORTE { get; set; }

        [StringLength(200)]
        public string NOMBRE_SOPORTE { get; set; }

        [StringLength(10)]
        public string TAMANO { get; set; }

        public bool APROBADO { get; set; }

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

        public virtual TIPO_SOPORTES TIPO_SOPORTES { get; set; }

        public virtual RETIROS RETIROS { get; set; }
    }
}
