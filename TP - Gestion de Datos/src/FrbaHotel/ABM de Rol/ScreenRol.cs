using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Business;
using FrbaHotel.Commons;
using FrbaHotel.Core;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ScreenRol : Form
    {
        private RolManager _RolManager = new RolManager();

        public ScreenRol()
        {
            InitializeComponent();

            BindingList<Rol> data_source = _RolManager.GetAll();

            dataGrid_rol.DataSource = data_source;
        }
        
        private void button_modif_Click (object sender, EventArgs e)
        {
            if (dataGrid_rol.SelectedRows.Count == 1)
            {
                AddEditRole edit_rol = new AddEditRole();
                var row = dataGrid_rol.CurrentRow;
                var rol = row.DataBoundItem as Rol;

                edit_rol.PreSet(rol);

                DialogResult res = edit_rol.ShowDialog();

                if (res == DialogResult.Cancel)
                {
                    refresh_grid();
                }
            }
            else { MessageBox.Show("Debe seleccionar una fila"); }
        }

        private void button_nuevo_Click(object sender, EventArgs e)
        {
            AddEditRole nuevo_rol = new AddEditRole();

            DialogResult res = nuevo_rol.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                refresh_grid();
            }
        }

        private void refresh_grid()
        {
            dataGrid_rol.Rows.Clear();
            BindingList<Rol> data_source = _RolManager.GetAll();
            dataGrid_rol.DataSource = data_source;
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


        private void ScreenRol_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
