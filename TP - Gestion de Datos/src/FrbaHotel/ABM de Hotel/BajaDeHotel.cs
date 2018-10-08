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
    public partial class BajaDeHotel : Form
    {
        private int ID_Hotel_global = 0;

        private HotelManager _HotelManager = new HotelManager();

        public BajaDeHotel(int ID_Value)
        {
            InitializeComponent();
            this.Text += ' ' + ID_Value.ToString();
            dateTimePicker_Inicio.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Inicio.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker_Fin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Fin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            ID_Hotel_global = ID_Value;
        }

        private void button_Bajar_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(dateTimePicker_Inicio.Text.ToString()) > DateTime.Parse(dateTimePicker_Fin.Text.ToString()))
            {
                MessageBox.Show("Fecha Inicio > Fecha Fin -> Error");
            }
            else
            {
                int valor_filas_afectadas = _HotelManager.BajarPorTiempoHotel(ID_Hotel_global, DateTime.Parse(dateTimePicker_Inicio.Text.ToString())
                                  , DateTime.Parse(dateTimePicker_Fin.Text.ToString()), textBox_Descripcion.Text.ToString());

                if (valor_filas_afectadas == 0)
                {
                    MessageBox.Show("Se ha efectivizado la baja del hotel Desde:" + dateTimePicker_Inicio.Text.ToString() + "Hasta:" + dateTimePicker_Fin.Text.ToString());
                }
                else
                {
                    MessageBox.Show("Hay " + valor_filas_afectadas.ToString() + " Reserva/s afectada/s, no se efectivizo la baja");
                }
            }          
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
