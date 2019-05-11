using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO_DATOS;

namespace REPOSITORIOS.MAPEOS
{
     public  class MAPEOS_SOPORTES:EntityTypeConfiguration<SOPORTES>
    {
        public MAPEOS_SOPORTES()
        {
            this.MapToStoredProcedures(sp =>
               sp.Update(u => u.HasName("RETIROS.ACTUALIZAR_SOPORTE")));

            this.MapToStoredProcedures(sp =>
               sp.Insert(i => i.HasName("RETIROS.CREAR_SOPORTE")));
        }
    }
}
