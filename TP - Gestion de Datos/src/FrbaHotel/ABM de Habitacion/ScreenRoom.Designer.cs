namespace FrbaHotel.ABM_de_Habitacion
{
    partial class ScreenRoom
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
            this.dataGrid_Habitaciones = new System.Windows.Forms.DataGridView();
            this.ID_Habitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baja_Logica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Borrado = new System.Windows.Forms.Button();
            this.button_modRoom = new System.Windows.Forms.Button();
            this.button_newRoom = new System.Windows.Forms.Button();
            this.button_Cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox_Hotel = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Habitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_Habitaciones
            // 
            this.dataGrid_Habitaciones.AllowUserToAddRows = false;
            this.dataGrid_Habitaciones.AllowUserToDeleteRows = false;
            this.dataGrid_Habitaciones.AllowUserToOrderColumns = true;
            this.dataGrid_Habitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Habitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Habitacion,
            this.Numero,
            this.Piso,
            this.Codigo_Tipo,
            this.ID_Hotel,
            this.Frente,
            this.Baja_Logica,
            this.Descripcion});
            this.dataGrid_Habitaciones.Location = new System.Drawing.Point(12, 35);
            this.dataGrid_Habitaciones.Name = "dataGrid_Habitaciones";
            this.dataGrid_Habitaciones.ReadOnly = true;
            this.dataGrid_Habitaciones.Size = new System.Drawing.Size(600, 313);
            this.dataGrid_Habitaciones.TabIndex = 0;
            // 
            // ID_Habitacion
            // 
            this.ID_Habitacion.HeaderText = "ID_Habitacion";
            this.ID_Habitacion.Name = "ID_Habitacion";
            this.ID_Habitacion.ReadOnly = true;
            this.ID_Habitacion.Visible = false;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            this.Piso.ReadOnly = true;
            // 
            // Codigo_Tipo
            // 
            this.Codigo_Tipo.HeaderText = "Codigo_Tipo";
            this.Codigo_Tipo.Name = "Codigo_Tipo";
            this.Codigo_Tipo.ReadOnly = true;
            // 
            // ID_Hotel
            // 
            this.ID_Hotel.HeaderText = "ID_Hotel";
            this.ID_Hotel.Name = "ID_Hotel";
            this.ID_Hotel.ReadOnly = true;
            this.ID_Hotel.Visible = false;
            // 
            // Frente
            // 
            this.Frente.HeaderText = "Frente";
            this.Frente.Name = "Frente";
            this.Frente.ReadOnly = true;
            // 
            // Baja_Logica
            // 
            this.Baja_Logica.HeaderText = "Baja_Logica";
            this.Baja_Logica.Name = "Baja_Logica";
            this.Baja_Logica.ReadOnly = true;
            // 
            // button_Borrado
            // 
            this.button_Borrado.Location = new System.Drawing.Point(173, 376);
            this.button_Borrado.Name = "button_Borrado";
            this.button_Borrado.Size = new System.Drawing.Size(110, 23);
            this.button_Borrado.TabIndex = 3;
            this.button_Borrado.Text = "Borrar Habitacion";
            this.button_Borrado.UseVisualStyleBackColor = true;
            this.button_Borrado.Click += new System.EventHandler(this.button_Borrado_Click);
            // 
            // button_modRoom
            // 
            this.button_modRoom.Location = new System.Drawing.Point(328, 376);
            this.button_modRoom.Name = "button_modRoom";
            this.button_modRoom.Size = new System.Drawing.Size(116, 23);
            this.button_modRoom.TabIndex = 2;
            this.button_modRoom.Text = "Modificar Habitacion";
            this.button_modRoom.UseVisualStyleBackColor = true;
            this.button_modRoom.Click += new System.EventHandler(this.button_modRoom_Click);
            // 
            // button_newRoom
            // 
            this.button_newRoom.Location = new System.Drawing.Point(12, 376);
            this.button_newRoom.Name = "button_newRoom";
            this.button_newRoom.Size = new System.Drawing.Size(111, 23);
            this.button_newRoom.TabIndex = 1;
            this.button_newRoom.Text = "Nueva Habitacion";
            this.button_newRoom.UseVisualStyleBackColor = true;
            this.button_newRoom.Click += new System.EventHandler(this.button_newRoom_Click);
            // 
            // button_Cerrar
            // 
            this.button_Cerrar.Location = new System.Drawing.Point(496, 376);
            this.button_Cerrar.Name = "button_Cerrar";
            this.button_Cerrar.Size = new System.Drawing.Size(116, 23);
            this.button_Cerrar.TabIndex = 7;
            this.button_Cerrar.Text = "Cerrar";
            this.button_Cerrar.UseVisualStyleBackColor = true;
            this.button_Cerrar.Click += new System.EventHandler(this.button_Cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Habitaciones Del Hotel";
            // 
            // maskedTextBox_Hotel
            // 
            this.maskedTextBox_Hotel.Location = new System.Drawing.Point(420, 7);
            this.maskedTextBox_Hotel.Name = "maskedTextBox_Hotel";
            this.maskedTextBox_Hotel.ReadOnly = true;
            this.maskedTextBox_Hotel.Size = new System.Drawing.Size(192, 20);
            this.maskedTextBox_Hotel.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hotel_Logeado";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // ScreenRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 412);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_Hotel);
            this.Controls.Add(this.button_Borrado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_modRoom);
            this.Controls.Add(this.button_Cerrar);
            this.Controls.Add(this.button_newRoom);
            this.Controls.Add(this.dataGrid_Habitaciones);
            this.Name = "ScreenRoom";
            this.Text = "Administración de habitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Habitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_Habitaciones;
        private System.Windows.Forms.Button button_modRoom;
        private System.Windows.Forms.Button button_newRoom;
        private System.Windows.Forms.Button button_Cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Borrado;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Hotel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Habitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baja_Logica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
    }
}