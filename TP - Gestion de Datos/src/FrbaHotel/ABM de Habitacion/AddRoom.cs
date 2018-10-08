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
    public partial class AddRoom : Form
    {
        private Tipo_habitacionManager _habtipoManager = new Tipo_habitacionManager();

        private HabitacionManager _habManager = new HabitacionManager();

        private int ID_Hotel_que_estoy_logeado = 0;

        public AddRoom(int id_hotel_logeado)
        {
            InitializeComponent();

            ID_Hotel_que_estoy_logeado = id_hotel_logeado;

            maskedTextBox_Hotel.Text = ID_Hotel_que_estoy_logeado.ToString();

            var descripcion_habitacion = _habtipoManager.GetAll();
            foreach (Tipo_habitacion tipo_hab in descripcion_habitacion)
            {
                comboBox_tipoRoom.Items.Add(tipo_hab.descripcion);
            }
            var lista_ubicaciones = _habManager.GetHabitacionUbicacion();
            foreach (String ubi_habs in lista_ubicaciones)
            {
                comboBox_ubicRoom.Items.Add(ubi_habs);
            }
                       
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Descripcion.Text.Length > 255)
            {
                MessageBox.Show("Descripcion mayor al tamaño maximo aceptado(255 caracteres)");
                return;
            }

            if (comboBox_ubicRoom.SelectedItem == null)
            {
                MessageBox.Show("Ingrese una Ubicacion de Habitacion");
            }
            else
            {
                if (comboBox_tipoRoom.SelectedItem == null)
                {
                    MessageBox.Show("Ingrese un Tipo de Habitacion");
                }
                else
                {
                    var habitaciones = _habManager.GetAll();
                    bool flag = true;
                    foreach (Habitacion hab in habitaciones)
                    {
                        if (hab.numero == numeric_Hab.Value)
                        {
                            flag = false;
                        }
                        
                    }
                    if (flag == true)
                    {
                        Habitacion habitacion_nueva = new Habitacion();
                        habitacion_nueva.numero = int.Parse(numeric_Hab.Value.ToString());
                        habitacion_nueva.piso = int.Parse(numeric_Piso.Value.ToString());
                        habitacion_nueva.frente = comboBox_ubicRoom.Text.ToString(); 
                        habitacion_nueva.descripcion = textBox_Descripcion.Text.ToString();
                        habitacion_nueva.id_tipo_hab = 0;

                        var tipo_dehabitaciones = _habtipoManager.GetAll();
                        foreach (Tipo_habitacion t_hab in tipo_dehabitaciones)
                        {
                           if (t_hab.descripcion == comboBox_tipoRoom.Text.ToString())
                           {
                               habitacion_nueva.id_tipo_hab = t_hab.codigo_tipo;
                           }
                        }
                        habitacion_nueva.id_hotel = ID_Hotel_que_estoy_logeado;

                        _habManager.InsertarHabitacion(habitacion_nueva);
                        MessageBox.Show("Se ingreso la habitacion nueva");
                    }
                    else
                    {
                        MessageBox.Show("Numero de Habitacion ya existente en el hotel");
                    }
                }
            }
        }
    }
}
