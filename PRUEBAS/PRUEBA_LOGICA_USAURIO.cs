using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PRUEBAS
{
	[TestClass]
	public class PRUEBA_LOGICA_USAURIO
	{
		[TestMethod]
		public void AUTENTICAR()
		{
			LOGICA.SEGURIDAD.USUARIO SBP = new LOGICA.SEGURIDAD.USUARIO();

			MODELO_DATOS.MODELOS_SEGURIDAD.APPLICATIONUSER RESULTADO = new MODELO_DATOS.MODELOS_SEGURIDAD.APPLICATIONUSER();
			//RESULTADO = await SBP.AUTENTICAR("CESNUN", "425353");

			RESULTADO = Task.Run(() => SBP.AUTENTICAR("CESNUN", "8513.ARGOS")).Result;

			Assert.AreEqual("CESNUN", RESULTADO.UserName);
		}
	}
}
