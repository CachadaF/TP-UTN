using System;
using System.Data;
using System.Windows.Forms;
using FrbaHotel.Commons;
using FrbaHotel.Business;
using System.Data.SqlClient;
using FrbaHotel_Commons;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class AddEditClientes : Form
    {
        NacionalidadManager _nacionalidadManager = new NacionalidadManager();
        ClienteManager _clienteManager = new ClienteManager();
        Cliente clienteModificado=null;

        public AddEditClientes()
        {
            InitializeComponent();
            var nacionalidades = _nacionalidadManager.GetAll();
            foreach (Nacionalidad n in nacionalidades)
            {
                this.combo_nacionalidad.Items.Add(n.descripcion);
            }
        }

        public AddEditClientes(Cliente cli)
        {
            //Modificacion de cliente seleccionado
            InitializeComponent();

            this.button_guardar.Text = "Actualizar";

            #region Carga valores ant
            clienteModificado = cli;
            textBox_nombre.Text = cli.nombre;
            textBox_apellido.Text = cli.apellido;
            textBox_doc.Text = Convert.ToString(cli.pasaporte);
            var nacionalidades = _nacionalidadManager.GetAll();
            foreach (Nacionalidad n in nacionalidades)
            {
                this.combo_nacionalidad.Items.Add(n.descripcion);
            }
            combo_nacionalidad.SelectedIndex = 0;
            dateTimePicker_fecha.Value = cli.fecha_nac;
            textBox_mail.Text = cli.mail;
            textBox_dpto.Text = cli.nro_depto;
            textBox_calle.Text = cli.dom_calle;
            textBox_num.Text = Convert.ToString(cli.dom_numero);
            textBox_piso.Text = Convert.ToString(cli.piso);
            checkBox_habilitado.Checked = !cli.baja_logica;
            
            #endregion
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            #region Toma los valores
            if(clienteModificado!=null) cliente.id_cliente = clienteModificado.id_cliente;
            cliente.nombre = textBox_nombre.Text.Trim();
            cliente.apellido = textBox_apellido.Text.Trim();
            cliente.nacionalidad = combo_nacionalidad.SelectedIndex+1;
            cliente.fecha_nac = dateTimePicker_fecha.Value;
            cliente.mail = textBox_mail.Text.Trim();
            cliente.nro_depto = textBox_dpto.Text.Trim();
            cliente.dom_calle = textBox_calle.Text.Trim();
            try
            {
                cliente.dom_numero = Convert.ToInt32(textBox_num.Text.Trim());
                cliente.pasaporte = Convert.ToInt32(textBox_doc.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese solo numeros en los campos Documento y Numero");
                return;
            }
            if (!string.IsNullOrEmpty(textBox_piso.Text))
                cliente.piso = Convert.ToInt32(textBox_piso.Text.Trim());
            else cliente.piso = -1;
            cliente.baja_logica = !checkBox_habilitado.Checked;
            #endregion

            string mensajeBD="";
            if (clienteModificado != null)
                mensajeBD = _clienteManager.ActualizarCliente(cliente);
            else
                mensajeBD = _clienteManager.AgregarCliente(cliente);

            if (string.IsNullOrEmpty(mensajeBD))
                this.Close();
            else
                MessageBox.Show(mensajeBD);

        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
