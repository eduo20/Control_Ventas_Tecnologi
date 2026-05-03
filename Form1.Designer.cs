namespace Control_Ventas_Tecnologi
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Inicio = new System.Windows.Forms.TabPage();
            this.panelContra1 = new System.Windows.Forms.Panel();
            this.buttonSiguiente2 = new System.Windows.Forms.Button();
            this.buttonRegresar2 = new System.Windows.Forms.Button();
            this.textBoxContra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelUser1 = new System.Windows.Forms.Panel();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAvanzar1 = new System.Windows.Forms.Button();
            this.buttonRegresar1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.buttonGerente = new System.Windows.Forms.Button();
            this.buttonCajero = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cajero = new System.Windows.Forms.TabPage();
            this.Gerente = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.Inicio.SuspendLayout();
            this.panelContra1.SuspendLayout();
            this.panelUser1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Inicio);
            this.tabControl1.Controls.Add(this.Cajero);
            this.tabControl1.Controls.Add(this.Gerente);
            this.tabControl1.Location = new System.Drawing.Point(10, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 580);
            this.tabControl1.TabIndex = 0;
            // 
            // Inicio
            // 
            this.Inicio.Controls.Add(this.panelUser1);
            this.Inicio.Controls.Add(this.panelContra1);
            this.Inicio.Controls.Add(this.dateTimePicker1);
            this.Inicio.Controls.Add(this.buttonSalir);
            this.Inicio.Controls.Add(this.buttonGerente);
            this.Inicio.Controls.Add(this.buttonCajero);
            this.Inicio.Controls.Add(this.label2);
            this.Inicio.Controls.Add(this.label1);
            this.Inicio.Location = new System.Drawing.Point(4, 22);
            this.Inicio.Margin = new System.Windows.Forms.Padding(2);
            this.Inicio.Name = "Inicio";
            this.Inicio.Size = new System.Drawing.Size(774, 554);
            this.Inicio.TabIndex = 2;
            this.Inicio.Text = "Pagina de Inicio";
            this.Inicio.UseVisualStyleBackColor = true;
            // 
            // panelContra1
            // 
            this.panelContra1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContra1.Controls.Add(this.buttonSiguiente2);
            this.panelContra1.Controls.Add(this.buttonRegresar2);
            this.panelContra1.Controls.Add(this.textBoxContra);
            this.panelContra1.Controls.Add(this.label4);
            this.panelContra1.Location = new System.Drawing.Point(194, 162);
            this.panelContra1.Margin = new System.Windows.Forms.Padding(2);
            this.panelContra1.Name = "panelContra1";
            this.panelContra1.Size = new System.Drawing.Size(400, 148);
            this.panelContra1.TabIndex = 5;
            this.panelContra1.Visible = false;
            // 
            // buttonSiguiente2
            // 
            this.buttonSiguiente2.Location = new System.Drawing.Point(310, 109);
            this.buttonSiguiente2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSiguiente2.Name = "buttonSiguiente2";
            this.buttonSiguiente2.Size = new System.Drawing.Size(60, 19);
            this.buttonSiguiente2.TabIndex = 3;
            this.buttonSiguiente2.Text = "Siguiente";
            this.buttonSiguiente2.UseVisualStyleBackColor = true;
            this.buttonSiguiente2.Click += new System.EventHandler(this.buttonSiguiente2_Click);
            // 
            // buttonRegresar2
            // 
            this.buttonRegresar2.Location = new System.Drawing.Point(20, 109);
            this.buttonRegresar2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegresar2.Name = "buttonRegresar2";
            this.buttonRegresar2.Size = new System.Drawing.Size(56, 19);
            this.buttonRegresar2.TabIndex = 2;
            this.buttonRegresar2.Text = "Regresar";
            this.buttonRegresar2.UseVisualStyleBackColor = true;
            this.buttonRegresar2.Click += new System.EventHandler(this.buttonRegresar2_Click);
            // 
            // textBoxContra
            // 
            this.textBoxContra.Location = new System.Drawing.Point(135, 63);
            this.textBoxContra.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxContra.Name = "textBoxContra";
            this.textBoxContra.Size = new System.Drawing.Size(240, 20);
            this.textBoxContra.TabIndex = 1;
            this.textBoxContra.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ingrese su Contraseña";
            // 
            // panelUser1
            // 
            this.panelUser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUser1.Controls.Add(this.textUser);
            this.panelUser1.Controls.Add(this.label3);
            this.panelUser1.Controls.Add(this.buttonAvanzar1);
            this.panelUser1.Controls.Add(this.buttonRegresar1);
            this.panelUser1.Location = new System.Drawing.Point(194, 162);
            this.panelUser1.Margin = new System.Windows.Forms.Padding(2);
            this.panelUser1.Name = "panelUser1";
            this.panelUser1.Size = new System.Drawing.Size(400, 148);
            this.panelUser1.TabIndex = 6;
            this.panelUser1.Visible = false;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(119, 53);
            this.textUser.Margin = new System.Windows.Forms.Padding(2);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(256, 20);
            this.textUser.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese su Usuario";
            // 
            // buttonAvanzar1
            // 
            this.buttonAvanzar1.Location = new System.Drawing.Point(307, 85);
            this.buttonAvanzar1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAvanzar1.Name = "buttonAvanzar1";
            this.buttonAvanzar1.Size = new System.Drawing.Size(68, 31);
            this.buttonAvanzar1.TabIndex = 1;
            this.buttonAvanzar1.Text = "Siguiente";
            this.buttonAvanzar1.UseVisualStyleBackColor = true;
            this.buttonAvanzar1.Click += new System.EventHandler(this.buttonAvanzar1_Click);
            // 
            // buttonRegresar1
            // 
            this.buttonRegresar1.Location = new System.Drawing.Point(17, 96);
            this.buttonRegresar1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegresar1.Name = "buttonRegresar1";
            this.buttonRegresar1.Size = new System.Drawing.Size(66, 31);
            this.buttonRegresar1.TabIndex = 0;
            this.buttonRegresar1.Text = "Regresar";
            this.buttonRegresar1.UseVisualStyleBackColor = true;
            this.buttonRegresar1.Click += new System.EventHandler(this.buttonRegresar1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(556, 19);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // buttonSalir
            // 
            this.buttonSalir.Font = new System.Drawing.Font("MS Reference Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalir.Location = new System.Drawing.Point(318, 446);
            this.buttonSalir.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(129, 59);
            this.buttonSalir.TabIndex = 4;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // buttonGerente
            // 
            this.buttonGerente.Font = new System.Drawing.Font("MS Reference Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGerente.Location = new System.Drawing.Point(458, 347);
            this.buttonGerente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGerente.Name = "buttonGerente";
            this.buttonGerente.Size = new System.Drawing.Size(165, 51);
            this.buttonGerente.TabIndex = 3;
            this.buttonGerente.Text = "Getente";
            this.buttonGerente.UseVisualStyleBackColor = true;
            this.buttonGerente.Click += new System.EventHandler(this.buttonGerente_Click);
            // 
            // buttonCajero
            // 
            this.buttonCajero.Font = new System.Drawing.Font("MS Reference Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCajero.Location = new System.Drawing.Point(146, 347);
            this.buttonCajero.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCajero.Name = "buttonCajero";
            this.buttonCajero.Size = new System.Drawing.Size(165, 51);
            this.buttonCajero.TabIndex = 2;
            this.buttonCajero.Text = "Cajero";
            this.buttonCajero.UseMnemonic = false;
            this.buttonCajero.UseVisualStyleBackColor = true;
            this.buttonCajero.Click += new System.EventHandler(this.buttonCajero_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(767, 72);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccióne su rol de esta empresa por favor, \r\nno obstante rogamos su discreción " +
    "en aspectos importantes de nuestra empresa.\r\n\r\nTENGA UNA EXELENTE JORNADA LABORA" +
    "L!\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido a TecnoMente ";
            // 
            // Cajero
            // 
            this.Cajero.Location = new System.Drawing.Point(4, 22);
            this.Cajero.Margin = new System.Windows.Forms.Padding(2);
            this.Cajero.Name = "Cajero";
            this.Cajero.Padding = new System.Windows.Forms.Padding(2);
            this.Cajero.Size = new System.Drawing.Size(774, 554);
            this.Cajero.TabIndex = 0;
            this.Cajero.Text = "Cajero";
            this.Cajero.UseVisualStyleBackColor = true;
            // 
            // Gerente
            // 
            this.Gerente.Location = new System.Drawing.Point(4, 22);
            this.Gerente.Margin = new System.Windows.Forms.Padding(2);
            this.Gerente.Name = "Gerente";
            this.Gerente.Padding = new System.Windows.Forms.Padding(2);
            this.Gerente.Size = new System.Drawing.Size(774, 554);
            this.Gerente.TabIndex = 1;
            this.Gerente.Text = "Gerente";
            this.Gerente.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 600);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.Inicio.ResumeLayout(false);
            this.Inicio.PerformLayout();
            this.panelContra1.ResumeLayout(false);
            this.panelContra1.PerformLayout();
            this.panelUser1.ResumeLayout(false);
            this.panelUser1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Cajero;
        private System.Windows.Forms.TabPage Gerente;
        private System.Windows.Forms.TabPage Inicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonGerente;
        private System.Windows.Forms.Button buttonCajero;
        private System.Windows.Forms.Panel panelUser1;
        private System.Windows.Forms.Button buttonAvanzar1;
        private System.Windows.Forms.Button buttonRegresar1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelContra1;
        private System.Windows.Forms.Button buttonSiguiente2;
        private System.Windows.Forms.Button buttonRegresar2;
        private System.Windows.Forms.TextBox textBoxContra;
        private System.Windows.Forms.Label label4;
    }
}

