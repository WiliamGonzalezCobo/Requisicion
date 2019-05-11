namespace PRUEBA_ACCESO_A_DATOS
{
    partial class RETIROS
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnBuscar = new System.Windows.Forms.Button();
			this.dtgvCagarRetiros = new System.Windows.Forms.DataGridView();
			this.rbJefe = new System.Windows.Forms.RadioButton();
			this.rbBp = new System.Windows.Forms.RadioButton();
			this.rbHc = new System.Windows.Forms.RadioButton();
			this.txtBusqueda = new System.Windows.Forms.TextBox();
			this.btnCrear = new System.Windows.Forms.Button();
			this.btnLogicaCrea = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btncorreo = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.USUARIO_textBox = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtgvCagarRetiros)).BeginInit();
			this.SuspendLayout();
			// 
			// btnBuscar
			// 
			this.btnBuscar.Location = new System.Drawing.Point(713, 24);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(75, 23);
			this.btnBuscar.TabIndex = 0;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// dtgvCagarRetiros
			// 
			this.dtgvCagarRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvCagarRetiros.EnableHeadersVisualStyles = false;
			this.dtgvCagarRetiros.Location = new System.Drawing.Point(12, 100);
			this.dtgvCagarRetiros.Name = "dtgvCagarRetiros";
			this.dtgvCagarRetiros.ReadOnly = true;
			this.dtgvCagarRetiros.Size = new System.Drawing.Size(776, 317);
			this.dtgvCagarRetiros.TabIndex = 1;
			this.dtgvCagarRetiros.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCagarRetiros_CellContentDoubleClick);
			this.dtgvCagarRetiros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCagarRetiros_CellDoubleClick);
			// 
			// rbJefe
			// 
			this.rbJefe.AutoSize = true;
			this.rbJefe.Location = new System.Drawing.Point(35, 13);
			this.rbJefe.Name = "rbJefe";
			this.rbJefe.Size = new System.Drawing.Size(45, 17);
			this.rbJefe.TabIndex = 2;
			this.rbJefe.TabStop = true;
			this.rbJefe.Text = "Jefe";
			this.rbJefe.UseVisualStyleBackColor = true;
			// 
			// rbBp
			// 
			this.rbBp.AutoSize = true;
			this.rbBp.Location = new System.Drawing.Point(35, 36);
			this.rbBp.Name = "rbBp";
			this.rbBp.Size = new System.Drawing.Size(39, 17);
			this.rbBp.TabIndex = 3;
			this.rbBp.TabStop = true;
			this.rbBp.Text = "BP";
			this.rbBp.UseVisualStyleBackColor = true;
			// 
			// rbHc
			// 
			this.rbHc.AutoSize = true;
			this.rbHc.Location = new System.Drawing.Point(35, 59);
			this.rbHc.Name = "rbHc";
			this.rbHc.Size = new System.Drawing.Size(40, 17);
			this.rbHc.TabIndex = 4;
			this.rbHc.TabStop = true;
			this.rbHc.Text = "HC";
			this.rbHc.UseVisualStyleBackColor = true;
			// 
			// txtBusqueda
			// 
			this.txtBusqueda.Location = new System.Drawing.Point(486, 26);
			this.txtBusqueda.Name = "txtBusqueda";
			this.txtBusqueda.Size = new System.Drawing.Size(221, 20);
			this.txtBusqueda.TabIndex = 5;
			// 
			// btnCrear
			// 
			this.btnCrear.Location = new System.Drawing.Point(625, 71);
			this.btnCrear.Name = "btnCrear";
			this.btnCrear.Size = new System.Drawing.Size(163, 23);
			this.btnCrear.TabIndex = 6;
			this.btnCrear.Text = "Crear";
			this.btnCrear.UseVisualStyleBackColor = true;
			this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
			// 
			// btnLogicaCrea
			// 
			this.btnLogicaCrea.Location = new System.Drawing.Point(262, 53);
			this.btnLogicaCrea.Name = "btnLogicaCrea";
			this.btnLogicaCrea.Size = new System.Drawing.Size(163, 23);
			this.btnLogicaCrea.TabIndex = 7;
			this.btnLogicaCrea.Text = "invocalogica";
			this.btnLogicaCrea.UseVisualStyleBackColor = true;
			this.btnLogicaCrea.Click += new System.EventHandler(this.btnLogicaCrea_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(431, 71);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(163, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "eliminar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(111, 59);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(127, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "crear usuario";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// btncorreo
			// 
			this.btncorreo.Location = new System.Drawing.Point(111, 10);
			this.btncorreo.Name = "btncorreo";
			this.btncorreo.Size = new System.Drawing.Size(127, 23);
			this.btncorreo.TabIndex = 10;
			this.btncorreo.Text = "crear correo notificacion";
			this.btncorreo.UseVisualStyleBackColor = true;
			this.btncorreo.Click += new System.EventHandler(this.btncorreo_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 423);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(163, 23);
			this.button3.TabIndex = 11;
			this.button3.Text = "Crea Usuario";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// USUARIO_textBox
			// 
			this.USUARIO_textBox.Location = new System.Drawing.Point(181, 426);
			this.USUARIO_textBox.Name = "USUARIO_textBox";
			this.USUARIO_textBox.Size = new System.Drawing.Size(118, 20);
			this.USUARIO_textBox.TabIndex = 12;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(625, 423);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(163, 23);
			this.button4.TabIndex = 13;
			this.button4.Text = "Consultar";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click_1);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(364, 423);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(163, 23);
			this.button5.TabIndex = 14;
			this.button5.Text = "ENVIAR CORREO";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click_1);
			// 
			// RETIROS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.USUARIO_textBox);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.btncorreo);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnLogicaCrea);
			this.Controls.Add(this.btnCrear);
			this.Controls.Add(this.txtBusqueda);
			this.Controls.Add(this.rbHc);
			this.Controls.Add(this.rbBp);
			this.Controls.Add(this.rbJefe);
			this.Controls.Add(this.dtgvCagarRetiros);
			this.Controls.Add(this.btnBuscar);
			this.Name = "RETIROS";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgvCagarRetiros)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dtgvCagarRetiros;
        private System.Windows.Forms.RadioButton rbJefe;
        private System.Windows.Forms.RadioButton rbBp;
        private System.Windows.Forms.RadioButton rbHc;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnLogicaCrea;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btncorreo;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox USUARIO_textBox;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}

