namespace WindowsFormsApplication1
{
    partial class Polinomios 
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
            this.FValorButton = new System.Windows.Forms.Button();
            this.ValorXBox = new System.Windows.Forms.TextBox();
            this.ProgTextBox = new System.Windows.Forms.RichTextBox();
            this.RegTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TablaDatos = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.X = new System.Data.DataColumn();
            this.Y = new System.Data.DataColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.GradoTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese Valor de X";
            // 
            // FValorButton
            // 
            this.FValorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FValorButton.Location = new System.Drawing.Point(218, 272);
            this.FValorButton.Name = "FValorButton";
            this.FValorButton.Size = new System.Drawing.Size(75, 23);
            this.FValorButton.TabIndex = 1;
            this.FValorButton.Text = "Calcular f(x)";
            this.FValorButton.UseVisualStyleBackColor = true;
            this.FValorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ValorXBox
            // 
            this.ValorXBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ValorXBox.Location = new System.Drawing.Point(112, 274);
            this.ValorXBox.Name = "ValorXBox";
            this.ValorXBox.Size = new System.Drawing.Size(75, 20);
            this.ValorXBox.TabIndex = 2;
            // 
            // ProgTextBox
            // 
            this.ProgTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ProgTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ProgTextBox.Location = new System.Drawing.Point(12, 106);
            this.ProgTextBox.Name = "ProgTextBox";
            this.ProgTextBox.ReadOnly = true;
            this.ProgTextBox.Size = new System.Drawing.Size(754, 59);
            this.ProgTextBox.TabIndex = 3;
            this.ProgTextBox.Text = "";
            // 
            // RegTextBox
            // 
            this.RegTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RegTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.RegTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.RegTextBox.Location = new System.Drawing.Point(12, 195);
            this.RegTextBox.Name = "RegTextBox";
            this.RegTextBox.ReadOnly = true;
            this.RegTextBox.Size = new System.Drawing.Size(754, 59);
            this.RegTextBox.TabIndex = 4;
            this.RegTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Polinomio Regresivo";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Polinomio Progresivo";
            // 
            // TablaDatos
            // 
            this.TablaDatos.DataSetName = "NewDataSet";
            this.TablaDatos.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.X,
            this.Y});
            this.dataTable1.TableName = "Table1";
            // 
            // X
            // 
            this.X.ColumnName = "X";
            this.X.DataType = typeof(double);
            // 
            // Y
            // 
            this.Y.ColumnName = "Y";
            this.Y.DataType = typeof(double);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Grado del Polinomio";
            // 
            // GradoTextBox
            // 
            this.GradoTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.GradoTextBox.Location = new System.Drawing.Point(11, 45);
            this.GradoTextBox.Name = "GradoTextBox";
            this.GradoTextBox.ReadOnly = true;
            this.GradoTextBox.Size = new System.Drawing.Size(102, 20);
            this.GradoTextBox.TabIndex = 8;
            // 
            // Polinomios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 319);
            this.Controls.Add(this.GradoTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RegTextBox);
            this.Controls.Add(this.ProgTextBox);
            this.Controls.Add(this.ValorXBox);
            this.Controls.Add(this.FValorButton);
            this.Controls.Add(this.label1);
            this.Name = "Polinomios";
            this.Text = "Polinomios";
            ((System.ComponentModel.ISupportInitialize)(this.TablaDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FValorButton;
        private System.Windows.Forms.TextBox ValorXBox;
        private System.Windows.Forms.RichTextBox ProgTextBox;
        private System.Windows.Forms.RichTextBox RegTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Data.DataSet TablaDatos;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn X;
        private System.Data.DataColumn Y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GradoTextBox;

        public System.EventHandler Form2_Load { get; set; }

        public System.EventHandler richTextBox1_TextChanged { get; set; }
    }
}