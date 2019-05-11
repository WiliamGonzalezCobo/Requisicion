using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAS
{
	static public class CONFIGURACIONES
	{
		static public string CONEXION_REPOSITORIO()
		{
			return @"data source=bronte;initial catalog=GESTION_HUMANA;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
		}

	}
}
