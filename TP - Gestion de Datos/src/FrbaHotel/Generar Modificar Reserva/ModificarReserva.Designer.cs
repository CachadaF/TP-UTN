﻿namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ModificarReserva
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
            this.numericUpDown_CodRes = new System.Windows.Forms.NumericUpDown();
            this.panel_Nro = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_FchIni = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_FchFin = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker_FchIni = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FchFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.comboBox_Cantidad = new System.Windows.Forms.ComboBox();
            this.panel_Fecha = new System.Windows.Forms.Panel();
            this.button_CambiarHabs = new System.Windows.Forms.Button();
            this.button_CambiarFechas = new System.Windows.Forms.Button();
            this.button_JumpARegimen = new System.Windows.Forms.Button();
            this.button_AcepVals = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_Habitaciones = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView_HabsDispo = new System.Windows.Forms.DataGridView();
            this.dataGridView_Habitaciones = new System.Windows.Forms.DataGridView();
            this.button_Aceptar_Habs = new System.Windows.Forms.Button();
            this.button_QuitarHab = new System.Windows.Forms.Button();
            this.button_Selec = new System.Windows.Forms.Button();
            this.panel_Regimen = new System.Windows.Forms.Panel();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.maskedTextBox_Total = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_ValDiario = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Regimenes = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.maskedTextBox_Usuario = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.maskedTextBox_Hotel = new System.Windows.Forms.MaskedTextBox();
            this.panel_Hoteles = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_Hoteles = new System.Windows.Forms.ComboBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.button_CancelarModif = new System.Windows.Forms.Button();
            this.panel_Capacidad = new System.Windows.Forms.Panel();
            this.ID_Habitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baja_Logica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Hot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baja_Logic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CodRes)).BeginInit();
            this.panel_Nro.SuspendLayout();
            this.panel_Fecha.SuspendLayout();
            this.panel_Habitaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HabsDispo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Habitaciones)).BeginInit();
            this.panel_Regimen.SuspendLayout();
            this.panel_Hoteles.SuspendLayout();
            this.panel_Capacidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de Reserva";
            // 
            // numericUpDown_CodRes
            // 
            this.numericUpDown_CodRes.Location = new System.Drawing.Point(380, 60);
            this.numericUpDown_CodRes.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_CodRes.Name = "numericUpDown_CodRes";
            this.numericUpDown_CodRes.Size = new System.Drawing.Size(166, 20);
            this.numericUpDown_CodRes.TabIndex = 1;
            this.numericUpDown_CodRes.ValueChanged += new System.EventHandler(this.numericUpDown_CodRes_ValueChanged);
            // 
            // panel_Nro
            // 
            this.panel_Nro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel_Nro.Controls.Add(this.label2);
            this.panel_Nro.ForeColor = System.Drawing.Color.White;
            this.panel_Nro.Location = new System.Drawing.Point(650, 62);
            this.panel_Nro.Name = "panel_Nro";
            this.panel_Nro.Size = new System.Drawing.Size(227, 18);
            this.panel_Nro.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nro Invalido";
            // 
            // maskedTextBox_FchIni
            // 
            this.maskedTextBox_FchIni.Location = new System.Drawing.Point(491, 14);
            this.maskedTextBox_FchIni.Name = "maskedTextBox_FchIni";
            this.maskedTextBox_FchIni.ReadOnly = true;
            this.maskedTextBox_FchIni.Size = new System.Drawing.Size(329, 20);
            this.maskedTextBox_FchIni.TabIndex = 3;
            // 
            // maskedTextBox_FchFin
            // 
            this.maskedTextBox_FchFin.Location = new System.Drawing.Point(491, 46);
            this.maskedTextBox_FchFin.Name = "maskedTextBox_FchFin";
            this.maskedTextBox_FchFin.ReadOnly = true;
            this.maskedTextBox_FchFin.Size = new System.Drawing.Size(329, 20);
            this.maskedTextBox_FchFin.TabIndex = 4;
            // 
            // dateTimePicker_FchIni
            // 
            this.dateTimePicker_FchIni.Location = new System.Drawing.Point(121, 15);
            this.dateTimePicker_FchIni.Name = "dateTimePicker_FchIni";
            this.dateTimePicker_FchIni.Size = new System.Drawing.Size(321, 20);
            this.dateTimePicker_FchIni.TabIndex = 5;
            // 
            // dateTimePicker_FchFin
            // 
            this.dateTimePicker_FchFin.Location = new System.Drawing.Point(121, 48);
            this.dateTimePicker_FchFin.Name = "dateTimePicker_FchFin";
            this.dateTimePicker_FchFin.Size = new System.Drawing.Size(321, 20);
            this.dateTimePicker_FchFin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Fin";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(686, 469);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(200, 23);
            this.button_Cancelar.TabIndex = 10;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // comboBox_Cantidad
            // 
            this.comboBox_Cantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Cantidad.FormattingEnabled = true;
            this.comboBox_Cantidad.Location = new System.Drawing.Point(91, 8);
            this.comboBox_Cantidad.Name = "comboBox_Cantidad";
            this.comboBox_Cantidad.Size = new System.Drawing.Size(139, 21);
            this.comboBox_Cantidad.TabIndex = 11;
            // 
            // panel_Fecha
            // 
            this.panel_Fecha.Controls.Add(this.button_CambiarHabs);
            this.panel_Fecha.Controls.Add(this.button_CambiarFechas);
            this.panel_Fecha.Controls.Add(this.button_JumpARegimen);
            this.panel_Fecha.Controls.Add(this.dateTimePicker_FchIni);
            this.panel_Fecha.Controls.Add(this.maskedTextBox_FchIni);
            this.panel_Fecha.Controls.Add(this.maskedTextBox_FchFin);
            this.panel_Fecha.Controls.Add(this.dateTimePicker_FchFin);
            this.panel_Fecha.Controls.Add(this.label4);
            this.panel_Fecha.Controls.Add(this.label3);
            this.panel_Fecha.Location = new System.Drawing.Point(15, 95);
            this.panel_Fecha.Name = "panel_Fecha";
            this.panel_Fecha.Size = new System.Drawing.Size(862, 132);
            this.panel_Fecha.TabIndex = 12;
            // 
            // button_CambiarHabs
            // 
            this.button_CambiarHabs.Location = new System.Drawing.Point(303, 91);
            this.button_CambiarHabs.Name = "button_CambiarHabs";
            this.button_CambiarHabs.Size = new System.Drawing.Size(195, 28);
            this.button_CambiarHabs.TabIndex = 19;
            this.button_CambiarHabs.Text = "Cambiar Habitacion Solamente";
            this.button_CambiarHabs.UseVisualStyleBackColor = true;
            this.button_CambiarHabs.Click += new System.EventHandler(this.button_CambiarHabs_Click);
            // 
            // button_CambiarFechas
            // 
            this.button_CambiarFechas.Location = new System.Drawing.Point(46, 91);
            this.button_CambiarFechas.Name = "button_CambiarFechas";
            this.button_CambiarFechas.Size = new System.Drawing.Size(187, 28);
            this.button_CambiarFechas.TabIndex = 18;
            this.button_CambiarFechas.Text = "Cambiar Fechas";
            this.button_CambiarFechas.UseVisualStyleBackColor = true;
            this.button_CambiarFechas.Click += new System.EventHandler(this.button_CambiarFechas_Click);
            // 
            // button_JumpARegimen
            // 
            this.button_JumpARegimen.Location = new System.Drawing.Point(531, 91);
            this.button_JumpARegimen.Name = "button_JumpARegimen";
            this.button_JumpARegimen.Size = new System.Drawing.Size(199, 28);
            this.button_JumpARegimen.TabIndex = 17;
            this.button_JumpARegimen.Text = "Cambiar Regimen Solamente";
            this.button_JumpARegimen.UseVisualStyleBackColor = true;
            this.button_JumpARegimen.Click += new System.EventHandler(this.button_JumpARegimen_Click);
            // 
            // button_AcepVals
            // 
            this.button_AcepVals.Location = new System.Drawing.Point(303, 6);
            this.button_AcepVals.Name = "button_AcepVals";
            this.button_AcepVals.Size = new System.Drawing.Size(139, 23);
            this.button_AcepVals.TabIndex = 16;
            this.button_AcepVals.Text = "Aceptar Valores";
            this.button_AcepVals.UseVisualStyleBackColor = true;
            this.button_AcepVals.Click += new System.EventHandler(this.button_AcepVals_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Capacidad";
            // 
            // panel_Habitaciones
            // 
            this.panel_Habitaciones.Controls.Add(this.label13);
            this.panel_Habitaciones.Controls.Add(this.label11);
            this.panel_Habitaciones.Controls.Add(this.dataGridView_HabsDispo);
            this.panel_Habitaciones.Controls.Add(this.dataGridView_Habitaciones);
            this.panel_Habitaciones.Controls.Add(this.button_Aceptar_Habs);
            this.panel_Habitaciones.Controls.Add(this.button_QuitarHab);
            this.panel_Habitaciones.Controls.Add(this.button_Selec);
            this.panel_Habitaciones.Location = new System.Drawing.Point(11, 275);
            this.panel_Habitaciones.Name = "panel_Habitaciones";
            this.panel_Habitaciones.Size = new System.Drawing.Size(669, 231);
            this.panel_Habitaciones.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Habitaciones Disponibles";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(383, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Habitaciones Estado Actual";
            // 
            // dataGridView_HabsDispo
            // 
            this.dataGridView_HabsDispo.AllowUserToAddRows = false;
            this.dataGridView_HabsDispo.AllowUserToDeleteRows = false;
            this.dataGridView_HabsDispo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HabsDispo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Hab,
            this.ID_Hot,
            this.Num,
            this.Pi,
            this.Codigo_Tip,
            this.Frent,
            this.Baja_Logic});
            this.dataGridView_HabsDispo.Location = new System.Drawing.Point(3, 23);
            this.dataGridView_HabsDispo.Name = "dataGridView_HabsDispo";
            this.dataGridView_HabsDispo.Size = new System.Drawing.Size(308, 159);
            this.dataGridView_HabsDispo.TabIndex = 27;
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
            this.dataGridView_Habitaciones.Location = new System.Drawing.Point(339, 23);
            this.dataGridView_Habitaciones.Name = "dataGridView_Habitaciones";
            this.dataGridView_Habitaciones.Size = new System.Drawing.Size(305, 159);
            this.dataGridView_Habitaciones.TabIndex = 14;
            // 
            // button_Aceptar_Habs
            // 
            this.button_Aceptar_Habs.Location = new System.Drawing.Point(161, 188);
            this.button_Aceptar_Habs.Name = "button_Aceptar_Habs";
            this.button_Aceptar_Habs.Size = new System.Drawing.Size(150, 30);
            this.button_Aceptar_Habs.TabIndex = 4;
            this.button_Aceptar_Habs.Text = "Aceptar Habitaciones";
            this.button_Aceptar_Habs.UseVisualStyleBackColor = true;
            this.button_Aceptar_Habs.Click += new System.EventHandler(this.button_Aceptar_Habs_Click);
            // 
            // button_QuitarHab
            // 
            this.button_QuitarHab.Location = new System.Drawing.Point(18, 188);
            this.button_QuitarHab.Name = "button_QuitarHab";
            this.button_QuitarHab.Size = new System.Drawing.Size(120, 30);
            this.button_QuitarHab.TabIndex = 3;
            this.button_QuitarHab.Text = "Quitar Habitacion";
            this.button_QuitarHab.UseVisualStyleBackColor = true;
            this.button_QuitarHab.Click += new System.EventHandler(this.button_QuitarHab_Click);
            // 
            // button_Selec
            // 
            this.button_Selec.Location = new System.Drawing.Point(339, 188);
            this.button_Selec.Name = "button_Selec";
            this.button_Selec.Size = new System.Drawing.Size(162, 30);
            this.button_Selec.TabIndex = 1;
            this.button_Selec.Text = "Seleccionar Habitacion";
            this.button_Selec.UseVisualStyleBackColor = true;
            this.button_Selec.Click += new System.EventHandler(this.button_Selec_Click);
            // 
            // panel_Regimen
            // 
            this.panel_Regimen.Controls.Add(this.button_Aceptar);
            this.panel_Regimen.Controls.Add(this.maskedTextBox_Total);
            this.panel_Regimen.Controls.Add(this.maskedTextBox_ValDiario);
            this.panel_Regimen.Controls.Add(this.label8);
            this.panel_Regimen.Controls.Add(this.label7);
            this.panel_Regimen.Controls.Add(this.label6);
            this.panel_Regimen.Controls.Add(this.comboBox_Regimenes);
            this.panel_Regimen.Location = new System.Drawing.Point(686, 233);
            this.panel_Regimen.Name = "panel_Regimen";
            this.panel_Regimen.Size = new System.Drawing.Size(191, 179);
            this.panel_Regimen.TabIndex = 14;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(14, 144);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(170, 23);
            this.button_Aceptar.TabIndex = 7;
            this.button_Aceptar.Text = "Aceptar Cambios";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // maskedTextBox_Total
            // 
            this.maskedTextBox_Total.Location = new System.Drawing.Point(14, 109);
            this.maskedTextBox_Total.Name = "maskedTextBox_Total";
            this.maskedTextBox_Total.ReadOnly = true;
            this.maskedTextBox_Total.Size = new System.Drawing.Size(170, 20);
            this.maskedTextBox_Total.TabIndex = 6;
            // 
            // maskedTextBox_ValDiario
            // 
            this.maskedTextBox_ValDiario.Location = new System.Drawing.Point(14, 61);
            this.maskedTextBox_ValDiario.Name = "maskedTextBox_ValDiario";
            this.maskedTextBox_ValDiario.ReadOnly = true;
            this.maskedTextBox_ValDiario.Size = new System.Drawing.Size(164, 20);
            this.maskedTextBox_ValDiario.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Valor Habitacion Por Dia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Valor Total Nuevo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Regimen";
            // 
            // comboBox_Regimenes
            // 
            this.comboBox_Regimenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Regimenes.FormattingEnabled = true;
            this.comboBox_Regimenes.Location = new System.Drawing.Point(66, 13);
            this.comboBox_Regimenes.Name = "comboBox_Regimenes";
            this.comboBox_Regimenes.Size = new System.Drawing.Size(118, 21);
            this.comboBox_Regimenes.TabIndex = 0;
            this.comboBox_Regimenes.SelectedIndexChanged += new System.EventHandler(this.comboBox_Regimenes_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Usuario";
            // 
            // maskedTextBox_Usuario
            // 
            this.maskedTextBox_Usuario.Location = new System.Drawing.Point(99, 21);
            this.maskedTextBox_Usuario.Name = "maskedTextBox_Usuario";
            this.maskedTextBox_Usuario.ReadOnly = true;
            this.maskedTextBox_Usuario.Size = new System.Drawing.Size(149, 20);
            this.maskedTextBox_Usuario.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Hotel Elegido";
            // 
            // maskedTextBox_Hotel
            // 
            this.maskedTextBox_Hotel.Location = new System.Drawing.Point(99, 60);
            this.maskedTextBox_Hotel.Name = "maskedTextBox_Hotel";
            this.maskedTextBox_Hotel.ReadOnly = true;
            this.maskedTextBox_Hotel.Size = new System.Drawing.Size(149, 20);
            this.maskedTextBox_Hotel.TabIndex = 20;
            // 
            // panel_Hoteles
            // 
            this.panel_Hoteles.Controls.Add(this.label10);
            this.panel_Hoteles.Controls.Add(this.comboBox_Hoteles);
            this.panel_Hoteles.Location = new System.Drawing.Point(367, 12);
            this.panel_Hoteles.Name = "panel_Hoteles";
            this.panel_Hoteles.Size = new System.Drawing.Size(510, 34);
            this.panel_Hoteles.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Seleccione Hotel";
            // 
            // comboBox_Hoteles
            // 
            this.comboBox_Hoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Hoteles.FormattingEnabled = true;
            this.comboBox_Hoteles.Location = new System.Drawing.Point(195, 10);
            this.comboBox_Hoteles.Name = "comboBox_Hoteles";
            this.comboBox_Hoteles.Size = new System.Drawing.Size(273, 21);
            this.comboBox_Hoteles.TabIndex = 0;
            this.comboBox_Hoteles.SelectedIndexChanged += new System.EventHandler(this.comboBox_Hoteles_SelectedIndexChanged);
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(562, 60);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(82, 20);
            this.button_Buscar.TabIndex = 24;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // button_CancelarModif
            // 
            this.button_CancelarModif.Location = new System.Drawing.Point(686, 434);
            this.button_CancelarModif.Name = "button_CancelarModif";
            this.button_CancelarModif.Size = new System.Drawing.Size(200, 23);
            this.button_CancelarModif.TabIndex = 25;
            this.button_CancelarModif.Text = "Cancelar Modificacion";
            this.button_CancelarModif.UseVisualStyleBackColor = true;
            this.button_CancelarModif.Click += new System.EventHandler(this.button_CancelarModif_Click);
            // 
            // panel_Capacidad
            // 
            this.panel_Capacidad.Controls.Add(this.comboBox_Cantidad);
            this.panel_Capacidad.Controls.Add(this.button_AcepVals);
            this.panel_Capacidad.Controls.Add(this.label5);
            this.panel_Capacidad.Location = new System.Drawing.Point(15, 233);
            this.panel_Capacidad.Name = "panel_Capacidad";
            this.panel_Capacidad.Size = new System.Drawing.Size(646, 34);
            this.panel_Capacidad.TabIndex = 26;
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
            // ID_Hab
            // 
            this.ID_Hab.HeaderText = "ID_Habitacion";
            this.ID_Hab.Name = "ID_Hab";
            this.ID_Hab.Visible = false;
            // 
            // ID_Hot
            // 
            this.ID_Hot.HeaderText = "ID_Hotel";
            this.ID_Hot.Name = "ID_Hot";
            this.ID_Hot.Visible = false;
            // 
            // Num
            // 
            this.Num.HeaderText = "Numero";
            this.Num.Name = "Num";
            // 
            // Pi
            // 
            this.Pi.HeaderText = "Piso";
            this.Pi.Name = "Pi";
            // 
            // Codigo_Tip
            // 
            this.Codigo_Tip.HeaderText = "Codigo_Tipo";
            this.Codigo_Tip.Name = "Codigo_Tip";
            this.Codigo_Tip.Visible = false;
            // 
            // Frent
            // 
            this.Frent.HeaderText = "Frente";
            this.Frent.Name = "Frent";
            // 
            // Baja_Logic
            // 
            this.Baja_Logic.HeaderText = "Baja_Logica";
            this.Baja_Logic.Name = "Baja_Logic";
            this.Baja_Logic.Visible = false;
            // 
            // ModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 518);
            this.Controls.Add(this.panel_Capacidad);
            this.Controls.Add(this.button_CancelarModif);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.maskedTextBox_Usuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maskedTextBox_Hotel);
            this.Controls.Add(this.panel_Hoteles);
            this.Controls.Add(this.panel_Regimen);
            this.Controls.Add(this.panel_Habitaciones);
            this.Controls.Add(this.panel_Fecha);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.panel_Nro);
            this.Controls.Add(this.numericUpDown_CodRes);
            this.Controls.Add(this.label1);
            this.Name = "ModificarReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificarReserva";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CodRes)).EndInit();
            this.panel_Nro.ResumeLayout(false);
            this.panel_Nro.PerformLayout();
            this.panel_Fecha.ResumeLayout(false);
            this.panel_Fecha.PerformLayout();
            this.panel_Habitaciones.ResumeLayout(false);
            this.panel_Habitaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HabsDispo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Habitaciones)).EndInit();
            this.panel_Regimen.ResumeLayout(false);
            this.panel_Regimen.PerformLayout();
            this.panel_Hoteles.ResumeLayout(false);
            this.panel_Hoteles.PerformLayout();
            this.panel_Capacidad.ResumeLayout(false);
            this.panel_Capacidad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_CodRes;
        private System.Windows.Forms.Panel panel_Nro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FchIni;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FchFin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FchIni;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FchFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.ComboBox comboBox_Cantidad;
        private System.Windows.Forms.Panel panel_Fecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_AcepVals;
        private System.Windows.Forms.Panel panel_Habitaciones;
        private System.Windows.Forms.Button button_Selec;
        private System.Windows.Forms.Panel panel_Regimen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Regimenes;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Total;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ValDiario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Usuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Hotel;
        private System.Windows.Forms.Panel panel_Hoteles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_Hoteles;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Button button_CancelarModif;
        private System.Windows.Forms.Button button_JumpARegimen;
        private System.Windows.Forms.Button button_CambiarHabs;
        private System.Windows.Forms.Button button_CambiarFechas;
        private System.Windows.Forms.Button button_Aceptar_Habs;
        private System.Windows.Forms.Button button_QuitarHab;
        private System.Windows.Forms.Panel panel_Capacidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView_HabsDispo;
        private System.Windows.Forms.DataGridView dataGridView_Habitaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Habitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baja_Logica;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baja_Logic;
    }
}