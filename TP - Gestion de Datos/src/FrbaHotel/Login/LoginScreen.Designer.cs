namespace FrbaHotel.Login
{
    partial class LoginScreen
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
            this.panelRol = new System.Windows.Forms.Panel();
            this.button_selRol = new System.Windows.Forms.Button();
            this.comboBox_rol = new System.Windows.Forms.ComboBox();
            this.label_rol = new System.Windows.Forms.Label();
            this.panel_inSesion = new System.Windows.Forms.Panel();
            this.button_login = new System.Windows.Forms.Button();
            this.label_pass = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.panelHotel = new System.Windows.Forms.Panel();
            this.button_selHot = new System.Windows.Forms.Button();
            this.comboBox_hotel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_iniciar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invitadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioRegistradoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_cancel = new System.Windows.Forms.Button();
            this.panelRol.SuspendLayout();
            this.panel_inSesion.SuspendLayout();
            this.panelHotel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRol
            // 
            this.panelRol.Controls.Add(this.button_selRol);
            this.panelRol.Controls.Add(this.comboBox_rol);
            this.panelRol.Controls.Add(this.label_rol);
            this.panelRol.Enabled = false;
            this.panelRol.Location = new System.Drawing.Point(74, 190);
            this.panelRol.Name = "panelRol";
            this.panelRol.Size = new System.Drawing.Size(270, 92);
            this.panelRol.TabIndex = 9;
            // 
            // button_selRol
            // 
            this.button_selRol.Location = new System.Drawing.Point(79, 52);
            this.button_selRol.Name = "button_selRol";
            this.button_selRol.Size = new System.Drawing.Size(124, 24);
            this.button_selRol.TabIndex = 5;
            this.button_selRol.Text = "Seleccionar";
            this.button_selRol.UseVisualStyleBackColor = true;
            this.button_selRol.Click += new System.EventHandler(this.buttonSelecRol_Click);
            // 
            // comboBox_rol
            // 
            this.comboBox_rol.FormattingEnabled = true;
            this.comboBox_rol.Location = new System.Drawing.Point(128, 15);
            this.comboBox_rol.Name = "comboBox_rol";
            this.comboBox_rol.Size = new System.Drawing.Size(122, 21);
            this.comboBox_rol.TabIndex = 3;
            // 
            // label_rol
            // 
            this.label_rol.AutoSize = true;
            this.label_rol.Location = new System.Drawing.Point(17, 16);
            this.label_rol.Name = "label_rol";
            this.label_rol.Size = new System.Drawing.Size(79, 13);
            this.label_rol.TabIndex = 2;
            this.label_rol.Text = "Seleccione Rol";
            // 
            // panel_inSesion
            // 
            this.panel_inSesion.Controls.Add(this.button_login);
            this.panel_inSesion.Controls.Add(this.label_pass);
            this.panel_inSesion.Controls.Add(this.label_user);
            this.panel_inSesion.Controls.Add(this.textBox_pass);
            this.panel_inSesion.Controls.Add(this.textBox_user);
            this.panel_inSesion.Enabled = false;
            this.panel_inSesion.Location = new System.Drawing.Point(74, 39);
            this.panel_inSesion.Name = "panel_inSesion";
            this.panel_inSesion.Size = new System.Drawing.Size(270, 145);
            this.panel_inSesion.TabIndex = 8;
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(79, 100);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(124, 24);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Location = new System.Drawing.Point(17, 66);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(61, 13);
            this.label_pass.TabIndex = 3;
            this.label_pass.Text = "Contraseña";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(17, 26);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(43, 13);
            this.label_user.TabIndex = 2;
            this.label_user.Text = "Usuario";
            // 
            // textBox_pass
            // 
            this.textBox_pass.Location = new System.Drawing.Point(101, 63);
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.PasswordChar = '*';
            this.textBox_pass.Size = new System.Drawing.Size(149, 20);
            this.textBox_pass.TabIndex = 1;
            this.textBox_pass.UseSystemPasswordChar = true;
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(101, 23);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(149, 20);
            this.textBox_user.TabIndex = 0;
            // 
            // panelHotel
            // 
            this.panelHotel.Controls.Add(this.button_selHot);
            this.panelHotel.Controls.Add(this.comboBox_hotel);
            this.panelHotel.Controls.Add(this.label1);
            this.panelHotel.Enabled = false;
            this.panelHotel.Location = new System.Drawing.Point(74, 288);
            this.panelHotel.Name = "panelHotel";
            this.panelHotel.Size = new System.Drawing.Size(270, 92);
            this.panelHotel.TabIndex = 10;
            // 
            // button_selHot
            // 
            this.button_selHot.Location = new System.Drawing.Point(79, 52);
            this.button_selHot.Name = "button_selHot";
            this.button_selHot.Size = new System.Drawing.Size(124, 24);
            this.button_selHot.TabIndex = 5;
            this.button_selHot.Text = "Seleccionar";
            this.button_selHot.UseVisualStyleBackColor = true;
            this.button_selHot.Click += new System.EventHandler(this.buttonSelecHotel_Click);
            // 
            // comboBox_hotel
            // 
            this.comboBox_hotel.FormattingEnabled = true;
            this.comboBox_hotel.Location = new System.Drawing.Point(128, 15);
            this.comboBox_hotel.Name = "comboBox_hotel";
            this.comboBox_hotel.Size = new System.Drawing.Size(122, 21);
            this.comboBox_hotel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione Hotel";
            // 
            // button_iniciar
            // 
            this.button_iniciar.Enabled = false;
            this.button_iniciar.Location = new System.Drawing.Point(74, 398);
            this.button_iniciar.Name = "button_iniciar";
            this.button_iniciar.Size = new System.Drawing.Size(123, 22);
            this.button_iniciar.TabIndex = 11;
            this.button_iniciar.Text = "Iniciar";
            this.button_iniciar.UseVisualStyleBackColor = true;
            this.button_iniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Maroon;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(420, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invitadoToolStripMenuItem,
            this.usuarioRegistradoToolStripMenuItem});
            this.menúToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.menúToolStripMenuItem.Text = "Entrar como...";
            // 
            // invitadoToolStripMenuItem
            // 
            this.invitadoToolStripMenuItem.Name = "invitadoToolStripMenuItem";
            this.invitadoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.invitadoToolStripMenuItem.Text = "Guest";
            this.invitadoToolStripMenuItem.Click += new System.EventHandler(this.guest_start);
            // 
            // usuarioRegistradoToolStripMenuItem
            // 
            this.usuarioRegistradoToolStripMenuItem.Name = "usuarioRegistradoToolStripMenuItem";
            this.usuarioRegistradoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.usuarioRegistradoToolStripMenuItem.Text = "Usuario registrado";
            this.usuarioRegistradoToolStripMenuItem.Click += new System.EventHandler(this.user_start);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(221, 398);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(123, 22);
            this.button_cancel.TabIndex = 13;
            this.button_cancel.Text = "Cancelar";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 432);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_iniciar);
            this.Controls.Add(this.panelHotel);
            this.Controls.Add(this.panelRol);
            this.Controls.Add(this.panel_inSesion);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.panelRol.ResumeLayout(false);
            this.panelRol.PerformLayout();
            this.panel_inSesion.ResumeLayout(false);
            this.panel_inSesion.PerformLayout();
            this.panelHotel.ResumeLayout(false);
            this.panelHotel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelRol;
        private System.Windows.Forms.Button button_selRol;
        private System.Windows.Forms.ComboBox comboBox_rol;
        private System.Windows.Forms.Label label_rol;
        private System.Windows.Forms.Panel panel_inSesion;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_pass;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Panel panelHotel;
        private System.Windows.Forms.Button button_selHot;
        private System.Windows.Forms.ComboBox comboBox_hotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_iniciar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invitadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioRegistradoToolStripMenuItem;
        private System.Windows.Forms.Button button_cancel;
    }
}