namespace FrbaHotel.ABM_de_Habitacion
{
    partial class DeleteRoom
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
            this.button_borrar = new System.Windows.Forms.Button();
            this.maskedTextBox_Hotel = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.maskedTextBox_Numero = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero_Habitacion";
            // 
            // button_borrar
            // 
            this.button_borrar.Location = new System.Drawing.Point(12, 104);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(174, 23);
            this.button_borrar.TabIndex = 2;
            this.button_borrar.Text = "Borrar";
            this.button_borrar.UseVisualStyleBackColor = true;
            this.button_borrar.Click += new System.EventHandler(this.button_borrar_Click);
            // 
            // maskedTextBox_Hotel
            // 
            this.maskedTextBox_Hotel.Location = new System.Drawing.Point(12, 53);
            this.maskedTextBox_Hotel.Name = "maskedTextBox_Hotel";
            this.maskedTextBox_Hotel.ReadOnly = true;
            this.maskedTextBox_Hotel.Size = new System.Drawing.Size(174, 20);
            this.maskedTextBox_Hotel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hotel";
            // 
            // button_cerrar
            // 
            this.button_cerrar.Location = new System.Drawing.Point(210, 104);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(187, 23);
            this.button_cerrar.TabIndex = 6;
            this.button_cerrar.Text = "Cerrar";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // maskedTextBox_Numero
            // 
            this.maskedTextBox_Numero.Location = new System.Drawing.Point(12, 12);
            this.maskedTextBox_Numero.Name = "maskedTextBox_Numero";
            this.maskedTextBox_Numero.ReadOnly = true;
            this.maskedTextBox_Numero.Size = new System.Drawing.Size(174, 20);
            this.maskedTextBox_Numero.TabIndex = 7;
            // 
            // DeleteRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 139);
            this.Controls.Add(this.maskedTextBox_Numero);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_Hotel);
            this.Controls.Add(this.button_borrar);
            this.Controls.Add(this.label1);
            this.Name = "DeleteRoom";
            this.Text = "Eliminación de habitación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_borrar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Hotel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Numero;

    }
}