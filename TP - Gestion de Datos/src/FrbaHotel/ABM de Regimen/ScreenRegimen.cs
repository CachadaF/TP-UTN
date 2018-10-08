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

namespace FrbaHotel.ABM_de_Regimen
{
    public partial class ScreenRegimen : Form
    {
        private RegimenManager _RegimenManager = new RegimenManager();

        public ScreenRegimen()
        {
            InitializeComponent();

            BindingList<Regimen> lista_regimenes = _RegimenManager.GetAll();

            foreach (Regimen regimen in lista_regimenes)
            {
                dataGridView_Regimen.Rows.Add(regimen.id_regimen,regimen.descripcion,regimen.precio,regimen.estado);
            }

            button_Agregar.Enabled = false;
            button_Eliminar.Enabled = false;
            button_Modificar.Enabled = false;

        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {

        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {

        }
    }
}
