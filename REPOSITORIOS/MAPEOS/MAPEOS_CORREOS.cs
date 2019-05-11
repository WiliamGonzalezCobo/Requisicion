using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO_DATOS;
using System.Data.Entity.ModelConfiguration;

namespace REPOSITORIOS.MAPEOS
{
    class MAPEOS_CORREOS:EntityTypeConfiguration<CORREOS>
    {
       public MAPEOS_CORREOS()
        {
            this.MapToStoredProcedures(sp =>
            sp.Insert(i => i.HasName("CONFIGURACIONES.CREAR_CORREO")));
        }
    }
}
