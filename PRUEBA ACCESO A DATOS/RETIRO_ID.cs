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
using Newtonsoft.Json;

namespace PRUEBA_ACCESO_A_DATOS
{
    public partial class RETIRO_ID : Form
    {
        private IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());
        private List<MODELO_DATOS.RETIROS> Retiros = new List<MODELO_DATOS.RETIROS>();
        private MODELO_DATOS.RETIROS Retiro = new MODELO_DATOS.RETIROS();

      
        public RETIRO_ID(MODELO_DATOS.RETIROS Retiro)
        {
            InitializeComponent();
            lbCodRet.Text = Convert.ToString(Retiro.COD_RETIRO);
            label1.Text = Retiro.NOMBRE;
            label2.Text = Retiro.USUARIO;
            label3.Text = Retiro.NUMERO_DOCUMENTO;
            labCargo.Text = Retiro.NOMBRE_CARGO;
            labCausa.Text = Retiro.NOMBRE_CAUSA_RETIRO;
            labEstado.Text = Convert.ToString(Retiro.ESTADO);
        }

        private void RETIRO_ID_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                      
            Retiro.COD_RETIRO = 1;
            Retiro.NUMERO_DOCUMENTO = "00013";
            Retiro.NOMBRE = "JULIO";// 
            Retiro.USUARIO = "JULFUE"; //
            Retiro.COD_CARGO = 001;//
            Retiro.NOMBRE_CARGO = "analista";// 
            Retiro.COD_CAUSA_RETIRO = 1;// MODIFICA
            Retiro.NOMBRE_CAUSA_RETIRO = "despido actualiza";//MODIFICA
            Retiro.FECHA_RETIRO = Convert.ToDateTime("2019/01/21");//MODIFICA
            Retiro.GENERA_VACANTE = true;//MODIFICA
            Retiro.COMENTARIOS = "MODIFICADO CESNUN";//MODIFICA
            Retiro.APROBADO = false; //
            Retiro.ESTADO = 2; //MODIFICA
            Retiro.COD_USUARIO_CREA = "julfue"; //
            Retiro.FECHA_MODIFICA = Convert.ToDateTime("2019/01/22");//MODIFICA
            Retiro.FECHA_CREA = Convert.ToDateTime("2019/01/22");
            Retiro.COD_USUARIO_CREA = "002";
            Retiro.COD_USUARIO_MODIFICA = "005";//MODIFICA
            Retiro.COD_ESTADO_RETIRO = 1; 

            REPOSITORIO.ACTUALIZAR_RETIRO(Retiro);
            REPOSITORIO.GUARDAR();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
           IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());

        Retiro.COD_RETIRO = Convert.ToDecimal(lbCodRet.Text);
            Retiro.NUMERO_DOCUMENTO = "--";
            Retiro.NOMBRE = "--";
            Retiro.USUARIO = "--";
            Retiro.COD_CARGO = 0;
            Retiro.NOMBRE_CARGO = "--";
            Retiro.COD_CAUSA_RETIRO = 0;
            Retiro.NOMBRE_CAUSA_RETIRO = "--";
            Retiro.FECHA_RETIRO = Convert.ToDateTime("1900/01/01");
            Retiro.GENERA_VACANTE = true;
            Retiro.COMENTARIOS = "--";
            Retiro.APROBADO = false;
            Retiro.ESTADO =3;
            Retiro.COD_USUARIO_CREA = "--";
            Retiro.FECHA_CREA = Convert.ToDateTime("1900/01/01");
            Retiro.COD_USUARIO_MODIFICA = "--";
            Retiro.FECHA_MODIFICA = Convert.ToDateTime("1900/01/01");

            //REPOSITORIO.ACTUALIZAR_ESTADO(Retiro);
            //REPOSITORIO.GUARDAR();
        }
    }
}
