using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REPOSITORIOS;
using MODELO_DATOS;
//using Newtonsoft.Json;
using LOGICA;
using WebGrease;

namespace PRUEBA_ACCESO_A_DATOS
{
    //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public partial class RETIROS : Form//, //IRETIROS_REP
    {
        //private IRETIROS_REP REPOSITORIO= new RETIROS_REP(new CONTEXTO());
        private List<MODELO_DATOS.RETIROS> Retiros = new List<MODELO_DATOS.RETIROS>();
        private MODELO_DATOS.RETIROS Retiro = new MODELO_DATOS.RETIROS();
        private MODELO_DATOS.SOPORTES Soporte = new MODELO_DATOS.SOPORTES();
        private LOGICA.RETIRO logica = new RETIRO();
        private LOGICA.SOPORTE logicasoporte = new SOPORTE();
        private LOGICA.TIPO_SOPORTE Logicatiposoporte = new TIPO_SOPORTE();
        private List<MODELO_DATOS.TIPO_SOPORTES> tiposoportes = new List<TIPO_SOPORTES>();
        private LOGICA.SEGURIDAD.USUARIO valida = new LOGICA.SEGURIDAD.USUARIO();

        private LOGICA.CLIENTE_CORREO Correo = new CLIENTE_CORREO();

        int rol = 1;
        int n = 0;
        public RETIROS()
        {
          
            InitializeComponent();


            //Retiros = REPOSITORIO.CONSULTAR_RETIROS(rol,null).ToList();
            //var json = JsonConvert.SerializeObject(Retiros);
            //dtgvCagarRetiros.DataSource = Retiros;
        }
            


        private void Form1_Load(object sender, EventArgs e)
        {

        }      

     

        private void dtgvCagarRetiros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int n = 0;


            //double Ndoc = double.Parse(dtgvCagarRetiros.Rows[n].Cells["COD_RETIRO"].Value.ToString());
            //Retiro = REPOSITORIO.CONSULTAR_RETIRO_POR_COD(Ndoc);
            //RETIRO_ID miForm2 = new RETIRO_ID(Retiro);
            //miForm2.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());

        rol = 1;
            if (rbJefe.Checked == true)
            { rol = 1; }
            if (rbBp.Checked == true)
            { rol = 2; }
            if (rbHc.Checked == true)
            { rol = 3; }

            string VALOR = txtBusqueda.Text;

            Retiros = REPOSITORIO.CONSULTAR_RETIROS("Jefe", VALOR, "CESNUN").ToList();
            dtgvCagarRetiros.DataSource = Retiros;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            INSER_RETIRO miform3 = new INSER_RETIRO();
            miform3.ShowDialog();


        }

        private void dtgvCagarRetiros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //       IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());
        ////int n = 0;
        //n = e.RowIndex;

        //    decimal Ndoc = decimal.Parse(dtgvCagarRetiros.Rows[n].Cells["COD_RETIRO"].Value.ToString());
        //    Retiro = REPOSITORIO.CONSULTAR_RETIRO_POR_CODIGO( mensajeDeError,Ndoc);
        //    RETIRO_ID miForm2 = new RETIRO_ID(Retiro);
        //    miForm2.ShowDialog();

        }

        private void btnLogicaCrea_Click(object sender, EventArgs e)
        {
			//log.Info("Ingreso correcto!!!");

			//IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());
			//CANCELAR
			//logica.CREAR( "80880812",1,DateTime.Now,"prueba crear","978.0");
			//  logica.ACTUALIZAR(7,DateTime.Now,1,false, "prueba el de actualizar con logica","0019");
			//logica.CANCELAR(16);
			//  logica.APROBAR(17, true, "978.0");

			LOGICA.SEGURIDAD.USUARIO USUARIO = new LOGICA.SEGURIDAD.USUARIO();
			USUARIO.CREAR("JUALOA");
			//USUARIO.CREAR("JUALOA");
			//USUARIO.CREAR("ANGPER");
			



			//try
			//{
			//    logica.CONSULTAR(16);
			//}
			//catch (Exception ex )
			//{
			//    throw;
			//}

		}

        private void button1_Click(object sender, EventArgs e)
        {
            IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());
            REPOSITORIO.ELIMINAR_RETIRO(17);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////consulata//
            //Soporte= logicasoporte.CONSULTAR(1);
            //label1.Text = Convert.ToString(Soporte.COD_SOPORTE);
            //label2.Text = Convert.ToString(Soporte.COD_RETIRO);
            //label3.Text = Convert.ToString(Soporte.RUTA_SOPORTE);
            ////fin consulta///
            //logicasoporte.APROBAR(2,true, "978.0");
            //logicasoporte.CREAR(1, 1, "Carta renuncia", "SYSYTEM");


            //dtgvCagarRetiros.DataSource = Retiros;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tiposoportes = Logicatiposoporte.CONSULTAR(1).ToList();
            //dtgvCagarRetiros.DataSource = retiro;
            //dtgvCagarRetiros.DataSource = tiposoportes;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logicasoporte.CONSULTA_ARCHIVO(12);
        }

        //private async void button5_Click(object sender, EventArgs e)
        private  void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(await valida.AUTENTICAR("julfue", "Tecno2019+"));
            //MessageBox.Show(await valida.AUTENTICAR("julfue", "Tecno2019+"));
            //bool x = await valida.CREAR("JULFUE");
            //bool x = valida.IsAuthenticated();
        }

        private void btncorreo_Click(object sender, EventArgs e)
        {

            string cadena = "P0047347_001_004";

            string resultado = cadena.Substring(0, 8);
            /*para crear correo*/
            //Correo.CREA_CORREO();
            //  var repuestaCortreo= Correo.CONSULTAR(3);
            //Correo.ENVIO_CORREO(1, "julfue@eltiempo.com");

        }

		private void button3_Click_1(object sender, EventArgs e)
		{
			LOGICA.SEGURIDAD.USUARIO USUARIO = new LOGICA.SEGURIDAD.USUARIO();
			USUARIO.CREAR(this.USUARIO_textBox.Text);
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			TIPO_SOPORTE tipo_soporte = new TIPO_SOPORTE("data source=bronte;initial catalog=GESTION_HUMANA;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
			IEnumerable<TIPO_SOPORTES> SOPORTES = 	tipo_soporte.CONSULTAR(1);
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			try
			{
				
				LOGICA.NOTIFICACION NOTIFICACION = new LOGICA.NOTIFICACION();
				NOTIFICACION.NOTIFICAR(19);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.InnerException + " "+  ex.Message);
			}

		}
	}




		//private void button2_Click(object sender, EventArgs e)
		//{
			
		//}

		//private async void button2_Click_1(object sender, EventArgs e)
		//{
		//	//REPOSITORIOS.SEGURIDAD.CUENTAS_REP account = new REPOSITORIOS.SEGURIDAD.CUENTAS_REP();
		//	//await account.REGISTRAR("cesnun");
		//	//REPOSITORIOS.SEGURIDAD.CUENTAS_REP account = new REPOSITORIOS.SEGURIDAD.CUENTAS_REP();
		//	//await account.VALIDAR("cesnun");
		//}
	//}
}
