namespace FrbaHotel.ABM_de_Hotel
{
    partial class ScreenHoteles
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
            this.button_Cerrar = new System.Windows.Forms.Button();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Baja = new System.Windows.Forms.Button();
            this.dataGridView_Hoteles = new System.Windows.Forms.DataGridView();
            this.ID_Hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nro_Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant_Estrellas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recarga_Estrellas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_Estrellas = new System.Windows.Forms.ComboBox();
            this.comboBox_Ciudad = new System.Windows.Forms.ComboBox();
            this.comboBox_Pais = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.button_Alta = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Hoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cerrar
            // 
            this.button_Cerrar.Location = new System.Drawing.Point(277, 387);
            this.button_Cerrar.Name = "button_Cerrar";
            this.button_Cerrar.Size = new System.Drawing.Size(83, 23);
            this.button_Cerrar.TabIndex = 0;
            this.button_Cerrar.Text = "Cerrar";
            this.button_Cerrar.UseVisualStyleBackColor = true;
            this.button_Cerrar.Click += new System.EventHandler(this.button_Cerrar_Click);
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(99, 387);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(83, 23);
            this.button_Modificar.TabIndex = 1;
            this.button_Modificar.Text = "Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Baja
            // 
            this.button_Baja.Location = new System.Drawing.Point(188, 387);
            this.button_Baja.Name = "button_Baja";
            this.button_Baja.Size = new System.Drawing.Size(83, 23);
            this.button_Baja.TabIndex = 2;
            this.button_Baja.Text = "Baja";
            this.button_Baja.UseVisualStyleBackColor = true;
            this.button_Baja.Click += new System.EventHandler(this.button_Baja_Click);
            // 
            // dataGridView_Hoteles
            // 
            this.dataGridView_Hoteles.AllowUserToAddRows = false;
            this.dataGridView_Hoteles.AllowUserToDeleteRows = false;
            this.dataGridView_Hoteles.AllowUserToOrderColumns = true;
            this.dataGridView_Hoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Hoteles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Hotel,
            this.Ciudad,
            this.Calle,
            this.Nro_Calle,
            this.Cant_Estrellas,
            this.Recarga_Estrellas,
            this.Telefono,
            this.Pais,
            this.Fecha_Creacion});
            this.dataGridView_Hoteles.Location = new System.Drawing.Point(12, 180);
            this.dataGridView_Hoteles.Name = "dataGridView_Hoteles";
            this.dataGridView_Hoteles.ReadOnly = true;
            this.dataGridView_Hoteles.Size = new System.Drawing.Size(348, 192);
            this.dataGridView_Hoteles.TabIndex = 3;
            // 
            // ID_Hotel
            // 
            this.ID_Hotel.HeaderText = "ID_Hotel";
            this.ID_Hotel.Name = "ID_Hotel";
            this.ID_Hotel.ReadOnly = true;
            this.ID_Hotel.Visible = false;
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            // 
            // Calle
            // 
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            // 
            // Nro_Calle
            // 
            this.Nro_Calle.HeaderText = "Nro_Calle";
            this.Nro_Calle.Name = "Nro_Calle";
            this.Nro_Calle.ReadOnly = true;
            // 
            // Cant_Estrellas
            // 
            this.Cant_Estrellas.HeaderText = "Cant_Estrellas";
            this.Cant_Estrellas.Name = "Cant_Estrellas";
            this.Cant_Estrellas.ReadOnly = true;
            // 
            // Recarga_Estrellas
            // 
            this.Recarga_Estrellas.HeaderText = "Recarga_Estrella";
            this.Recarga_Estrellas.Name = "Recarga_Estrellas";
            this.Recarga_Estrellas.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Pais
            // 
            this.Pais.HeaderText = "Pais";
            this.Pais.Name = "Pais";
            this.Pais.ReadOnly = true;
            // 
            // Fecha_Creacion
            // 
            this.Fecha_Creacion.HeaderText = "Fecha_Creacion";
            this.Fecha_Creacion.Name = "Fecha_Creacion";
            this.Fecha_Creacion.ReadOnly = true;
            // 
            // comboBox_Estrellas
            // 
            this.comboBox_Estrellas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Estrellas.FormattingEnabled = true;
            this.comboBox_Estrellas.Location = new System.Drawing.Point(152, 56);
            this.comboBox_Estrellas.Name = "comboBox_Estrellas";
            this.comboBox_Estrellas.Size = new System.Drawing.Size(208, 21);
            this.comboBox_Estrellas.TabIndex = 4;
            // 
            // comboBox_Ciudad
            // 
            this.comboBox_Ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Ciudad.FormattingEnabled = true;
            this.comboBox_Ciudad.Location = new System.Drawing.Point(152, 88);
            this.comboBox_Ciudad.Name = "comboBox_Ciudad";
            this.comboBox_Ciudad.Size = new System.Drawing.Size(208, 21);
            this.comboBox_Ciudad.TabIndex = 5;
            // 
            // comboBox_Pais
            // 
            this.comboBox_Pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Pais.FormattingEnabled = true;
            this.comboBox_Pais.Location = new System.Drawing.Point(152, 121);
            this.comboBox_Pais.Name = "comboBox_Pais";
            this.comboBox_Pais.Size = new System.Drawing.Size(208, 21);
            this.comboBox_Pais.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cantidad De Estrellas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ciudad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pais";
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(151, 148);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(209, 26);
            this.button_Filtrar.TabIndex = 10;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // button_Alta
            // 
            this.button_Alta.Location = new System.Drawing.Point(7, 387);
            this.button_Alta.Name = "button_Alta";
            this.button_Alta.Size = new System.Drawing.Size(86, 23);
            this.button_Alta.TabIndex = 11;
            this.button_Alta.Text = "Alta";
            this.button_Alta.UseVisualStyleBackColor = true;
            this.button_Alta.Click += new System.EventHandler(this.button_Alta_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "User Logeado";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(151, 12);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.ReadOnly = true;
            this.textBox_User.Size = new System.Drawing.Size(209, 20);
            this.textBox_User.TabIndex = 14;
            // 
            // ScreenHoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 433);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Alta);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Pais);
            this.Controls.Add(this.comboBox_Ciudad);
            this.Controls.Add(this.comboBox_Estrellas);
            this.Controls.Add(this.dataGridView_Hoteles);
            this.Controls.Add(this.button_Baja);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.button_Cerrar);
            this.Name = "ScreenHoteles";
            this.Text = "Administración de Hoteles";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Hoteles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cerrar;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Baja;
        private System.Windows.Forms.DataGridView dataGridView_Hoteles;
        private System.Windows.Forms.ComboBox comboBox_Estrellas;
        private System.Windows.Forms.ComboBox comboBox_Ciudad;
        private System.Windows.Forms.ComboBox comboBox_Pais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant_Estrellas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recarga_Estrellas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Creacion;
        private System.Windows.Forms.Button button_Alta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_User;
    }
}