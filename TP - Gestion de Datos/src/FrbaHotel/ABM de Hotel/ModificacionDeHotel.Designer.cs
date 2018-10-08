namespace FrbaHotel.ABM_de_Hotel
{
    partial class ModificacionDeHotel
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
            this.dataGridView_Regimenes = new System.Windows.Forms.DataGridView();
            this.ID_Regimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_CantEstre = new System.Windows.Forms.ComboBox();
            this.textBox_Ciudad = new System.Windows.Forms.TextBox();
            this.textBox_Calle = new System.Windows.Forms.TextBox();
            this.numericUpDown_Nrocalle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_RecargaEstre = new System.Windows.Forms.NumericUpDown();
            this.textBox_Telefono = new System.Windows.Forms.TextBox();
            this.textBox_Pais = new System.Windows.Forms.TextBox();
            this.maskedTextBox_Ciudad = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Calle = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Nrocalle = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_CantEstrellas = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_RecargaEstrellas = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Telefono = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Pais = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_FchCrea = new System.Windows.Forms.MaskedTextBox();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.comboBox_RegAdd = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_BorrarRegimen = new System.Windows.Forms.Button();
            this.comboBox_RegABorrar = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Regimenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Nrocalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RecargaEstre)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Regimenes
            // 
            this.dataGridView_Regimenes.AllowUserToAddRows = false;
            this.dataGridView_Regimenes.AllowUserToDeleteRows = false;
            this.dataGridView_Regimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Regimenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Regimen,
            this.Descripcion,
            this.Precio,
            this.Estado});
            this.dataGridView_Regimenes.Location = new System.Drawing.Point(11, 282);
            this.dataGridView_Regimenes.Name = "dataGridView_Regimenes";
            this.dataGridView_Regimenes.ReadOnly = true;
            this.dataGridView_Regimenes.Size = new System.Drawing.Size(256, 170);
            this.dataGridView_Regimenes.TabIndex = 0;
            // 
            // ID_Regimen
            // 
            this.ID_Regimen.HeaderText = "ID_Regimen";
            this.ID_Regimen.Name = "ID_Regimen";
            this.ID_Regimen.ReadOnly = true;
            this.ID_Regimen.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Calle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nro_Calle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cantidad de Estrellas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Recarga Estrellas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Pais";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Fecha de Creacion";
            // 
            // comboBox_CantEstre
            // 
            this.comboBox_CantEstre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CantEstre.FormattingEnabled = true;
            this.comboBox_CantEstre.Location = new System.Drawing.Point(120, 96);
            this.comboBox_CantEstre.Name = "comboBox_CantEstre";
            this.comboBox_CantEstre.Size = new System.Drawing.Size(194, 21);
            this.comboBox_CantEstre.TabIndex = 9;
            // 
            // textBox_Ciudad
            // 
            this.textBox_Ciudad.Location = new System.Drawing.Point(120, 6);
            this.textBox_Ciudad.Name = "textBox_Ciudad";
            this.textBox_Ciudad.Size = new System.Drawing.Size(194, 20);
            this.textBox_Ciudad.TabIndex = 10;
            // 
            // textBox_Calle
            // 
            this.textBox_Calle.Location = new System.Drawing.Point(120, 36);
            this.textBox_Calle.Name = "textBox_Calle";
            this.textBox_Calle.Size = new System.Drawing.Size(194, 20);
            this.textBox_Calle.TabIndex = 11;
            // 
            // numericUpDown_Nrocalle
            // 
            this.numericUpDown_Nrocalle.Location = new System.Drawing.Point(120, 65);
            this.numericUpDown_Nrocalle.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_Nrocalle.Name = "numericUpDown_Nrocalle";
            this.numericUpDown_Nrocalle.Size = new System.Drawing.Size(194, 20);
            this.numericUpDown_Nrocalle.TabIndex = 12;
            // 
            // numericUpDown_RecargaEstre
            // 
            this.numericUpDown_RecargaEstre.DecimalPlaces = 2;
            this.numericUpDown_RecargaEstre.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.numericUpDown_RecargaEstre.Location = new System.Drawing.Point(120, 129);
            this.numericUpDown_RecargaEstre.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_RecargaEstre.Name = "numericUpDown_RecargaEstre";
            this.numericUpDown_RecargaEstre.Size = new System.Drawing.Size(194, 20);
            this.numericUpDown_RecargaEstre.TabIndex = 13;
            // 
            // textBox_Telefono
            // 
            this.textBox_Telefono.Location = new System.Drawing.Point(120, 163);
            this.textBox_Telefono.Name = "textBox_Telefono";
            this.textBox_Telefono.Size = new System.Drawing.Size(194, 20);
            this.textBox_Telefono.TabIndex = 14;
            // 
            // textBox_Pais
            // 
            this.textBox_Pais.Location = new System.Drawing.Point(120, 194);
            this.textBox_Pais.Name = "textBox_Pais";
            this.textBox_Pais.Size = new System.Drawing.Size(194, 20);
            this.textBox_Pais.TabIndex = 15;
            // 
            // maskedTextBox_Ciudad
            // 
            this.maskedTextBox_Ciudad.Location = new System.Drawing.Point(335, 6);
            this.maskedTextBox_Ciudad.Name = "maskedTextBox_Ciudad";
            this.maskedTextBox_Ciudad.ReadOnly = true;
            this.maskedTextBox_Ciudad.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_Ciudad.TabIndex = 16;
            // 
            // maskedTextBox_Calle
            // 
            this.maskedTextBox_Calle.Location = new System.Drawing.Point(335, 36);
            this.maskedTextBox_Calle.Name = "maskedTextBox_Calle";
            this.maskedTextBox_Calle.ReadOnly = true;
            this.maskedTextBox_Calle.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_Calle.TabIndex = 17;
            // 
            // maskedTextBox_Nrocalle
            // 
            this.maskedTextBox_Nrocalle.Location = new System.Drawing.Point(335, 65);
            this.maskedTextBox_Nrocalle.Name = "maskedTextBox_Nrocalle";
            this.maskedTextBox_Nrocalle.ReadOnly = true;
            this.maskedTextBox_Nrocalle.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_Nrocalle.TabIndex = 18;
            // 
            // maskedTextBox_CantEstrellas
            // 
            this.maskedTextBox_CantEstrellas.Location = new System.Drawing.Point(335, 96);
            this.maskedTextBox_CantEstrellas.Name = "maskedTextBox_CantEstrellas";
            this.maskedTextBox_CantEstrellas.ReadOnly = true;
            this.maskedTextBox_CantEstrellas.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_CantEstrellas.TabIndex = 19;
            // 
            // maskedTextBox_RecargaEstrellas
            // 
            this.maskedTextBox_RecargaEstrellas.Location = new System.Drawing.Point(335, 129);
            this.maskedTextBox_RecargaEstrellas.Name = "maskedTextBox_RecargaEstrellas";
            this.maskedTextBox_RecargaEstrellas.ReadOnly = true;
            this.maskedTextBox_RecargaEstrellas.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_RecargaEstrellas.TabIndex = 20;
            // 
            // maskedTextBox_Telefono
            // 
            this.maskedTextBox_Telefono.Location = new System.Drawing.Point(335, 163);
            this.maskedTextBox_Telefono.Name = "maskedTextBox_Telefono";
            this.maskedTextBox_Telefono.ReadOnly = true;
            this.maskedTextBox_Telefono.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_Telefono.TabIndex = 21;
            // 
            // maskedTextBox_Pais
            // 
            this.maskedTextBox_Pais.Location = new System.Drawing.Point(335, 194);
            this.maskedTextBox_Pais.Name = "maskedTextBox_Pais";
            this.maskedTextBox_Pais.ReadOnly = true;
            this.maskedTextBox_Pais.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_Pais.TabIndex = 22;
            // 
            // maskedTextBox_FchCrea
            // 
            this.maskedTextBox_FchCrea.Location = new System.Drawing.Point(335, 229);
            this.maskedTextBox_FchCrea.Name = "maskedTextBox_FchCrea";
            this.maskedTextBox_FchCrea.ReadOnly = true;
            this.maskedTextBox_FchCrea.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBox_FchCrea.TabIndex = 23;
            // 
            // button_Agregar
            // 
            this.button_Agregar.Location = new System.Drawing.Point(308, 322);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(251, 23);
            this.button_Agregar.TabIndex = 24;
            this.button_Agregar.Text = "Agregar Regimen";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // comboBox_RegAdd
            // 
            this.comboBox_RegAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RegAdd.FormattingEnabled = true;
            this.comboBox_RegAdd.Location = new System.Drawing.Point(409, 282);
            this.comboBox_RegAdd.Name = "comboBox_RegAdd";
            this.comboBox_RegAdd.Size = new System.Drawing.Size(150, 21);
            this.comboBox_RegAdd.TabIndex = 25;
            this.comboBox_RegAdd.SelectedIndexChanged += new System.EventHandler(this.comboBox_RegAdd_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(305, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Regimen a Agregar";
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(11, 480);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(256, 23);
            this.button_Modificar.TabIndex = 29;
            this.button_Modificar.Text = "Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(308, 480);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(251, 23);
            this.button_Cancelar.TabIndex = 30;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_BorrarRegimen
            // 
            this.button_BorrarRegimen.Location = new System.Drawing.Point(308, 415);
            this.button_BorrarRegimen.Name = "button_BorrarRegimen";
            this.button_BorrarRegimen.Size = new System.Drawing.Size(251, 23);
            this.button_BorrarRegimen.TabIndex = 31;
            this.button_BorrarRegimen.Text = "Borrar Regimen";
            this.button_BorrarRegimen.UseVisualStyleBackColor = true;
            this.button_BorrarRegimen.Click += new System.EventHandler(this.button_BorrarRegimen_Click);
            // 
            // comboBox_RegABorrar
            // 
            this.comboBox_RegABorrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RegABorrar.FormattingEnabled = true;
            this.comboBox_RegABorrar.Location = new System.Drawing.Point(409, 372);
            this.comboBox_RegABorrar.Name = "comboBox_RegABorrar";
            this.comboBox_RegABorrar.Size = new System.Drawing.Size(150, 21);
            this.comboBox_RegABorrar.TabIndex = 32;
            this.comboBox_RegABorrar.SelectedIndexChanged += new System.EventHandler(this.comboBox_RegABorrar_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 375);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Regimen a Borrar";
            // 
            // ModificacionDeHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 515);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox_RegABorrar);
            this.Controls.Add(this.button_BorrarRegimen);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox_RegAdd);
            this.Controls.Add(this.button_Agregar);
            this.Controls.Add(this.maskedTextBox_FchCrea);
            this.Controls.Add(this.maskedTextBox_Pais);
            this.Controls.Add(this.maskedTextBox_Telefono);
            this.Controls.Add(this.maskedTextBox_RecargaEstrellas);
            this.Controls.Add(this.maskedTextBox_CantEstrellas);
            this.Controls.Add(this.maskedTextBox_Nrocalle);
            this.Controls.Add(this.maskedTextBox_Calle);
            this.Controls.Add(this.maskedTextBox_Ciudad);
            this.Controls.Add(this.textBox_Pais);
            this.Controls.Add(this.textBox_Telefono);
            this.Controls.Add(this.numericUpDown_RecargaEstre);
            this.Controls.Add(this.numericUpDown_Nrocalle);
            this.Controls.Add(this.textBox_Calle);
            this.Controls.Add(this.textBox_Ciudad);
            this.Controls.Add(this.comboBox_CantEstre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Regimenes);
            this.Name = "ModificacionDeHotel";
            this.Text = "Edición de Hotel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Regimenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Nrocalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RecargaEstre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Regimenes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_CantEstre;
        private System.Windows.Forms.TextBox textBox_Ciudad;
        private System.Windows.Forms.TextBox textBox_Calle;
        private System.Windows.Forms.NumericUpDown numericUpDown_Nrocalle;
        private System.Windows.Forms.NumericUpDown numericUpDown_RecargaEstre;
        private System.Windows.Forms.TextBox textBox_Telefono;
        private System.Windows.Forms.TextBox textBox_Pais;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Ciudad;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Calle;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Nrocalle;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_CantEstrellas;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RecargaEstrellas;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Telefono;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Pais;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FchCrea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Regimen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.ComboBox comboBox_RegAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_BorrarRegimen;
        private System.Windows.Forms.ComboBox comboBox_RegABorrar;
        private System.Windows.Forms.Label label10;
    }
}