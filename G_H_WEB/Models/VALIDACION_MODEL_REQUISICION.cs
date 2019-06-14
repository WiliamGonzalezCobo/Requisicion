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

        public List<VALIDACION_ERRORES_ViewModel> ValidarModelo(REQUISICIONViewModel _modelRequisicion,int _tipoRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR1", "ValidarModelo");
                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqNoPresupuestada) || _tipoRequisicion.Equals(SettingsManager.CodTipoReqPresupuestada) || _tipoRequisicion.Equals(SettingsManager.CodTipoReqModificacion)) {
                    if (esJefe)
                    {
                        ValidaInfoRequisicion(_modelRequisicion);

                    }
                    if (esController)
                    {

                    }
                    if (esBp)
                    {

                    }
                    if (esRRHH)
                    {

                    }
                    if (esUsc)
                    {


                    }
                    ValidaAutorizacion(_modelRequisicion);
                }

                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqLicencia) || _tipoRequisicion.Equals(SettingsManager.CodTipoReqIncapacidad))
                {
                    if (esJefe)
                    {
                        ValidaInfoRequisicionLi(_modelRequisicion);

                    }
                    if (esController)
                    {

                    }
                    if (esBp)
                    {

                    }
                    if (esRRHH)
                    {

                    }
                    if (esUsc)
                    {


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

        #region ParcialesLicenciayIncapacidad

        private void ValidaInfoRequisicionLi(REQUISICIONViewModel modelRequisicion)
        {
            validarEntero(modelRequisicion.COD_TIPO_DOCUMENTO, "TIPO DE DOCUMENTO", true);
            validarEntero(modelRequisicion.NUMERO_DOCUMENTO_EMPLEADO, "NÚMERO DE DOCUMENTO", true);
            validarString(modelRequisicion.NOMBRE_EMPLEADO, "NOMBRE EMPLEADO", true);
            validarFecha(modelRequisicion.FECHA_INICIO, "FECHA INICIO", true);
            validarFecha(modelRequisicion.FECHA_FIN, "FECHA FIN", true);

            throw new NotImplementedException();
        }

        private void ValidaInfoGeneralLi(REQUISICIONViewModel modelRequisicion)
        {
            validarEntero(modelRequisicion.COD_CARGO, "CÓDIGO DEL CARGO", true);
            validarString(modelRequisicion.NOMBRE_CARGO, "NOMBRE CARGO", true);
            validarEntero(modelRequisicion.COD_CECO, "CÓDIGO DEL CECO", true);
            validarString(modelRequisicion.NOMBRE_CECO, "NOMBRE CECO", true);

            throw new NotImplementedException();
        }

        private void ValidaInfoSalarialLi(REQUISICIONViewModel modelRequisicion)
        {
            validarDecimal(modelRequisicion.SALARIO_FIJO, "SALARIO FIJO", true);
            validarDecimal(modelRequisicion.SALARIO_VARIABLE, "SALARIO VARIABLE", true);
            validarDecimal(modelRequisicion.SOBREREMUNERACION, "SOBRE REMUNERACION", true);
            validarDecimal(modelRequisicion.EXTRA_FIJA, "EXTRA FIJA", true);
            validarDecimal(modelRequisicion.RECARGO_NOCTURNO, "RECARGO NOCTURNO", true);
            validarDecimal(modelRequisicion.MEDIO_TRANSPORTE, "MEDIO TRANSPORTE", true);
            validarDecimal(modelRequisicion.NUMERO_SALARIOS, "NUMERO SALARIOS", true);

            throw new NotImplementedException();
        }

        #endregion ParcialesLicenciayIncapacidad

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

        private void ValidarInfoGeneral(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR4", "ValidarInfoGeneral");

                logCentralizado.FINALIZANDO_LOG("MOD_VMR4", "ValidarInfoGeneral");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("MOD_VMR4", "ValidarInfoGeneral", ex);
                throw ex;
            }
        }

        private void ValidarInfoSalarial(REQUISICIONViewModel modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("MOD_VMR5", "ValidarInfoSalarial");

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
                    if (_obj.Equals(0) && requerido)
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
    }
}


