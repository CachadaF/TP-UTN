namespace FrbaHotel.ABM_de_Hotel
{
    partial class BajaDeHotel
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
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Bajar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(12, 48);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(222, 20);
            this.dateTimePicker_Inicio.TabIndex = 0;
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(258, 48);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(228, 20);
            this.dateTimePicker_Fin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de Inicio de Baja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha De Fin de Baja";
            // 
            // button_Bajar
            // 
            this.button_Bajar.Location = new System.Drawing.Point(15, 150);
            this.button_Bajar.Name = "button_Bajar";
            this.button_Bajar.Size = new System.Drawing.Size(219, 23);
            this.button_Bajar.TabIndex = 4;
            this.button_Bajar.Text = "Realizar Baja";
            this.button_Bajar.UseVisualStyleBackColor = true;
            this.button_Bajar.Click += new System.EventHandler(this.button_Bajar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(258, 150);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(228, 23);
            this.button_Cancelar.TabIndex = 5;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripcion de la Baja";
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(15, 113);
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(471, 20);
            this.textBox_Descripcion.TabIndex = 7;
            // 
            // BajaDeHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 197);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Bajar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_Fin);
            this.Controls.Add(this.dateTimePicker_Inicio);
            this.Name = "BajaDeHotel";
            this.Text = "Inhabilitacion de Hotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Bajar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Descripcion;

    }
}