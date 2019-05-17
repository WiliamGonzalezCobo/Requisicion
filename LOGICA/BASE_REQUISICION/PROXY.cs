using MODELO_DATOS.MODELO_REQUISICION.LISTAS_API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UTILS.Settings;

namespace LOGICA.LOGICA_REQUISICION
{
   public class PROXY{
      string  urlApi = SettingsManager.Urlapi;

        public List<LIST_CARGO> CONSULTAR_CARGOS_API(){
            HttpStatusCode status;
            List<LIST_CARGO> respuesta = new BASE_PROXY(urlApi + "CARGOS").Get<List<LIST_CARGO>>(out status, null);
            return respuesta;
        }
        public List<CENTRO_TRABAJO> CONSULTAR_CECO_API() {
            HttpStatusCode status;
            List<CENTRO_TRABAJO> respuesta = new BASE_PROXY(urlApi + "CENTROS_COSTO").Get<List<CENTRO_TRABAJO>>(out status, null);
            return respuesta;
        }
        public List<GERENCIA> CONSULTAR_GERENCIAS_API() {
            HttpStatusCode status;
            List<GERENCIA> respuesta = new BASE_PROXY(urlApi + "GERENCIAS").Get<List<GERENCIA>>(out status, null);
            return respuesta;
        }
        public List<TIPO_CONTRATO> CONSULTAR_CONTRATO_API(){
            HttpStatusCode status;
            List<TIPO_CONTRATO> respuesta = new BASE_PROXY(urlApi + "TIPOS_CONTRATO").Get<List<TIPO_CONTRATO>>(out status, null);
            return respuesta;
        }
        public List<SOCIEDAD> CONSULTAR_SOCIEDAD_API() {
            HttpStatusCode status;
            List<SOCIEDAD> respuesta = new BASE_PROXY(urlApi + "SOCIEDADES").Get<List<SOCIEDAD>>(out status, null);
            return respuesta;
        }
        public List<EQUIPO_VENTA> CONSULTAR_EQUIPOS_VENTAS_API(){
            HttpStatusCode status;
            List<EQUIPO_VENTA> respuesta = new BASE_PROXY(urlApi + "EQUIPOS_VENTA").Get<List<EQUIPO_VENTA>>(out status, null);
            return respuesta;
        }
        public List<CIUDAD> CONSULTAR_CIUDADES_TRABAJO_API(){
            HttpStatusCode status;
            List<CIUDAD> respuesta = new BASE_PROXY(urlApi + "CIUDADES").Get<List<CIUDAD>>(out status, null);
            return respuesta;
        }
        public List<UBICACION_FISICA> CONSULTAR_UBICACIONES_FISICAS_API(){
            HttpStatusCode status;
            List<UBICACION_FISICA> respuesta = new BASE_PROXY(urlApi + "UBICACIONES_FISICA").Get<List<UBICACION_FISICA>>(out status, null);
            return respuesta;
        }
        public List<NIVEL_RIESGO> CONSULTAR_RIESGOS_ARL_API(){
            HttpStatusCode status;
            List<NIVEL_RIESGO> respuesta = new BASE_PROXY(urlApi + "NIVELES_RIESGO").Get<List<NIVEL_RIESGO>>(out status, null);
            return respuesta;
        }
        public List<CATEGORIA_EVALUACION_DESEMPENO> CONSULTAR_CATEGORIAS_ED_API(){
            HttpStatusCode status;
            List<CATEGORIA_EVALUACION_DESEMPENO> respuesta = new BASE_PROXY(urlApi + "CATEGORIAS_EVALUACION_DESEMPENO").Get<List<CATEGORIA_EVALUACION_DESEMPENO>>(out status, null);
            return respuesta;
        }
        public List<JORNADA_TRABAJO> CONSULTAR_JORNADAS_LABORALES_API(){
            HttpStatusCode status;
            List<JORNADA_TRABAJO> respuesta = new BASE_PROXY(urlApi + "JORNADAS_TRABAJO").Get<List<JORNADA_TRABAJO>>(out status, null);
            return respuesta;
        }
        public List<TIPO_SALARIO> CONSULTAR_TIPOS_SALARIOS_API(){
            HttpStatusCode status;
            List<TIPO_SALARIO> respuesta = new BASE_PROXY(urlApi + "TIPOS_SALARIO").Get<List<TIPO_SALARIO>>(out status, null);
            return respuesta;
        }
        public List<CATEGORIA_SALARIAL> CONSULTAR_CATEGORIAS_API(){
            HttpStatusCode status;
            List<CATEGORIA_SALARIAL> respuesta = new BASE_PROXY(urlApi + "CATEGORIAS_SALARIAL").Get<List<CATEGORIA_SALARIAL>>(out status, null);
            return respuesta;
        }
        public List<DIA_LABORAL> CONSULTAR_DIAS_LABORALES_API(){
            HttpStatusCode status;
            List<DIA_LABORAL> respuesta = new BASE_PROXY(urlApi + "DIAS_LABORAL").Get<List<DIA_LABORAL>>(out status, null);
            return respuesta;
        }
        public List<HORARIO_TRABAJO> CONSULTAR_HORARIOS_LABORALES_API() {
            HttpStatusCode status;
            List<HORARIO_TRABAJO> respuesta = new BASE_PROXY(urlApi + "HORARIOS_TRABAJO").Get<List<HORARIO_TRABAJO>>(out status, null);
            return respuesta;
        }

    }


}
