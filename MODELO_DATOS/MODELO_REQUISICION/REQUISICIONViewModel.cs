using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MODELO_DATOS.MODELO_REQUISICION
{
    public class REQUISICIONViewModel
    {
   
        /// <summary>
        /// codigo unico de la Requisición
        /// </summary>
        public int COD_REQUISICION { get; set; }

        /// <summary>
        /// id de la necesidad,(martinezluir) viene desde la base de datos por eso no se guarda el value
        /// </summary>
        [Required(ErrorMessage = "Tipo necesidad es requerido")]
        public int COD_TIPO_NECESIDAD { get; set; }
        [DisplayName("Tipo Necesidad")]
        public List<SelectListItem> LIST_NOMBRE_TIPO_NECESIDAD { get; set; }

        /// <summary>
        /// id del cargo
        /// </summary>
        [Required(ErrorMessage = "Nombre del cargo es requerido")]
        public int COD_CARGO { get; set; }
        [DisplayName("Cargo")]
        public List<SelectListItem> LIST_NOMBRE_CARGO { get; set; }
        [DisplayName("Cargo")]
        public string NOMBRE_CARGO { get; set; }

        /// <summary>
        /// texto orden
        /// </summary>
        [Required(ErrorMessage = "Orden es requerido")]
        [DisplayName("Orden")]
        public string ORDEN { get; set; }

        /// <summary>
        /// codigo del tipo de la Requisición,(martinezluir)  no se mapea porque es de el filtro
        /// </summary>
        [Required]
        public int COD_TIPO_REQUISICION { get; set; }
        [DisplayName("Tipo Requisición")]
        public string NOMBRE_TIPO_REQUISICION { get; set; }
        public List<SelectListItem> LIST_NOMBRE_TIPO_REQUISICION { get; set; }

        /// <summary>
        /// cod tipo de documento,(martinezluir)  el valor no se guarda en base de datos
        /// </summary>
        [Required(ErrorMessage = "Tipo de Documento es requerido")]
        public int? COD_TIPO_DOCUMENTO { get; set; }
        [DisplayName("Tipo Documento")]
        public string NOMBRE_TIPO_DOCUMENTO { get; set; }
        [DisplayName("Tipo Documento")]
        public List<SelectListItem> LIST_TIPO_DOCUMENTO { get; set; }

        /// <summary>
        /// Numero de identificacion del empleado
        /// </summary>
        [DisplayName("Documento Empleado")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar un numero de documento")]
        [Required(ErrorMessage = "Numero del documento es requerido")]
        public string NUMERO_DOCUMENTO_EMPLEADO { get; set; }

        /// <summary>
        /// nombre completo del empleado
        /// </summary>
        [DisplayName("Nombre Empleado")]
        [DataType(DataType.Text, ErrorMessage = "El numbre del empleado debe ser solo texto")]
        [Required(ErrorMessage = "Nombre del empleado es requerido")]
        public string NOMBRE_EMPLEADO { get; set; }

        /// <summary>
        /// login del empleado
        /// </summary>
        public string LOGIN_EMPLEADO { get; set; }

        /// <summary>
        /// campo para fecha con validacion
        /// </summary>
        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Text, ErrorMessage = "El campo Fecha Inicio tiene un formato incorrecto")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_INICIO { get; set; }

        /// <summary>
        /// campo para fecha con validacion
        /// </summary>
        [DisplayName("Fecha Fin")]
        [DataType(DataType.Text, ErrorMessage = "El campo Fecha Fin tiene un formato incorrecto")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_FIN { get; set; }

        /// <summary>
        /// indica si se esta modificando la Requisición
        /// </summary>
        [Required]
        [DisplayName("Es Modificación")]
        public Boolean ES_MODIFICACION { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "La Observación es requerida")]
        [DisplayName("Observación")]
        public string OBSERVACION { get; set; }

        /// <summary>
        /// contiene los comentarios concatenados
        /// </summary>
        [DisplayName("Observaciones")]
        public string OBSERVACIONES { get; set; }

        /// <summary>
        ///  OBSERVACION DE CREACION
        /// </summary>
        [Required(ErrorMessage = "La Observación es requerida")]
        [DisplayName("Observación")]
        public string OBSERVACION_CREACION { get; set; }

        /// <summary>
        /// COD ESTADO DE LA Requisición (martinezluir) no se una el text en la base de datos
        /// </summary>
        public int COD_ESTADO_REQUISICION { get; set; }
        [DisplayName("Estado")]
        public string NOMBRE_ESTADO_REQUISICION { get; set; }
        [Required(ErrorMessage = "Nombre del estado es requerido")]
        [DisplayName("Estado")]
        public List<SelectListItem> LIST_NOMBRE_ESTADO_REQUISICION { get; set; }

        /// <summary>
        /// USUARIO QUE CREA LA Requisición
        /// </summary>
        [Required]
        [DisplayName("Creado Por")]
        public string USUARIO_CREACION { get; set; }

        /// <summary>
        /// EMAIL DEL USUARIO QUE CREA LA Requisición
        /// </summary>
        public string EMAIL_USUARIO_CREACION { get; set; }

        /// <summary>
        /// FECHA DE CREACION O SOLICITUD
        /// </summary>
        [Required]
        [DisplayName("Fecha de Solicitud")]
        public string FECHA_CREACION { get; set; }

        /// <summary>
        /// USUARIO QUE MODIFICA LA Requisición
        /// </summary>
        public string USUARIO_MODIFICACION { get; set; }

        /// <summary>
        /// FECHA DE MODIFICACION
        /// </summary>
        public DateTime FECHA_MODIFICACION { get; set; }

        /// <summary>
        /// CODIGO DATOS GENERALES
        /// </summary>
        public int COD_DATOS_GENERALES { get; set; }

        /// <summary>
        /// COD DE GERENCIA
        /// </summary>
        [Required(ErrorMessage = "La Gerencia es requerida")]
        public int COD_GERENCIA { get; set; }
        [DisplayName("Gerencia")]
        public List<SelectListItem> LIST_NOMBRE_GERENCIA { get; set; }
        public string NOMBRE_GERENCIA { get; set; }

        /// <summary>
        /// CODIGO TIPO DE CONTRATO
        /// </summary>
        [Required(ErrorMessage = "El contrato es requerido")]
        public int COD_TIPO_CONTRATO { get; set; }
        [DisplayName("Tipo Contrato")]
        public List<SelectListItem> LIST_NOMBRE_TIPO_CONTRATO { get; set; }
        public string NOMBRE_TIPO_CONTRATO { get; set; }
        /// <summary>
        /// NOMBRE JEFE INMEDIATO
        /// </summary>
        [DisplayName("Jefe Inmediato"), StringLength(100)]
        [Required(ErrorMessage = "El Jefe Inmediato es requerido")]
        public string JEFE_INMEDIATO { get; set; }

        /// <summary>
        /// CODIGO DE CENTRO DE COSTO
        /// </summary>
        [DisplayName("Ceco")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo permite números")]
        public int COD_CECO { get; set; }
        [Required(ErrorMessage = "Centro de costo es requerido")]
        [DisplayName("CeCo")]
        public List<SelectListItem> LIST_NOMBRE_CECO { get; set; }
        public string NOMBRE_CECO { get; set; }

        /// <summary>
        /// COD DE SOCIEDAD
        /// </summary>
        [Required(ErrorMessage = "Sociedad es requerida")]
        public int COD_SOCIEDAD { get; set; }
        [DisplayName("Sociedad")]
        public List<SelectListItem> LIST_NOMBRE_SOCIEDAD { get; set; }
        public string NOMBRE_SOCIEDAD { get; set; }
        /// <summary>
        /// CODIGO DE EQUIPO DE VENTAS
        /// </summary>
        [Required(ErrorMessage = "Equipo de ventas es requerido")]
        public int COD_EQUIPO_VENTAS { get; set; }
        [DisplayName("Equipo de Ventas")]
        public List<SelectListItem> LIST_NOMBRE_EQIPO_VENTAS { get; set; }
        public string NOMBRE_EQIPO_VENTAS { get; set; }

        /// <summary>
        /// CODIGO CIUDAD DE TRABAJO
        /// </summary>
        [Required(ErrorMessage = "Ciudad trabajo es requerida")]
        public int COD_CIUDAD_TRABAJO { get; set; }
        [DisplayName("Ciudad Trabajo")]
        public List<SelectListItem> LIST_NOMBRE_CIUDAD_TRABAJO { get; set; }
        public string NOMBRE_CIUDAD_TRABAJO { get; set; }

        /// <summary>
        /// COD DANE CIUDAD DE TRABAJO
        /// </summary>
        public int COD_DANE_CIUDAD_TRABAJO { get; set; }

        /// <summary>
        /// CODIGO UBICACION FISICA
        /// </summary>
        [Required(ErrorMessage = "Ubicación Física es requerida")]
        public int COD_UBICACION_FISICA { get; set; }
        [DisplayName("Ubicación Física")]
        public List<SelectListItem> LIST_NOMBRE_UBICACION_FISICA { get; set; }
        [DisplayName("Ubicación Física")]
        public string NOMBRE_UBICACION_FISICA { get; set; }

        /// <summary>
        /// CODIGO NIVEL DE RIESGO ARL
        /// </summary>
        [Required(ErrorMessage = "Nivel Riesgo ARL es requerida")]
        public int COD_NIVEL_RIESGO_ARL { get; set; }
        [DisplayName("Nivel Riesgo ARL")]
        public List<SelectListItem> LIST_NIVEL_RIESGO_ARL { get; set; }
        public string NIVEL_RIESGO_ARL { get; set; }
        /// <summary>
        /// CODIGO Categoría ED
        /// </summary>
        [Required(ErrorMessage = "Categoría ED es requerida")]
        public int COD_CATEGORIA_ED { get; set; }
        [DisplayName("Categoría ED*")]
        public List<SelectListItem> LIST_NOMBRE_CATEGORIA_ED { get; set; }
        public string NOMBRE_CATEGORIA_ED { get; set; }
        /// <summary>
        /// CARGO Crítico TRUE O FALSE
        /// </summary>
        [DisplayName("Cargo Crítico")]
        public bool CARGO_CRITICO { get; set; }

        /// <summary>
        /// COD JORNADA LABORAL
        /// </summary>
        [Required(ErrorMessage = "Jornada laboral es requerida")]
        public int COD_JORNADA_LABORAL { get; set; }
        [DisplayName("Jornada laboral")]
        public List<SelectListItem> LIST_NOMBRE_JORNADA_LABORAL { get; set; }
        [DisplayName("Jornada laboral")]
        public string NOMBRE_JORNADA_LABORAL { get; set; }

        /// <summary>
        /// fecha desde de horario laboral
        /// </summary>
        public int COD_HORARIO_LABORAL_DESDE { get; set; }
        [DisplayName("Jornada laboral")]
        public List<SelectListItem> LIST_HORARIO_LABORAL_DESDE { get; set; }
        [DisplayName("desde"), StringLength(50)]
        [Required(ErrorMessage = "Horario laboral desde es requerido")]
        public string HORARIO_LABORAL_DESDE { get; set; }

        /// <summary>
        /// fecha hasta de horario laboral
        /// </summary>
        public int COD_HORARIO_LABORAL_HASTA { get; set; }
        [DisplayName("Jornada laboral")]
        public List<SelectListItem> LIST_HORARIO_LABORAL_HASTA { get; set; }
        [DisplayName("hasta"), StringLength(50)]
        [Required(ErrorMessage = "Horario laboral hasta es requerido")]
        public string HORARIO_LABORAL_HASTA { get; set; }

        /// <summary>
        /// cod dia laboral desde
        /// </summary>
        [Required(ErrorMessage ="Día laboral desde es requerida")]
        public int COD_DIA_LABORAL_DESDE { get; set; }
        [DisplayName("Día laboral desde")]
        public List<SelectListItem> LIST_DIA_LABORAL_DESDE { get; set; }
        public string DIA_LABORAL_DESDE { get; set; }
        /// <summary>
        /// COD DIA LABORAL HASTA
        /// </summary>
        [Required(ErrorMessage = "Día laboral hasta es requerida")]
        public int COD_DIA_LABORAL_HASTA { get; set; }
        [DisplayName("Día laboral hasta")]
        public List<SelectListItem> LIST_DIA_LABORAL_HASTA { get; set; }
        public string DIA_LABORAL_HASTA { get; set; }

        /// <summary>
        /// texto posicion
        /// </summary>
        [DisplayName("Posición")]
        [DataType(DataType.Text, ErrorMessage = "Solo puede ingresar textos")]
        public string POSICION { get; set; }

        /// <summary>
        /// texto empresa temporal
        /// </summary>
        public string EMPRESA_TEMPORAL { get; set; }

        /// <summary>
        /// cod datos salariales
        /// </summary>
        public int COD_DATOS_SALARIALES { get; set; }

        /// <summary>
        /// salario fijo
        /// </summary>
        [DisplayName("Salario fijo")]
        [Required(ErrorMessage = "Salario fijo requerido")]
        public decimal SALARIO_FIJO { get; set; }

        /// <summary>
        /// porcentaje salario fijo
        /// </summary>
        [DisplayName("Porcentaje")]
        public decimal PORCENTAJE_SALARIO_FIJO { get; set; }

        /// <summary>
        /// valor decimal salario variable
        /// </summary>
        [DisplayName("Salario variable")]
        public decimal SALARIO_VARIABLE { get; set; }

        /// <summary>
        /// valor decimal procentaje salario variable
        /// </summary>
        [DisplayName("Porcentaje")]
        public decimal PORCENTAJE_SALARIO_VARIABLE { get; set; }

        /// <summary>
        /// valor decimal sobreremuneracion
        /// </summary>
        [DisplayName("Sobre remuneración")]
        public decimal SOBREREMUNERACION { get; set; }

        /// <summary>
        /// valor decimal porcentaje sobreremuneracion
        /// </summary>
        [DisplayName("Porcentaje")]
        public decimal PORCENTAJE_SOBREREMUNERACION { get; set; }

        /// <summary>
        /// valor decimal extra fija
        /// </summary>
        [DisplayName("Extra Fija")]
        public decimal EXTRA_FIJA { get; set; }

        /// <summary>
        /// valor decimal recargo nocturno
        /// </summary>
        [DisplayName("Recargo Nocturno")]
        public decimal RECARGO_NOCTURNO { get; set; }

        /// <summary>
        /// medio de trasporte valor decimal
        /// </summary>
        [DisplayName("Medio de transporte")]
        public decimal MEDIO_TRANSPORTE { get; set; }

        /// <summary>
        /// salario total
        /// </summary>
        [DisplayName("Salario Total")]
        public decimal SALARIO_TOTAL { get; set; }

        /// <summary>
        /// valor decimal bono anual 
        /// </summary>
        [DisplayName("Bono anual")]
        public decimal BONO_ANUAL { get; set; }

        /// <summary>
        /// numero de salarios
        /// </summary>
        [DisplayName("Número Salarios")]
        public int NUMERO_SALARIOS { get; set; }

        /// <summary>
        /// meses garantizados
        /// </summary>
        [DisplayName("Meses Garantizados")]
        public int MESES_GARANTIZADOS { get; set; }

        /// <summary>
        /// cod tipo de salario
        /// </summary>
        [Required(ErrorMessage = "Tipo Salario es requerido")]
        public int COD_TIPO_SALARIO { get; set; }
        [DisplayName("Tipo Salario")]
        public List<SelectListItem> LIST_NOMBRE_TIPO_SALARIO { get; set; }
        public string NOMBRE_TIPO_SALARIO { get; set; }

        /// <summary>
        /// valor decimal factor prestacional
        /// </summary>
        [DisplayName("Factor Prestacional")]
        public decimal FACTOR_PRESTACIONAL { get; set; }

        /// <summary>
        /// ingreso promedio mensual 
        /// </summary>
        [DisplayName("Ingreso Promedio Mensual")]
        public decimal INGRESO_PROM_MENSUAL { get; set; }

        /// <summary>
        /// ingreso promedio anual
        /// </summary>
        [DisplayName("Ingreso Promedio Anual")]
        public decimal INGRESO_PROM_ANUAL { get; set; }

        /// <summary>
        /// texto de mercado
        /// </summary>
        [Required(ErrorMessage = "Mercado es requerida")]
        public int COD_MERCADO { get; set; }
        [DisplayName("Mercado")]
        public List<SelectListItem> LIST_MERCADO { get; set; }
        [Required(ErrorMessage = "Mercado es requerido")]
        [DisplayName("Mercado"), StringLength(100)]
        public string MERCADO { get; set; }

        /// <summary>
        /// cod Categoría
        /// </summary>
        [Required(ErrorMessage = "Categoría es requerida")]
        public int COD_CATEGORIA { get; set; }
        [DisplayName("Categoría")]
        public List<SelectListItem> LIST_NOMBRE_CATEGORIA { get; set; }
        public string NOMBRE_CATEGORIA { get; set; }
        /// <summary>
        /// valor decimal punto medio 80
        /// </summary>
        [DisplayName("80%")]
        public decimal PUNTO_MEDIO_80 { get; set; }

        /// <summary>
        /// valor decimal punto medio 100
        /// </summary>
        [DisplayName("100%")]
        public decimal PUNTO_MEDIO_100 { get; set; }

        /// <summary>
        /// valor decimal punto medio 120
        /// </summary>
        [DisplayName("120%")]
        public decimal PUNTO_MEDIO_120 { get; set; }

        /// <summary>
        /// valor decimal posicionamiento
        /// </summary>
        [DisplayName("Posicionamiento")]
        public decimal POSICIONAMIENTO { get; set; }

        public string COLORES_ESTADOS { get; set; }

        public string NOMBRES_USUARIO { get; set; }

        public string COD_CORREO_CONTROLLER { get; set; }


        [Required(ErrorMessage = "El motivo de rechazo es requerido")]
        [DisplayName("Motivo de rechazo")]
        public string MOTIVO_RECHAZO { get; set; }
    }
}