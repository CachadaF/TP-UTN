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
    public partial class EditRoom : Form
    {
        private HabitacionManager _habManager = new HabitacionManager();

        private Tipo_habitacionManager _habtipoManager = new Tipo_habitacionManager();

        private int ID_hotel_que_estoy_logeado = 0;

        private int Numero_Habitacion_Elegida = 0;

        public EditRoom(int id_hotel_logeado,int numero_hab_elegida)
        {
            InitializeComponent();

            ID_hotel_que_estoy_logeado = id_hotel_logeado;

            Numero_Habitacion_Elegida = numero_hab_elegida;

            maskedTextBox_Hotel.Text = ID_hotel_que_estoy_logeado.ToString();

            maskedTextBox_NroHab.Text = Numero_Habitacion_Elegida.ToString();

            var tipo_hab_lista = _habtipoManager.GetAll();
            foreach (Tipo_habitacion tipo_hab in tipo_hab_lista)
            {
                comboBox_Tipo.Items.Add(tipo_hab.descripcion);
            }
            var lista_ubicaciones = _habManager. GetHabitacionUbicacion();
            foreach (String ubi_habs in lista_ubicaciones)
            {
                comboBox_Ubicacion.Items.Add(ubi_habs);
            }
            comboBox_BajaLogica.Items.Add("True");
            comboBox_BajaLogica.Items.Add("False");

            Habitacion hab_buscada = _habManager.GetHabitacionHotel(Numero_Habitacion_Elegida, ID_hotel_que_estoy_logeado);
            maskedTextBox_NroHab.Text = hab_buscada.numero.ToString();
            maskedTextBox_BajaLogica.Text = hab_buscada.baja_logica.ToString();
            maskedTextBox_Ubicacion.Text = hab_buscada.frente.ToString();
            maskedTextBox_Piso.Text = hab_buscada.piso.ToString();
            maskedTextBox_Tipo.Text = _habtipoManager.Get_Tipo_Hab(hab_buscada.id_tipo_hab);
            textBox_Descrip_Act.Text = hab_buscada.descripcion;
    
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Descripcion.Text.Length > 255)
            {
                MessageBox.Show("Descripcion mayor al tamaño maximo aceptado(255 caracteres)");
                return;
            }

            if (comboBox_BajaLogica.SelectedItem != null && comboBox_Ubicacion.SelectedItem != null
                 && comboBox_Tipo.SelectedItem != null)
            {
                Habitacion hab_modificada = new Habitacion();
                hab_modificada.id_hotel = ID_hotel_que_estoy_logeado;     
                hab_modificada.numero = Numero_Habitacion_Elegida;
                hab_modificada.piso = int.Parse(numericUpDown_Piso.Value.ToString());
                hab_modificada.frente = comboBox_Ubicacion.Text.ToString();
                hab_modificada.baja_logica = Boolean.Parse(comboBox_BajaLogica.Text.ToString());
                hab_modificada.id_tipo_hab = _habtipoManager.Get_ID_Tipo(comboBox_Tipo.Text.ToString());
                hab_modificada.descripcion = textBox_Descripcion.Text.ToString();

                _habManager.ModificarHabitacion(hab_modificada);

                MessageBox.Show("Se modificaron el/los valores de la habitacion");

                //Refresh de los valores actuales
                Habitacion hab_buscada = _habManager.GetHabitacionHotel(Numero_Habitacion_Elegida, ID_hotel_que_estoy_logeado);
                maskedTextBox_NroHab.Text = hab_buscada.numero.ToString();
                maskedTextBox_BajaLogica.Text = hab_buscada.baja_logica.ToString();
                maskedTextBox_Ubicacion.Text = hab_buscada.frente.ToString();
                maskedTextBox_Piso.Text = hab_buscada.piso.ToString();
                maskedTextBox_Tipo.Text = _habtipoManager.Get_Tipo_Hab(hab_buscada.id_tipo_hab);
                textBox_Descrip_Act.Text = hab_buscada.descripcion;

            }
            else
            {
                MessageBox.Show("Rellene todos los campos, son obligatorios");
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
