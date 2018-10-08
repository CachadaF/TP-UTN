namespace FrbaHotel.Cancelar_Reserva
{
    partial class CancelReservaScreen
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
            this.button_cancel_reserva = new System.Windows.Forms.Button();
            this.textBox_idReserva = new System.Windows.Forms.TextBox();
            this.textBox_motivoBaja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1_fechaCancel = new System.Windows.Forms.DateTimePicker();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_cancel_reserva
            // 
            this.button_cancel_reserva.Location = new System.Drawing.Point(149, 306);
            this.button_cancel_reserva.Name = "button_cancel_reserva";
            this.button_cancel_reserva.Size = new System.Drawing.Size(108, 23);
            this.button_cancel_reserva.TabIndex = 0;
            this.button_cancel_reserva.Text = "Cancelar Reserva";
            this.button_cancel_reserva.UseVisualStyleBackColor = true;
            this.button_cancel_reserva.Click += new System.EventHandler(this.button_cancel_reserva_Click);
            // 
            // textBox_idReserva
            // 
            this.textBox_idReserva.Location = new System.Drawing.Point(149, 39);
            this.textBox_idReserva.Name = "textBox_idReserva";
            this.textBox_idReserva.Size = new System.Drawing.Size(108, 20);
            this.textBox_idReserva.TabIndex = 1;
            // 
            // textBox_motivoBaja
            // 
            this.textBox_motivoBaja.Location = new System.Drawing.Point(67, 87);
            this.textBox_motivoBaja.Multiline = true;
            this.textBox_motivoBaja.Name = "textBox_motivoBaja";
            this.textBox_motivoBaja.Size = new System.Drawing.Size(282, 142);
            this.textBox_motivoBaja.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CODIGO DE RESERVA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MOTIVO DE CANCELACIÓN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "FECHA DE CANCELACIÓN";
            // 
            // dateTimePicker1_fechaCancel
            // 
            this.dateTimePicker1_fechaCancel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1_fechaCancel.Location = new System.Drawing.Point(149, 259);
            this.dateTimePicker1_fechaCancel.Name = "dateTimePicker1_fechaCancel";
            this.dateTimePicker1_fechaCancel.Size = new System.Drawing.Size(108, 20);
            this.dateTimePicker1_fechaCancel.TabIndex = 7;
            // 
            // button_cerrar
            // 
            this.button_cerrar.Location = new System.Drawing.Point(168, 357);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(69, 23);
            this.button_cerrar.TabIndex = 8;
            this.button_cerrar.Text = "Cerrar";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // Form_canc_reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 404);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.dateTimePicker1_fechaCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_motivoBaja);
            this.Controls.Add(this.textBox_idReserva);
            this.Controls.Add(this.button_cancel_reserva);
            this.Name = "Form_canc_reserva";
            this.Text = "Cancelación de reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancel_reserva;
        private System.Windows.Forms.TextBox textBox_idReserva;
        private System.Windows.Forms.TextBox textBox_motivoBaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_fechaCancel;
        private System.Windows.Forms.Button button_cerrar;
    }
}