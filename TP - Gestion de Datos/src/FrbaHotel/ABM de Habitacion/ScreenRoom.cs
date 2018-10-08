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
    public partial class ScreenRoom : Form
    {
        private HabitacionManager _HabitacionManager = new HabitacionManager();

        private int ID_Hotel_que_estoy_logeado = 0;

        public ScreenRoom(int ID_Hotel_Logeado)
        {
            InitializeComponent();

            ID_Hotel_que_estoy_logeado = ID_Hotel_Logeado;

            maskedTextBox_Hotel.Text = ID_Hotel_que_estoy_logeado.ToString();

            recargar_habitaciones_estado();

        }

        private void recargar_habitaciones_estado()
        {
            dataGrid_Habitaciones.Rows.Clear();
            dataGrid_Habitaciones.Refresh();

            BindingList<Habitacion> lista_habitaciones = _HabitacionManager.GetAllPorHotel(ID_Hotel_que_estoy_logeado);

            foreach (Habitacion hab in lista_habitaciones)
            {
                dataGrid_Habitaciones.Rows.Add(hab.id_habitacion, hab.numero, hab.piso, hab.id_tipo_hab, hab.id_hotel,
                    hab.frente, hab.baja_logica,hab.descripcion);
            }

        }

        private void button_Borrado_Click(object sender, EventArgs e)
        {
            if (dataGrid_Habitaciones.RowCount > 0)
            {
                int numero_habitacion = int.Parse(dataGrid_Habitaciones.CurrentRow.Cells["Numero"].Value.ToString());

                if (bool.Parse(dataGrid_Habitaciones.CurrentRow.Cells["Baja_Logica"].Value.ToString()) == false)
                {
                    Form abrir = new FrbaHotel.ABM_de_Habitacion.DeleteRoom(ID_Hotel_que_estoy_logeado, numero_habitacion);
                    abrir.ShowDialog();
                }
                else
                {
                    MessageBox.Show("La habitacion Nro : "+numero_habitacion.ToString()+" ya esta dada de baja");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una habitacion");
            }          
            recargar_habitaciones_estado();
        }

        private void button_modRoom_Click(object sender, EventArgs e)
        {
            if (dataGrid_Habitaciones.RowCount > 0)
            {
                int numero_habitacion = int.Parse(dataGrid_Habitaciones.CurrentRow.Cells["Numero"].Value.ToString());
                Form abrir = new FrbaHotel.ABM_de_Habitacion.EditRoom(ID_Hotel_que_estoy_logeado, numero_habitacion);
                abrir.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una habitacion");
            }
            recargar_habitaciones_estado();
        }

        private void button_newRoom_Click(object sender, EventArgs e)
        {
            Form abrir = new FrbaHotel.ABM_de_Habitacion.AddRoom(ID_Hotel_que_estoy_logeado);
            abrir.ShowDialog();

            recargar_habitaciones_estado();
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
