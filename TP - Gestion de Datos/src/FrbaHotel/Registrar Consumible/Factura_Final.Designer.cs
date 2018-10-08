namespace FrbaHotel.Registrar_Consumible
{
    partial class Factura_Final
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
            this.dataGridView_Factura = new System.Windows.Forms.DataGridView();
            this.Codigo_Consumible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox_MontoTotal = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Cerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox_Factura = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Factura)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Factura
            // 
            this.dataGridView_Factura.AllowUserToAddRows = false;
            this.dataGridView_Factura.AllowUserToDeleteRows = false;
            this.dataGridView_Factura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Factura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo_Consumible,
            this.Detalle,
            this.Cantidad,
            this.Monto});
            this.dataGridView_Factura.Location = new System.Drawing.Point(12, 79);
            this.dataGridView_Factura.Name = "dataGridView_Factura";
            this.dataGridView_Factura.ReadOnly = true;
            this.dataGridView_Factura.Size = new System.Drawing.Size(497, 283);
            this.dataGridView_Factura.TabIndex = 0;
            // 
            // Codigo_Consumible
            // 
            this.Codigo_Consumible.HeaderText = "Codigo_Consumible";
            this.Codigo_Consumible.Name = "Codigo_Consumible";
            this.Codigo_Consumible.ReadOnly = true;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Factura";
            // 
            // maskedTextBox_MontoTotal
            // 
            this.maskedTextBox_MontoTotal.Location = new System.Drawing.Point(308, 9);
            this.maskedTextBox_MontoTotal.Name = "maskedTextBox_MontoTotal";
            this.maskedTextBox_MontoTotal.ReadOnly = true;
            this.maskedTextBox_MontoTotal.Size = new System.Drawing.Size(201, 20);
            this.maskedTextBox_MontoTotal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monto Total";
            // 
            // button_Cerrar
            // 
            this.button_Cerrar.Location = new System.Drawing.Point(308, 50);
            this.button_Cerrar.Name = "button_Cerrar";
            this.button_Cerrar.Size = new System.Drawing.Size(201, 23);
            this.button_Cerrar.TabIndex = 4;
            this.button_Cerrar.Text = "Cerrar";
            this.button_Cerrar.UseVisualStyleBackColor = true;
            this.button_Cerrar.Click += new System.EventHandler(this.button_Cerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Numero Factura";
            // 
            // maskedTextBox_Factura
            // 
            this.maskedTextBox_Factura.Location = new System.Drawing.Point(103, 50);
            this.maskedTextBox_Factura.Name = "maskedTextBox_Factura";
            this.maskedTextBox_Factura.ReadOnly = true;
            this.maskedTextBox_Factura.Size = new System.Drawing.Size(138, 20);
            this.maskedTextBox_Factura.TabIndex = 6;
            // 
            // Factura_Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 374);
            this.Controls.Add(this.maskedTextBox_Factura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Cerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_MontoTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Factura);
            this.Name = "Factura_Final";
            this.Text = "Vista de Factura";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Factura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Factura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_MontoTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Cerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Consumible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Factura;
    }
}