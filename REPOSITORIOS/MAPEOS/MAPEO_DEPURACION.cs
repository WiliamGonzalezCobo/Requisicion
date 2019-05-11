using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO_DATOS;

namespace REPOSITORIOS.MAPEOS
{
    class MAPEO_DEPURACION : EntityTypeConfiguration<DEPURARCION>
    {
        public MAPEO_DEPURACION()
        {

            this.MapToStoredProcedures(sp =>
               sp.Insert(i => i.HasName("AUDITORIA.GUARDA_DEPURARCION")));
        }

 
    }
}
