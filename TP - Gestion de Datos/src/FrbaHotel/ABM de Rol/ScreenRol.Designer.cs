namespace FrbaHotel.ABM_de_Rol
{
    partial class ScreenRol
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
            this.dataGrid_rol = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_newRol = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_rol)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_rol
            // 
            this.dataGrid_rol.AllowUserToAddRows = false;
            this.dataGrid_rol.AllowUserToDeleteRows = false;
            this.dataGrid_rol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_rol.Location = new System.Drawing.Point(12, 62);
            this.dataGrid_rol.Name = "dataGrid_rol";
            this.dataGrid_rol.ReadOnly = true;
            this.dataGrid_rol.Size = new System.Drawing.Size(295, 226);
            this.dataGrid_rol.TabIndex = 0;
            this.dataGrid_rol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(124, 348);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Roles actuales del sistema:";
            // 
            // button_newRol
            // 
            this.button_newRol.Location = new System.Drawing.Point(69, 294);
            this.button_newRol.Name = "button_newRol";
            this.button_newRol.Size = new System.Drawing.Size(75, 23);
            this.button_newRol.TabIndex = 5;
            this.button_newRol.Text = "Nuevo Rol";
            this.button_newRol.UseVisualStyleBackColor = true;
            this.button_newRol.Click += new System.EventHandler(this.button_nuevo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_modif_Click);
            // 
            // ScreenRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 383);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_newRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid_rol);
            this.Name = "ScreenRol";
            this.Text = "Administración de roles";
            this.Load += new System.EventHandler(this.ScreenRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_rol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_rol;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_newRol;
        private System.Windows.Forms.Button button2;
    }
}