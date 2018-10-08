namespace FrbaHotel.ABM_de_Rol
{
    partial class AddEditRole
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
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_estadoRol = new System.Windows.Forms.ComboBox();
            this.textBox_nomRol = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox_preFunc = new System.Windows.Forms.ListBox();
            this.textBox_preEstado = new System.Windows.Forms.TextBox();
            this.textBox_preNom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_func = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(48, 325);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 0;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(187, 325);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancelar";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Funcionalidades";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "¿Inhabilitado?";
            // 
            // comboBox_estadoRol
            // 
            this.comboBox_estadoRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_estadoRol.FormattingEnabled = true;
            this.comboBox_estadoRol.Location = new System.Drawing.Point(147, 252);
            this.comboBox_estadoRol.Name = "comboBox_estadoRol";
            this.comboBox_estadoRol.Size = new System.Drawing.Size(115, 21);
            this.comboBox_estadoRol.TabIndex = 7;
            // 
            // textBox_nomRol
            // 
            this.textBox_nomRol.Location = new System.Drawing.Point(149, 34);
            this.textBox_nomRol.Name = "textBox_nomRol";
            this.textBox_nomRol.Size = new System.Drawing.Size(111, 20);
            this.textBox_nomRol.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.listBox_preFunc);
            this.panel1.Controls.Add(this.textBox_preEstado);
            this.panel1.Controls.Add(this.textBox_preNom);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(313, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 273);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // listBox_preFunc
            // 
            this.listBox_preFunc.FormattingEnabled = true;
            this.listBox_preFunc.HorizontalScrollbar = true;
            this.listBox_preFunc.Location = new System.Drawing.Point(133, 62);
            this.listBox_preFunc.Name = "listBox_preFunc";
            this.listBox_preFunc.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_preFunc.Size = new System.Drawing.Size(111, 134);
            this.listBox_preFunc.TabIndex = 18;
            // 
            // textBox_preEstado
            // 
            this.textBox_preEstado.Location = new System.Drawing.Point(133, 228);
            this.textBox_preEstado.Name = "textBox_preEstado";
            this.textBox_preEstado.ReadOnly = true;
            this.textBox_preEstado.Size = new System.Drawing.Size(111, 20);
            this.textBox_preEstado.TabIndex = 17;
            // 
            // textBox_preNom
            // 
            this.textBox_preNom.Location = new System.Drawing.Point(133, 8);
            this.textBox_preNom.Name = "textBox_preNom";
            this.textBox_preNom.ReadOnly = true;
            this.textBox_preNom.Size = new System.Drawing.Size(111, 20);
            this.textBox_preNom.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nombre rol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Funcionalidades";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "¿Inhabilitado?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Valores actuales";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // listBox_func
            // 
            this.listBox_func.FormattingEnabled = true;
            this.listBox_func.HorizontalScrollbar = true;
            this.listBox_func.Location = new System.Drawing.Point(147, 86);
            this.listBox_func.Name = "listBox_func";
            this.listBox_func.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_func.Size = new System.Drawing.Size(111, 134);
            this.listBox_func.TabIndex = 19;
            // 
            // AddEditRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 360);
            this.Controls.Add(this.listBox_func);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_nomRol);
            this.Controls.Add(this.comboBox_estadoRol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.panel1);
            this.Name = "AddEditRole";
            this.Text = "Edición de rol";
            this.Load += new System.EventHandler(this.AddEditRole_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_estadoRol;
        private System.Windows.Forms.TextBox textBox_nomRol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_preNom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_preEstado;
        private System.Windows.Forms.ListBox listBox_preFunc;
        private System.Windows.Forms.ListBox listBox_func;
    }
}