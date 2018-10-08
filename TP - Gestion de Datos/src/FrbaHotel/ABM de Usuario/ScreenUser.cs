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

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class ScreenUser : Form
    {
        private UsuarioManager _UsuarioManager = new UsuarioManager(); 

        public ScreenUser()
        {
            InitializeComponent();

            BindingList<Usuario> data_source = _UsuarioManager.GetAll();
            dataGrid_users.DataSource = data_source;
            

        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_nuevo_Click(object sender, EventArgs e)
        {
            AddEditUser new_user = new AddEditUser(null);
            DialogResult res = new_user.ShowDialog(this);
            if (res == DialogResult.OK || res == DialogResult.Cancel)
            {
                refresh_grid();
            }
      
        }

        private void refresh_grid()
        {
            dataGrid_users.Rows.Clear();
            dataGrid_users.Refresh();
            BindingList<Usuario> data_source = _UsuarioManager.GetAll();

            dataGrid_users.DataSource = data_source;
        }

        private void button_modif_Click(object sender, EventArgs e)
        {
            if (dataGrid_users.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un Usuario para modificarlo");
            }
            else
            {
                Usuario user = dataGrid_users.CurrentRow.DataBoundItem as Usuario;
           
                AddEditUser mod_user = new AddEditUser(user);
                DialogResult res = mod_user.ShowDialog(this);

                if (res == DialogResult.OK || res == DialogResult.Cancel)
                {
                    refresh_grid();
                }
               
            }
        }

    }
}
