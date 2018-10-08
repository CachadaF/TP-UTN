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
    public partial class Registrar_Consumibles : Form
    {
        private EstadiaManager _estadiaManager = new EstadiaManager();

        private ConsumibleManager _consumiblesManager = new ConsumibleManager();

        public DataGridView dataGridFromParent;

        public Registrar_Consumibles(int id_estadia) //se lo paso desde el screen de checkOut Estadia
        {
            InitializeComponent();

            /*HARDCODEADO EL HOTEL 1
            int ID_HOTEL_PRUEBA = 1;

            if (id_estadia != null) //se lo pase desde el checkout
            {*/
            textBox_estadia.Text = id_estadia.ToString(); //unicamente cargo el id pasado por parametro 
            maskedTextBox_hotel.Text = Sesion.id_hotel.ToString();
        //    }
        //    else
        /*    {
                var estadias_sin_facturar = _estadiaManager.GetAllPorHotel(ID_HOTEL_PRUEBA);
                foreach (Estadia tipo_estadia in estadias_sin_facturar)
                {
                    comboBox_Estadias_SinFacturar.Items.Add(tipo_estadia.id_estadia);
                }
            }*/

                   
            var consumibles_que_tengo = _consumiblesManager.GetAll();
            foreach (Consumible tipo_consu in consumibles_que_tengo)
            {
                comboBox_Consumibles.Items.Add(tipo_consu.descripcion);
            }
            maskedTextBox_Precio.Enabled = false;
            numericUpDown_Cantidad.Enabled = false;
            button_Registrar.Enabled = false;
            comboBox_Consumibles.Enabled = false;
            button_AgregarConsumible.Enabled = false;
            button_Limpiar.Enabled = false;
            button_EliminarConsumible.Enabled = false;

        }

        private void button_Registrar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Consumibles.RowCount == 0)
            {
                MessageBox.Show("Ingrese consumibles");
            }
            else
            {
                dataGridFromParent = dataGridView_Consumibles; //lo asigno para mostrarlos en la pantalla de checkout
                var lista_item_factura = new BindingList<Item_factura>();
                foreach (DataGridViewRow dr in dataGridView_Consumibles.Rows)
                {
                    Item_factura item_fact = new Item_factura();
                    item_fact.consumible = _consumiblesManager.GetNumeroConsumible(dr.Cells["Consumible"].Value.ToString());
                    item_fact.cantidad = int.Parse(dr.Cells["Cantidad"].Value.ToString());
                    item_fact.monto = decimal.Parse(dr.Cells["Precio"].Value.ToString()) * int.Parse(dr.Cells["Cantidad"].Value.ToString());
                    item_fact.estadia = int.Parse(comboBox_Estadias_SinFacturar.Text.ToString());
                    lista_item_factura.Add(item_fact);

                }
                _consumiblesManager.Insertar_Items_Factura(lista_item_factura);
                MessageBox.Show("Se han registrado los consumibles con exito");

                //Limpio todo y bloqueo las ventanas
                maskedTextBox_Precio.Enabled = false;
                numericUpDown_Cantidad.Enabled = false;
                button_Registrar.Enabled = false;
                comboBox_Consumibles.Enabled = false;
                button_AgregarConsumible.Enabled = false;
                button_Limpiar.Enabled = false;
                button_EliminarConsumible.Enabled = false;
                dataGridView_Consumibles.Rows.Clear();
                dataGridView_Consumibles.Refresh();
                textBox_estadia.Text = "";
             //   comboBox_Estadias_SinFacturar.Items.Clear();
                //HARDCODEADO EL HOTEL 1
             //   int ID_HOTEL_PRUEBA = 1;
            /*    var estadias_sin_facturar = _estadiaManager.GetAllPorHotel(ID_HOTEL_PRUEBA);
                foreach (Estadia tipo_estadia in estadias_sin_facturar)
                {
                    comboBox_Estadias_SinFacturar.Items.Add(tipo_estadia.id_estadia);
                }*/
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void comboBox_Consumibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Registrar.Enabled = true;
            button_AgregarConsumible.Enabled = true;
            numericUpDown_Cantidad.Enabled = true;
            button_EliminarConsumible.Enabled = true;
            decimal precio = _consumiblesManager.GetPrecioParaConsumible(comboBox_Consumibles.Text.ToString());

            maskedTextBox_Precio.Text = precio.ToString();

        }

        private void comboBox_Estadias_SinFacturar_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Consumibles.Enabled = true;
            button_Limpiar.Enabled = true;
        }

        private void button_AgregarConsumible_Click(object sender, EventArgs e)
        {
            dataGridView_Consumibles.Rows.Add(comboBox_Consumibles.Text.ToString(),numericUpDown_Cantidad.Text.ToString(), maskedTextBox_Precio.Text.ToString());            

        }

        private void EliminarConsumible_Click(object sender, EventArgs e)
        {
            //Verifica si hay valores para borrar
            if (dataGridView_Consumibles.CurrentRow == null)
            {
                //Envia error cuando no hay mas filas que borrar
                MessageBox.Show("No hay mas consumibles para borrar");
            }
            else
            { 
                //Borra una fila
                dataGridView_Consumibles.Rows.RemoveAt(dataGridView_Consumibles.CurrentCell.RowIndex);          
            }
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            dataGridView_Consumibles.Rows.Clear();
            dataGridView_Consumibles.Refresh();
        }
    }
}
