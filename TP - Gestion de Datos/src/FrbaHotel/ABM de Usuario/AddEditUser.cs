using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons;
using FrbaHotel.Business;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AddEditUser : Form
    {
        private bool es_modificacion = false;
        Usuario current_user = new Usuario();
        RolManager _rolMan = new RolManager();
        HotelManager _hotelMan = new HotelManager();
        UsuarioManager _userMan = new UsuarioManager();
        BindingList<int> hoteles_elegidos = new BindingList<int>();
        BindingList<string> roles_elegidos = new BindingList<string>();
        
        
        public AddEditUser(Usuario user)
        {
            InitializeComponent();
            
            button_modifDatos.Enabled = false;

            BindingList<Rol> all_roles = _rolMan.GetAll();

            listBox_rol.DataSource = all_roles;
            listBox_rol.DisplayMember = "nombre_rol";
            listBox_rol.SelectedItems.Clear();

            BindingList<int> all_hoteles=_hotelMan.GetAll();

            listBox_hots.DataSource = all_hoteles;
            listBox_hots.SelectedItems.Clear();
            
            comboBox_estadoUser.Items.Add("True");
            comboBox_estadoUser.Items.Add("False");
            
            if (user!=null)
            {
                              
                current_user = user;

                current_user.hoteles = _hotelMan.GetAllPorUser(current_user.id_usuario);
                if (!current_user.hoteles.Contains(Sesion.id_hotel))
                {
                    MessageBox.Show("El Usuario seleccionado no pertenece a este hotel");
                    string hoteles = "";
                    foreach (int hotel in current_user.hoteles)
                    {
                        hoteles += '-' + hotel.ToString();
                    }
                    MessageBox.Show("Para modificarlo, contacte al admin de los siguientes hoteles:\n"+hoteles);
                    button_guardar.Enabled = false;
                    return;
                }

                listBox_preHot.DataSource = current_user.hoteles;

                es_modificacion = true;

                textBox_preUser.Text = current_user.id_usuario;
                textBox_username.Text = current_user.id_usuario;
                textBox_preUser.Enabled = false;
                textBox_username.Enabled = false;
                textBox_prePass.Text = current_user.password;
                textBox_prePass.Enabled = false;

                current_user.roles = _rolMan.GetAllPorUser(textBox_preUser.Text,false);
                listBox_preRol.DataSource = current_user.roles;

                textBox_preInt.Text = Convert.ToString(current_user.intentos);
                textBox_preInt.Enabled = false;

                     
                textBox_preEstado.Text = Convert.ToString(current_user.baja_logica);

            }
            else
            {
                panel_mod.Visible = false;                
            }
        }


        private void refresh_valoresActuales()
        {
            textBox_preUser.Text = current_user.id_usuario;
            textBox_username.Text = current_user.id_usuario;
            textBox_preUser.Enabled = false;
            textBox_username.Enabled = false;
            textBox_prePass.Text = current_user.password;
            textBox_prePass.Enabled = false;

            current_user.roles = _rolMan.GetAllPorUser(textBox_preUser.Text,false);
            listBox_preRol.DataSource = current_user.roles;

            textBox_preInt.Text = Convert.ToString(current_user.intentos);
            textBox_preInt.Enabled = false;

            current_user.hoteles = _hotelMan.GetAllPorUser(textBox_preUser.Text);
            listBox_preHot.DataSource = current_user.hoteles;

            textBox_preEstado.Text = Convert.ToString(current_user.baja_logica);

            hoteles_elegidos.Clear();
            roles_elegidos.Clear();
        }


        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text != "" &&
                textBox_password.Text != "" &&
                textBox_confPassw.Text != "" &&
                listBox_rol.SelectedItems.Count!=0 &&
                textBox_intentos.Text != "" &&
                listBox_hots.SelectedItems.Count!=0 &&
                comboBox_estadoUser.SelectedItem != null)
            {
                if (textBox_confPassw.Text != textBox_password.Text)
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden \n Por favor, reingreselas");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Los datos no pueden estar en blanco \nPor favor complete cada uno de los campos");
                return;
            }

            if (es_modificacion)
            {
                                                
           //   mod_user.id_usuario = textBox_username.Text;
                current_user.password = textBox_password.Text;
                current_user.intentos = Convert.ToInt32(textBox_intentos.Text);
                current_user.baja_logica = Convert.ToBoolean(comboBox_estadoUser.SelectedItem);

                 _userMan.Modificar(current_user,current_user.id_usuario);

                 foreach (Rol rol in listBox_rol.SelectedItems)
                 {
                                  
                     if (_rolMan.estaEnUser(rol.nombre_rol,current_user.roles)==false)
                     {
                         _rolMan.AgregarEnUser(rol.nombre_rol,current_user.id_usuario);
                     }

                     roles_elegidos.Add(rol.nombre_rol);
                 }

                 foreach (int id_hotel in listBox_hots.SelectedItems)
                 {
                   
                     if (_userMan.pertenece_aHotel(id_hotel, current_user.hoteles) == false)
                     {
                         _userMan.agregarEnHotel(id_hotel, current_user.id_usuario);
                     }

                     hoteles_elegidos.Add(id_hotel);
                 }

                 foreach (string rol in listBox_preRol.Items)
                 {

                     if (_rolMan.estaEnUser(rol, roles_elegidos) == false)
                     {
                         _rolMan.EliminarDeUser(rol, current_user.id_usuario);
                     }
                 }


                 foreach (int id_hotel in listBox_preHot.Items)
                 {

                     if (_userMan.pertenece_aHotel(id_hotel, hoteles_elegidos) == false)
                     {
                         _userMan.EliminarDeHotel(id_hotel, current_user.id_usuario);
                     }
                 }


                MessageBox.Show("Se ha modificado el usuario", current_user.id_usuario);
                 
             }
            else
            {
              //Usuario current_user = new Usuario();
                current_user.id_usuario = textBox_username.Text;
                current_user.password = textBox_password.Text;
                current_user.intentos = 0;
                current_user.baja_logica = Convert.ToBoolean(comboBox_estadoUser.SelectedItem);

                if (_userMan.Insertar(current_user) == false)
                {

                    MessageBox.Show("Ya existe el usuario \a" + current_user.id_usuario + "\a en el sistema");
                    return;
                }

                foreach (Rol rol in listBox_rol.SelectedItems)
                {
                    _rolMan.AgregarEnUser(rol.nombre_rol, current_user.id_usuario);
                }

                foreach (int id_hotel in listBox_hots.SelectedItems)
                {
                    _userMan.agregarEnHotel(id_hotel, current_user.id_usuario);
                }

                MessageBox.Show("Se ha añadido nuevo usuario",current_user.id_usuario);
                MessageBox.Show("Se deben cargar los datos personales antes de salir");
            }

            refresh_valoresActuales();


            button_modifDatos.Enabled = true;

        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button_datosper_Click(object sender, EventArgs e)
        {
            
            
            if (es_modificacion)
            {
                DatosPersonales datos_pers = new DatosPersonales(current_user.id_usuario, true);
                datos_pers.ShowDialog();
            }
            else
            {
                DatosPersonales datos_pers = new DatosPersonales(current_user.id_usuario, false);
                datos_pers.ShowDialog();
            }

            
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
