namespace FrbaHotel.Registrar_Consumible
{
    partial class Registrar_Consumibles
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
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Registrar = new System.Windows.Forms.Button();
            this.comboBox_Consumibles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_Precio = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_AgregarConsumible = new System.Windows.Forms.Button();
            this.dataGridView_Consumibles = new System.Windows.Forms.DataGridView();
            this.Consumible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericUpDown_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.button_EliminarConsumible = new System.Windows.Forms.Button();
            this.maskedTextBox_hotel = new System.Windows.Forms.MaskedTextBox();
            this.Hotel = new System.Windows.Forms.Label();
            this.textBox_estadia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Consumibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Limpiar.Location = new System.Drawing.Point(226, 362);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(120, 23);
            this.button_Limpiar.TabIndex = 0;
            this.button_Limpiar.Text = "Limpiar Consumibles";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancelar.Location = new System.Drawing.Point(352, 362);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(108, 23);
            this.button_Cancelar.TabIndex = 1;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Registrar
            // 
            this.button_Registrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Registrar.Location = new System.Drawing.Point(15, 362);
            this.button_Registrar.Name = "button_Registrar";
            this.button_Registrar.Size = new System.Drawing.Size(91, 23);
            this.button_Registrar.TabIndex = 2;
            this.button_Registrar.Text = "Registrar";
            this.button_Registrar.UseVisualStyleBackColor = true;
            this.button_Registrar.Click += new System.EventHandler(this.button_Registrar_Click);
            // 
            // comboBox_Consumibles
            // 
            this.comboBox_Consumibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Consumibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Consumibles.FormattingEnabled = true;
            this.comboBox_Consumibles.Location = new System.Drawing.Point(105, 63);
            this.comboBox_Consumibles.Name = "comboBox_Consumibles";
            this.comboBox_Consumibles.Size = new System.Drawing.Size(176, 21);
            this.comboBox_Consumibles.TabIndex = 3;
            this.comboBox_Consumibles.SelectedIndexChanged += new System.EventHandler(this.comboBox_Consumibles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Consumible";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cantidad";
            // 
            // maskedTextBox_Precio
            // 
            this.maskedTextBox_Precio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_Precio.Location = new System.Drawing.Point(352, 63);
            this.maskedTextBox_Precio.Name = "maskedTextBox_Precio";
            this.maskedTextBox_Precio.ReadOnly = true;
            this.maskedTextBox_Precio.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox_Precio.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Estadia";
            // 
            // button_AgregarConsumible
            // 
            this.button_AgregarConsumible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AgregarConsumible.Location = new System.Drawing.Point(294, 97);
            this.button_AgregarConsumible.Name = "button_AgregarConsumible";
            this.button_AgregarConsumible.Size = new System.Drawing.Size(158, 23);
            this.button_AgregarConsumible.TabIndex = 11;
            this.button_AgregarConsumible.Text = "Agregar Consumible";
            this.button_AgregarConsumible.UseVisualStyleBackColor = true;
            this.button_AgregarConsumible.Click += new System.EventHandler(this.button_AgregarConsumible_Click);
            // 
            // dataGridView_Consumibles
            // 
            this.dataGridView_Consumibles.AllowUserToAddRows = false;
            this.dataGridView_Consumibles.AllowUserToDeleteRows = false;
            this.dataGridView_Consumibles.AllowUserToOrderColumns = true;
            this.dataGridView_Consumibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Consumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Consumibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Consumible,
            this.Cantidad,
            this.Precio});
            this.dataGridView_Consumibles.Location = new System.Drawing.Point(15, 126);
            this.dataGridView_Consumibles.Name = "dataGridView_Consumibles";
            this.dataGridView_Consumibles.ReadOnly = true;
            this.dataGridView_Consumibles.Size = new System.Drawing.Size(445, 230);
            this.dataGridView_Consumibles.TabIndex = 12;
            // 
            // Consumible
            // 
            this.Consumible.HeaderText = "Consumible";
            this.Consumible.Name = "Consumible";
            this.Consumible.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // numericUpDown_Cantidad
            // 
            this.numericUpDown_Cantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Cantidad.Location = new System.Drawing.Point(105, 97);
            this.numericUpDown_Cantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Cantidad.Name = "numericUpDown_Cantidad";
            this.numericUpDown_Cantidad.Size = new System.Drawing.Size(176, 20);
            this.numericUpDown_Cantidad.TabIndex = 13;
            this.numericUpDown_Cantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_EliminarConsumible
            // 
            this.button_EliminarConsumible.Location = new System.Drawing.Point(112, 362);
            this.button_EliminarConsumible.Name = "button_EliminarConsumible";
            this.button_EliminarConsumible.Size = new System.Drawing.Size(108, 23);
            this.button_EliminarConsumible.TabIndex = 14;
            this.button_EliminarConsumible.Text = "EliminarConsumible";
            this.button_EliminarConsumible.UseVisualStyleBackColor = true;
            this.button_EliminarConsumible.Click += new System.EventHandler(this.EliminarConsumible_Click);
            // 
            // maskedTextBox_hotel
            // 
            this.maskedTextBox_hotel.Location = new System.Drawing.Point(352, 30);
            this.maskedTextBox_hotel.Name = "maskedTextBox_hotel";
            this.maskedTextBox_hotel.ReadOnly = true;
            this.maskedTextBox_hotel.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox_hotel.TabIndex = 15;
            // 
            // Hotel
            // 
            this.Hotel.AutoSize = true;
            this.Hotel.Location = new System.Drawing.Point(293, 33);
            this.Hotel.Name = "Hotel";
            this.Hotel.Size = new System.Drawing.Size(32, 13);
            this.Hotel.TabIndex = 16;
            this.Hotel.Text = "Hotel";
            // 
            // textBox_estadia
            // 
            this.textBox_estadia.Enabled = false;
            this.textBox_estadia.Location = new System.Drawing.Point(105, 31);
            this.textBox_estadia.Name = "textBox_estadia";
            this.textBox_estadia.Size = new System.Drawing.Size(175, 20);
            this.textBox_estadia.TabIndex = 17;
            // 
            // Registrar_Consumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 397);
            this.Controls.Add(this.textBox_estadia);
            this.Controls.Add(this.Hotel);
            this.Controls.Add(this.maskedTextBox_hotel);
            this.Controls.Add(this.button_EliminarConsumible);
            this.Controls.Add(this.numericUpDown_Cantidad);
            this.Controls.Add(this.dataGridView_Consumibles);
            this.Controls.Add(this.button_AgregarConsumible);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBox_Precio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Consumibles);
            this.Controls.Add(this.button_Registrar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Limpiar);
            this.Name = "Registrar_Consumibles";
            this.Text = "Registro de consumibles";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Consumibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Cantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Registrar;
        private System.Windows.Forms.ComboBox comboBox_Consumibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Precio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_AgregarConsumible;
        private System.Windows.Forms.DataGridView dataGridView_Consumibles;
        private System.Windows.Forms.NumericUpDown numericUpDown_Cantidad;
        private System.Windows.Forms.Button button_EliminarConsumible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consumible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_hotel;
        private System.Windows.Forms.Label Hotel;
        private System.Windows.Forms.TextBox textBox_estadia;
    }
}