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
            this.Cajero = new System.Windows.Forms.TabPage();
            this.Gerente = new System.Windows.Forms.TabPage();
            this.Inicio = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCajero = new System.Windows.Forms.Button();
            this.buttonGerente = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panelUser1 = new System.Windows.Forms.Panel();
            this.buttonRegresar1 = new System.Windows.Forms.Button();
            this.buttonAvanzar1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelContra1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxContra = new System.Windows.Forms.TextBox();
            this.buttonRegresar2 = new System.Windows.Forms.Button();
            this.buttonSiguiente2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Inicio.SuspendLayout();
            this.panelUser1.SuspendLayout();
            this.panelContra1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Inicio);
            this.tabControl1.Controls.Add(this.Cajero);
            this.tabControl1.Controls.Add(this.Gerente);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1043, 714);
            this.tabControl1.TabIndex = 0;
            // 
            // Cajero
            // 
            this.Cajero.Location = new System.Drawing.Point(4, 25);
            this.Cajero.Name = "Cajero";
            this.Cajero.Padding = new System.Windows.Forms.Padding(3);
            this.Cajero.Size = new System.Drawing.Size(1035, 685);
            this.Cajero.TabIndex = 0;
            this.Cajero.Text = "Cajero";
            this.Cajero.UseVisualStyleBackColor = true;
            // 
            // Gerente
            // 
            this.Gerente.Location = new System.Drawing.Point(4, 25);
            this.Gerente.Name = "Gerente";
            this.Gerente.Padding = new System.Windows.Forms.Padding(3);
            this.Gerente.Size = new System.Drawing.Size(1035, 685);
            this.Gerente.TabIndex = 1;
            this.Gerente.Text = "Gerente";
            this.Gerente.UseVisualStyleBackColor = true;
            // 
            // Inicio
            // 
            this.Inicio.Controls.Add(this.panelContra1);
            this.Inicio.Controls.Add(this.panelUser1);
            this.Inicio.Controls.Add(this.dateTimePicker1);
            this.Inicio.Controls.Add(this.buttonSalir);
            this.Inicio.Controls.Add(this.buttonGerente);
            this.Inicio.Controls.Add(this.buttonCajero);
            this.Inicio.Controls.Add(this.label2);
            this.Inicio.Controls.Add(this.label1);
            this.Inicio.Location = new System.Drawing.Point(4, 25);
            this.Inicio.Name = "Inicio";
            this.Inicio.Size = new System.Drawing.Size(1035, 685);
            this.Inicio.TabIndex = 2;
            this.Inicio.Text = "Pagina de Inicio";
            this.Inicio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido a TecnoMente ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(906, 88);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccióne su rol de esta empresa por favor, \r\nno obstante rogamos su discreción " +
    "en aspectos importantes de nuestra empresa.\r\n\r\nTENGA UNA EXELENTE JORNADA LABORA" +
    "L!\r\n";
            // 
            // buttonCajero
            // 
            this.buttonCajero.Font = new System.Drawing.Font("MS Reference Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCajero.Location = new System.Drawing.Point(194, 427);
            this.buttonCajero.Name = "buttonCajero";
            this.buttonCajero.Size = new System.Drawing.Size(220, 63);
            this.buttonCajero.TabIndex = 2;
            this.buttonCajero.Text = "Cajero";
            this.buttonCajero.UseMnemonic = false;
            this.buttonCajero.UseVisualStyleBackColor = true;
            // 
            // buttonGerente
            // 
            this.buttonGerente.Font = new System.Drawing.Font("MS Reference Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGerente.Location = new System.Drawing.Point(611, 427);
            this.buttonGerente.Name = "buttonGerente";
            this.buttonGerente.Size = new System.Drawing.Size(220, 63);
            this.buttonGerente.TabIndex = 3;
            this.buttonGerente.Text = "Getente";
            this.buttonGerente.UseVisualStyleBackColor = true;
            // 
            // buttonSalir
            // 
            this.buttonSalir.Font = new System.Drawing.Font("MS Reference Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalir.Location = new System.Drawing.Point(424, 549);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(172, 73);
            this.buttonSalir.TabIndex = 4;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(742, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(249, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // panelUser1
            // 
            this.panelUser1.Controls.Add(this.textBox1);
            this.panelUser1.Controls.Add(this.label3);
            this.panelUser1.Controls.Add(this.buttonAvanzar1);
            this.panelUser1.Controls.Add(this.buttonRegresar1);
            this.panelUser1.Location = new System.Drawing.Point(17, 3);
            this.panelUser1.Name = "panelUser1";
            this.panelUser1.Size = new System.Drawing.Size(533, 194);
            this.panelUser1.TabIndex = 6;
            // 
            // buttonRegresar1
            // 
            this.buttonRegresar1.Location = new System.Drawing.Point(23, 118);
            this.buttonRegresar1.Name = "buttonRegresar1";
            this.buttonRegresar1.Size = new System.Drawing.Size(88, 38);
            this.buttonRegresar1.TabIndex = 0;
            this.buttonRegresar1.Text = "Regresar";
            this.buttonRegresar1.UseVisualStyleBackColor = true;
            // 
            // buttonAvanzar1
            // 
            this.buttonAvanzar1.Location = new System.Drawing.Point(409, 105);
            this.buttonAvanzar1.Name = "buttonAvanzar1";
            this.buttonAvanzar1.Size = new System.Drawing.Size(90, 38);
            this.buttonAvanzar1.TabIndex = 1;
            this.buttonAvanzar1.Text = "Siguiente";
            this.buttonAvanzar1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese su Usuario";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(159, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(340, 22);
            this.textBox1.TabIndex = 4;
            // 
            // panelContra1
            // 
            this.panelContra1.Controls.Add(this.buttonSiguiente2);
            this.panelContra1.Controls.Add(this.buttonRegresar2);
            this.panelContra1.Controls.Add(this.textBoxContra);
            this.panelContra1.Controls.Add(this.label4);
            this.panelContra1.Location = new System.Drawing.Point(361, 227);
            this.panelContra1.Name = "panelContra1";
            this.panelContra1.Size = new System.Drawing.Size(533, 194);
            this.panelContra1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ingrese su Contraseña";
            // 
            // textBoxContra
            // 
            this.textBoxContra.Location = new System.Drawing.Point(180, 78);
            this.textBoxContra.Name = "textBoxContra";
            this.textBoxContra.Size = new System.Drawing.Size(319, 22);
            this.textBoxContra.TabIndex = 1;
            // 
            // buttonRegresar2
            // 
            this.buttonRegresar2.Location = new System.Drawing.Point(26, 134);
            this.buttonRegresar2.Name = "buttonRegresar2";
            this.buttonRegresar2.Size = new System.Drawing.Size(75, 23);
            this.buttonRegresar2.TabIndex = 2;
            this.buttonRegresar2.Text = "Regresar";
            this.buttonRegresar2.UseVisualStyleBackColor = true;
            // 
            // buttonSiguiente2
            // 
            this.buttonSiguiente2.Location = new System.Drawing.Point(424, 134);
            this.buttonSiguiente2.Name = "buttonSiguiente2";
            this.buttonSiguiente2.Size = new System.Drawing.Size(75, 23);
            this.buttonSiguiente2.TabIndex = 3;
            this.buttonSiguiente2.Text = "Siguiente";
            this.buttonSiguiente2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 739);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.Inicio.ResumeLayout(false);
            this.Inicio.PerformLayout();
            this.panelUser1.ResumeLayout(false);
            this.panelUser1.PerformLayout();
            this.panelContra1.ResumeLayout(false);
            this.panelContra1.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelContra1;
        private System.Windows.Forms.Button buttonSiguiente2;
        private System.Windows.Forms.Button buttonRegresar2;
        private System.Windows.Forms.TextBox textBoxContra;
        private System.Windows.Forms.Label label4;
    }
}

