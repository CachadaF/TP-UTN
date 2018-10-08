namespace FrbaHotel.Registrar_Consumible
{
    partial class TarjetaFacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_NroTarjeta = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Tipo = new System.Windows.Forms.ComboBox();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NroTarjeta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero Tarjeta";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(12, 216);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(131, 23);
            this.button_Guardar.TabIndex = 1;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cerrar
            // 
            this.button_Cerrar.Location = new System.Drawing.Point(160, 216);
            this.button_Cerrar.Name = "button_Cerrar";
            this.button_Cerrar.Size = new System.Drawing.Size(127, 23);
            this.button_Cerrar.TabIndex = 2;
            this.button_Cerrar.Text = "Cerrar";
            this.button_Cerrar.UseVisualStyleBackColor = true;
            this.button_Cerrar.Click += new System.EventHandler(this.button_Cerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripcion (Opcional)";
            // 
            // numericUpDown_NroTarjeta
            // 
            this.numericUpDown_NroTarjeta.Location = new System.Drawing.Point(126, 20);
            this.numericUpDown_NroTarjeta.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDown_NroTarjeta.Name = "numericUpDown_NroTarjeta";
            this.numericUpDown_NroTarjeta.Size = new System.Drawing.Size(161, 20);
            this.numericUpDown_NroTarjeta.TabIndex = 5;
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(126, 61);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(161, 21);
            this.comboBox_Tipo.TabIndex = 6;
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(126, 103);
            this.textBox_Descripcion.MaxLength = 255;
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(161, 92);
            this.textBox_Descripcion.TabIndex = 20;
            // 
            // TarjetaFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 251);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.comboBox_Tipo);
            this.Controls.Add(this.numericUpDown_NroTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Cerrar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.label1);
            this.Name = "TarjetaFacturas";
            this.Text = "Tarjeta para Facturar";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NroTarjeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_NroTarjeta;
        private System.Windows.Forms.ComboBox comboBox_Tipo;
        private System.Windows.Forms.TextBox textBox_Descripcion;
    }
}