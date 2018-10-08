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

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class DeleteRoom : Form
    {
        private HabitacionManager _habManager = new HabitacionManager();

        private int ID_hotel_en_que_estoy_logeado = 0;

        private int Numero_Habitacion_Elegida = 0;

        public DeleteRoom(int hotel_logeado,int numero_habitacion_sel)
        {
            InitializeComponent();

            ID_hotel_en_que_estoy_logeado = hotel_logeado;

            Numero_Habitacion_Elegida = numero_habitacion_sel;

            maskedTextBox_Hotel.Text = ID_hotel_en_que_estoy_logeado.ToString();
            maskedTextBox_Numero.Text = Numero_Habitacion_Elegida.ToString();

        }

        private void button_borrar_Click(object sender, EventArgs e)
        {
            Habitacion habitacion = _habManager.GetHabitacionHotel(Numero_Habitacion_Elegida,ID_hotel_en_que_estoy_logeado);

            _habManager.EliminarHabitacion(habitacion.id_habitacion);

            MessageBox.Show("La habitacion Nro :"+habitacion.numero+" se dio de baja temporalmente");

            this.Close();

        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
