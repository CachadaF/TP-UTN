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

namespace FrbaHotel.Registrar_Consumible
{
    public partial class TarjetaFacturas : Form
    {

        private TarjetaManager _tarjetaManager = new TarjetaManager();

        public TarjetaFacturas()
        {
            InitializeComponent();

            comboBox_Tipo.Items.Add("Tarjeta de Credito");
            comboBox_Tipo.Items.Add("Tarjeta de Debito");
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (numericUpDown_NroTarjeta.Value == 0 || comboBox_Tipo.SelectedItem == null)
            {
                MessageBox.Show("Falta uno de los campos obligatorios");
                return;
            }

            if (textBox_Descripcion.Text.Length > 255)
            {
                MessageBox.Show("Descripcion supera los 255 caracteres (Debe ser menor a 255)");
                return;
            }

            bool existe_tarjeta = false;

            existe_tarjeta = _tarjetaManager.ExisteTarjeta(int.Parse(numericUpDown_NroTarjeta.Value.ToString())
                ,comboBox_Tipo.Text.ToString());


            if (existe_tarjeta == true)
            {
                MessageBox.Show("Tarjeta existente");
                return;
            }

            Tarjeta tarj = new Tarjeta();
            tarj.numero = int.Parse(numericUpDown_NroTarjeta.Value.ToString());
            tarj.tipo = comboBox_Tipo.Text.ToString();

            if (textBox_Descripcion.Text.Length == 0)
            {
                tarj.descripcion = " ";
            }
            else
            {
                tarj.descripcion = textBox_Descripcion.Text.ToString();
            }


            _tarjetaManager.InsertarTarjeta(tarj);

            MessageBox.Show("Su tarjeta ha sido cargada, pruebe de realizar la factura ahora");

            this.Close();
        }
    }
}
