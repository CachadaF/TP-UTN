namespace FrbaHotel.Registrar_Estadia
{
    partial class EstadiaScreen
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
            this.textBox_codigoReserva = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_huesped = new System.Windows.Forms.DataGridView();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_guardarIN = new System.Windows.Forms.Button();
            this.button_reg_huesped = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.button_fact_estadia = new System.Windows.Forms.Button();
            this.dataGridView_consum = new System.Windows.Forms.DataGridView();
            this.button_guardarOUT = new System.Windows.Forms.Button();
            this.button_reg_consum = new System.Windows.Forms.Button();
            this.dateTimePicker_fOut = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.dataGridView_reserva = new System.Windows.Forms.DataGridView();
            this.Fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant_noches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant_pers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_huesped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_consum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reserva)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código de Reserva";
            // 
            // textBox_codigoReserva
            // 
            this.textBox_codigoReserva.Location = new System.Drawing.Point(5, 25);
            this.textBox_codigoReserva.Name = "textBox_codigoReserva";
            this.textBox_codigoReserva.Size = new System.Drawing.Size(98, 20);
            this.textBox_codigoReserva.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(5, 121);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_huesped);
            this.splitContainer1.Panel1.Controls.Add(this.button_guardarIN);
            this.splitContainer1.Panel1.Controls.Add(this.button_reg_huesped);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker_fecha);
            this.splitContainer1.Panel1.Enabled = false;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_fact_estadia);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_consum);
            this.splitContainer1.Panel2.Controls.Add(this.button_guardarOUT);
            this.splitContainer1.Panel2.Controls.Add(this.button_reg_consum);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker_fOut);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(444, 342);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView_huesped
            // 
            this.dataGridView_huesped.AllowUserToAddRows = false;
            this.dataGridView_huesped.AllowUserToDeleteRows = false;
            this.dataGridView_huesped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_huesped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Apellido,
            this.Nombre});
            this.dataGridView_huesped.Location = new System.Drawing.Point(7, 101);
            this.dataGridView_huesped.MultiSelect = false;
            this.dataGridView_huesped.Name = "dataGridView_huesped";
            this.dataGridView_huesped.ReadOnly = true;
            this.dataGridView_huesped.RowHeadersVisible = false;
            this.dataGridView_huesped.Size = new System.Drawing.Size(204, 188);
            this.dataGridView_huesped.TabIndex = 63;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // button_guardarIN
            // 
            this.button_guardarIN.Enabled = false;
            this.button_guardarIN.Location = new System.Drawing.Point(44, 314);
            this.button_guardarIN.Name = "button_guardarIN";
            this.button_guardarIN.Size = new System.Drawing.Size(125, 25);
            this.button_guardarIN.TabIndex = 62;
            this.button_guardarIN.Text = "Guardar";
            this.button_guardarIN.UseVisualStyleBackColor = true;
            this.button_guardarIN.Click += new System.EventHandler(this.buttonGuardarIN_Click);
            // 
            // button_reg_huesped
            // 
            this.button_reg_huesped.Enabled = false;
            this.button_reg_huesped.Location = new System.Drawing.Point(44, 70);
            this.button_reg_huesped.Name = "button_reg_huesped";
            this.button_reg_huesped.Size = new System.Drawing.Size(125, 25);
            this.button_reg_huesped.TabIndex = 61;
            this.button_reg_huesped.Text = "Registrar Huesped";
            this.button_reg_huesped.UseVisualStyleBackColor = true;
            this.button_reg_huesped.Click += new System.EventHandler(this.buttonRegistrarHuesped_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Check-IN";
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.Enabled = false;
            this.dateTimePicker_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(60, 33);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker_fecha.TabIndex = 58;
            this.dateTimePicker_fecha.Value = new System.DateTime(2014, 10, 8, 13, 6, 14, 0);
            // 
            // button_fact_estadia
            // 
            this.button_fact_estadia.Enabled = false;
            this.button_fact_estadia.Location = new System.Drawing.Point(53, 314);
            this.button_fact_estadia.Name = "button_fact_estadia";
            this.button_fact_estadia.Size = new System.Drawing.Size(125, 25);
            this.button_fact_estadia.TabIndex = 66;
            this.button_fact_estadia.Text = "Facturar Estadia";
            this.button_fact_estadia.UseVisualStyleBackColor = true;
            this.button_fact_estadia.Click += new System.EventHandler(this.button_fact_estadia_Click);
            // 
            // dataGridView_consum
            // 
            this.dataGridView_consum.AllowUserToAddRows = false;
            this.dataGridView_consum.AllowUserToDeleteRows = false;
            this.dataGridView_consum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_consum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.Precio});
            this.dataGridView_consum.Location = new System.Drawing.Point(21, 101);
            this.dataGridView_consum.Name = "dataGridView_consum";
            this.dataGridView_consum.ReadOnly = true;
            this.dataGridView_consum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_consum.Size = new System.Drawing.Size(178, 157);
            this.dataGridView_consum.TabIndex = 64;
            // 
            // button_guardarOUT
            // 
            this.button_guardarOUT.Enabled = false;
            this.button_guardarOUT.Location = new System.Drawing.Point(53, 264);
            this.button_guardarOUT.Name = "button_guardarOUT";
            this.button_guardarOUT.Size = new System.Drawing.Size(125, 25);
            this.button_guardarOUT.TabIndex = 63;
            this.button_guardarOUT.Text = "Cerrar Estadía";
            this.button_guardarOUT.UseVisualStyleBackColor = true;
            this.button_guardarOUT.Click += new System.EventHandler(this.buttonGuardarOUT_Click);
            // 
            // button_reg_consum
            // 
            this.button_reg_consum.Location = new System.Drawing.Point(53, 70);
            this.button_reg_consum.Name = "button_reg_consum";
            this.button_reg_consum.Size = new System.Drawing.Size(125, 25);
            this.button_reg_consum.TabIndex = 60;
            this.button_reg_consum.Text = "Registrar Consumibles";
            this.button_reg_consum.UseVisualStyleBackColor = true;
            this.button_reg_consum.Click += new System.EventHandler(this.buttonRegConsumibles_Click);
            // 
            // dateTimePicker_fOut
            // 
            this.dateTimePicker_fOut.Enabled = false;
            this.dateTimePicker_fOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fOut.Location = new System.Drawing.Point(64, 33);
            this.dateTimePicker_fOut.Name = "dateTimePicker_fOut";
            this.dateTimePicker_fOut.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker_fOut.TabIndex = 59;
            this.dateTimePicker_fOut.Value = new System.DateTime(2014, 10, 8, 13, 6, 14, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Check-OUT";
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(367, 20);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(82, 28);
            this.button_buscar.TabIndex = 3;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridView_reserva
            // 
            this.dataGridView_reserva.AllowUserToAddRows = false;
            this.dataGridView_reserva.AllowUserToDeleteRows = false;
            this.dataGridView_reserva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_reserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reserva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha_inicio,
            this.cant_noches,
            this.cant_pers});
            this.dataGridView_reserva.Location = new System.Drawing.Point(5, 54);
            this.dataGridView_reserva.Name = "dataGridView_reserva";
            this.dataGridView_reserva.ReadOnly = true;
            this.dataGridView_reserva.RowHeadersVisible = false;
            this.dataGridView_reserva.Size = new System.Drawing.Size(444, 61);
            this.dataGridView_reserva.TabIndex = 4;
            // 
            // Fecha_inicio
            // 
            this.Fecha_inicio.HeaderText = "Fecha Inicio";
            this.Fecha_inicio.Name = "Fecha_inicio";
            this.Fecha_inicio.ReadOnly = true;
            // 
            // cant_noches
            // 
            this.cant_noches.HeaderText = "Noches";
            this.cant_noches.Name = "cant_noches";
            this.cant_noches.ReadOnly = true;
            // 
            // cant_pers
            // 
            this.cant_pers.HeaderText = "Personas";
            this.cant_pers.Name = "cant_pers";
            this.cant_pers.ReadOnly = true;
            // 
            // button_cerrar
            // 
            this.button_cerrar.Location = new System.Drawing.Point(368, 478);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(81, 25);
            this.button_cerrar.TabIndex = 64;
            this.button_cerrar.Text = "Cerrar";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.FillWeight = 80F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // EstadiaScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 515);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.dataGridView_reserva);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox_codigoReserva);
            this.Controls.Add(this.label1);
            this.Name = "EstadiaScreen";
            this.Text = "Registro de estadia";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_huesped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_consum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_codigoReserva;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Button button_reg_consum;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fOut;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button button_reg_huesped;
        private System.Windows.Forms.Button button_guardarIN;
        private System.Windows.Forms.DataGridView dataGridView_reserva;
        private System.Windows.Forms.DataGridView dataGridView_huesped;
        private System.Windows.Forms.DataGridView dataGridView_consum;
        private System.Windows.Forms.Button button_guardarOUT;
        private System.Windows.Forms.Button button_fact_estadia;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant_noches;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant_pers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
    }
}