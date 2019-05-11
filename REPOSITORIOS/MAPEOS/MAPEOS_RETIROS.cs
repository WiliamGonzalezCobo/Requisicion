using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO_DATOS;

namespace REPOSITORIOS.MAPEOS
{
    class MAPEOS_RETIROS:EntityTypeConfiguration<RETIROS>
    {
        public MAPEOS_RETIROS()
        {
            this.MapToStoredProcedures(sp =>
               sp.Update(u => u.HasName("RETIROS.ACTUALIZAR_RETIRO")));
 
            this.MapToStoredProcedures(sp =>
               sp.Delete(d => d.HasName("RETIROS.ELIMINAR_RETIRO")));

            this.MapToStoredProcedures(sp =>
               sp.Insert(i => i.HasName("RETIROS.CREAR_RETIRO")));
        }
    }
}
