using log4net;
using REPOSITORIOS.TRAZA_LOG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTILS.Settings;

namespace MODELO_DATOS.MODELO_REQUISICION
{
    public class VALIDACION_MODEL_REQUISICION
    {
        private bool esJefe;
        private bool esController;
        private bool esBp;
        private bool esRRHH;
        private bool esUsc;
        private List<VALIDACION_ERRORES_ViewModel> listaErrores;
        private LOG_CENTRALIZADO logCentralizado = new LOG_CENTRALIZADO(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));

        public VALIDACION_MODEL_REQUISICION(bool _esJefe, bool _esController, bool _esBp, bool _esRRHH, bool _esUsc)
        {
            esJefe = _esJefe;
            esController = _esController;
            esBp = _esBp;
            esRRHH = _esRRHH;
            esUsc = _esUsc;
            listaErrores = new List<VALIDACION_ERRORES_ViewModel>();
        }

        public List<VALIDACION_ERRORES_ViewModel> ValidarModelo(REQUISICIONViewModel _modelRequisicion, int _tipoRequisicion, string _accionSubmit)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR1", "ValidarModelo");
                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqNoPresupuestada) || _tipoRequisicion.Equals(SettingsManager.CodTipoReqPresupuestada) || _tipoRequisicion.Equals(SettingsManager.CodTipoReqModificacion))
                {
                    if (esJefe || esController)
                    {
                        ValidaInfoRequisicion(_modelRequisicion);
                        ValidaAutorizacion(_modelRequisicion);
                    }
                    if (esBp)
                    {
                        ValidaInfoRequisicion(_modelRequisicion);
                        //ValidarInfoGeneral(_modelRequisicion); //Todos los campos son deshabilitados y vienen de la api
                        ValidarInfoSalarial(_modelRequisicion);
                        ValidaAutorizacion(_modelRequisicion);
                    }
                    if (esRRHH || esUsc)
                    {
                        ValidaInfoRequisicion(_modelRequisicion);
                        //ValidarInfoGeneral(_modelRequisicion); //Todos los campos son deshabilitados y vienen de la api
                        ValidarInfoSalarial(_modelRequisicion);
                        ValidaAutorizacion(_modelRequisicion);


                    }
                    //si el evento es de rechazar requisicion valida el campo
                    if (_accionSubmit.Equals("ENVIAR RESPUESTA"))
                    {
                        ValidaRechazar(_modelRequisicion);
                    }

                    ValidaAutorizacion(_modelRequisicion);


                }

                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqLicencia) || _tipoRequisicion.Equals(SettingsManager.CodTipoReqIncapacidad))
                {
                    if (esJefe)
                    {
                        ValidaInfoRequisicionLi(_modelRequisicion);
                        ValidaInfoGeneralLi(_modelRequisicion);
                        ValidaInfoSalarialLi(_modelRequisicion);

                    }
                    if (esBp)
                    {
                        //ValidaGeneralProPuestaLi(_modelRequisicion); //Todos Los Campos se deshabilitaron 
                        ValidaInfoSalarialLi(_modelRequisicion);
                        //ValidaInfoSalarialLi2(_modelRequisicion);//Todos Los Campos se deshabilitaron
                    }
                    if (esRRHH)
                    {
                        //ValidaGeneralProPuestaLi(_modelRequisicion);//Todos Los Campos se deshabilitaron
                        ValidaInfoSalarialLi(_modelRequisicion);
                        //ValidaInfoSalarialLi2(_modelRequisicion);//Todos Los Campos se deshabilitaron
                    }
                    if (esUsc)
                    {
                        //ValidaGeneralProPuestaLi(_modelRequisicion);//Todos Los Campos se deshabilitaron
                        ValidaInfoSalarialLi(_modelRequisicion);
                        //ValidaInfoSalarialLi2(_modelRequisicion);//Todos Los Campos se deshabilitaron
                    }
                    //si el evento es de rechazar requisicion valida el campo
                    if (_accionSubmit.Equals("ENVIAR RESPUESTA"))
                    {
                        ValidaRechazar(_modelRequisicion);
                    }
                    ValidaAutorizacion(_modelRequisicion);
                }



                logCentralizado.FINALIZANDO_LOG("MOD_VMR1", "ValidarModelo");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR1", "ValidarModelo", ex);
                throw ex;
            }

            return listaErrores;
        }

        #region ParcialesPresupuestadayNoPresupuestada

        private void ValidaInfoRequisicion(REQUISICIONViewModel model)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR3", "ValidaInfoRequisicion");

                validarEntero(model.COD_TIPO_NECESIDAD, "TIPO DE NECESIDAD", true);
                validarEntero(model.COD_CARGO, "CODIGO CARGO", true);
                validarString(model.NOMBRE_CARGO, "NOMBRE DEL CARGO", true);
                validarString(model.ORDEN, "ORDEN", true);
                validarEntero(model.COD_CECO, "COD CECO", true);
                validarString(model.NOMBRE_CECO, "NOMBRE CECO", true);
                validarEntero(model.COD_REQUISICION, "COD DE REQUISICION", false);
                if (model.ES_MODIFICACION)
                {
                    validarString(model.NOMBRE_EMPLEADO, "NOMBRE EMPLEADO", true);
                    validarString(model.NUMERO_DOCUMENTO_EMPLEADO, "NUMERO DE DOCUMENTO", true);
                }


                logCentralizado.FINALIZANDO_LOG("MOD_VMR3", "ValidaInfoRequisicion");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR3", "ValidaInfoRequisicion", ex);
                throw ex;
            }


        }

        private void ValidarInfoGeneral(REQUISICIONViewModel model)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR4", "ValidarInfoGeneral");
                validarEntero(model.COD_GERENCIA, "CÓDIGO GERENCIA", true);
                validarString(model.NOMBRE_GERENCIA, "NOMBRE GERENCIA", true);
                validarEntero(model.COD_TIPO_CONTRATO, "CÓDIGO TIPO CONTRATO", true);
                validarString(model.NOMBRE_TIPO_CONTRATO, "NOMBRE TIPO CONTRATO", true);
                validarString(model.JEFE_INMEDIATO, "JEFE INMEDIATO", true);
                validarEntero(model.COD_CECO, "COD CECO", true);
                validarString(model.NOMBRE_CECO, "NOMBRE CECO", true);
                validarEntero(model.COD_SOCIEDAD, "CÓDIGO SOCIEDAD", true);
                validarString(model.NOMBRE_SOCIEDAD, "NOMBRE SOCIEDAD", true);
                validarEntero(model.COD_EQUIPO_VENTAS, "CÓDIGO EQUIPO VENTAS", true);
                validarEntero(model.COD_CIUDAD_TRABAJO, "CÓDIGO CIUDAD DE TRABAJO", true);
                validarString(model.NOMBRE_CIUDAD_TRABAJO, "NOMBRE CIUDAD DE TRABAJO", true);
                validarEntero(model.COD_UBICACION_FISICA, "CÓDIGO UBICACIÓN FÍSICA", true);
                validarString(model.NOMBRE_UBICACION_FISICA, "NOMBRE UBICACIÓN FÍSICA", true);
                validarEntero(model.COD_NIVEL_RIESGO_ARL, "CÓDIGO UBICACIÓN FÍSICA", true);
                validarString(model.NIVEL_RIESGO_ARL, "NOMBRE UBICACIÓN FÍSICA", true);
                validarEntero(model.COD_CATEGORIA_ED, "CÓDIGO CATEGORÍA ED", true);
                validarString(model.NOMBRE_CATEGORIA_ED, "NOMBRE CATEGORÍA ED", true);
                validarEntero(model.COD_JORNADA_LABORAL, "CÓDIGO JORNADA LABORAL", true);
                validarString(model.NOMBRE_JORNADA_LABORAL, "NOMBRE JORNADA LABORAL", true);
                validarString(model.HORARIO_LABORAL_DESDE, "HORARIO LABORAL DESDE", true);  //El value es el mismo texto
                validarString(model.HORARIO_LABORAL_HASTA, "HORARIO LABORAL HASTA", true);  //El value es el mismo texto
                validarString(model.DIA_LABORAL_DESDE, "DÍA LABORAL DESDE", true);  //El value es el mismo texto
                validarString(model.DIA_LABORAL_HASTA, "DÍA LABORAL HASTA", true);  //El value es el mismo texto
                logCentralizado.FINALIZANDO_LOG("MOD_VMR4", "ValidarInfoGeneral");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR4", "ValidarInfoGeneral", ex);
                throw ex;
            }
        }

        private void ValidarInfoSalarial(REQUISICIONViewModel model)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR5", "ValidarInfoSalarial");
                validarDecimal(model.SALARIO_FIJO, "SALARIO FIJO", false);
                validarDecimal(model.SALARIO_VARIABLE, "SALARIO VARIABLE", false);
                validarDecimal(model.SOBREREMUNERACION, "SOBRE REMUNERACIÓN", false);
                validarDecimal(model.EXTRA_FIJA, "EXTRA FIJA", false);
                validarDecimal(model.RECARGO_NOCTURNO, "RECARGO NOCTURNO", false);
                validarDecimal(model.MEDIO_TRANSPORTE, "MEDIO TRANSPORTE", false);
                validarEntero(model.NUMERO_SALARIOS, "NÚMERO SALARIOS", false);
                validarEntero(model.MESES_GARANTIZADOS, "MESES GARANTIZADOS", false);
                validarEntero(model.COD_TIPO_SALARIO, "CÓDIGO TIPO SALARIO", true);
                validarString(model.NOMBRE_TIPO_SALARIO, "NOMBRE TIPO SALARIO", true);
                validarEntero(model.COD_MERCADO, "CÓDIGO MERCADO", true);
                validarString(model.MERCADO, "NOMBRE MERCADO", true);
                validarEntero(model.COD_CATEGORIA, "CÓDIGO CATEGORÍA", true);
                validarString(model.NOMBRE_CATEGORIA, "NOMBRE CATEGORÍA", true);
                logCentralizado.FINALIZANDO_LOG("MOD_VMR5", "ValidarInfoSalarial");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR5", "ValidarInfoSalarial", ex);
                throw ex;
            }
        }

        #endregion ParcialesPresupuestadayNoPresupuestada

        #region ParcialesComunes

        private void ValidaAutorizacion(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR2", "ValidaAutorizacion");

                validarString(modelRequisicion.OBSERVACION, "Observación", true);

                logCentralizado.FINALIZANDO_LOG("MOD_VMR2", "ValidaAutorizacion");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR2", "ValidaAutorizacion", ex);
                throw ex;
            }
        }

        private void ValidaRechazar(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR2.1", "ValidaRechazar");

                validarString(modelRequisicion.MOTIVO_RECHAZO, "MOTIVO RECHAZO", true);

                logCentralizado.FINALIZANDO_LOG("MOD_VMR2.1", "ValidaRechazar");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR2.1", "ValidaRechazar", ex);
                throw ex;
            }
        }

        #endregion ParcialesComunes

        #region validaciones

        private void validarEntero(object _obj, string _nombreCampo, bool requerido)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR6", "validarEntero");
                if (_obj != null)
                {
                    if (_obj.Equals(0) && requerido)
                    {
                        listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es requerido.", _nombreCampo) });
                    }
                    if (!int.TryParse(_obj.ToString(), out int i))
                    {
                        listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} debe ser numérico.", _nombreCampo) });
                    }
                }
                else
                {
                    listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es nulo.", _nombreCampo) });
                }
                logCentralizado.FINALIZANDO_LOG("MOD_VMR6", "validarEntero");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR6", "validarEntero", ex);
                throw ex;
            }

        }

        private void validarString(object _obj, string _nombreCampo, bool _requerido)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR7", "validarString");
                if (_obj != null)
                {
                    if (string.IsNullOrEmpty(_obj.ToString()) && _requerido)
                    {
                        listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es requerido.", _nombreCampo) });
                    }
                }
                else
                {
                    listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es nulo.", _nombreCampo) });
                }
                logCentralizado.FINALIZANDO_LOG("MOD_VMR7", "validarString");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR7", "validarString", ex);
                throw ex;
            }

        }

        private void validarDecimal(object _obj, string _nombreCampo, bool requerido)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR8", "validarDecimal");
                if (_obj != null)
                {
                    if (_obj.Equals(0M) && requerido)
                    {
                        listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es requerido.", _nombreCampo) });
                    }
                    if (!decimal.TryParse(_obj.ToString(), out decimal i))
                    {
                        listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} debe ser decimal.", _nombreCampo) });
                    }
                }
                else
                {
                    listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es nulo.", _nombreCampo) });
                }
                logCentralizado.FINALIZANDO_LOG("MOD_VMR8", "validarDecimal");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR8", "validarDecimal", ex);
                throw ex;
            }

        }


        private void validarFecha(object _obj, string _nombreCampo, bool _requerido)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR9", "validarFecha");
                if (_obj != null)
                {
                    if (string.IsNullOrEmpty(_obj.ToString()) && _requerido)
                    {
                        listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es requerido.", _nombreCampo) });
                    }
                }
                else
                {
                    listaErrores.Add(new VALIDACION_ERRORES_ViewModel { Campo = _nombreCampo, Error = string.Format("El Campo {0} es nulo.", _nombreCampo) });
                }
                logCentralizado.FINALIZANDO_LOG("MOD_VMR9", "validarFecha");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR9", "validarFecha", ex);
                throw ex;
            }

        }
        #endregion validaciones

        #region ParcialesLicenciayIncapacidad

        private void ValidaInfoRequisicionLi(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR10", "ValidaInfoRequisicionLi");
                validarEntero(modelRequisicion.COD_TIPO_DOCUMENTO, "TIPO DE DOCUMENTO", true);
                validarEntero(modelRequisicion.NUMERO_DOCUMENTO_EMPLEADO, "NÚMERO DE DOCUMENTO", true);
                validarString(modelRequisicion.NOMBRE_EMPLEADO, "NOMBRE EMPLEADO", true);
                validarFecha(modelRequisicion.FECHA_INICIO, "FECHA INICIO", true);
                validarFecha(modelRequisicion.FECHA_FIN, "FECHA FIN", true);
                logCentralizado.FINALIZANDO_LOG("MOD_VMR10", "ValidaInfoRequisicionLi");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR10", "ValidaInfoRequisicionLi", ex);
                throw ex;
            }
        }

        private void ValidaInfoGeneralLi(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR11", "ValidaInfoGeneralLi");
                validarEntero(modelRequisicion.COD_CARGO, "CÓDIGO DEL CARGO", true);
                validarString(modelRequisicion.NOMBRE_CARGO, "NOMBRE CARGO", true);
                validarEntero(modelRequisicion.COD_CECO, "CÓDIGO DEL CECO", true);
                validarString(modelRequisicion.NOMBRE_CECO, "NOMBRE CECO", true);
                logCentralizado.FINALIZANDO_LOG("MOD_VMR11", "ValidaInfoGeneralLi");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR11", "ValidaInfoGeneralLi", ex);
                throw ex;
            }
        }

        private void ValidaInfoSalarialLi(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR12", "ValidaInfoSalarialLi");
                validarDecimal(modelRequisicion.SALARIO_FIJO, "SALARIO FIJO", true);
                validarDecimal(modelRequisicion.SALARIO_VARIABLE, "SALARIO VARIABLE", false);
                validarDecimal(modelRequisicion.SOBREREMUNERACION, "SOBRE REMUNERACION", false);
                validarDecimal(modelRequisicion.EXTRA_FIJA, "EXTRA FIJA", false);
                validarDecimal(modelRequisicion.RECARGO_NOCTURNO, "RECARGO NOCTURNO", false);
                validarDecimal(modelRequisicion.MEDIO_TRANSPORTE, "MEDIO TRANSPORTE", false);
                validarEntero(modelRequisicion.NUMERO_SALARIOS, "NUMERO SALARIOS", false);
                logCentralizado.FINALIZANDO_LOG("MOD_VMR12", "ValidaInfoSalarialLi");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR12", "ValidaInfoSalarialLi", ex);
                throw ex;
            }
        }

        private void ValidaInfoSalarialLi2(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR13", "ValidaInfoSalarialLi2");
                validarString(modelRequisicion.MESES_GARANTIZADOS, "MESES GARANTIZADOS", true);
                validarEntero(modelRequisicion.COD_TIPO_SALARIO, "CÓDIGO TIPO SALARIO", true);
                validarString(modelRequisicion.NOMBRE_TIPO_SALARIO, "NOMBRE TIPO SALARIO", true);
                validarEntero(modelRequisicion.COD_MERCADO, "CÓDIGO DE MERCADO", true);
                validarString(modelRequisicion.MERCADO, "MERCADO", true);
                validarString(modelRequisicion.COD_CATEGORIA, "CÓDIGO CATEGORIA", true);
                validarString(modelRequisicion.NOMBRE_CATEGORIA, "NOMBRE CATEGORIA", true);
                logCentralizado.FINALIZANDO_LOG("MOD_VMR13", "ValidaInfoSalarialLi2");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR13", "ValidaInfoSalarialLi2", ex);
                throw ex;
            }
        }

        private void ValidaGeneralProPuestaLi(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR14", "ValidaGeneralProPuestaLi");
                validarEntero(modelRequisicion.COD_TIPO_CONTRATO, "CÓDIGO TIPO CONTRATO", true);
                validarString(modelRequisicion.NOMBRE_TIPO_CONTRATO, "NOMBRE DEL TIPO DE CONTRATO", true);
                validarString(modelRequisicion.JEFE_INMEDIATO, "JEFE INMEDIATO", true);
                validarEntero(modelRequisicion.COD_NIVEL_RIESGO_ARL, "CÓDIGO DEL NIVEL DE RIESGO", true);
                validarString(modelRequisicion.NIVEL_RIESGO_ARL, "NIVEL DE RIESGO", true);
                logCentralizado.FINALIZANDO_LOG("MOD_VMR14", "ValidaGeneralProPuestaLi");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR14", "ValidaGeneralProPuestaLi", ex);
                throw ex;
            }
        }

        #endregion ParcialesLicenciayIncapacidad
    }
}


