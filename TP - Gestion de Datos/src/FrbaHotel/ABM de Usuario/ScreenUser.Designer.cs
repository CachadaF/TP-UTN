namespace FrbaHotel.ABM_de_Usuario
{
    partial class ScreenUser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_modUser = new System.Windows.Forms.Button();
            this.button_newUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGrid_users = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_users)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_modUser);
            this.panel1.Controls.Add(this.button_newUser);
            this.panel1.Location = new System.Drawing.Point(21, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 37);
            this.panel1.TabIndex = 9;
            // 
            // button_modUser
            // 
            this.button_modUser.Location = new System.Drawing.Point(159, 9);
            this.button_modUser.Name = "button_modUser";
            this.button_modUser.Size = new System.Drawing.Size(101, 23);
            this.button_modUser.TabIndex = 2;
            this.button_modUser.Text = "Modificar Usuario";
            this.button_modUser.UseVisualStyleBackColor = true;
            this.button_modUser.Click += new System.EventHandler(this.button_modif_Click);
            // 
            // button_newUser
            // 
            this.button_newUser.Location = new System.Drawing.Point(30, 9);
            this.button_newUser.Name = "button_newUser";
            this.button_newUser.Size = new System.Drawing.Size(94, 23);
            this.button_newUser.TabIndex = 1;
            this.button_newUser.Text = "Nuevo Usuario";
            this.button_newUser.UseVisualStyleBackColor = true;
            this.button_newUser.Click += new System.EventHandler(this.button_nuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuario actuales:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(129, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // dataGrid_users
            // 
            this.dataGrid_users.AllowUserToAddRows = false;
            this.dataGrid_users.AllowUserToDeleteRows = false;
            this.dataGrid_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_users.Location = new System.Drawing.Point(17, 53);
            this.dataGrid_users.MultiSelect = false;
            this.dataGrid_users.Name = "dataGrid_users";
            this.dataGrid_users.ReadOnly = true;
            this.dataGrid_users.Size = new System.Drawing.Size(295, 226);
            this.dataGrid_users.TabIndex = 6;
            // 
            // ScreenUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid_users);
            this.Name = "ScreenUser";
            this.Text = "Administración de usuarios";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_modUser;
        private System.Windows.Forms.Button button_newUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGrid_users;
    }
}