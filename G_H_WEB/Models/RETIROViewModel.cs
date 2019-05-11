using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace G_H_WEB.Models
{
    public class RETIRO_CONSULTA_ViewModel
    {
        [Display(Name = "BuscarConsulta")]
        public string BUSCAR_CONSULTA { get; set; }

        public IEnumerable<RETIRO_ViewModel> RETIROS;

        public ERROR_ViewModel ERROR;
       public string VISTA { get; set; }
        public string CONTROLER { get; set; }


    }
    public class RETIRO_ViewModel
    {
        public decimal COD_RETIRO { get; set; }
        public string NOMBRE { get; set; }

        public string USUARIO { get; set; }

        public string CAUSAL { get; set; }

        public string FECHA_SOLICITUD { get; set; }

        public string ESTADO { get; set; }
        public string CONTROLER { get; set; }

    }


    public class RETIRO_APRUEBA_ViewModel
    {
        public decimal COD_RETIRO { get; set; }

        public string NOMBRE { get; set; }

        public string USUARIO { get; set; }

        public string DOCUMENTO { get; set; }

        public string CARGO { get; set; }

        public string CAUSAL { get; set; }

        public string FECHA_RETIRO { get; set; }

        public string ESTADO { get; set; }

        public string COMENTARIOS { get; set; }

        public IEnumerable<SOPORTE_RETIRO_ViewModel> SOPORTES { get; set; }

        public List<RETIRO_APRUEBA_ViewModel> APROBAR;
    }

    public class RETIRO_CREA_ViewModel
    {

        public string BUSCAR_CREAR { get; set; }

         public IEnumerable<RETIRO_CREA_ViewModel> CREA;
        //[Display(Name = "BuscarConsulta")]
        public string BuscarConsulta { get; set; }
        public string COMENTARIO_CREAR { get; internal set; }
 
        public IEnumerable<EMPLEADO_CONSULTA_ViewModel> EMPLEADOS;
        public  EMPLEADO_CONSULTA_ViewModel EMPLEADO;
        public IEnumerable<CAUSA_RETIRO_ViewModel> CAUSAS_RETIROS { get; set; }

        public int COD_CAUSA_RETIRO { set; get; }
        public IEnumerable<CAUSA_RETIRO_ViewModel> CAUSAS_RETIRO_COD;

        public IEnumerable<SOPORTES_RETIRO_ViewModel> SOPORTES;
        public ERROR_ViewModel ERROR;

    }
    public class EMPLEADO_CONSULTA_ViewModel
    {
        public string COD_EMPLEADO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public decimal? ESTADO { get; set; }
        public string USUARIO { get; set; }
        public decimal COD_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }
        public string AREA { get; set; }
    }



    public class RETIRO_EDITA_ViewModel
    {   [Required]
        public decimal COD_RETIRO { get; set; }

        public string BUSCAR_EDITAR { get; set; }

        public string NOMBRE { get; set; }

        public string DOCUMENTO { get; set; }

        public string CARGO { get; set; }
        [Required(ErrorMessage = "Campo requerido ")]
        [Display(Name = "Detalle")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 2)]
        public string COMENTARIOS { get; set; }
        public decimal COD_CAUSA_RETIRO { get; set; }
        public string NOMBRE_CAUSA_RETIRO { get; set; }

        public bool GENERA_VACANTE { get; set; }
        [Required]
        public string FECHA_RETIRO { get; set; }
        public string USUARIO { get; set; }

		public string ESTADO { get; set; }
        public IEnumerable<CAUSA_RETIRO_ViewModel> CAUSAS_RETIROS { get; set; }

        public IEnumerable<RETIRO_EDITA_ViewModel> RETIRO;

        public List<SOPORTES_RETIRO_ViewModel> SOPORTES;
        public ERROR_ViewModel ERROR;
        public string NOMBRE_VISTA { get; set; }


    }

    public class CAUSA_RETIRO_ViewModel
    {
        public decimal COD_CAUSA_RETIRO { get; set; }
        public string NOMBRE { get; set; }
    }


    public class RETIRO_SOPORTES_ViewModel
    {
        public decimal COD_RETIRO { get; set; }

        public IEnumerable<SOPORTES_RETIRO_ViewModel> SOPORTES;
        
    }

    public class SOPORTES_RETIRO_ViewModel
    {
        public decimal COD_RETIRO { get; set; }
        public decimal COD_SOPORTE { get; set; }
        public decimal COD_TIPO_SOPORTE { get; set; }
        public string NOMBRE_TIPO_SOPORTE { get; set; }
        public string NOMBRE_SOPORTE { get; set; }
        public string TAMANO { get; set; }
        public bool APROBADO { get; set; }
        public bool REQUERIDO { get; set; }
        public string ESTADO { get; set; }
    }

    public class TIPO_SOPORTES_SOPORTES_ViewModel
    {
        public decimal COD_RETIRO { get; set; }
        public decimal COD_SOPORTE { get; set; }
        public decimal COD_TIPO_SOPORTE { get; set; }
        public string NOMBRE_TIPO_SOPORTE { get; set; }
        public string NOMBRE_SOPORTE { get; set; }
        public string TAMANO { get; set; }
        public bool APROBADO { get; set; }
        public bool REQUERIDO { get; set; }
    }


    public class DATOS_CREA_RETIRO_ViewModel
      {
        public decimal COD_RETIRO { get; set; }
        [Required]
        public string NUMERO_DOCUMENTO { get; set; }
        [Required]
        public decimal COD_CAUSA_RETIRO { get; set; }
        [Required]
        public DateTime FECHA_RETIRO { get; set; }
        [Required]
        public string COMENTARIOS { get; set; }
        public string USUARIO { get; set; }
    }

    public class ERROR_ViewModel
    {
        public decimal COD_RETIRO { get; set; }
        public string COD_ERROR { get; set; }
        public string DETALLE { get; set; }
        public IEnumerable<ModelError> CAMPOS_INVALIDOS { get; set; }
  

    }
    





}