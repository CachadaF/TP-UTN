namespace WindowsFormsApplication1
{
    partial class Valores
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
            this.TablaValores = new System.Data.DataSet();
            this.tablaDatos = new System.Data.DataTable();
            this.dataX = new System.Data.DataColumn();
            this.dataY = new System.Data.DataColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.valoresXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoresYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenerarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TablaValores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaValores
            // 
            this.TablaValores.DataSetName = "NewDataSet";
            this.TablaValores.Tables.AddRange(new System.Data.DataTable[] {
            this.tablaDatos});
            // 
            // tablaDatos
            // 
            this.tablaDatos.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataX,
            this.dataY});
            this.tablaDatos.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "valoresX"}, true)});
            this.tablaDatos.PrimaryKey = new System.Data.DataColumn[] {
        this.dataX};
            this.tablaDatos.TableName = "tablaDatos";
            // 
            // dataX
            // 
            this.dataX.AllowDBNull = false;
            this.dataX.ColumnName = "valoresX";
            this.dataX.DataType = typeof(double);
            // 
            // dataY
            // 
            this.dataY.AllowDBNull = false;
            this.dataY.ColumnName = "valoresY";
            this.dataY.DataType = typeof(double);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valoresXDataGridViewTextBoxColumn,
            this.valoresYDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "tablaDatos";
            this.dataGridView1.DataSource = this.TablaValores;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridView1.Location = new System.Drawing.Point(13, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 159);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // valoresXDataGridViewTextBoxColumn
            // 
            this.valoresXDataGridViewTextBoxColumn.DataPropertyName = "valoresX";
            this.valoresXDataGridViewTextBoxColumn.HeaderText = "valoresX";
            this.valoresXDataGridViewTextBoxColumn.Name = "valoresXDataGridViewTextBoxColumn";
            this.valoresXDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // valoresYDataGridViewTextBoxColumn
            // 
            this.valoresYDataGridViewTextBoxColumn.DataPropertyName = "valoresY";
            this.valoresYDataGridViewTextBoxColumn.HeaderText = "valoresY";
            this.valoresYDataGridViewTextBoxColumn.Name = "valoresYDataGridViewTextBoxColumn";
            this.valoresYDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GenerarButton
            // 
            this.GenerarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GenerarButton.Location = new System.Drawing.Point(13, 188);
            this.GenerarButton.Name = "GenerarButton";
            this.GenerarButton.Size = new System.Drawing.Size(88, 46);
            this.GenerarButton.TabIndex = 1;
            this.GenerarButton.Text = "Generar Polinomio";
            this.GenerarButton.UseVisualStyleBackColor = true;
            this.GenerarButton.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Location = new System.Drawing.Point(158, 188);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(95, 46);
            this.LimpiarButton.TabIndex = 2;
            this.LimpiarButton.Text = "Eliminar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // Valores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 246);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.GenerarButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Valores";
            this.Text = "Valores";
            ((System.ComponentModel.ISupportInitialize)(this.TablaValores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet TablaValores;
        private System.Data.DataTable tablaDatos;
        private System.Data.DataColumn dataX;
        private System.Data.DataColumn dataY;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button GenerarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoresXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoresYDataGridViewTextBoxColumn;


    }
}

