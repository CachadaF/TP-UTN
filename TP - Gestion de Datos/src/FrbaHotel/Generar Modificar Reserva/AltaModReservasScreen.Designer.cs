namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class AltaModReservasScreen
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
            this.panel_Hoteles = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Hoteles = new System.Windows.Forms.ComboBox();
            this.maskedTextBox_Hotel = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Cerrar = new System.Windows.Forms.Button();
            this.maskedTextBox_Tipo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Cantidad = new System.Windows.Forms.ComboBox();
            this.dataGridView_Habitaciones = new System.Windows.Forms.DataGridView();
            this.ID_Habitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baja_Logica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Habitaciones = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Aceptar_Habs = new System.Windows.Forms.Button();
            this.dataGridView_Seleccionadas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_SelecHab = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_Regimenes = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_ValTotalRes = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBox_PrecioDia = new System.Windows.Forms.MaskedTextBox();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.comboBox_Regimenes = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.maskedTextBox_Usuario = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.panel_Cantidad = new System.Windows.Forms.Panel();
            this.button_SeleccionarFecha = new System.Windows.Forms.Button();
            this.panel_Fecha = new System.Windows.Forms.Panel();
            this.panel_Hoteles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Habitaciones)).BeginInit();
            this.panel_Habitaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Seleccionadas)).BeginInit();
            this.panel_Regimenes.SuspendLayout();
            this.panel_Cantidad.SuspendLayout();
            this.panel_Fecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Hoteles
            // 
            this.panel_Hoteles.Controls.Add(this.label1);
            this.panel_Hoteles.Controls.Add(this.comboBox_Hoteles);
            this.panel_Hoteles.Location = new System.Drawing.Point(450, 12);
            this.panel_Hoteles.Name = "panel_Hoteles";
            this.panel_Hoteles.Size = new System.Drawing.Size(381, 39);
            this.panel_Hoteles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione Hotel";
            // 
            // comboBox_Hoteles
            // 
            this.comboBox_Hoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Hoteles.FormattingEnabled = true;
            this.comboBox_Hoteles.Location = new System.Drawing.Point(105, 9);
            this.comboBox_Hoteles.Name = "comboBox_Hoteles";
            this.comboBox_Hoteles.Size = new System.Drawing.Size(273, 21);
            this.comboBox_Hoteles.TabIndex = 0;
            this.comboBox_Hoteles.SelectedIndexChanged += new System.EventHandler(this.comboBox_Hoteles_SelectedIndexChanged);
            // 
            // maskedTextBox_Hotel
            // 
            this.maskedTextBox_Hotel.Location = new System.Drawing.Point(555, 57);
            this.maskedTextBox_Hotel.Name = "maskedTextBox_Hotel";
            this.maskedTextBox_Hotel.ReadOnly = true;
            this.maskedTextBox_Hotel.Size = new System.Drawing.Size(273, 20);
            this.maskedTextBox_Hotel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hotel Elegido";
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(160, 12);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(273, 20);
            this.dateTimePicker_Inicio.TabIndex = 3;
            this.dateTimePicker_Inicio.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(160, 41);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(273, 20);
            this.dateTimePicker_Fin.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Inicio de Reserva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha Fin de Reserva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cantidad Personas";
            // 
            // button_Cerrar
            // 
            this.button_Cerrar.Location = new System.Drawing.Point(672, 482);
            this.button_Cerrar.Name = "button_Cerrar";
            this.button_Cerrar.Size = new System.Drawing.Size(156, 23);
            this.button_Cerrar.TabIndex = 9;
            this.button_Cerrar.Text = "Cerrar";
            this.button_Cerrar.UseVisualStyleBackColor = true;
            this.button_Cerrar.Click += new System.EventHandler(this.button_Cerrar_Click_1);
            // 
            // maskedTextBox_Tipo
            // 
            this.maskedTextBox_Tipo.Location = new System.Drawing.Point(610, 6);
            this.maskedTextBox_Tipo.Name = "maskedTextBox_Tipo";
            this.maskedTextBox_Tipo.ReadOnly = true;
            this.maskedTextBox_Tipo.Size = new System.Drawing.Size(210, 20);
            this.maskedTextBox_Tipo.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(419, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo de Habitacion Correspondiente";
            // 
            // comboBox_Cantidad
            // 
            this.comboBox_Cantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Cantidad.FormattingEnabled = true;
            this.comboBox_Cantidad.Location = new System.Drawing.Point(126, 10);
            this.comboBox_Cantidad.Name = "comboBox_Cantidad";
            this.comboBox_Cantidad.Size = new System.Drawing.Size(276, 21);
            this.comboBox_Cantidad.TabIndex = 12;
            this.comboBox_Cantidad.SelectedIndexChanged += new System.EventHandler(this.comboBox_Cantidad_SelectedIndexChanged);
            // 
            // dataGridView_Habitaciones
            // 
            this.dataGridView_Habitaciones.AllowUserToAddRows = false;
            this.dataGridView_Habitaciones.AllowUserToDeleteRows = false;
            this.dataGridView_Habitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Habitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Habitacion,
            this.ID_Hotel,
            this.Numero,
            this.Piso,
            this.Codigo_Tipo,
            this.Frente,
            this.Baja_Logica});
            this.dataGridView_Habitaciones.Location = new System.Drawing.Point(3, 35);
            this.dataGridView_Habitaciones.Name = "dataGridView_Habitaciones";
            this.dataGridView_Habitaciones.Size = new System.Drawing.Size(351, 159);
            this.dataGridView_Habitaciones.TabIndex = 13;
            // 
            // ID_Habitacion
            // 
            this.ID_Habitacion.HeaderText = "ID_Habitacion";
            this.ID_Habitacion.Name = "ID_Habitacion";
            this.ID_Habitacion.Visible = false;
            // 
            // ID_Hotel
            // 
            this.ID_Hotel.HeaderText = "ID_Hotel";
            this.ID_Hotel.Name = "ID_Hotel";
            this.ID_Hotel.Visible = false;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            // 
            // Codigo_Tipo
            // 
            this.Codigo_Tipo.HeaderText = "Codigo_Tipo";
            this.Codigo_Tipo.Name = "Codigo_Tipo";
            this.Codigo_Tipo.Visible = false;
            // 
            // Frente
            // 
            this.Frente.HeaderText = "Frente";
            this.Frente.Name = "Frente";
            // 
            // Baja_Logica
            // 
            this.Baja_Logica.HeaderText = "Baja_Logica";
            this.Baja_Logica.Name = "Baja_Logica";
            this.Baja_Logica.Visible = false;
            // 
            // panel_Habitaciones
            // 
            this.panel_Habitaciones.Controls.Add(this.label10);
            this.panel_Habitaciones.Controls.Add(this.button_Aceptar_Habs);
            this.panel_Habitaciones.Controls.Add(this.dataGridView_Seleccionadas);
            this.panel_Habitaciones.Controls.Add(this.button_SelecHab);
            this.panel_Habitaciones.Controls.Add(this.label7);
            this.panel_Habitaciones.Controls.Add(this.dataGridView_Habitaciones);
            this.panel_Habitaciones.Location = new System.Drawing.Point(8, 169);
            this.panel_Habitaciones.Name = "panel_Habitaciones";
            this.panel_Habitaciones.Size = new System.Drawing.Size(823, 197);
            this.panel_Habitaciones.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Habitaciones Seleccionadas";
            // 
            // button_Aceptar_Habs
            // 
            this.button_Aceptar_Habs.Location = new System.Drawing.Point(369, 149);
            this.button_Aceptar_Habs.Name = "button_Aceptar_Habs";
            this.button_Aceptar_Habs.Size = new System.Drawing.Size(83, 45);
            this.button_Aceptar_Habs.TabIndex = 21;
            this.button_Aceptar_Habs.Text = "Aceptar Habitaciones";
            this.button_Aceptar_Habs.UseVisualStyleBackColor = true;
            this.button_Aceptar_Habs.Click += new System.EventHandler(this.button_Aceptar_Habs_Click);
            // 
            // dataGridView_Seleccionadas
            // 
            this.dataGridView_Seleccionadas.AllowUserToAddRows = false;
            this.dataGridView_Seleccionadas.AllowUserToDeleteRows = false;
            this.dataGridView_Seleccionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Seleccionadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataGridView_Seleccionadas.Location = new System.Drawing.Point(467, 35);
            this.dataGridView_Seleccionadas.Name = "dataGridView_Seleccionadas";
            this.dataGridView_Seleccionadas.Size = new System.Drawing.Size(353, 159);
            this.dataGridView_Seleccionadas.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID_Habitacion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "ID_Hotel";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Numero";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Piso";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Codigo_Tipo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Frente";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Baja_Logica";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // button_SelecHab
            // 
            this.button_SelecHab.Location = new System.Drawing.Point(369, 83);
            this.button_SelecHab.Name = "button_SelecHab";
            this.button_SelecHab.Size = new System.Drawing.Size(83, 49);
            this.button_SelecHab.TabIndex = 15;
            this.button_SelecHab.Text = "Seleccionar Habitacion";
            this.button_SelecHab.UseVisualStyleBackColor = true;
            this.button_SelecHab.Click += new System.EventHandler(this.button_SelecHab_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Habitaciones Disponibles";
            // 
            // panel_Regimenes
            // 
            this.panel_Regimenes.Controls.Add(this.label8);
            this.panel_Regimenes.Controls.Add(this.maskedTextBox_ValTotalRes);
            this.panel_Regimenes.Controls.Add(this.label11);
            this.panel_Regimenes.Controls.Add(this.maskedTextBox_PrecioDia);
            this.panel_Regimenes.Controls.Add(this.button_Aceptar);
            this.panel_Regimenes.Controls.Add(this.comboBox_Regimenes);
            this.panel_Regimenes.Controls.Add(this.label9);
            this.panel_Regimenes.Location = new System.Drawing.Point(8, 372);
            this.panel_Regimenes.Name = "panel_Regimenes";
            this.panel_Regimenes.Size = new System.Drawing.Size(491, 146);
            this.panel_Regimenes.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Valor Total Reservado";
            // 
            // maskedTextBox_ValTotalRes
            // 
            this.maskedTextBox_ValTotalRes.Location = new System.Drawing.Point(124, 103);
            this.maskedTextBox_ValTotalRes.Name = "maskedTextBox_ValTotalRes";
            this.maskedTextBox_ValTotalRes.ReadOnly = true;
            this.maskedTextBox_ValTotalRes.Size = new System.Drawing.Size(171, 20);
            this.maskedTextBox_ValTotalRes.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Valor Total por Dia";
            // 
            // maskedTextBox_PrecioDia
            // 
            this.maskedTextBox_PrecioDia.Location = new System.Drawing.Point(124, 62);
            this.maskedTextBox_PrecioDia.Name = "maskedTextBox_PrecioDia";
            this.maskedTextBox_PrecioDia.ReadOnly = true;
            this.maskedTextBox_PrecioDia.Size = new System.Drawing.Size(171, 20);
            this.maskedTextBox_PrecioDia.TabIndex = 2;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(330, 62);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(131, 61);
            this.button_Aceptar.TabIndex = 16;
            this.button_Aceptar.Text = "Aceptar Reserva";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // comboBox_Regimenes
            // 
            this.comboBox_Regimenes.FormattingEnabled = true;
            this.comboBox_Regimenes.Location = new System.Drawing.Point(124, 22);
            this.comboBox_Regimenes.Name = "comboBox_Regimenes";
            this.comboBox_Regimenes.Size = new System.Drawing.Size(171, 21);
            this.comboBox_Regimenes.TabIndex = 1;
            this.comboBox_Regimenes.SelectedValueChanged += new System.EventHandler(this.comboBox_Regimenes_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Regimen";
            // 
            // maskedTextBox_Usuario
            // 
            this.maskedTextBox_Usuario.Location = new System.Drawing.Point(555, 98);
            this.maskedTextBox_Usuario.Name = "maskedTextBox_Usuario";
            this.maskedTextBox_Usuario.ReadOnly = true;
            this.maskedTextBox_Usuario.Size = new System.Drawing.Size(273, 20);
            this.maskedTextBox_Usuario.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(506, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Usuario";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(672, 426);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(156, 23);
            this.button_Cancelar.TabIndex = 19;
            this.button_Cancelar.Text = "Cancelar Actual";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // panel_Cantidad
            // 
            this.panel_Cantidad.Controls.Add(this.comboBox_Cantidad);
            this.panel_Cantidad.Controls.Add(this.label5);
            this.panel_Cantidad.Controls.Add(this.maskedTextBox_Tipo);
            this.panel_Cantidad.Controls.Add(this.label6);
            this.panel_Cantidad.Location = new System.Drawing.Point(8, 129);
            this.panel_Cantidad.Name = "panel_Cantidad";
            this.panel_Cantidad.Size = new System.Drawing.Size(828, 34);
            this.panel_Cantidad.TabIndex = 20;
            // 
            // button_SeleccionarFecha
            // 
            this.button_SeleccionarFecha.Location = new System.Drawing.Point(160, 77);
            this.button_SeleccionarFecha.Name = "button_SeleccionarFecha";
            this.button_SeleccionarFecha.Size = new System.Drawing.Size(271, 21);
            this.button_SeleccionarFecha.TabIndex = 21;
            this.button_SeleccionarFecha.Text = "Setear Fecha";
            this.button_SeleccionarFecha.UseVisualStyleBackColor = true;
            this.button_SeleccionarFecha.Click += new System.EventHandler(this.button_SeleccionarFecha_Click);
            // 
            // panel_Fecha
            // 
            this.panel_Fecha.Controls.Add(this.dateTimePicker_Inicio);
            this.panel_Fecha.Controls.Add(this.button_SeleccionarFecha);
            this.panel_Fecha.Controls.Add(this.dateTimePicker_Fin);
            this.panel_Fecha.Controls.Add(this.label4);
            this.panel_Fecha.Controls.Add(this.label3);
            this.panel_Fecha.Location = new System.Drawing.Point(8, 12);
            this.panel_Fecha.Name = "panel_Fecha";
            this.panel_Fecha.Size = new System.Drawing.Size(436, 111);
            this.panel_Fecha.TabIndex = 22;
            // 
            // AltaModReservasScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 520);
            this.Controls.Add(this.panel_Fecha);
            this.Controls.Add(this.panel_Cantidad);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.maskedTextBox_Usuario);
            this.Controls.Add(this.panel_Regimenes);
            this.Controls.Add(this.panel_Habitaciones);
            this.Controls.Add(this.button_Cerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_Hotel);
            this.Controls.Add(this.panel_Hoteles);
            this.Name = "AltaModReservasScreen";
            this.Text = "Form1";
            this.panel_Hoteles.ResumeLayout(false);
            this.panel_Hoteles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Habitaciones)).EndInit();
            this.panel_Habitaciones.ResumeLayout(false);
            this.panel_Habitaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Seleccionadas)).EndInit();
            this.panel_Regimenes.ResumeLayout(false);
            this.panel_Regimenes.PerformLayout();
            this.panel_Cantidad.ResumeLayout(false);
            this.panel_Cantidad.PerformLayout();
            this.panel_Fecha.ResumeLayout(false);
            this.panel_Fecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Hoteles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Hoteles;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Hotel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Cerrar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Tipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Cantidad;
        private System.Windows.Forms.DataGridView dataGridView_Habitaciones;
        private System.Windows.Forms.Panel panel_Habitaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_SelecHab;
        private System.Windows.Forms.Panel panel_Regimenes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PrecioDia;
        private System.Windows.Forms.ComboBox comboBox_Regimenes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Usuario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ValTotalRes;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.DataGridView dataGridView_Seleccionadas;
        private System.Windows.Forms.Button button_Aceptar_Habs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel_Cantidad;
        private System.Windows.Forms.Button button_SeleccionarFecha;
        private System.Windows.Forms.Panel panel_Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Habitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baja_Logica;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}