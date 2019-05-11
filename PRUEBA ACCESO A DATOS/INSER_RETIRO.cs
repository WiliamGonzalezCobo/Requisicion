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

namespace PRUEBA_ACCESO_A_DATOS
{
    public partial class INSER_RETIRO : Form
    {

        private IRETIROS_REP REPOSITORIO = new RETIROS_REP(new CONTEXTO());
        private MODELO_DATOS.RETIROS Retiro = new MODELO_DATOS.RETIROS();
        public INSER_RETIRO()
        {
            InitializeComponent();
        }

      

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Retiro.NUMERO_DOCUMENTO = "00012";//txtCodNombre.Text;//
            Retiro.NOMBRE = "dario";// txtnombre.Text;
            Retiro.USUARIO = "edcar"; //txtUsuario.Text;
            Retiro.COD_CARGO = 001;//Convert.ToDecimal(txtCodCargo.Text);
            Retiro.NOMBRE_CARGO = "analista";// txtNomCargo.Text;
            Retiro.COD_CAUSA_RETIRO = 1;///Convert.ToDecimal(txtCodCausa.Text);
            Retiro.NOMBRE_CAUSA_RETIRO = "despido";///txtCausa.Text;
            Retiro.FECHA_RETIRO = Convert.ToDateTime("2019/01/21");//Convert.ToDateTime(dateTimePFecharetiro.Text);
            Retiro.GENERA_VACANTE= true;
            Retiro.COMENTARIOS = "asdasda";//txtComentario.Text;
            Retiro.APROBADO =false; //checkAprobado.Checked;
            Retiro.ESTADO = 1; //Convert.ToInt16(txtEstado.Text);
            Retiro.COD_USUARIO_CREA = "julfue"; //txtCodUsuCrea.Text;
            Retiro.FECHA_MODIFICA= Convert.ToDateTime("2019/01/21");
            Retiro.FECHA_CREA= Convert.ToDateTime("2019/01/21");
            Retiro.COD_USUARIO_CREA = "001";
            Retiro.COD_USUARIO_MODIFICA = "001";
            Retiro.COD_ESTADO_RETIRO = 1; 

            REPOSITORIO.CREAR_RETIRO(Retiro);
            REPOSITORIO.GUARDAR();


        }
    }
}
