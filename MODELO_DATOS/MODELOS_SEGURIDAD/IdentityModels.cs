using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO_DATOS.MODELOS_SEGURIDAD
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class APPLICATIONUSER : IdentityUser
	{
	}

	public class ApplicationDbContext : IdentityDbContext<APPLICATIONUSER>
	{
		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}


		//public ApplicationDbContext()
		//: base("data source=bronte;initial catalog=GESTION_HUMANA;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
		//{
		//}
	}
}
