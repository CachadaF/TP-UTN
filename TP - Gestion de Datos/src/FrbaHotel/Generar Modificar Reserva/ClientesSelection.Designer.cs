namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ClientesSelection
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
            this.button_Agregar = new System.Windows.Forms.Button();
            this.button_Seleccionar = new System.Windows.Forms.Button();
            this.button_Buscar = new System.Windows.Forms.Button();
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
            this.textBox_doc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Clientes = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Agregar
            // 
            this.button_Agregar.Location = new System.Drawing.Point(9, 472);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(124, 23);
            this.button_Agregar.TabIndex = 50;
            this.button_Agregar.Text = "Agregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // button_Seleccionar
            // 
            this.button_Seleccionar.Location = new System.Drawing.Point(313, 472);
            this.button_Seleccionar.Name = "button_Seleccionar";
            this.button_Seleccionar.Size = new System.Drawing.Size(124, 23);
            this.button_Seleccionar.TabIndex = 51;
            this.button_Seleccionar.Text = "Seleccionar";
            this.button_Seleccionar.UseVisualStyleBackColor = true;
            this.button_Seleccionar.Click += new System.EventHandler(this.button_Seleccionar_Click);
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(163, 472);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(124, 23);
            this.button_Buscar.TabIndex = 52;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
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
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 119);
            this.panel1.TabIndex = 53;
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
            // textBox_doc
            // 
            this.textBox_doc.Location = new System.Drawing.Point(72, 37);
            this.textBox_doc.MaxLength = 9;
            this.textBox_doc.Name = "textBox_doc";
            this.textBox_doc.ShortcutsEnabled = false;
            this.textBox_doc.Size = new System.Drawing.Size(143, 20);
            this.textBox_doc.TabIndex = 27;
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
            // dataGridView_Clientes
            // 
            this.dataGridView_Clientes.AllowUserToAddRows = false;
            this.dataGridView_Clientes.AllowUserToDeleteRows = false;
            this.dataGridView_Clientes.AllowUserToOrderColumns = true;
            this.dataGridView_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Clientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Mail,
            this.Estado});
            this.dataGridView_Clientes.Location = new System.Drawing.Point(12, 128);
            this.dataGridView_Clientes.MultiSelect = false;
            this.dataGridView_Clientes.Name = "dataGridView_Clientes";
            this.dataGridView_Clientes.ReadOnly = true;
            this.dataGridView_Clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Clientes.Size = new System.Drawing.Size(428, 338);
            this.dataGridView_Clientes.TabIndex = 54;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.FillWeight = 89.3401F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 87;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.FillWeight = 89.3401F;
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 87;
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.FillWeight = 89.3401F;
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.Width = 87;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Baja_Logica";
            this.Estado.FillWeight = 131.9797F;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Estado.Width = 129;
            // 
            // ClientesSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 507);
            this.Controls.Add(this.dataGridView_Clientes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.button_Seleccionar);
            this.Controls.Add(this.button_Agregar);
            this.Name = "ClientesSelection";
            this.Text = "ClientesSelection";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Button button_Seleccionar;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox_tipoDoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_doc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Clientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
    }
}