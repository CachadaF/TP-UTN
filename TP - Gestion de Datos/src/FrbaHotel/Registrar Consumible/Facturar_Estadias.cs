using System;
using System.Windows.Forms;
using FrbaHotel.Business;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class Facturar_Estadias : Form
    {
        private EstadiaManager _estadiaManager = new EstadiaManager();

        private TarjetaManager _tarjetaManager = new TarjetaManager();

        private string tarj_cred = "Tarjeta de Credito";
        private string tarj_deb = "Tarjeta de Debito";
        public int id_estadia;

        public Facturar_Estadias() //me lo manda la pantalla de checkout
        {
            InitializeComponent();
            maskedTextBox1.Text = Convert.ToString(Sesion.id_hotel);
            ini_campos();
            textBox_estadia.Enabled = true;
        }


        public Facturar_Estadias(int id_estadia) //me lo manda la pantalla de checkout
        {
            InitializeComponent();

             textBox_estadia.Text = id_estadia.ToString();
             maskedTextBox1.Text = Sesion.id_hotel.ToString();
       //     }
       //     else
       //     {
       //         var estadias_para_facturar = _estadiaManager.GetAllEstadiasSinFacturarPorHotel(ID_HOTEL_PRUEBA);
       //        foreach (Estadia tipo_estadia in estadias_para_facturar)
       //         {
       //             comboBox_Estadia.Items.Add(tipo_estadia.id_estadia);
       //        }
       //     }
            ini_campos();

        }
        private void ini_campos()
        {
            comboBox_FormaDePago.Items.Add("Efectivo");
            comboBox_FormaDePago.Items.Add("Tarjeta de Credito");
            comboBox_FormaDePago.Items.Add("Tarjeta de Debito");
            comboBox_Cuotas.Items.Add("1");
            comboBox_Cuotas.Items.Add("3");
            comboBox_Cuotas.Items.Add("6");
            comboBox_Cuotas.Items.Add("12");

            //comboBox_FormaDePago.Enabled = false;
            comboBox_Cuotas.Enabled = false;
            numericUpDown_Tarjeta.Enabled = false;
            panel_Tarjeta.Hide();
            //button_Facturar.Enabled = false;
        }
        private void Facturar_Click(object sender, EventArgs e)
        {

            decimal valor_estadia = 0;
            bool Estado_Tarjeta = false;

            if (string.IsNullOrEmpty(textBox_estadia.Text))
            {
                MessageBox.Show("Ingrese numero de estadia");
                return;
            }

            if (comboBox_FormaDePago.SelectedItem == null || (comboBox_Cuotas.Enabled == true && (comboBox_Cuotas.SelectedItem == null)))
            {
                MessageBox.Show("Faltan seleccionar campos");
            }
            else
            {
                if (int.Parse(numericUpDown_Tarjeta.Text.ToString()) == 0 && (comboBox_FormaDePago.Text.ToString() == tarj_cred || comboBox_FormaDePago.Text.ToString() == tarj_deb))
                {
                    MessageBox.Show("Numero de tarjeta no valido, ingrese un numero valido");
                }
                else
                {
                    Estado_Tarjeta = _tarjetaManager.ExisteTarjeta(int.Parse(numericUpDown_Tarjeta.Value.ToString())
                        ,comboBox_FormaDePago.Text.ToString());
                    if (Estado_Tarjeta == false && comboBox_FormaDePago.Text.ToString() != "Efectivo")
                    {
                        MessageBox.Show("Su tarjeta no esta cargada en el sistema, ingresela a continuacion");
                        Form abrir_tarj = new FrbaHotel.Registrar_Consumible.TarjetaFacturas();
                        abrir_tarj.ShowDialog();
                        return;
                    }

                    if (comboBox_FormaDePago.Text.ToString() == tarj_cred || comboBox_FormaDePago.Text.ToString() == tarj_deb)
                    {
                        valor_estadia = _estadiaManager.GetValorEstadiaFinal(
                         comboBox_FormaDePago.Text.ToString(),
                         int.Parse(textBox_estadia.Text.ToString()),
                         int.Parse(comboBox_Cuotas.Text.ToString()),
                         int.Parse(numericUpDown_Tarjeta.Text.ToString())
                         );
                    }
                    else
                    {
                         valor_estadia = _estadiaManager.GetValorEstadiaFinal(
                         comboBox_FormaDePago.Text.ToString(),
                         int.Parse(textBox_estadia.Text.ToString()),
                         0,0
                         );
                    }
                    //MessageBox.Show( String.Format("Monto Total:{0}",valor_estadia.ToString()));
                    //Muestro la factura
                    //
                    Form abrir = new FrbaHotel.Registrar_Consumible.Factura_Final(valor_estadia, int.Parse(textBox_estadia.Text.ToString()));
                    abrir.ShowDialog();
                    //
                    //Recargo ventanas
                    comboBox_FormaDePago.Enabled = false;
                    comboBox_Cuotas.Enabled = false;
                    numericUpDown_Tarjeta.Enabled = false;
                    panel_Tarjeta.Hide();
                    textBox_estadia.Text = "";
                    comboBox_FormaDePago.Text = "";
                    comboBox_Cuotas.Text = "";
                }
            }        
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_FormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_FormaDePago.Text.ToString() == tarj_cred || comboBox_FormaDePago.Text.ToString() == tarj_deb)
            {
                panel_Tarjeta.Show();
                comboBox_Cuotas.Enabled = true;
                numericUpDown_Tarjeta.Enabled = true;
            }
            else
            {
                panel_Tarjeta.Hide();
                comboBox_Cuotas.Enabled = false;
                numericUpDown_Tarjeta.Enabled = false;
            }
        }

        private void comboBox_Estadia_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_FormaDePago.Enabled = true;
            button_Facturar.Enabled = true;
        }
    }
}
