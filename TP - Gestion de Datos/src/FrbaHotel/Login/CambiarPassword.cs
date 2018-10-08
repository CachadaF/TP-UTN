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
    public partial class CambiarPassword : Form
    {
        UsuarioManager _userMan = new UsuarioManager();

        public CambiarPassword()
        {
            InitializeComponent();
            label1.Text = Sesion.user_id;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBox_passAct.Text != "" && textBox_newPass.Text != "" && textBox_confPass.Text != "")
            {

                string hashed_pass = Encriptacion.get_hash(textBox_passAct.Text);
                
                if (hashed_pass != Sesion.password)
                {
                    MessageBox.Show("La contraseña actual no es correcta", label1.Text);
                    return;
                }

                if (textBox_newPass.Text != textBox_confPass.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.\nPor favor, reintentelo", label1.Text);
                    return;
                }

                _userMan.cambiarPassword(Sesion.user_id, textBox_newPass.Text);

                MessageBox.Show("Contraseña cambiada correctamente.\nSe reiniciará la sesión",Sesion.user_id);
                

            }
            else
            {
                MessageBox.Show("Complete todos los campos", label1.Text);
            }

            this.Dispose();
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
