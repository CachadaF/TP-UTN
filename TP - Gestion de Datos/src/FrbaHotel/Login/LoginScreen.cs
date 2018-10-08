using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Business;
using FrbaHotel.Commons;

namespace FrbaHotel.Login
{
    public partial class LoginScreen : Form
    {

        LoginManager _loginMan = new LoginManager();
        UsuarioManager _userMan = new UsuarioManager();
        RolManager _rolMan = new RolManager();
        HotelManager _hotelMan = new HotelManager();
        FuncionalidadManager _funcMan = new FuncionalidadManager();
        private string user_id;
        private string password;
        private string rol;
        private int id_hotel;
        private BindingList<Funcionalidad> funcionalidades;

        public LoginScreen()
        {
            InitializeComponent();
        }


        private void guest_start(object sender, EventArgs e)
        {
            panel_inSesion.Enabled = false;
            panelHotel.Enabled = false;
            panelRol.Enabled = false;
            button_iniciar.Enabled = true;
            button_iniciar.Focus();
            id_hotel = 0;
            rol = "Guest";
            user_id = "Guest";
            //Sesion.funcionalidades = _funcMan.GetPorRol(_rolMan.GetIdPorNombre("Guest"));
        }  

        private void user_start(object sender, EventArgs e)
        {
            panel_inSesion.Enabled = true;
            button_login.Focus();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            if (textBox_user.Text.Length == 0 || textBox_pass.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Usuario y Contraseña","Error");
                return;
            }

            try
            {
                _loginMan.login(textBox_user.Text, textBox_pass.Text);
               
                user_id = textBox_user.Text;
                password = Encriptacion.get_hash(textBox_pass.Text);
                                
                var roles = _rolMan.GetAllPorUser(user_id,true); //solo cargo los activos

                foreach (string rol in roles) comboBox_rol.Items.Add(rol);
                panelRol.Enabled = true;
                panel_inSesion.Enabled = false;
               
                var hoteles = _hotelMan.GetAllPorUser(user_id);
                foreach (int hotel in hoteles) comboBox_hotel.Items.Add(hotel);

              // Sesion.iniciada = true;
                
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void buttonSelecRol_Click(object sender, EventArgs e)
        {
            if (comboBox_rol.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un Rol");
                return;
            }
            
            rol =comboBox_rol.SelectedItem.ToString();
            panelHotel.Enabled = true;
            panelRol.Enabled = false;
        }

        private void buttonSelecHotel_Click(object sender, EventArgs e)
        {
            if (comboBox_hotel.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un Hotel");
                return;
            }
                        
            id_hotel = Convert.ToInt32(comboBox_hotel.SelectedItem);
            button_iniciar.Enabled = true;
            panelHotel.Enabled = false;
            button_iniciar.Focus();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            funcionalidades = _funcMan.GetPorRol(_rolMan.GetIdPorNombre(rol));

            Sesion.iniciar_se(user_id,password,rol,id_hotel,funcionalidades);

            this.Dispose(); //TODO: ver si esto no borra nada
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
          //  Sesion.cerrar_se();
            this.Dispose();
            this.Close();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
