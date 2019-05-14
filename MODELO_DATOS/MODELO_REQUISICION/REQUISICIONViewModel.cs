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

        public int COD_REQUISICION { get; set; }
        [Required]
        public int COD_TIPO_NECESIDAD { get; set; }
        [Required]
        [DisplayName("Tipo Necesidad")]
        public List<SelectListItem> NOMBRE_TIPO_NECESIDAD { get; set; }
         

        [Required]
        [DisplayName("Cargo")]
        public int COD_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }
        [Required]
        [DisplayName("Cargo")]
        public List<SelectListItem> NOMBRE_CARGO_LIST { get; set; }
        [Required]
        [DisplayName("Orden")]
        public string ORDEN { get; set; }
        //public string CECO { get; set; }

        [Required]
        public int COD_TIPO_REQUISICION { get; set; }
        [Required]
        [DisplayName("Tipo")]
        public string  NOMBRE_TIPO_REQUISICION { get; set; }
   



        public int? COD_TIPO_DOCUMENTO { get; set; }
        /// <summary>
        /// Para Lista de tipo de documentos, viene del servicio
        /// </summary>
        /// 
        [DisplayName("Tipo")]
        public List<SelectListItem> TIPO_DOCUMENTO { get; set; }

        /// <summary>
        /// Numero de documento con validaciones
        /// </summary>
        [DisplayName("Documento")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar un numero de documento")]
        [Required]
        public string NUMERO_DOCUMENTO_EMPLEADO { get; set; }

        [DisplayName("Nombre")]
        [DataType(DataType.Text, ErrorMessage = "El numbre del empleado debe ser solo texto") ]
        public List<SelectListItem> NOMBRE_EMPLEADO { get; set; }

        public string LOGIN_EMPLEADO { get; set; }

        /// <summary>
        /// campo para fecha con validacion
        /// </summary>
        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Date, ErrorMessage = "El campo Fecha Inicio tiene un formato incorrecto")]
        public DateTime FECHA_INICIO { get; set; }


        [DisplayName("Fecha Fin")]
        [DataType(DataType.Date, ErrorMessage = "El campo Fecha Fin tiene un formato incorrecto")]
        public DateTime FECHA_FIN { get; set; }
        [Required]
        [DisplayName("Es Modificación")]
        public Boolean ES_MODIFICACION { get; set; }
        [Required]
        [DisplayName("Observación")]
        public string OBSERVACION { get; set; }
        [Required]
        [DisplayName("Observación")]
        public string OBSERVACION_CREACION { get; set; }

        public int COD_ESTADO_REQUISICION { get; set; }
        [Required]
        [DisplayName("Estado")]
        public string NOMBRE_ESTADO_REQUISICION { get; set; }
        [Required]
        [DisplayName("Creado Por")]
        public string USUARIO_CREACION { get; set; }
        public string EMAIL_USUARIO_CREACION { get; set; }
        [Required]
        [DisplayName("Fecha de Solicitud")]
        public string FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }

        public int MyProperty { get; set; }
        public int COD_DATOS_GENERALES { get; set; }


        //martinezluir Porque tantas variables para gerencia
        public int COD_GERENCIA { get; set; }
        [Required]
        [DisplayName("Gerencia")]
        public string NOMBRE_GERENCIA { get; set; }

        [Required]
        [DisplayName("Gerencia")]
        public  List<SelectListItem>NOMBRE_GERENCIA_LISTA{ get; set; }


        public int COD_TIPO_CONTRATO { get; set; }
        [Required]
        [DisplayName("Tipo Contrato")]
        public string NOMBRE_TIPO_CONTRATO { get; set; }
        [DisplayName("Tipo Contrato")]
		public List<SelectListItem> LIST_NOMBRE_TIPO_CONTRATO { get; set; }
        [DisplayName("Jefe Inmediato"), StringLength(100)]
        public string JEFE_INMEDIATO { get; set; }

        [DisplayName("Ceco")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo permite numeros")]
        public int COD_CECO { get; set; }
        [Required]
        [DisplayName("CeCo")]
        public List<SelectListItem> NOMBRE_CECO { get; set; }

        //Martinezluir porque tantas variables para sociedad
        public int COD_SOCIEDAD { get; set; }
        public string NOMBRE_SOCIEDAD { get; set; }
        [DisplayName("Sociedad")]
        public List<SelectListItem> NOMBRE_SOCIEDAD_LISTA { get; set; }


        //Martinezluir porque tantas variables para COD_EQUIPO_VENTAS_LISTA

        [DisplayName("Equipo de Ventas")]
        public List<SelectListItem> COD_EQUIPO_VENTAS_LISTA { get; set; }
        public int COD_EQUIPO_VENTAS { get; set; }


        public int COD_NOMBRE_EQIPO_VENTAS { get; set; }
        public string NOMBRE_EQIPO_VENTAS { get; set; }
        [DisplayName("Equipo de Ventas")]
        public List<SelectListItem> LIST_NOMBRE_EQIPO_VENTAS { get; set; }
        public int COD_CIUDAD_TRABAJO { get; set; }
        [DisplayName("Ciudad Trabajo"), StringLength(100)]
        public string NOMBRE_CIUDAD_TRABAJO { get; set; }
        public int COD_DANE_CIUDAD_TRABAJO { get; set; }
        public int COD_UBICACION_FISICA { get; set; }
        [DisplayName("Ubicación Física"), StringLength(100)]
        public string NOMBRE_UBICACION_FISICA { get; set; }
        public int COD_NIVEL_RIESGO_ARL { get; set; }
        public string NIVEL_RIESGO_ARL { get; set; }
        [DisplayName("Nivel Riesgo ARL")]
        public List<SelectListItem> LIST_NIVEL_RIESGO_ARL { get; set; }
        public int COD_CATEGORIA_ED { get; set; }

        [DisplayName("Categoría ED")]
        public List<SelectListItem> COD_CATEGORIA_ED_LISTA { get; set; }



        [DisplayName("Categoria ED*")]
        public List<SelectListItem> LIST_NOMBRE_CATEGORIA_ED { get; set; }
        [DisplayName("Cargo Critico")]
        public bool CARGO_CRITICO { get; set; }
        public int COD_JORNADA_LABORAL { get; set; }
        [DisplayName("Jornada de Trabajo")]
        public string NOMBRE_JORNADA_LABORAL { get; set; }

        [DisplayName("desde"), StringLength(50)]
        //[DataType(DataType.Date, ErrorMessage = "El campo desde tiene un formato incorrecto")]
        public string HORARIO_LABORAL_DESDE { get; set; }

        [DisplayName("hasta"), StringLength(50)]
        //[DataType(DataType.Date, ErrorMessage = "El campo Fecha hasta tiene un formato incorrecto")]
        public string HORARIO_LABORAL_HASTA { get; set; }

        [DisplayName("desde"), StringLength(50)]
        //[DataType(DataType.Date, ErrorMessage = "El campo desde tiene un formato incorrecto")]
        public string DIA_LABORAL_DESDE { get; set; }

        [DisplayName("hasta"), StringLength(50)]
        //[DataType(DataType.Date, ErrorMessage = "El campo Fecha hasta tiene un formato incorrecto")]
        public string DIA_LABORAL_HASTA { get; set; }



        [DisplayName("Dias Laborales")]
        public int COD_DIA_LABORAL_DESDE { get; set; }
        public int COD_DIA_LABORAL_HASTA { get; set; }

        [DisplayName("Posición")]
        [DataType(DataType.Text, ErrorMessage ="Solo puede ingresar textos")]
        public string POSICION { get; set; }
        public string EMPRESA_TEMPORAL { get; set; }


       

        public int COD_DATOS_SALARIALES { get; set; }

        [DisplayName("Salario fijo")]
        public decimal SALARIO_FIJO { get; set; }
        [DisplayName("Porcentaje")]
        public decimal PORCENTAJE_SALARIO_FIJO { get; set; }

        [DisplayName("Salario variable")]
        public decimal SALARIO_VARIABLE { get; set; }
        [DisplayName("Porcentaje")]
        public decimal PORCENTAJE_SALARIO_VARIABLE { get; set; }
        [DisplayName("Sobreremuneración")]
        public decimal SOBREREMUNERACION { get; set; }
        [DisplayName("Porcentaje")]
        public decimal PORCENTAJE_SOBREREMUNERACION { get; set; }

        [DisplayName("Extra Fija")]
        public decimal EXTRA_FIJA { get; set; }

        [DisplayName("Recargo Nocturno")]
        public decimal RECARGO_NOCTURNO { get; set; }

        [DisplayName("Medio de transporte")]
        public decimal MEDIO_TRANSPORTE { get; set; }

        [DisplayName("Salario Total")]
        public decimal SALARIO_TOTAL { get; set; }

        [DisplayName("Bono anual")]
        public decimal BONO_ANUAL { get; set; }

        [DisplayName("Número Salarios")]
        public int NUMERO_SALARIOS { get; set; }
        [DisplayName("Meses Garantizados")]
        public int MESES_GARANTIZADOS { get; set; }
        public int COD_TIPO_SALARIO { get; set; }
        public string NOMBRE_TIPO_SALARIO { get; set; }
        [DisplayName("Tipo SAlario")]
        public List<SelectListItem> LIST_NOMBRE_TIPO_SALARIO { get; set; }
        [DisplayName("Factor Prestacional")]
        public decimal FACTOR_PRESTACIONAL { get; set; }
        [DisplayName("Ingreso Promedio Mensual")]
        public decimal INGRESO_PROM_MENSUAL { get; set; }
        [DisplayName("Ingreso Promedio Anual")]
        public decimal INGRESO_PROM_ANUAL { get; set; }
        [DisplayName("Mercado"), StringLength(100)]
        public string MERCADO { get; set; }
        public int COD_CATEGORIA { get; set; }
        public string NOMBRE_CATEGORIA { get; set; }
        [DisplayName("Categoria")]
        public List<SelectListItem> LIST_NOMBRE_CATEGORIA { get; set; }
        [DisplayName("80%")]
        public decimal PUNTO_MEDIO_80 { get; set; }
        [DisplayName("100%")]
        public decimal PUNTO_MEDIO_100 { get; set; }
        [DisplayName("120%")]
        public decimal PUNTO_MEDIO_120 { get; set; }
        [DisplayName("Posicionamiento")]
        public decimal POSICIONAMIENTO { get; set; }
    }
}