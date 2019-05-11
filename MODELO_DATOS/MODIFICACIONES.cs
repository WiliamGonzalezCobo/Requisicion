namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUDITORIAS.MODIFICACIONES")]
    public partial class MODIFICACIONES
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_AUDITORIA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_TABLA { get; set; }

        [Required]
        [StringLength(50)]
        public string TABLA { get; set; }

        [Required]
        [StringLength(50)]
        public string COLUMNA { get; set; }

        [Required]
        public string DATO_ANTERIOR { get; set; }

        [Required]
        public string DATO_NUEVO { get; set; }

        [Required]
        [StringLength(126)]
        public string COD_USUARIO_MODIFICO { get; set; }

        public DateTime FECHA_MODIFICACION { get; set; }
    }
}
