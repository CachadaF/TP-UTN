using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using FrbaHotel.Business;
using FrbaHotel.Commons;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class AltaModReservasScreen : Form
    {
        private HotelManager _HotelManager = new HotelManager();

        private ReservaManager _ReservaManager = new ReservaManager();

        private ClienteManager _ClienteManager = new ClienteManager();

        private Tipo_habitacionManager _TipoHabitacionManager = new Tipo_habitacionManager();

        private int ID_Hotel_global = 0;

        private string usuario_logeado;

        public AltaModReservasScreen(int hotel_en_que_me_logee, string user_logeado)
        {
            InitializeComponent();

            if (hotel_en_que_me_logee == 0)
            {
                panel_Hoteles.Show();
                usuario_logeado = user_logeado;
                maskedTextBox_Usuario.Text = Sesion.user_id;
                panel_Fecha.Enabled = false;
                panel_Cantidad.Enabled = false;
            }
            else
            {
                ID_Hotel_global = hotel_en_que_me_logee;
                maskedTextBox_Usuario.Text = user_logeado.ToString();
                panel_Hoteles.Hide();
                usuario_logeado = user_logeado;
                panel_Fecha.Enabled = true;
                maskedTextBox_Hotel.Text = ID_Hotel_global.ToString();
                panel_Cantidad.Enabled = false;
            }

            dateTimePicker_Inicio.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Inicio.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker_Inicio.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            dateTimePicker_Fin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Fin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker_Fin.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            panel_Habitaciones.Enabled = false;
            panel_Regimenes.Enabled = false;
            panel_Cantidad.Enabled = false;

            recargar_tipo_habitacion();

            recargar_hotelesytipo();
        }

        //Recarga los tipos de habitacion disponibles dependiendo del hotel seleccionado y la cantidad
        private void recargar_tipo_habitacion()
        {
            if (comboBox_Cantidad.SelectedItem != null )
            {
                Tipo_habitacion tipo_h = _TipoHabitacionManager.GetPorCantidad(int.Parse(comboBox_Cantidad.SelectedItem.ToString()));

                maskedTextBox_Tipo.Text = tipo_h.descripcion.ToString();

                dataGridView_Habitaciones.Rows.Clear();
                dataGridView_Habitaciones.Refresh();

                BindingList<Habitacion> habitaciones_disponibles = _HotelManager.GetAllHabitacionDisponiblesEnFechaYCantidad(
                    ID_Hotel_global,tipo_h.codigo_tipo,DateTime.Parse(dateTimePicker_Inicio.Text.ToString()),
                    DateTime.Parse(dateTimePicker_Fin.Text.ToString()));

                foreach (Habitacion hab_dispo in habitaciones_disponibles)
                {
                    dataGridView_Habitaciones.Rows.Add(hab_dispo.id_habitacion, hab_dispo.id_hotel, hab_dispo.numero, 
                        hab_dispo.piso, hab_dispo.id_tipo_hab,  hab_dispo.frente, hab_dispo.baja_logica);
                }

                if (dataGridView_Habitaciones.RowCount > 0)
                {
                    panel_Habitaciones.Enabled = true;
                }
                else
                {
                    panel_Habitaciones.Enabled = false;
                }
            }
        }

        //Recarga los regimenes cuando cambio el hotel
        private void recargar_regimenes()
        {
            comboBox_Regimenes.Items.Clear();
            maskedTextBox_PrecioDia.Text = " ";
            maskedTextBox_ValTotalRes.Text = " ";

            BindingList<Regimen> lista_regimenes_del_hotel = _HotelManager.GetAllRegimenPorHotel(ID_Hotel_global);

            foreach (Regimen reg_hotel in lista_regimenes_del_hotel)
            {
                comboBox_Regimenes.Items.Add(reg_hotel.descripcion);
            }
        }
        //Recarga hoteles y tipos de habitacion
        private void recargar_hotelesytipo()
        {
            comboBox_Hoteles.Items.Clear();
            comboBox_Cantidad.Items.Clear();

            BindingList<int> lista_id_hoteles = _HotelManager.GetAll();

            foreach (int id_hoteles in lista_id_hoteles)
            {
                comboBox_Hoteles.Items.Add(id_hoteles.ToString());
            }

            BindingList<Tipo_habitacion> tipos_habit = _TipoHabitacionManager.GetAll();

            foreach (Tipo_habitacion tipo in tipos_habit)
            {
                comboBox_Cantidad.Items.Add(tipo.capacidad.ToString());
            }
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Evento de cambios en hotel -> Activa las fechas
        private void comboBox_Hoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID_Hotel_global = int.Parse(comboBox_Hoteles.SelectedItem.ToString());
            maskedTextBox_Hotel.Text = ID_Hotel_global.ToString();
            panel_Fecha.Enabled = true;
        }

        //Evento de Cantidades que van a ir a la habitacion -> Cambia la habitaciones disponibles si hay
        private void comboBox_Cantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            recargar_tipo_habitacion();
        }

        //Activa los regimenes cuando seleccionas una habitacion dependiendo del hotel
        private void button_SelecHab_Click(object sender, EventArgs e)
        {
            if (dataGridView_Habitaciones.RowCount <= 0)
            {
                MessageBox.Show("No selecciono ninguna habitacion");
                return;
            }

            Habitacion hab_aux = new Habitacion();
            hab_aux.id_habitacion = int.Parse(dataGridView_Habitaciones.CurrentRow.Cells["ID_Habitacion"].Value.ToString());
            hab_aux.numero = int.Parse(dataGridView_Habitaciones.CurrentRow.Cells["Numero"].Value.ToString());
            hab_aux.piso = int.Parse(dataGridView_Habitaciones.CurrentRow.Cells["Piso"].Value.ToString());
            hab_aux.id_tipo_hab = int.Parse(dataGridView_Habitaciones.CurrentRow.Cells["Codigo_Tipo"].Value.ToString());
            hab_aux.id_hotel = int.Parse(dataGridView_Habitaciones.CurrentRow.Cells["ID_Hotel"].Value.ToString());
            hab_aux.frente = dataGridView_Habitaciones.CurrentRow.Cells["Frente"].Value.ToString();
            hab_aux.baja_logica = bool.Parse(dataGridView_Habitaciones.CurrentRow.Cells["Baja_Logica"].Value.ToString());

            foreach (DataGridViewRow row in dataGridView_Seleccionadas.Rows)
            {
                if (int.Parse(row.Cells[0].Value.ToString()) == hab_aux.id_habitacion)
                {
                    MessageBox.Show("Ya esta seleccionada esa habitacion, por favor seleccione otra");
                    return;
                }
            }

            dataGridView_Seleccionadas.Rows.Add(hab_aux.id_habitacion ,hab_aux.id_hotel, hab_aux.numero, hab_aux.piso, 
                hab_aux.id_tipo_hab,hab_aux.frente, hab_aux.baja_logica);

            recargar_tipo_habitacion();           
        }

        //Acepto todas las habitaciones
        private void button_Aceptar_Habs_Click(object sender, EventArgs e)
        {
            if (dataGridView_Seleccionadas.RowCount <= 0)
            {
                MessageBox.Show("No selecciono ninguna habitacion, no se puede reservar");
                return;
            }

            panel_Habitaciones.Enabled = false;
            panel_Regimenes.Enabled = true;
            recargar_regimenes();
        }

        //Guarda los valores
        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (comboBox_Regimenes.SelectedItem == null)
            {
                MessageBox.Show("Elija un regimen");
                return;
            }

            DateTime fecha_inicio = DateTime.Parse(dateTimePicker_Inicio.Text.ToString());
            TimeSpan diferencia_dias = DateTime.Parse(dateTimePicker_Fin.Text.ToString())-DateTime.Parse(dateTimePicker_Inicio.Text.ToString());
            int cantidad_dias = int.Parse(diferencia_dias.Days.ToString());
            DateTime fecha_realizada = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
            string regimen = comboBox_Regimenes.Text.ToString();
            //
            //Genero la reserva primero
            //
            int Codigo_Reserva = _ReservaManager.InsertarReserva(fecha_inicio, cantidad_dias, fecha_realizada, regimen,usuario_logeado);
            //
            //Cargo todas las habitaciones
            //
            foreach (DataGridViewRow row in dataGridView_Seleccionadas.Rows)
            {
                _ReservaManager.InsertarReservaHabitacion(int.Parse(row.Cells[0].Value.ToString()),Codigo_Reserva);
            }                      
            //
            //Cargo el Clientes antes de devolverle el Codigo de Reserva
            //
            Form abrir = new FrbaHotel.Generar_Modificar_Reserva.ClientesSelection(Codigo_Reserva);
            abrir.ShowDialog();
            //
            //
            //
            MessageBox.Show("Codigo de Reserva:" + Codigo_Reserva);
            recargar_regimenes();
            panel_Regimenes.Enabled = false;
            panel_Habitaciones.Enabled = false;
            panel_Cantidad.Enabled = false;
            dataGridView_Habitaciones.Rows.Clear();
            dataGridView_Habitaciones.Refresh();
            dataGridView_Seleccionadas.Rows.Clear();
            dataGridView_Seleccionadas.Refresh();
            recargar_hotelesytipo();
        }
        //Dependiendo del regimen te va cambiando los precios
        private void comboBox_Regimenes_SelectedValueChanged(object sender, EventArgs e)
        {
            decimal valor_habitaciones = 0;
            int id_hot = 0;
            int id_hab = 0;
            TimeSpan diferencia_dias = DateTime.Parse(dateTimePicker_Fin.Text.ToString()) -
                            DateTime.Parse(dateTimePicker_Inicio.Text.ToString());
            string regimen = comboBox_Regimenes.Text.ToString();      

            foreach (DataGridViewRow row in dataGridView_Seleccionadas.Rows)
            {
                id_hab = int.Parse(row.Cells[0].Value.ToString());
                id_hot = int.Parse(row.Cells[1].Value.ToString());
                valor_habitaciones =+ _HotelManager.GetValorHabitacion(id_hab, id_hot, regimen); 
            }            

            maskedTextBox_PrecioDia.Text = valor_habitaciones.ToString();
            maskedTextBox_ValTotalRes.Text = (valor_habitaciones * int.Parse(diferencia_dias.Days.ToString())).ToString();
            
        }

        //Cancela todo lo que habia hecho
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            recargar_hotelesytipo();
            recargar_regimenes();

            dataGridView_Habitaciones.Rows.Clear();
            dataGridView_Habitaciones.Refresh();
            dataGridView_Seleccionadas.Rows.Clear();
            dataGridView_Seleccionadas.Refresh();

            panel_Habitaciones.Enabled = false;
            panel_Regimenes.Enabled = false;
            if (ID_Hotel_global == 0)
            {
                panel_Fecha.Enabled = false;
            }
            else
            {
                panel_Fecha.Enabled = true;
            }
            panel_Cantidad.Enabled = false;
        }

        private void button_Cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_SeleccionarFecha_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(dateTimePicker_Inicio.Text.ToString()) < DateTime.Parse(dateTimePicker_Fin.Text.ToString()))
            {
                panel_Cantidad.Enabled = true;
                panel_Fecha.Enabled = false;
            }
            else
            {
                panel_Cantidad.Enabled = false;
                if (DateTime.Parse(dateTimePicker_Inicio.Text.ToString()) == DateTime.Parse(dateTimePicker_Fin.Text.ToString()))
                {
                    MessageBox.Show("Fecha al revez (Fin = Inicio)");
                }
                else
                {
                    MessageBox.Show("Fecha al revez (Fin < Inicio)");
                }
            }
        }

        private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_Fin.MinDate = dateTimePicker_Inicio.Value;
            dateTimePicker_Fin.Update();
        }
    }
}
