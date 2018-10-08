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
    public partial class DatosPersonales : Form
    {

        UsuarioManager _userMan = new UsuarioManager();
        PersonaDeUser datosUser = new PersonaDeUser();
        string user;
        private bool es_modificacion;

        public DatosPersonales(string user_id, bool es_modif)
        {
            InitializeComponent();

            button_cerrar.Enabled = false;
            es_modificacion = es_modif;
            user = user_id;

            this.Text = "Datos personales del user: " + user_id ;

            comboBox_tdoc.Items.Add("DNI");
            comboBox_tdoc.Items.Add("Pas");
            comboBox_tdoc.Items.Add("LC");
            comboBox_tdoc.Items.Add("LE");

            if (es_modificacion)
            {
                button_cerrar.Enabled = true;

                datosUser = _userMan.getDatosPersonales(user);
                textBox_preNom.Text = datosUser.nombre;
                textBox_preAp.Text = datosUser.apellido;
                textBox_preDoc.Text = Convert.ToString(datosUser.documento);
                comboBox_pretdoc.SelectedText = datosUser.tipo_doc;
                textBox_preMail.Text = datosUser.mail;
                textBox_preTel.Text = Convert.ToString (datosUser.telefono);
                dateTimePicker_preFec.Value = datosUser.fecha_nac;
                textBox_preCalle.Text = datosUser.dom_calle;
                textBox_preNum.Text = Convert.ToString(datosUser.dom_numero);
                textBox_prePiso.Text = Convert.ToString(datosUser.piso);
                textBox_preDpto.Text = datosUser.nro_depto;
                textBox_preLoc.Text = datosUser.localidad;
            }
            else
            {
                panel2.Visible = false;
            }

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            if (textBox_nombre.Text != "" &&
                textBox_apellido.Text != "" &&
                comboBox_tdoc.SelectedValue==null &&
                textBox_doc.Text != "" &&
                textBox_mail.Text != "" &&
                textBox_telefono.Text != "" &&
                dateTimePicker_fecha.Value != null &&
                textBox_calle.Text != "" &&
                textBox_num.Text != "" &&
                textBox_piso.Text != "" &&
                textBox_dpto.Text != "" &&
                textBox_localidad.Text != "")
            {
            }
            else
            {
                MessageBox.Show("Los datos no pueden estar en blanco \nPor favor complete cada uno de los campos");
                return;
            }

            datosUser.nombre = textBox_nombre.Text;
            datosUser.apellido = textBox_apellido.Text;
            datosUser.tipo_doc = comboBox_tdoc.SelectedText; ; 
            datosUser.documento = Convert.ToInt32(textBox_doc.Text);
            datosUser.fecha_nac = dateTimePicker_fecha.Value;
            datosUser.dom_calle = textBox_calle.Text;
            datosUser.dom_numero = Convert.ToInt32(textBox_num.Text);
            datosUser.piso = Convert.ToInt32(textBox_piso.Text);
            datosUser.nro_depto = textBox_dpto.Text;
            datosUser.localidad = textBox_localidad.Text;
            datosUser.telefono = textBox_telefono.Text;
            datosUser.mail = textBox_mail.Text;
       
            _userMan.insertarDatosPersonales(user, datosUser, es_modificacion);
            
            MessageBox.Show("Se han actualizado los datos del usuario",user);

            refresh_valoresActuales();

            button_cerrar.Enabled = true;
        }

        public void refresh_valoresActuales()
        {
            datosUser = _userMan.getDatosPersonales(user);
            textBox_preNom.Text = datosUser.nombre;
            textBox_preAp.Text = datosUser.apellido;
            textBox_preDoc.Text = Convert.ToString(datosUser.documento);
            comboBox_pretdoc.SelectedText = datosUser.tipo_doc;
            textBox_preMail.Text = datosUser.mail;
            textBox_preTel.Text = Convert.ToString(datosUser.telefono);
            dateTimePicker_preFec.Value = datosUser.fecha_nac;
            textBox_preCalle.Text = datosUser.dom_calle;
            textBox_preNum.Text = Convert.ToString(datosUser.dom_numero);
            textBox_prePiso.Text = Convert.ToString(datosUser.piso);
            textBox_preDpto.Text = datosUser.nro_depto;
            textBox_preLoc.Text = datosUser.localidad;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void DatosPersonales_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
