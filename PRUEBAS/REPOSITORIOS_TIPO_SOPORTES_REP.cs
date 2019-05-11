using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using REPOSITORIOS;

namespace PRUEBAS
{
	[TestClass]
	public class REPOSITORIOS_TIPO_SOPORTES_REP
	{
		
		[TestMethod]
		public void CONSULTA_TIPO_RETIRO()
		{
			ITIPO_SOPORTES_REP SBP = new REPOSITORIOS.TIPO_SOPORTES_REP(new CONTEXTO(CONFIGURACIONES.CONEXION_REPOSITORIO()));
			IEnumerable<MODELO_DATOS.TIPO_SOPORTES> RESULTADO  = SBP.CONSULTA_TIPO_RETIRO(1);
			int CANTIDAD = 0;
			foreach (MODELO_DATOS.TIPO_SOPORTES TIPO_SOPORTE in RESULTADO)
			{
				CANTIDAD = CANTIDAD + 1;
			}
			Assert.AreEqual(3, CANTIDAD);
		}
	}
}
