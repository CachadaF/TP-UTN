namespace FrbaHotel.Registrar_Consumible
{
    partial class Facturar_Estadias
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_FormaDePago = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Cuotas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Facturar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel_Tarjeta = new System.Windows.Forms.Panel();
            this.numericUpDown_Tarjeta = new System.Windows.Forms.NumericUpDown();
            this.textBox_estadia = new System.Windows.Forms.TextBox();
            this.panel_Tarjeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tarjeta)).BeginInit();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(231, 12);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.Text = "Hardcodeado 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estadia";
            // 
            // comboBox_FormaDePago
            // 
            this.comboBox_FormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FormaDePago.FormattingEnabled = true;
            this.comboBox_FormaDePago.Location = new System.Drawing.Point(133, 45);
            this.comboBox_FormaDePago.Name = "comboBox_FormaDePago";
            this.comboBox_FormaDePago.Size = new System.Drawing.Size(198, 21);
            this.comboBox_FormaDePago.TabIndex = 7;
            this.comboBox_FormaDePago.SelectedIndexChanged += new System.EventHandler(this.comboBox_FormaDePago_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Forma De Pago";
            // 
            // comboBox_Cuotas
            // 
            this.comboBox_Cuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Cuotas.FormattingEnabled = true;
            this.comboBox_Cuotas.Location = new System.Drawing.Point(118, 57);
            this.comboBox_Cuotas.Name = "comboBox_Cuotas";
            this.comboBox_Cuotas.Size = new System.Drawing.Size(197, 21);
            this.comboBox_Cuotas.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cuotas";
            // 
            // button_Facturar
            // 
            this.button_Facturar.Location = new System.Drawing.Point(12, 250);
            this.button_Facturar.Name = "button_Facturar";
            this.button_Facturar.Size = new System.Drawing.Size(143, 23);
            this.button_Facturar.TabIndex = 11;
            this.button_Facturar.Text = "Facturar";
            this.button_Facturar.UseVisualStyleBackColor = true;
            this.button_Facturar.Click += new System.EventHandler(this.Facturar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(198, 250);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(135, 23);
            this.Cancelar.TabIndex = 12;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Numero Tarjeta";
            // 
            // panel_Tarjeta
            // 
            this.panel_Tarjeta.Controls.Add(this.numericUpDown_Tarjeta);
            this.panel_Tarjeta.Controls.Add(this.comboBox_Cuotas);
            this.panel_Tarjeta.Controls.Add(this.label5);
            this.panel_Tarjeta.Controls.Add(this.label8);
            this.panel_Tarjeta.Location = new System.Drawing.Point(13, 72);
            this.panel_Tarjeta.Name = "panel_Tarjeta";
            this.panel_Tarjeta.Size = new System.Drawing.Size(320, 146);
            this.panel_Tarjeta.TabIndex = 25;
            // 
            // numericUpDown_Tarjeta
            // 
            this.numericUpDown_Tarjeta.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown_Tarjeta.Location = new System.Drawing.Point(118, 20);
            this.numericUpDown_Tarjeta.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDown_Tarjeta.Name = "numericUpDown_Tarjeta";
            this.numericUpDown_Tarjeta.Size = new System.Drawing.Size(197, 20);
            this.numericUpDown_Tarjeta.TabIndex = 21;
            this.numericUpDown_Tarjeta.TabStop = false;
            // 
            // textBox_estadia
            // 
            this.textBox_estadia.Enabled = false;
            this.textBox_estadia.Location = new System.Drawing.Point(60, 12);
            this.textBox_estadia.Name = "textBox_estadia";
            this.textBox_estadia.Size = new System.Drawing.Size(116, 20);
            this.textBox_estadia.TabIndex = 26;
            // 
            // Facturar_Estadias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 285);
            this.Controls.Add(this.textBox_estadia);
            this.Controls.Add(this.panel_Tarjeta);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.button_Facturar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_FormaDePago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox1);
            this.Name = "Facturar_Estadias";
            this.Text = "Facturación de estadía";
            this.panel_Tarjeta.ResumeLayout(false);
            this.panel_Tarjeta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tarjeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_FormaDePago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Cuotas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Facturar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel_Tarjeta;
        private System.Windows.Forms.NumericUpDown numericUpDown_Tarjeta;
        private System.Windows.Forms.TextBox textBox_estadia;
    }
}