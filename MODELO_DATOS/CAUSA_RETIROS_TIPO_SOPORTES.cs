namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REFERENCIAS.CAUSA_RETIROS_TIPO_SOPORTES")]
    public partial class CAUSA_RETIROS_TIPO_SOPORTES
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_CAUSA_RETIRO_TIPO_SOPORTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_CAUSA_RETIRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_TIPO_SOPORTE { get; set; }

        public bool REQUERIDO { get; set; }

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
    }
}
