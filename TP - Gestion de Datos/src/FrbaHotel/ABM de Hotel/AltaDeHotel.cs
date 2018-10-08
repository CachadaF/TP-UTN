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



namespace FrbaHotel.ABM_de_Hotel
{
    public partial class AltaDeHotel : Form
    {
        private HotelManager _HotelManager = new HotelManager();

        private RegimenManager _RegimenManager = new RegimenManager();

        private int id_hotel_agregado = 0;

        private string user_admin_actual;

        private void recargar_regimenes()
        {
            comboBox_Regimenes.Items.Clear();

            BindingList<Regimen> lista_regimenes_existentes = _RegimenManager.GetNoRepetidos(id_hotel_agregado);

            foreach (Regimen reg in lista_regimenes_existentes)
            {
                comboBox_Regimenes.Items.Add(reg.descripcion.ToString());
            }
        }

        public AltaDeHotel(string user_admin_logeado)
        {
            InitializeComponent();

            comboBox_CantEstre.Items.Add("1");
            comboBox_CantEstre.Items.Add("2");
            comboBox_CantEstre.Items.Add("3");
            comboBox_CantEstre.Items.Add("4");
            comboBox_CantEstre.Items.Add("5");

            user_admin_actual = user_admin_logeado;

            panel_Regimenes.Hide();

        }

        private void button_Alta_Click(object sender, EventArgs e)
        {
            if (comboBox_CantEstre.SelectedItem == null || textBox_Calle.SelectedText == null || textBox_Ciudad.SelectedText == null
                 || textBox_Pais.SelectedText == null || textBox_Telefono.SelectedText == null)
            {
                MessageBox.Show("No se aceptan valores Null o Cero de campos");
            }
            else
            {
                Hotel hotel_alta = new Hotel();
                hotel_alta.nro_calle = int.Parse(numericUpDown_Nrocalle.Value.ToString());
                hotel_alta.calle = textBox_Calle.Text.ToString();
                hotel_alta.cant_estrellas = int.Parse(comboBox_CantEstre.Text.ToString());
                hotel_alta.ciudad = textBox_Ciudad.Text.ToString();
                hotel_alta.pais = textBox_Pais.Text.ToString();
                hotel_alta.recarga_estrella = decimal.Parse(numericUpDown_RecargaEstre.Value.ToString());
                hotel_alta.telefono = textBox_Telefono.Text.ToString();
                hotel_alta.fecha_creacion = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());

                id_hotel_agregado = _HotelManager.InsertarHotel(hotel_alta,user_admin_actual);
                panel_Hotel.Enabled = false;
                recargar_regimenes();
                panel_Regimenes.Show();
            }          
        }

        private void button_AgregarRegimen_Click(object sender, EventArgs e)
        {
            if (comboBox_Regimenes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un Regimen");
            }
            else
            {
                _RegimenManager.InsertarNuevoRegimenHotel(id_hotel_agregado,comboBox_Regimenes.Text.ToString());
                recargar_regimenes();
            }
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
