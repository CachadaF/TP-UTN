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

namespace FrbaHotel.ABM_de_Rol
{
    public partial class AddEditRole : Form
    {
        FuncionalidadManager funcMan = new FuncionalidadManager();
        RolManager rolMan = new RolManager();
        Rol current_Rol = new Rol();
        BindingList<Funcionalidad> elegidas = new BindingList<Funcionalidad>();

        private bool Es_Modificacion = false;

        public AddEditRole()
        {
            InitializeComponent();
            panel1.Visible = false;
            label7.Visible = false;
 
            listBox_func.DataSource = funcMan.GetAll();
            listBox_func.DisplayMember = "nombre_funcionalidad";
            listBox_func.SelectedItems.Clear();

            comboBox_estadoRol.Items.Add("True");
            comboBox_estadoRol.Items.Add("False");

        }

        public void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void refresh_valoresActuales()
        {
            textBox_preNom.Text = current_Rol.nombre_rol;
            textBox_preEstado.Text = Convert.ToString(current_Rol.baja_logica);
            current_Rol.funcionalidad = funcMan.GetPorRol(current_Rol.id_rol);

            listBox_preFunc.DataSource = current_Rol.funcionalidad;
            listBox_preFunc.DisplayMember = "nombre_funcionalidad";
            elegidas.Clear();
        }

        public void PreSet (Rol rol)
        {
            panel1.Visible = true;
            label7.Visible = true;

            current_Rol = rol;
            Es_Modificacion = true;

            textBox_preNom.Text = current_Rol.nombre_rol;
            textBox_preEstado.Text = Convert.ToString(current_Rol.baja_logica);
            current_Rol.funcionalidad = funcMan.GetPorRol(current_Rol.id_rol);

            listBox_preFunc.DataSource = current_Rol.funcionalidad;
           listBox_preFunc.DisplayMember = "nombre_funcionalidad";
           
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {

            foreach (Funcionalidad f in listBox_func.SelectedItems) elegidas.Add(f);
            
            if (textBox_nomRol.Text == "" || listBox_func.SelectedItems.Count == 0 || comboBox_estadoRol.SelectedItem == null)
            {
                MessageBox.Show("Complete todos los campos, son obligatorios");
                return;
            }
            if (textBox_nomRol.Text != "" && listBox_func.SelectedItems.Count != 0 && comboBox_estadoRol.SelectedItem != null)
            {
                current_Rol.nombre_rol = textBox_nomRol.Text;
                current_Rol.baja_logica = Convert.ToBoolean(comboBox_estadoRol.SelectedItem);


                if (Es_Modificacion)
                {
                    rolMan.Modificar(current_Rol);
                    foreach (Funcionalidad f in listBox_preFunc.Items)
                    {
                        if (funcMan.estaEnLista(f, elegidas) == false)
                        {
                            funcMan.EliminarDeRol(f, current_Rol.id_rol);
                        }
                    }
                }
                else
                {
                    rolMan.Insertar(current_Rol);
                    current_Rol.id_rol = rolMan.GetIdPorNombre(current_Rol.nombre_rol);
                }

                
                foreach (Funcionalidad item in listBox_func.SelectedItems)
                {
                    if (funcMan.estaEnLista(item,current_Rol.funcionalidad)==false)
                    {
                       funcMan.AgregarEnRol(item, current_Rol.id_rol);
                       
                    }
                }

                if (Es_Modificacion) MessageBox.Show("Se ha modificado el Rol",current_Rol.nombre_rol);
                else MessageBox.Show("Se ha agregado el nuevo Rol", current_Rol.nombre_rol);
            }

            refresh_valoresActuales();
        }

        private void AddEditRole_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
