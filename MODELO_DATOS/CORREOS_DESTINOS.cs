namespace MODELO_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONFIGURACIONES.CORREOS_DESTINOS")]
    public partial class CORREOS_DESTINOS
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal COD_CORREO_DESTINO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD_CORREO { get; set; }

        [Required]
        [StringLength(50)]
        public string CORREO { get; set; }

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
        // martinezluir agregado
        public string COD_ASPNETUSER_JEFE { get; set; }
        public string COD_ASPNETUSER_CONTROLLER { get; set; }

        public virtual CORREOS CORREOS { get; set; }
    }
}
