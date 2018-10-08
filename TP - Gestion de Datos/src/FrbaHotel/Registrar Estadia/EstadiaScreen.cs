using System;
using System.Configuration;
using System.Windows.Forms;
using FrbaHotel.Business;
using FrbaHotel.Commons;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Registrar_Consumible;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class EstadiaScreen : Form
    {
        EstadiaManager _estMan = new EstadiaManager();
        ReservaManager _resMan = new ReservaManager();
        ClienteManager _cliMan = new ClienteManager();
        ConsumibleManager _cons_man = new ConsumibleManager();
        Reserva current_reserva;
        int clientesCargados = 0;
        int cantidadPersonas_deReserva;
        int estadia_checkOut = 0;
        DateTime fechaHoy = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

        public EstadiaScreen()
        {
           
            InitializeComponent();

            MessageBox.Show("Se ejecutará la actualizacion del estado de reservas","FrbaHotel");

            this.UseWaitCursor = true;

            _resMan.actualizarNo_Show();

            this.UseWaitCursor = false;

            dateTimePicker_fecha.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            dateTimePicker_fOut.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            AcceptButton = button_buscar;
        }

        private void buttonRegConsumibles_Click(object sender, EventArgs e)
        {
            Registrar_Consumibles consScreen = new Registrar_Consumibles(estadia_checkOut);
            DialogResult res = consScreen.ShowDialog();
           
            cargarConsumibles(current_reserva.codigo_reserva);
        }

        private void buttonGuardarIN_Click(object sender, EventArgs e)
        {
            _estMan.insertarNuevaEstadia(current_reserva);
            MessageBox.Show("Check In realizado correctamente", current_reserva.codigo_reserva.ToString());
        }

        private void buttonGuardarOUT_Click(object sender, EventArgs e)
        {
            TimeSpan ts = dateTimePicker_fecha.Value - current_reserva.fecha_inicio;
            int dias_estadia = ts.Days; 
            _estMan.cerrarEstadia (estadia_checkOut,dias_estadia);
            button_fact_estadia.Enabled = true;
            button_guardarOUT.Enabled = false;
            button_reg_consum.Enabled = false;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            dataGridView_reserva.Rows.Clear();
            dataGridView_reserva.Refresh();

            if (textBox_codigoReserva.Text.Length == 0)
            {

                MessageBox.Show("Ingrese un numero de reserva");
                return;
            }

            current_reserva = _resMan.getReservaHotel(Convert.ToInt32(textBox_codigoReserva.Text),Sesion.id_hotel);

            if (current_reserva == null)
            {
                MessageBox.Show("No existe una reserva en el hotel "+Sesion.id_hotel.ToString()+" con el código ingresado");
                return;
            }

            cantidadPersonas_deReserva = _resMan.CalcularCantidadDePersonas(current_reserva.codigo_reserva);
            dataGridView_reserva.Rows.Add(current_reserva.fecha_inicio,current_reserva.cant_noches,cantidadPersonas_deReserva);

            string mensaje;
            if (_resMan.esReservaErronea(current_reserva,out mensaje))
            {
                MessageBox.Show(mensaje);
                return;
            }


            if (current_reserva.fecha_inicio > fechaHoy)
            {
                MessageBox.Show("La reserva es posterior al día de hoy.\nEl Check In se realiza el dia de comienzo de la misma");
                return;
            }

            if (current_reserva.estado == 6) //ya se hizo el checkIN
            {
                splitContainer1.Panel1.Visible = false;
                splitContainer1.Panel2.Enabled = true;
                button_guardarOUT.Enabled = true; //si no agrega ningun consumible esta igual
                button_reg_consum.Enabled = true;
                estadia_checkOut = _estMan.getIdPorReserva(current_reserva.codigo_reserva);
                cargarConsumibles(current_reserva.codigo_reserva);
            }
            else //todavia no se hizo el checkIN
            {
                dateTimePicker_fecha.Enabled = true;
                splitContainer1.Panel2.Visible = false;
                splitContainer1.Panel1.Enabled = true;
                button_reg_huesped.Enabled = true;
            }

            int cliente_gen_reserva = _resMan.getClienteGenerador(current_reserva.codigo_reserva);
            
            checkIN_load(cliente_gen_reserva);
           
        }

        public void checkIN_load (int cliente)
        {
            Cliente cli = _cliMan.Build(cliente);
            dataGridView_huesped.Rows.Add(cli.apellido,cli.nombre);
            clientesCargados += 1;
            if (clientesCargados == cantidadPersonas_deReserva)
                button_guardarIN.Enabled = true;
        }

        private void buttonRegistrarHuesped_click(object sender, EventArgs e)
        {

            if (clientesCargados >= cantidadPersonas_deReserva)
            {
                MessageBox.Show("Ya se han cargado todos los clientes de la reserva");
                return;
            }
            
            ClientesSelection clientesSeleccion = new ClientesSelection(current_reserva.codigo_reserva);
       
            DialogResult res = clientesSeleccion.ShowDialog();
            if (res == DialogResult.OK)
            {
                checkIN_load(clientesSeleccion.ret_cliente); //el cliente ya fue cargado en el form hijo
            }

            if (clientesCargados == cantidadPersonas_deReserva)
            {
                button_guardarIN.Enabled = true;
            }
 
        }

        private void cargarConsumibles(int cod_reserva)
        {
            this.dataGridView_consum.DataSource = _cons_man.GetConsumiblesDeReserva(current_reserva.codigo_reserva);
            this.dataGridView_consum.Refresh();
        }

        private void buttonFacturar_Click(object sender, EventArgs e)
        {
            Facturar_Estadias fact_screen = new Facturar_Estadias (estadia_checkOut);
            fact_screen.ShowDialog();
         
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_fact_estadia_Click(object sender, EventArgs e)
        {
            Facturar_Estadias fact = new Facturar_Estadias(estadia_checkOut);
            DialogResult res = fact.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
