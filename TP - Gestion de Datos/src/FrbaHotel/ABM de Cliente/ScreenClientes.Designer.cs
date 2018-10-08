namespace FrbaHotel.ABM_de_Cliente
{
    partial class ScreenClientes
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
            this.Aceptar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_doc = new System.Windows.Forms.TextBox();
            this.grid_clientes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_tipoDoc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_clientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(12, 474);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 46;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(137, 474);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(90, 23);
            this.Agregar.TabIndex = 42;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(370, 474);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 41;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(365, 141);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 40;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Documento";
            // 
            // textBox_doc
            // 
            this.textBox_doc.Location = new System.Drawing.Point(72, 37);
            this.textBox_doc.MaxLength = 9;
            this.textBox_doc.Name = "textBox_doc";
            this.textBox_doc.ShortcutsEnabled = false;
            this.textBox_doc.Size = new System.Drawing.Size(143, 20);
            this.textBox_doc.TabIndex = 27;
            // 
            // grid_clientes
            // 
            this.grid_clientes.AllowUserToAddRows = false;
            this.grid_clientes.AllowUserToDeleteRows = false;
            this.grid_clientes.AllowUserToOrderColumns = true;
            this.grid_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_clientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Mail,
            this.Estado});
            this.grid_clientes.Location = new System.Drawing.Point(12, 170);
            this.grid_clientes.MultiSelect = false;
            this.grid_clientes.Name = "grid_clientes";
            this.grid_clientes.ReadOnly = true;
            this.grid_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_clientes.Size = new System.Drawing.Size(433, 298);
            this.grid_clientes.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.comboBox_tipoDoc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_mail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_apellido);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_nombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_doc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 119);
            this.panel1.TabIndex = 48;
            // 
            // comboBox_tipoDoc
            // 
            this.comboBox_tipoDoc.FormattingEnabled = true;
            this.comboBox_tipoDoc.Location = new System.Drawing.Point(294, 36);
            this.comboBox_tipoDoc.Name = "comboBox_tipoDoc";
            this.comboBox_tipoDoc.Size = new System.Drawing.Size(127, 21);
            this.comboBox_tipoDoc.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Tipo Doc.";
            // 
            // textBox_mail
            // 
            this.textBox_mail.Location = new System.Drawing.Point(72, 89);
            this.textBox_mail.MaxLength = 255;
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.ShortcutsEnabled = false;
            this.textBox_mail.Size = new System.Drawing.Size(143, 20);
            this.textBox_mail.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "E-mail";
            // 
            // textBox_apellido
            // 
            this.textBox_apellido.Location = new System.Drawing.Point(294, 63);
            this.textBox_apellido.MaxLength = 255;
            this.textBox_apellido.Name = "textBox_apellido";
            this.textBox_apellido.ShortcutsEnabled = false;
            this.textBox_apellido.Size = new System.Drawing.Size(127, 20);
            this.textBox_apellido.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Apellido";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(72, 63);
            this.textBox_nombre.MaxLength = 255;
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.ShortcutsEnabled = false;
            this.textBox_nombre.Size = new System.Drawing.Size(143, 20);
            this.textBox_nombre.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Flitrar:";
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(240, 474);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(90, 23);
            this.buttonModificar.TabIndex = 49;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Baja_Logica";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ScreenClientes
            // 
            this.AcceptButton = this.Buscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 509);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grid_clientes);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.Cancelar);
            this.Name = "ScreenClientes";
            this.Text = "Administracion de clientes";
            ((System.ComponentModel.ISupportInitialize)(this.grid_clientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_doc;
        private System.Windows.Forms.DataGridView grid_clientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_tipoDoc;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;

    }
}