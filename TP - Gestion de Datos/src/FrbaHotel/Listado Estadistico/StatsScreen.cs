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

namespace FrbaHotel.Listado_Estadistico
{
    public partial class StatsScreen : Form
    {

        private string ptos_cliente = "Clientes con más puntos";
        private string res_cancel = "Reservas canceladas";
        private string cons_fact = "Consumibles facturados";
        private string hab_usadas = "Habitaciones más utilizadas";
        private string hot_fuera_serv = "Hoteles fuera de servicio";

        public StatsScreen()
        {
            InitializeComponent();
            int CurrentYear = DateTime.Today.Year;
            
            int i = CurrentYear;
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString()
                        , "LOS_NULL.DAMEMENORFECHA");
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    i = int.Parse(row["Año"].ToString());
                }
            }

            for (; i <= CurrentYear; i++)
            {
                comboBox_anio.Items.Add(i);
            }
            comboBox_trim.Items.Add(1);
            comboBox_trim.Items.Add(2);
            comboBox_trim.Items.Add(3);
            comboBox_trim.Items.Add(4);
            comboBox_categor.Items.Add(res_cancel);
            comboBox_categor.Items.Add(cons_fact);
            comboBox_categor.Items.Add(hot_fuera_serv);
            comboBox_categor.Items.Add(hab_usadas);
            comboBox_categor.Items.Add(ptos_cliente);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            if (comboBox_anio.SelectedItem == null)
            {
                MessageBox.Show("Falta ingresar el año");
            }
            else
            {
                if (comboBox_trim.SelectedItem == null)
                {
                    MessageBox.Show("Falta ingresar el Trimestre");
                }
                else
                {
                    if (comboBox_categor.SelectedItem == null)
                    {
                        MessageBox.Show("Falta ingresar el Listado");
                    }
                    else
                    {
                        if (comboBox_categor.Text == ptos_cliente)
                        {
                            SqlDataAdapter sda = new SqlDataAdapter(@"LOS_NULL.TOP5PUNTOSXCLIENTE '" + Trimestre.calcularFechaTrimestre(int.Parse(comboBox_anio.Text)
                            ,int.Parse(comboBox_trim.Text)).ToShortDateString() + @"'"
                            ,ConfigurationManager.ConnectionStrings["StringConexion"].ToString());
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        if (comboBox_categor.Text == res_cancel)
                        {
                            SqlDataAdapter sda = new SqlDataAdapter(@"LOS_NULL.TOP5RESERVASCANCELADAS '" + Trimestre.calcularFechaTrimestre(int.Parse(comboBox_anio.Text)
                            , int.Parse(comboBox_trim.Text)).ToShortDateString() + @"'"
                            , ConfigurationManager.ConnectionStrings["StringConexion"].ToString());
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        if (comboBox_categor.Text == cons_fact)
                        {
                            SqlDataAdapter sda = new SqlDataAdapter(@"LOS_NULL.TOP5CONSUMIBLESFACTURADOS '" + Trimestre.calcularFechaTrimestre(int.Parse(comboBox_anio.Text)
                            , int.Parse(comboBox_trim.Text)).ToShortDateString() + @"'"
                            , ConfigurationManager.ConnectionStrings["StringConexion"].ToString());
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        if (comboBox_categor.Text == hab_usadas)
                        {
                            SqlDataAdapter sda = new SqlDataAdapter(@"LOS_NULL.TOP5HABITACIONESOCUPADAS '" + Trimestre.calcularFechaTrimestre(int.Parse(comboBox_anio.Text)
                            , int.Parse(comboBox_trim.Text)).ToShortDateString() + @"'"
                            , ConfigurationManager.ConnectionStrings["StringConexion"].ToString());
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        if (comboBox_categor.Text == hot_fuera_serv)
                        {
                            SqlDataAdapter sda = new SqlDataAdapter(@"LOS_NULL.TOP5HOTELESFUERADESERVICIO '" + Trimestre.calcularFechaTrimestre(int.Parse(comboBox_anio.Text)
                            , int.Parse(comboBox_trim.Text)).ToShortDateString() + @"'"
                            , ConfigurationManager.ConnectionStrings["StringConexion"].ToString());
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }     
                    }
                }
            }
        }

        private void comboBox_categor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
