namespace FrbaHotel.Listado_Estadistico
{
    partial class StatsScreen
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_trim = new System.Windows.Forms.ComboBox();
            this.comboBox_anio = new System.Windows.Forms.ComboBox();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_categor = new System.Windows.Forms.ComboBox();
            this.button_buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Trimestre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Año";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(12, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(456, 284);
            this.dataGridView1.TabIndex = 3;
            // 
            // comboBox_trim
            // 
            this.comboBox_trim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_trim.FormattingEnabled = true;
            this.comboBox_trim.Location = new System.Drawing.Point(127, 29);
            this.comboBox_trim.Name = "comboBox_trim";
            this.comboBox_trim.Size = new System.Drawing.Size(74, 21);
            this.comboBox_trim.TabIndex = 11;
            // 
            // comboBox_anio
            // 
            this.comboBox_anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_anio.FormattingEnabled = true;
            this.comboBox_anio.Location = new System.Drawing.Point(12, 29);
            this.comboBox_anio.Name = "comboBox_anio";
            this.comboBox_anio.Size = new System.Drawing.Size(74, 21);
            this.comboBox_anio.TabIndex = 10;
            // 
            // button_cerrar
            // 
            this.button_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cerrar.Location = new System.Drawing.Point(378, 27);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(75, 23);
            this.button_cerrar.TabIndex = 5;
            this.button_cerrar.Text = "Cerrar";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox_categor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button_cerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_buscar);
            this.panel1.Controls.Add(this.comboBox_trim);
            this.panel1.Controls.Add(this.comboBox_anio);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 106);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Seleccione categoria:";
            // 
            // comboBox_categor
            // 
            this.comboBox_categor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_categor.FormattingEnabled = true;
            this.comboBox_categor.Location = new System.Drawing.Point(127, 72);
            this.comboBox_categor.Name = "comboBox_categor";
            this.comboBox_categor.Size = new System.Drawing.Size(228, 21);
            this.comboBox_categor.TabIndex = 14;
            this.comboBox_categor.SelectedIndexChanged += new System.EventHandler(this.comboBox_categor_SelectedIndexChanged);
            // 
            // button_buscar
            // 
            this.button_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_buscar.Location = new System.Drawing.Point(378, 72);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 1;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // StatsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(480, 420);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "StatsScreen";
            this.Text = "Estadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_trim;
        private System.Windows.Forms.ComboBox comboBox_anio;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_categor;

    }
}