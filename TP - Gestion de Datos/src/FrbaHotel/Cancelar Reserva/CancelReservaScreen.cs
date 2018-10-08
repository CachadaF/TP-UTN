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
using FrbaHotel.Commons;
using FrbaHotel.Business;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class CancelReservaScreen : Form
    {
        ReservaManager _reservaManager = new ReservaManager();

        public CancelReservaScreen()
        {
            InitializeComponent();
            dateTimePicker1_fechaCancel.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            AcceptButton = button_cancel_reserva;
        }

        private void button_cancel_reserva_Click(object sender, EventArgs e)
        {
            int Codigo_Reserva;
            string motivoBaja = textBox_motivoBaja.Text.Trim();
            if (string.IsNullOrEmpty(motivoBaja))
            {
                MessageBox.Show("Debe ingresar el motivo de la cancelación");
                return;
            }
            DateTime fechaBaja = dateTimePicker1_fechaCancel.Value;
            string usuario = Sesion.user_id;
            try
            {
                Codigo_Reserva = Convert.ToInt32(textBox_idReserva.Text.Trim());
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Ingrese solo numeros en Codigo de Reserva");
                return;
            }
            
            ReservaManager _res_man = new ReservaManager();
            Reserva r = _res_man.Build(Codigo_Reserva);

            if (r != null)
            {
                if (MessageBox.Show("Cancelará la reserva " + Codigo_Reserva +
                    " del " + r.fecha_inicio.ToShortDateString() +
                    " realizada el " + r.fecha_realizada.ToShortDateString(),
                    "Confirmar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string resultado = _reservaManager.cancelarReserva(
                        motivoBaja, fechaBaja, usuario, Codigo_Reserva);
                    MessageBox.Show(resultado);
                }
            }
            else
            {
                MessageBox.Show("Esa reserva no existe.");
                return;
            }
        }


        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
