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
    public partial class Factura_Final : Form
    {
        private ConsumibleManager _consumibleManager = new ConsumibleManager();

        public Factura_Final(decimal valor_final_factura,int id_estadia)
        {
            InitializeComponent();
            maskedTextBox_MontoTotal.Text = valor_final_factura.ToString();

            BindingList<Item_factura> lista_item_factura = _consumibleManager.GetAllItemsFacturaEstadia(id_estadia);

                foreach (Item_factura item in lista_item_factura)
                {
                    dataGridView_Factura.Rows.Add(item.consumible,item.descripcion,item.cantidad,item.monto);
                    maskedTextBox_Factura.Text = item.factura.ToString();
                }
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
