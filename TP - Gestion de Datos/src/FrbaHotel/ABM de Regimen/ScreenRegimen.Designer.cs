namespace FrbaHotel.ABM_de_Regimen
{
    partial class ScreenRegimen
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
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Cerrar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.dataGridView_Regimen = new System.Windows.Forms.DataGridView();
            this.ID_Regimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Regimen)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Agregar
            // 
            this.button_Agregar.Location = new System.Drawing.Point(12, 239);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(84, 23);
            this.button_Agregar.TabIndex = 0;
            this.button_Agregar.Text = "Agregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(113, 239);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(78, 23);
            this.button_Modificar.TabIndex = 1;
            this.button_Modificar.Text = "Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Cerrar
            // 
            this.button_Cerrar.Location = new System.Drawing.Point(304, 239);
            this.button_Cerrar.Name = "button_Cerrar";
            this.button_Cerrar.Size = new System.Drawing.Size(78, 23);
            this.button_Cerrar.TabIndex = 2;
            this.button_Cerrar.Text = "Cerrar";
            this.button_Cerrar.UseVisualStyleBackColor = true;
            this.button_Cerrar.Click += new System.EventHandler(this.button_Cerrar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Location = new System.Drawing.Point(214, 239);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_Eliminar.TabIndex = 3;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // dataGridView_Regimen
            // 
            this.dataGridView_Regimen.AllowUserToAddRows = false;
            this.dataGridView_Regimen.AllowUserToDeleteRows = false;
            this.dataGridView_Regimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Regimen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Regimen,
            this.Descripcion,
            this.Precio,
            this.Estado});
            this.dataGridView_Regimen.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Regimen.Name = "dataGridView_Regimen";
            this.dataGridView_Regimen.Size = new System.Drawing.Size(370, 203);
            this.dataGridView_Regimen.TabIndex = 4;
            // 
            // ID_Regimen
            // 
            this.ID_Regimen.HeaderText = "ID_Regimen";
            this.ID_Regimen.Name = "ID_Regimen";
            this.ID_Regimen.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // ScreenRegimen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 274);
            this.Controls.Add(this.dataGridView_Regimen);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.button_Cerrar);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.button_Agregar);
            this.Name = "ScreenRegimen";
            this.Text = "Administración de regimenes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Regimen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Cerrar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.DataGridView dataGridView_Regimen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Regimen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}