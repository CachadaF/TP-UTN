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
    public partial class ModificacionDeHotel : Form
    {
        private HotelManager _HotelManager = new HotelManager();

        private RegimenManager _RegimenManager = new RegimenManager();

        private int ID_Hotel_global = 0;

        private void recargaModificaciones()
        {
            comboBox_RegAdd.Items.Clear();
            comboBox_RegABorrar.Items.Clear();
            comboBox_CantEstre.Items.Clear();
            dataGridView_Regimenes.Rows.Clear();
            dataGridView_Regimenes.Refresh();
            button_Agregar.Enabled = false;
            button_BorrarRegimen.Enabled = false;


            Hotel hotel = _HotelManager.GetPorIDHotel(ID_Hotel_global);
            comboBox_CantEstre.Items.Add("1");
            comboBox_CantEstre.Items.Add("2");
            comboBox_CantEstre.Items.Add("3");
            comboBox_CantEstre.Items.Add("4");
            comboBox_CantEstre.Items.Add("5");
            maskedTextBox_Calle.Text = hotel.calle;
            textBox_Calle.Text = hotel.calle;
            maskedTextBox_CantEstrellas.Text = hotel.cant_estrellas.ToString();
            comboBox_CantEstre.SelectedItem = hotel.cant_estrellas.ToString();
            maskedTextBox_Ciudad.Text = hotel.ciudad;
            textBox_Ciudad.Text = hotel.ciudad;
            maskedTextBox_FchCrea.Text = hotel.fecha_creacion.ToString();
            maskedTextBox_Nrocalle.Text = hotel.nro_calle.ToString();
            numericUpDown_Nrocalle.Value = hotel.nro_calle;
            maskedTextBox_Pais.Text = hotel.pais.ToString();
            textBox_Pais.Text = hotel.pais.ToString();
            maskedTextBox_RecargaEstrellas.Text = hotel.recarga_estrella.ToString();
            numericUpDown_RecargaEstre.Value = hotel.recarga_estrella;
            maskedTextBox_Telefono.Text = hotel.telefono.ToString();
            textBox_Telefono.Text = hotel.telefono.ToString();
            
            BindingList<Regimen> lista_regimenes_del_hotel = _HotelManager.GetAllRegimenPorHotel(hotel.id_hotel);

            BindingList<Regimen> lista_regimenes_faltantes = _RegimenManager.GetNoRepetidos(hotel.id_hotel);

            BindingList<Regimen> lista_regimenes_borrables = _RegimenManager.GetBorrablesPorHotel(hotel.id_hotel);

            foreach (Regimen reg in lista_regimenes_del_hotel)
            {
                dataGridView_Regimenes.Rows.Add(reg.id_regimen.ToString(), reg.descripcion.ToString(),
                reg.precio.ToString(), reg.estado.ToString());
            }

            foreach (Regimen reg_fal in lista_regimenes_faltantes)
            {
                comboBox_RegAdd.Items.Add(reg_fal.descripcion);
            }

            foreach(Regimen reg_borrable in lista_regimenes_borrables)
            {
                comboBox_RegABorrar.Items.Add(reg_borrable.descripcion);
            }
        }

        public ModificacionDeHotel(int ID_Value)
        {
            InitializeComponent();

            this.Text += ' ' + ID_Value.ToString();

            ID_Hotel_global = ID_Value;

            recargaModificaciones();
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {
            Hotel hotel_modificado = new Hotel();
            hotel_modificado.id_hotel = ID_Hotel_global;
            hotel_modificado.nro_calle = int.Parse(numericUpDown_Nrocalle.Value.ToString());
            hotel_modificado.calle = textBox_Calle.Text.ToString();
            hotel_modificado.cant_estrellas = int.Parse(comboBox_CantEstre.Text.ToString());
            hotel_modificado.ciudad = textBox_Ciudad.Text.ToString();
            hotel_modificado.pais = textBox_Pais.Text.ToString();
            hotel_modificado.recarga_estrella = decimal.Parse(numericUpDown_RecargaEstre.Value.ToString());
            hotel_modificado.telefono = textBox_Telefono.Text.ToString();

            _HotelManager.ModificarHotel(hotel_modificado);
            recargaModificaciones();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            _RegimenManager.InsertarNuevoRegimenHotel(ID_Hotel_global, comboBox_RegAdd.Text.ToString());
            recargaModificaciones();
        }

        private void comboBox_RegAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Agregar.Enabled = true;
        }

        private void comboBox_RegABorrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_BorrarRegimen.Enabled = true;
        }

        private void button_BorrarRegimen_Click(object sender, EventArgs e)
        {
            _RegimenManager.EliminarRegimenHotel(ID_Hotel_global, comboBox_RegABorrar.Text.ToString());
            recargaModificaciones();
        }
    }
}
