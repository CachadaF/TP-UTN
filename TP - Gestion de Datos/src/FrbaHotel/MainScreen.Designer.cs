namespace FrbaHotel
{
    partial class MainScreen
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.estadíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.facturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regímenDeEstadíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.habitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_CancelarReserva = new System.Windows.Forms.Button();
            this.button_ModificarReserva = new System.Windows.Forms.Button();
            this.button_GenerarReserva = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonClientes = new System.Windows.Forms.Button();
            this.button_Usuarios = new System.Windows.Forms.Button();
            this.button_Roles = new System.Windows.Forms.Button();
            this.button_Estadisticas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel_Login = new System.Windows.Forms.LinkLabel();
            this.linkLabelCerrar = new System.Windows.Forms.LinkLabel();
            this.linkLabel_pass = new System.Windows.Forms.LinkLabel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(722, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(38, 17);
            this.StatusLabel.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadíaToolStripMenuItem,
            this.regímenDeEstadíaToolStripMenuItem,
            this.hotelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // estadíaToolStripMenuItem
            // 
            this.estadíaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.facturarToolStripMenuItem});
            this.estadíaToolStripMenuItem.Name = "estadíaToolStripMenuItem";
            this.estadíaToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.estadíaToolStripMenuItem.Text = "Estadía";
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.AccessibleName = "RegistrarEstadia";
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.registrarToolStripMenuItem.Text = "Registrar Estadía";
            this.registrarToolStripMenuItem.Click += new System.EventHandler(this.registrarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // facturarToolStripMenuItem
            // 
            this.facturarToolStripMenuItem.AccessibleName = "Facturar...";
            this.facturarToolStripMenuItem.Name = "facturarToolStripMenuItem";
            this.facturarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.facturarToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.facturarToolStripMenuItem.Text = "Facturar...";
            this.facturarToolStripMenuItem.Click += new System.EventHandler(this.facturarToolStripMenuItem_Click);
            // 
            // regímenDeEstadíaToolStripMenuItem
            // 
            this.regímenDeEstadíaToolStripMenuItem.AccessibleName = "Regímen d Estadía";
            this.regímenDeEstadíaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionToolStripMenuItem,
            this.nuevaToolStripMenuItem});
            this.regímenDeEstadíaToolStripMenuItem.Name = "regímenDeEstadíaToolStripMenuItem";
            this.regímenDeEstadíaToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.regímenDeEstadíaToolStripMenuItem.Text = "Regímen de Estadía";
            // 
            // seleccionToolStripMenuItem
            // 
            this.seleccionToolStripMenuItem.AccessibleName = "Selección de Regímen...";
            this.seleccionToolStripMenuItem.Name = "seleccionToolStripMenuItem";
            this.seleccionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.seleccionToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.seleccionToolStripMenuItem.Text = "Selección de Regímen...";
            this.seleccionToolStripMenuItem.Click += new System.EventHandler(this.seleccionToolStripMenuItem_Click);
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.AccessibleName = "Nuevo...";
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.R)));
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.nuevaToolStripMenuItem.Text = "Nuevo...";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // hotelToolStripMenuItem
            // 
            this.hotelToolStripMenuItem.AccessibleName = "Hotel";
            this.hotelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionHotelToolStripMenuItem,
            this.nuevoHotelToolStripMenuItem,
            this.toolStripMenuItem2,
            this.habitacionesToolStripMenuItem});
            this.hotelToolStripMenuItem.Name = "hotelToolStripMenuItem";
            this.hotelToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hotelToolStripMenuItem.Text = "Hotel";
            // 
            // seleccionHotelToolStripMenuItem
            // 
            this.seleccionHotelToolStripMenuItem.AccessibleName = "Selección de Hotel";
            this.seleccionHotelToolStripMenuItem.Name = "seleccionHotelToolStripMenuItem";
            this.seleccionHotelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.seleccionHotelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.seleccionHotelToolStripMenuItem.Text = "Selección de Hotel...";
            this.seleccionHotelToolStripMenuItem.Click += new System.EventHandler(this.seleccionHotelToolStripMenuItem_Click);
            // 
            // nuevoHotelToolStripMenuItem
            // 
            this.nuevoHotelToolStripMenuItem.AccessibleName = "Nuevo Hotel...";
            this.nuevoHotelToolStripMenuItem.Name = "nuevoHotelToolStripMenuItem";
            this.nuevoHotelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.H)));
            this.nuevoHotelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.nuevoHotelToolStripMenuItem.Text = "Nuevo Hotel...";
            this.nuevoHotelToolStripMenuItem.Click += new System.EventHandler(this.nuevoHotelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(222, 6);
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.AccessibleName = "Habitaciones...";
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.habitacionesToolStripMenuItem.Text = "Habitaciones...";
            this.habitacionesToolStripMenuItem.Click += new System.EventHandler(this.habitacionesToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button_CancelarReserva);
            this.panel1.Controls.Add(this.button_ModificarReserva);
            this.panel1.Controls.Add(this.button_GenerarReserva);
            this.panel1.Location = new System.Drawing.Point(17, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 148);
            this.panel1.TabIndex = 4;
            // 
            // button_CancelarReserva
            // 
            this.button_CancelarReserva.Location = new System.Drawing.Point(437, 52);
            this.button_CancelarReserva.Name = "button_CancelarReserva";
            this.button_CancelarReserva.Size = new System.Drawing.Size(140, 61);
            this.button_CancelarReserva.TabIndex = 2;
            this.button_CancelarReserva.Text = "Cancelar Reserva";
            this.button_CancelarReserva.UseVisualStyleBackColor = true;
            this.button_CancelarReserva.Click += new System.EventHandler(this.button_CancelarReserva_Click);
            // 
            // button_ModificarReserva
            // 
            this.button_ModificarReserva.Location = new System.Drawing.Point(272, 52);
            this.button_ModificarReserva.Name = "button_ModificarReserva";
            this.button_ModificarReserva.Size = new System.Drawing.Size(140, 61);
            this.button_ModificarReserva.TabIndex = 1;
            this.button_ModificarReserva.Text = "Modificar Reserva";
            this.button_ModificarReserva.UseVisualStyleBackColor = true;
            this.button_ModificarReserva.Click += new System.EventHandler(this.button_ModificarReserva_Click);
            // 
            // button_GenerarReserva
            // 
            this.button_GenerarReserva.Location = new System.Drawing.Point(109, 52);
            this.button_GenerarReserva.Name = "button_GenerarReserva";
            this.button_GenerarReserva.Size = new System.Drawing.Size(140, 61);
            this.button_GenerarReserva.TabIndex = 0;
            this.button_GenerarReserva.Text = "Generar Reserva";
            this.button_GenerarReserva.UseVisualStyleBackColor = true;
            this.button_GenerarReserva.Click += new System.EventHandler(this.button_GenerarReserva_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonClientes);
            this.panel2.Controls.Add(this.button_Usuarios);
            this.panel2.Controls.Add(this.button_Roles);
            this.panel2.Controls.Add(this.button_Estadisticas);
            this.panel2.Location = new System.Drawing.Point(17, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 118);
            this.panel2.TabIndex = 6;
            // 
            // buttonClientes
            // 
            this.buttonClientes.Image = global::FrbaHotel.Properties.Resources._48px_System_users_svg;
            this.buttonClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClientes.Location = new System.Drawing.Point(356, 33);
            this.buttonClientes.Name = "buttonClientes";
            this.buttonClientes.Size = new System.Drawing.Size(140, 57);
            this.buttonClientes.TabIndex = 6;
            this.buttonClientes.Text = "ABM de Clientes";
            this.buttonClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClientes.UseVisualStyleBackColor = true;
            this.buttonClientes.Click += new System.EventHandler(this.buttonClientes_Click);
            // 
            // button_Usuarios
            // 
            this.button_Usuarios.Image = global::FrbaHotel.Properties.Resources.client_icon;
            this.button_Usuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Usuarios.Location = new System.Drawing.Point(194, 33);
            this.button_Usuarios.Name = "button_Usuarios";
            this.button_Usuarios.Size = new System.Drawing.Size(140, 57);
            this.button_Usuarios.TabIndex = 5;
            this.button_Usuarios.Text = "ABM de Usuarios";
            this.button_Usuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Usuarios.UseVisualStyleBackColor = true;
            this.button_Usuarios.Click += new System.EventHandler(this.button_Usuarios_Click);
            // 
            // button_Roles
            // 
            this.button_Roles.Image = global::FrbaHotel.Properties.Resources.keys1;
            this.button_Roles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Roles.Location = new System.Drawing.Point(33, 33);
            this.button_Roles.Name = "button_Roles";
            this.button_Roles.Size = new System.Drawing.Size(140, 57);
            this.button_Roles.TabIndex = 4;
            this.button_Roles.Text = "ABM de Roles";
            this.button_Roles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Roles.UseVisualStyleBackColor = true;
            this.button_Roles.Click += new System.EventHandler(this.button_Roles_Click);
            // 
            // button_Estadisticas
            // 
            this.button_Estadisticas.Image = global::FrbaHotel.Properties.Resources.stats_icon;
            this.button_Estadisticas.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button_Estadisticas.Location = new System.Drawing.Point(518, 33);
            this.button_Estadisticas.Name = "button_Estadisticas";
            this.button_Estadisticas.Size = new System.Drawing.Size(140, 57);
            this.button_Estadisticas.TabIndex = 3;
            this.button_Estadisticas.Text = "Estadísticas";
            this.button_Estadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Estadisticas.UseVisualStyleBackColor = true;
            this.button_Estadisticas.Click += new System.EventHandler(this.button_Estadisticas_Click);
            // 
            // label1
            // 
            this.label1.Image = global::FrbaHotel.Properties.Resources.hotel;
            this.label1.Location = new System.Drawing.Point(257, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 40);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(297, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "FRBA Hotel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel_Login
            // 
            this.linkLabel_Login.AutoSize = true;
            this.linkLabel_Login.Location = new System.Drawing.Point(630, 34);
            this.linkLabel_Login.Name = "linkLabel_Login";
            this.linkLabel_Login.Size = new System.Drawing.Size(70, 13);
            this.linkLabel_Login.TabIndex = 10;
            this.linkLabel_Login.TabStop = true;
            this.linkLabel_Login.Text = "Iniciar Sesión";
            this.linkLabel_Login.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabel_Login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Login_LinkClicked);
            // 
            // linkLabelCerrar
            // 
            this.linkLabelCerrar.AutoSize = true;
            this.linkLabelCerrar.Location = new System.Drawing.Point(630, 34);
            this.linkLabelCerrar.Name = "linkLabelCerrar";
            this.linkLabelCerrar.Size = new System.Drawing.Size(70, 13);
            this.linkLabelCerrar.TabIndex = 11;
            this.linkLabelCerrar.TabStop = true;
            this.linkLabelCerrar.Text = "Cerrar Sesión";
            this.linkLabelCerrar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabelCerrar.Visible = false;
            this.linkLabelCerrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCerrar_LinkClicked);
            // 
            // linkLabel_pass
            // 
            this.linkLabel_pass.AutoSize = true;
            this.linkLabel_pass.Location = new System.Drawing.Point(505, 34);
            this.linkLabel_pass.Name = "linkLabel_pass";
            this.linkLabel_pass.Size = new System.Drawing.Size(102, 13);
            this.linkLabel_pass.TabIndex = 12;
            this.linkLabel_pass.TabStop = true;
            this.linkLabel_pass.Text = "Cambiar Contraseña";
            this.linkLabel_pass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabel_pass.Visible = false;
            this.linkLabel_pass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cambiar_contraseñaClick);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(722, 361);
            this.Controls.Add(this.linkLabel_pass);
            this.Controls.Add(this.linkLabelCerrar);
            this.Controls.Add(this.linkLabel_Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Hotel";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Usuarios;
        private System.Windows.Forms.Button button_Roles;
        private System.Windows.Forms.Button button_Estadisticas;
        private System.Windows.Forms.ToolStripMenuItem estadíaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regímenDeEstadíaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoHotelToolStripMenuItem;
        private System.Windows.Forms.Button button_GenerarReserva;
        private System.Windows.Forms.Button button_CancelarReserva;
        private System.Windows.Forms.Button button_ModificarReserva;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem;
        private System.Windows.Forms.Button buttonClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel_Login;
        private System.Windows.Forms.LinkLabel linkLabelCerrar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.LinkLabel linkLabel_pass;
    }
}

