namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUDITORIAS.DEPURARCION")]
    public partial class DEPURARCION
    {
        [Key]
        [Column(Order = 0)]
        public int COD_ERROR { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime FECHA { get; set; }

        [StringLength(50)]
        public string NOMBRE_CLASE { get; set; }

        [StringLength(50)]
        public string NOMBRE_METODO { get; set; }

        [StringLength(20)]
        public string CODIGO_ERROR { get; set; }

        public string DETALLE { get; set; }
    }
}
