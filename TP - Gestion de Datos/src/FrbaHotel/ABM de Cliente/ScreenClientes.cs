using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using FrbaHotel.Commons.Entidades;
using FrbaHotel.Business;
using FrbaHotel.Commons;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ScreenClientes : Form
    {
        private ClienteManager _clienteManager = new ClienteManager();

        public ScreenClientes()
        {
            InitializeComponent();
            /*
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString()
                , "LOS_NULL.GET_TIPODOC");
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    this.comboBox_tipoDoc.Items.Add(row["Descripcion"].ToString());
                }
            }*/
            this.textBox_doc.Focus();

            this.comboBox_tipoDoc.Items.Add("Pasaporte");
        }


        private void Buscar_Click(object sender, EventArgs e)
        {
            if (textBox_apellido.Text.Length == 0 && textBox_doc.Text.Length == 0 && textBox_mail.Text.Length == 0 && textBox_nombre.Text.Length == 0)
            {
                MessageBox.Show("Por favor rellene algun campo de filtrado");
            }
            else
            {
                try
                {
                    int doc;
                    if (!string.IsNullOrEmpty(textBox_doc.Text))
                        doc = Convert.ToInt32(textBox_doc.Text);
                    else doc = 0;

                    BindingList<Cliente> listado = _clienteManager.listado_cliente_por_datos(
                        doc,
                        textBox_nombre.Text.Trim(),
                        textBox_apellido.Text.Trim(),
                        textBox_mail.Text.Trim());

                    grid_clientes.DataSource = listado;
                }
                catch (FormatException f)
                {
                    MessageBox.Show("Solo ingresar numeros en Documento.\n" + f);
                }
            }
        }


        private void Agregar_Click(object sender, EventArgs e)
        {
            AddEditClientes agregarForm = new AddEditClientes();
            agregarForm.ShowDialog();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (grid_clientes.DataSource != null && grid_clientes.SelectedRows.Count > 0)
                foreach (DataGridViewRow row in grid_clientes.SelectedRows)
                {
                    AddEditClientes modifForm = new AddEditClientes((Cliente) row.DataBoundItem);
                    modifForm.ShowDialog();
                }
        }


        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Aceptar_Click(sender, e);
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        
    }
}
