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
    public partial class ScreenHoteles : Form
    {
        private HotelManager _HotelManager = new HotelManager();
 
        private string user_admin;

        private void reset_comboboxes()
        {
            comboBox_Estrellas.Items.Clear();
            comboBox_Ciudad.Items.Clear();
            comboBox_Pais.Items.Clear();
            comboBox_Estrellas.Items.Add("1");
            comboBox_Estrellas.Items.Add("2");
            comboBox_Estrellas.Items.Add("3");
            comboBox_Estrellas.Items.Add("4");
            comboBox_Estrellas.Items.Add("5");

            var lista_ciudades_hotel = _HotelManager.GetAllHotelesCiudades(user_admin);
            foreach (string ciudad in lista_ciudades_hotel)
            {
                comboBox_Ciudad.Items.Add(ciudad.Trim());
            }
            var lista_paises_hotel = _HotelManager.GetAllHotelesPaises(user_admin);
            foreach (string pais in lista_paises_hotel)
            {
                comboBox_Pais.Items.Add(pais.Trim());
            }
        }

        public ScreenHoteles(string user_logeado)
        {
            user_admin = user_logeado;

            InitializeComponent();

           // textBox_User.Text = user_admin;
            textBox_User.Text = Sesion.user_id;
            reset_comboboxes();
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            dataGridView_Hoteles.Rows.Clear();
            dataGridView_Hoteles.Refresh();

            if (comboBox_Pais.SelectedItem == null && comboBox_Estrellas.SelectedItem == null && comboBox_Ciudad.SelectedItem == null)
            {
                MessageBox.Show("Indique un campo de filtrado");
            }
            else
            {

                int cantdeestrellas = 0;

                if (comboBox_Estrellas.SelectedItem != null)
                {
                    cantdeestrellas = int.Parse(comboBox_Estrellas.Text.ToString().Trim());
                }             

                var lista_hoteles = _HotelManager.GetAllHotelesFiltrados(user_admin,
                    cantdeestrellas,
                    comboBox_Ciudad.Text.ToString().Trim(),
                    comboBox_Pais.Text.ToString().Trim());

                foreach (Hotel hotel in lista_hoteles)
                {
                    dataGridView_Hoteles.Rows.Add(hotel.id_hotel,hotel.ciudad.ToString().Trim(),hotel.calle,hotel.nro_calle
                        ,hotel.cant_estrellas,hotel.recarga_estrella,hotel.telefono,hotel.pais,hotel.fecha_creacion);
                }                         
            }
            reset_comboboxes();
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {
            //Manda a pantalla de modificacion
            if (dataGridView_Hoteles.RowCount > 0)
            {
                int identificador_hotel = int.Parse(dataGridView_Hoteles.CurrentRow.Cells["ID_Hotel"].Value.ToString());
                Form abrir = new FrbaHotel.ABM_de_Hotel.ModificacionDeHotel(identificador_hotel);
                abrir.ShowDialog();
                //
            }
            else
            {
                MessageBox.Show("No hay elementos para seleccionar");
            }
        }

        private void button_Baja_Click(object sender, EventArgs e)
        {
            //Manda a pantalla de bajas
            if (dataGridView_Hoteles.RowCount > 0)
            {
                int identificador_hotel = int.Parse(dataGridView_Hoteles.CurrentRow.Cells["ID_Hotel"].Value.ToString());
                Form abrir = new FrbaHotel.ABM_de_Hotel.BajaDeHotel(identificador_hotel);
                abrir.ShowDialog();  
            }
            else
            {
                MessageBox.Show("No hay elementos para seleccionar");
            }
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Alta_Click(object sender, EventArgs e)
        {
            if (user_admin != " " || user_admin != null)
            {
                Form abrir = new FrbaHotel.ABM_de_Hotel.AltaDeHotel(user_admin);
                abrir.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay admin logeado");
            }

        }
    }
}
