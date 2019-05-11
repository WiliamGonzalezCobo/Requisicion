using MODELO_DATOS;
using REPOSITORIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace prueba_api.Controllers
{
    public class RETIROSController : ApiController
    {
        private IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());
        public List<RETIROS> Retiro = new List<RETIROS>();
        public IHttpActionResult Get()
        {
            Retiro = REPOSITORIO.CONSULTAR();
            return Ok(Retiro.ToList());

        }


    }
}
