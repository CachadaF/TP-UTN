namespace FrbaHotel.Login
{
    partial class CambiarPassword
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_passAct = new System.Windows.Forms.TextBox();
            this.textBox_newPass = new System.Windows.Forms.TextBox();
            this.textBox_confPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nueva contraseña";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Confirmar nueva contraseña";
            // 
            // textBox_passAct
            // 
            this.textBox_passAct.Location = new System.Drawing.Point(201, 99);
            this.textBox_passAct.Name = "textBox_passAct";
            this.textBox_passAct.PasswordChar = '*';
            this.textBox_passAct.Size = new System.Drawing.Size(133, 20);
            this.textBox_passAct.TabIndex = 6;
            this.textBox_passAct.UseSystemPasswordChar = true;
            // 
            // textBox_newPass
            // 
            this.textBox_newPass.Location = new System.Drawing.Point(201, 145);
            this.textBox_newPass.Name = "textBox_newPass";
            this.textBox_newPass.PasswordChar = '*';
            this.textBox_newPass.Size = new System.Drawing.Size(133, 20);
            this.textBox_newPass.TabIndex = 7;
            this.textBox_newPass.UseSystemPasswordChar = true;
            // 
            // textBox_confPass
            // 
            this.textBox_confPass.Location = new System.Drawing.Point(201, 196);
            this.textBox_confPass.Name = "textBox_confPass";
            this.textBox_confPass.PasswordChar = '*';
            this.textBox_confPass.Size = new System.Drawing.Size(133, 20);
            this.textBox_confPass.TabIndex = 8;
            this.textBox_confPass.UseSystemPasswordChar = true;
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 321);
            this.Controls.Add(this.textBox_confPass);
            this.Controls.Add(this.textBox_newPass);
            this.Controls.Add(this.textBox_passAct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "CambiarPassword";
            this.Text = "Cambiar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_passAct;
        private System.Windows.Forms.TextBox textBox_newPass;
        private System.Windows.Forms.TextBox textBox_confPass;
    }
}