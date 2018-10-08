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

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class ModificarReserva : Form
    {
        private HotelManager _HotelManager = new HotelManager();

        private ReservaManager _ReservaManager = new ReservaManager();

        private Tipo_habitacionManager _TipoHabitacionManager = new Tipo_habitacionManager();

        private RegimenManager _RegimenManager = new RegimenManager();

        private int ID_Hotel_global = 0;

        private int Codigo_Reserva_Modificando = 0;

        private string usuario_logeado;

        private bool usar_masked_text_fechas = false;

        private bool usar_masked_fechas_para_habs = false;

        public ModificarReserva(int hotel_en_que_me_logee, string user_logeado)
        {
            InitializeComponent();
            if (hotel_en_que_me_logee == 0)
            {
                panel_Hoteles.Show();
                usuario_logeado = user_logeado;
                maskedTextBox_Usuario.Text = Sesion.user_id;
                button_Buscar.Enabled = false;
                BindingList<int> lista_id_hoteles = _HotelManager.GetAll();

                foreach (int id_hoteles in lista_id_hoteles)
                {
                    comboBox_Hoteles.Items.Add(id_hoteles.ToString());
                }
            }
            else
            {
                ID_Hotel_global = hotel_en_que_me_logee;
                maskedTextBox_Usuario.Text = user_logeado.ToString();
                panel_Hoteles.Hide();
                usuario_logeado = user_logeado;
                maskedTextBox_Hotel.Text = ID_Hotel_global.ToString();
            }
            recargar_todohotelescambio();

            dateTimePicker_FchIni.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FchIni.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker_FchFin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FchFin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            
            panel_Fecha.Enabled = false;
            panel_Habitaciones.Enabled = false;
            panel_Capacidad.Enabled = false;
            panel_Nro.Hide();
            panel_Regimen.Enabled = false;
            
        }

        //Recarga hoteles y tipos de habitacion
        private void recargar_todohotelescambio()
        {
            comboBox_Cantidad.Items.Clear();
            comboBox_Regimenes.Items.Clear();

            BindingList<Tipo_habitacion> tipos_habit = _TipoHabitacionManager.GetAll();

            foreach (Tipo_habitacion tipo in tipos_habit)
            {
                comboBox_Cantidad.Items.Add(tipo.capacidad.ToString());
            }

            BindingList<Regimen> lista_regimenes_del_hotel = _HotelManager.GetAllRegimenPorHotel(ID_Hotel_global);

            foreach (Regimen reg_hotel in lista_regimenes_del_hotel)
            {
                comboBox_Regimenes.Items.Add(reg_hotel.descripcion);
            }
        }   

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown_CodRes_ValueChanged(object sender, EventArgs e)
        {
            panel_Nro.Hide();
        }

        private void button_AcepVals_Click(object sender, EventArgs e)
        {
            if (comboBox_Cantidad.SelectedItem == null)
            {
                MessageBox.Show("Indique una capacidad");
            }
            else
            {
                panel_Fecha.Enabled = false;
                panel_Habitaciones.Enabled = true;

                dataGridView_HabsDispo.Rows.Clear();
                dataGridView_HabsDispo.Refresh();

                Tipo_habitacion tipo_h = _TipoHabitacionManager.GetPorCantidad(int.Parse(comboBox_Cantidad.SelectedItem.ToString()));

                BindingList<Habitacion> habitaciones_disponibles;

                if (usar_masked_fechas_para_habs == true)
                {
                    DateTime fecha_ini = DateTime.Parse(maskedTextBox_FchIni.Text.ToString());

                    int dias_add = int.Parse(maskedTextBox_FchFin.Text.ToString());

                    DateTime fecha_fin = fecha_ini.AddDays(dias_add);

                    habitaciones_disponibles = _HotelManager.GetAllHabitacionDisponiblesEnFechaYCantidad(
                        ID_Hotel_global, tipo_h.codigo_tipo, fecha_ini,
                        fecha_fin);
                }
                else
                {
                    habitaciones_disponibles = _HotelManager.GetAllHabitacionDisponiblesEnFechaYCantidad(
                        ID_Hotel_global, tipo_h.codigo_tipo, DateTime.Parse(dateTimePicker_FchIni.Text.ToString()),
                        DateTime.Parse(dateTimePicker_FchFin.Text.ToString()));
                }

                foreach (Habitacion hab_dispo in habitaciones_disponibles)
                {
                    dataGridView_HabsDispo.Rows.Add(hab_dispo.id_habitacion, hab_dispo.id_hotel,
                        hab_dispo.numero, hab_dispo.piso, hab_dispo.id_tipo_hab
                         , hab_dispo.frente, hab_dispo.baja_logica);
                }

                if (dataGridView_HabsDispo.RowCount > 0)
                {
                    panel_Habitaciones.Enabled = true;
                }
                else
                {                    
                    MessageBox.Show("No hay habitaciones disponibles");
                }
            }
        }
        //
        //  Aca van los cambios en el grid de habitaciones
        //
        private void button_Selec_Click(object sender, EventArgs e)
        {
            if (dataGridView_HabsDispo.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una habitacion de las disponibles");
            }
            else
            {
                Habitacion hab_aux = new Habitacion();
                hab_aux.id_habitacion = int.Parse(dataGridView_HabsDispo.CurrentRow.Cells["ID_Hab"].Value.ToString());
                hab_aux.numero = int.Parse(dataGridView_HabsDispo.CurrentRow.Cells["Num"].Value.ToString());
                hab_aux.piso = int.Parse(dataGridView_HabsDispo.CurrentRow.Cells["Pi"].Value.ToString());
                hab_aux.id_tipo_hab = int.Parse(dataGridView_HabsDispo.CurrentRow.Cells["Codigo_Tip"].Value.ToString());
                hab_aux.id_hotel = int.Parse(dataGridView_HabsDispo.CurrentRow.Cells["ID_Hot"].Value.ToString());
                hab_aux.frente = dataGridView_HabsDispo.CurrentRow.Cells["Frent"].Value.ToString();
                hab_aux.baja_logica = bool.Parse(dataGridView_HabsDispo.CurrentRow.Cells["Baja_Logic"].Value.ToString());

                foreach (DataGridViewRow row in dataGridView_Habitaciones.Rows)
                {
                    if (int.Parse(row.Cells[0].Value.ToString()) == hab_aux.id_habitacion)
                    {
                        MessageBox.Show("Ya esta seleccionada esa habitacion, por favor seleccione otra");
                        return;
                    }
                }
                dataGridView_Habitaciones.Rows.Add(hab_aux.id_habitacion, hab_aux.id_hotel, hab_aux.numero, hab_aux.piso,
                    hab_aux.id_tipo_hab, hab_aux.frente, hab_aux.baja_logica);
            }
        }

        private void button_QuitarHab_Click(object sender, EventArgs e)
        {
            //Quito del Datagridview
            if (dataGridView_Habitaciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una habitacion para quitar");
            }
            else
            {
                int index = dataGridView_Habitaciones.CurrentRow.Index;

                dataGridView_Habitaciones.Rows.RemoveAt(index);

                dataGridView_Habitaciones.Refresh();
            }

        }

        private void button_Aceptar_Habs_Click(object sender, EventArgs e)
        {
            if (dataGridView_Habitaciones.Rows.Count <= 0)
            {
                MessageBox.Show("No hay habitaciones seleccionadas");
            }
            else
            {
                panel_Habitaciones.Enabled = false;
                panel_Regimen.Enabled = true;
                panel_Capacidad.Enabled = false;
            }
        }
        //
        //
        //
        private void comboBox_Hoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Hoteles.SelectedItem != null)
            {
                ID_Hotel_global = int.Parse(comboBox_Hoteles.Text.ToString());
                maskedTextBox_Hotel.Text = ID_Hotel_global.ToString();
                recargar_todohotelescambio();
                button_Buscar.Enabled = true;
            }
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            Reserva reserva_existe = _ReservaManager.ExisteReserva(int.Parse(numericUpDown_CodRes.Value.ToString()),ID_Hotel_global);
            if (reserva_existe.codigo_reserva == 0)
            {
                panel_Nro.Show();
            }
            else
            {
                Codigo_Reserva_Modificando = reserva_existe.codigo_reserva;
                panel_Fecha.Show();
                maskedTextBox_FchFin.Text = reserva_existe.cant_noches.ToString();
                maskedTextBox_FchIni.Text = reserva_existe.fecha_inicio.ToString();
                panel_Fecha.Enabled = true;
                numericUpDown_CodRes.Enabled = false;
                button_Buscar.Enabled = false;
                panel_Hoteles.Enabled = false;
            }

        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            int codigo_reserva;
            int cant_noches;
            DateTime fecha_inicio;
            DateTime fecha_realizada;

            if (usar_masked_text_fechas == true)
            {
                //Solo modifico el Regimen -> Las fechas no las permito (No toque las habitaciones)
                panel_Regimen.Enabled = false;
                MessageBox.Show("Esta modificando solamente Regimen de la Reserva");
                codigo_reserva = Codigo_Reserva_Modificando;
                cant_noches = int.Parse(maskedTextBox_FchFin.Text.ToString());
                fecha_inicio = DateTime.Parse(maskedTextBox_FchIni.Text.ToString());
                fecha_realizada = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
            }
            else
            {
                codigo_reserva = Codigo_Reserva_Modificando;
                TimeSpan diferencia_dias = DateTime.Parse(dateTimePicker_FchFin.Text.ToString())-DateTime.Parse(dateTimePicker_FchIni.Text.ToString());
                cant_noches = int.Parse(diferencia_dias.Days.ToString());
                fecha_inicio = DateTime.Parse(dateTimePicker_FchIni.Text.ToString());;
                fecha_realizada = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());                
            }

            if (comboBox_Regimenes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un Regimen");
            }
            else
            {
                //
                usar_masked_text_fechas = false;
                //
                MessageBox.Show("Se han guardado los cambios");
                panel_Regimen.Enabled = false;
                string regimen = comboBox_Regimenes.Text.ToString();
                //Reserva modificada
                _ReservaManager.ModificarReserva(fecha_inicio,cant_noches,fecha_realizada,regimen,usuario_logeado,Codigo_Reserva_Modificando);

                dataGridView_HabsDispo.Rows.Clear();
                dataGridView_HabsDispo.Refresh();
                dataGridView_Habitaciones.Rows.Clear();
                dataGridView_Habitaciones.Refresh();
            }


        }

        private void button_CancelarModif_Click(object sender, EventArgs e)
        {
            panel_Fecha.Enabled = false;

            dataGridView_Habitaciones.Rows.Clear();
            dataGridView_Habitaciones.Refresh();
            dataGridView_HabsDispo.Rows.Clear();
            dataGridView_HabsDispo.Refresh();

            panel_Habitaciones.Enabled = false;
            panel_Regimen.Enabled = false;
            panel_Capacidad.Enabled = false;
            numericUpDown_CodRes.Enabled = true;
            button_Buscar.Enabled = true;
            if (usuario_logeado == "Guest")
            {
                panel_Hoteles.Enabled = true;
            }
            //
            usar_masked_text_fechas = false;
            usar_masked_fechas_para_habs = false;
            //
        }

        private void button_JumpARegimen_Click(object sender, EventArgs e)
        {
            panel_Fecha.Enabled = false;
            panel_Regimen.Enabled = true;

            //Marca que use las fechas de anteriores
            usar_masked_text_fechas = true;
            usar_masked_fechas_para_habs = false;
            
            BindingList<Habitacion> listado_reservas = _ReservaManager.GetHabitacionPorCodigoReserva(Codigo_Reserva_Modificando);
            foreach (Habitacion hab_dispo in listado_reservas)
            {
                dataGridView_Habitaciones.Rows.Add(hab_dispo.id_habitacion, hab_dispo.id_hotel,
                    hab_dispo.numero, hab_dispo.piso, hab_dispo.id_tipo_hab
                     , hab_dispo.frente, hab_dispo.baja_logica);
            }        
        }

        private void comboBox_Regimenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Regimenes.SelectedItem != null)
            {
                decimal valor_habitaciones = 0;
                int id_hot = 0;
                int id_hab = 0;
                string regimen = comboBox_Regimenes.Text.ToString();              
                   
                foreach (DataGridViewRow row in dataGridView_Habitaciones.Rows)
                {
                    id_hab = int.Parse(row.Cells[0].Value.ToString());
                    id_hot = int.Parse(row.Cells[1].Value.ToString());
                    valor_habitaciones = +_HotelManager.GetValorHabitacion(id_hab, id_hot, regimen);
                }

                
                maskedTextBox_ValDiario.Text = valor_habitaciones.ToString();

                if (usar_masked_text_fechas == true)
                {
                    //Hice cambios de habitacion y/o regimen solamente
                    int cant_noches = int.Parse(maskedTextBox_FchFin.Text.ToString());
                    maskedTextBox_Total.Text = (valor_habitaciones * int.Parse(cant_noches.ToString())).ToString();
                }
                else
                {
                    //Hice cambios de fecha
                    TimeSpan diferencia_dias = DateTime.Parse(dateTimePicker_FchFin.Text.ToString()) -
                        DateTime.Parse(dateTimePicker_FchIni.Text.ToString());
                    maskedTextBox_Total.Text = (valor_habitaciones * int.Parse(diferencia_dias.Days.ToString())).ToString();
                }

            }
            else
            {
                int ze = 0;
                maskedTextBox_ValDiario.Text =ze.ToString();
                maskedTextBox_Total.Text = ze.ToString();
            }

        }

        private void button_CambiarFechas_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(dateTimePicker_FchIni.Text.ToString()) < DateTime.Parse(dateTimePicker_FchFin.Text.ToString()))
            {
                panel_Capacidad.Enabled = true;
                panel_Fecha.Enabled = false;
            }
            else
            {
                panel_Capacidad.Enabled = false;
                if (DateTime.Parse(dateTimePicker_FchIni.Text.ToString()) == DateTime.Parse(dateTimePicker_FchFin.Text.ToString()))
                {
                    MessageBox.Show("Fecha al revez (Fin = Inicio)");
                    return;
                }
                else
                {
                    MessageBox.Show("Fecha al revez (Fin < Inicio)");
                    return;
                }
            }

            //
            //Quito todas las reservas que tenia este codigo
            //
            BindingList<Habitacion> listado_reservas = _ReservaManager.GetHabitacionPorCodigoReserva(Codigo_Reserva_Modificando);

            foreach (Habitacion habs_l in listado_reservas)
            {
                _ReservaManager.QuitarReservaHabitacion(habs_l.id_habitacion, Codigo_Reserva_Modificando);
            }
            //
            //
            //
        }

        private void button_CambiarHabs_Click(object sender, EventArgs e)
        {
            panel_Fecha.Enabled = false;
            panel_Capacidad.Enabled = true;
            panel_Habitaciones.Enabled = true;

            //
            //Agrego todas las habitaciones que tenia
            //
            BindingList<Habitacion> listado_reservas = _ReservaManager.GetHabitacionPorCodigoReserva(Codigo_Reserva_Modificando);

            foreach (Habitacion habs_l in listado_reservas)
            {
                dataGridView_Habitaciones.Rows.Add(habs_l.id_habitacion, habs_l.id_hotel,
                       habs_l.numero, habs_l.piso, habs_l.id_tipo_hab
                        , habs_l.frente, habs_l.baja_logica);
            }

            usar_masked_fechas_para_habs = true;
            usar_masked_text_fechas = true;
            //
            //
            //
        }


    }
}
