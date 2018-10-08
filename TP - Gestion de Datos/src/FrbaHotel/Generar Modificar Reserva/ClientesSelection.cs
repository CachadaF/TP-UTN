using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrbaHotel.Business;
using FrbaHotel.Commons;
using FrbaHotel.Registrar_Estadia;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class ClientesSelection : Form
    {
        private int NumeroReservaGlobal = 0;

        private ClienteManager _clienteManager = new ClienteManager();

        private ReservaManager _ReservaManager = new ReservaManager();

        public int ret_cliente; //variable que se le pasa al Form padre de Estadia

        public ClientesSelection(int CodigoReserva)
        {
            InitializeComponent();

            NumeroReservaGlobal = CodigoReserva;

            /*
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString()
                , "LOS_NULL.GET_TIPODOC");
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    this.comboBox_tipoDoc.Items.Add(row["Descripcion"].ToString());
                }
            }*/
            this.textBox_doc.Focus();
            this.AcceptButton = button_Buscar;
            this.comboBox_tipoDoc.Items.Add("Pasaporte");

        }

        private void button_Seleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Clientes.RowCount > 0 )
            {
                if (dataGridView_Clientes.SelectedRows != null)
                {
                    foreach (DataGridViewRow selected_row in dataGridView_Clientes.SelectedRows)
                    {
                        int ID_Cliente = Convert.ToInt32(selected_row.Cells["ID_Cliente"].Value.ToString());
                        try
                        {
                            _ReservaManager.InsertClientexReserva(NumeroReservaGlobal, ID_Cliente);
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Ese cliente ya se ingresó.");
                            return;
                        }

                        ret_cliente = ID_Cliente;
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccione los datos del Cliente");

                    return;
                }
            }
            else
            {
                MessageBox.Show("No hay elementos para seleccionar");
            }

        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            Form abrir = new FrbaHotel.ABM_de_Cliente.AddEditClientes();
            abrir.ShowDialog();
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            if (textBox_apellido.Text.Length == 0 && textBox_doc.Text.Length == 0 && textBox_mail.Text.Length == 0 && textBox_nombre.Text.Length == 0)
            {
                MessageBox.Show("Por favor rellene algun campo de filtrado");
            }
            else
            {
                try
                {
                    int doc;
                    if (!string.IsNullOrEmpty(textBox_doc.Text))
                        doc = Convert.ToInt32(textBox_doc.Text);
                    else doc = 0;

                    BindingList<Cliente> listado = _clienteManager.listado_cliente_por_datos(
                        doc,
                        textBox_nombre.Text.Trim(),
                        textBox_apellido.Text.Trim(),
                        textBox_mail.Text.Trim());

                    dataGridView_Clientes.DataSource = listado;
                }
                catch (FormatException f)
                {
                    MessageBox.Show("Solo ingresar numeros en Documento.\n" + f);
                }
            }
         

        }

        private void doble_click_fila(EstadiaScreen estadia_screen)
        {

        }
    }
}
