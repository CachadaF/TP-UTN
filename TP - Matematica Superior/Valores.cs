using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Valores : Form
    {
        public Valores()
        {
            InitializeComponent();

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            if (dataGridView1.ColumnCount == 2 && dataGridView1.RowCount == 1)
                {           
                MessageBox.Show("No ha ingresado ningun numero");
                }
            else
                {
                var form = new Polinomios(TablaValores.Tables["tablaDatos"]);
                form.ShowIcon = false;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ShowInTaskbar = false;
                form.TopMost = true;
                form.ShowDialog();
                }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {            
            MessageBox.Show("Falta Valor o el Valor esta repetido");
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            //Verifica si hay valores para borrar
            if (dataGridView1.CurrentRow == null)
                //Envia error cuando no hay mas filas que borrar
                MessageBox.Show("No hay mas datos para borrar");
            else
                //Borra una fila
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
               // dataGridView1.Rows.Remove(dataGridView1.Rows.RemoveAt);
        }

    }
}
