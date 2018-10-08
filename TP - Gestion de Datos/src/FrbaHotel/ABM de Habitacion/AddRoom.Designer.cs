namespace FrbaHotel.ABM_de_Habitacion
{
    partial class AddRoom
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
            this.comboBox_tipoRoom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.comboBox_ubicRoom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.numeric_Hab = new System.Windows.Forms.NumericUpDown();
            this.numeric_Piso = new System.Windows.Forms.NumericUpDown();
            this.maskedTextBox_Hotel = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Hab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Piso)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_tipoRoom
            // 
            this.comboBox_tipoRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipoRoom.FormattingEnabled = true;
            this.comboBox_tipoRoom.Location = new System.Drawing.Point(148, 124);
            this.comboBox_tipoRoom.Name = "comboBox_tipoRoom";
            this.comboBox_tipoRoom.Size = new System.Drawing.Size(115, 21);
            this.comboBox_tipoRoom.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Numero habitación";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(188, 315);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 9;
            this.button_cancel.Text = "Cancelar";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(49, 315);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 8;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // comboBox_ubicRoom
            // 
            this.comboBox_ubicRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ubicRoom.FormattingEnabled = true;
            this.comboBox_ubicRoom.Location = new System.Drawing.Point(148, 163);
            this.comboBox_ubicRoom.Name = "comboBox_ubicRoom";
            this.comboBox_ubicRoom.Size = new System.Drawing.Size(115, 21);
            this.comboBox_ubicRoom.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ubicación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Piso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Descripción";
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(148, 204);
            this.textBox_Descripcion.MaxLength = 255;
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(115, 92);
            this.textBox_Descripcion.TabIndex = 19;
            // 
            // numeric_Hab
            // 
            this.numeric_Hab.Location = new System.Drawing.Point(148, 51);
            this.numeric_Hab.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_Hab.Name = "numeric_Hab";
            this.numeric_Hab.Size = new System.Drawing.Size(115, 20);
            this.numeric_Hab.TabIndex = 20;
            // 
            // numeric_Piso
            // 
            this.numeric_Piso.Location = new System.Drawing.Point(148, 88);
            this.numeric_Piso.Name = "numeric_Piso";
            this.numeric_Piso.Size = new System.Drawing.Size(115, 20);
            this.numeric_Piso.TabIndex = 21;
            // 
            // maskedTextBox_Hotel
            // 
            this.maskedTextBox_Hotel.Location = new System.Drawing.Point(148, 12);
            this.maskedTextBox_Hotel.Name = "maskedTextBox_Hotel";
            this.maskedTextBox_Hotel.ReadOnly = true;
            this.maskedTextBox_Hotel.Size = new System.Drawing.Size(115, 20);
            this.maskedTextBox_Hotel.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Hotel";
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 360);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBox_Hotel);
            this.Controls.Add(this.numeric_Piso);
            this.Controls.Add(this.numeric_Hab);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_ubicRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_tipoRoom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_guardar);
            this.Name = "AddRoom";
            this.Text = "Nueva habitación";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Hab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Piso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_tipoRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.ComboBox comboBox_ubicRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.NumericUpDown numeric_Hab;
        private System.Windows.Forms.NumericUpDown numeric_Piso;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Hotel;
        private System.Windows.Forms.Label label6;
    }
}