using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.Business;
using FrbaHotel.Cancelar_Reserva;
using FrbaHotel.Commons;
using FrbaHotel.Core;
using FrbaHotel.Login;
using FrbaHotel.Registrar_Estadia;

namespace FrbaHotel
{
    public partial class MainScreen : Form
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["StringConexion"].ToString());

        public MainScreen()
        {
            InitializeComponent();
            linkLabel_Login.Visible = true;
            linkLabelCerrar.Visible = false;
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;
            this.menuStrip1.Enabled = false;
            ActualizarStatusStrip();
            mostrar_InicioDeSesion();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            //establecer como ventana principal
            ViewManager.SetMainWindow(this);
            
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            ActualizarStatusStrip();
        }

        private void mostrar_InicioDeSesion()
        {
            LoginScreen login_scr = new LoginScreen();
            login_scr.ShowDialog();
            if (Sesion.iniciada)
            {
                ActualizarStatusStrip();
                habilitar_segun_rol();
                linkLabelCerrar.Visible = true;
                linkLabel_Login.Visible = false;
                if (Sesion.user_id != "Guest")
                    linkLabel_pass.Visible = true;
            }
        }

        private void linkLabel_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mostrar_InicioDeSesion();
        }

        private void linkLabelCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sesion.cerrar_se();
            linkLabel_Login.Visible = true;
            linkLabelCerrar.Visible = false;
            linkLabel_pass.Visible = false;
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;
            this.menuStrip1.Enabled = false;
            ActualizarStatusStrip();
        }
         
        public void habilitar_segun_rol()
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            menuStrip1.Enabled = true;
            BindingList<Funcionalidad> f = Sesion.funcionalidades;
            button_GenerarReserva.Enabled = f.Any(func => func.nombre_funcionalidad == "generarReserva");
            button_ModificarReserva.Enabled = f.Any(func => func.nombre_funcionalidad == "generarReserva");
            button_CancelarReserva.Enabled = f.Any(func => func.nombre_funcionalidad == "cancelarReserva");
            button_Roles.Enabled = f.Any(func => func.nombre_funcionalidad == "abmRol");
            buttonClientes.Enabled = f.Any(func => func.nombre_funcionalidad == "abmClientes");
            button_Usuarios.Enabled = f.Any(func => func.nombre_funcionalidad == "abmUsuario");
            button_Estadisticas.Enabled = f.Any(func => func.nombre_funcionalidad == "listadoEstadistico");

            ToolStripItemCollection items = menuStrip1.Items;

            ToolStripItem menu_estadia = menuStrip1.Items.Find("registrarToolStripMenuItem", true)[0];
            menu_estadia.Enabled = f.Any(func => func.nombre_funcionalidad == "registrarEstadia");

            ToolStripItem menu_facturar = menuStrip1.Items.Find("facturarToolStripMenuItem", true)[0];
            menu_facturar.Enabled = f.Any(func => func.nombre_funcionalidad == "facturarPublicaciones");

            ToolStripItem menu_regimen = menuStrip1.Items.Find("seleccionToolStripMenuItem", true)[0];
            menu_regimen.Enabled = f.Any(func => func.nombre_funcionalidad == "abmRegimenEstadia");

            ToolStripItem menu_nuevo_regimen = menuStrip1.Items.Find("nuevaToolStripMenuItem", true)[0];
            menu_nuevo_regimen.Enabled = f.Any(func => func.nombre_funcionalidad == "abmRegimenEstadia");

            ToolStripItem menu_seleccion_hotel = menuStrip1.Items.Find("seleccionHotelToolStripMenuItem", true)[0];
            menu_seleccion_hotel.Enabled = f.Any(func => func.nombre_funcionalidad == "abmHotel");

            ToolStripItem menu_nuevo_hotel = menuStrip1.Items.Find("nuevoHotelToolStripMenuItem", true)[0];
            menu_nuevo_hotel.Enabled = f.Any(func => func.nombre_funcionalidad == "abmHotel");

            ToolStripItem menu_habitaciones = menuStrip1.Items.Find("habitacionesToolStripMenuItem", true)[0];
            menu_habitaciones.Enabled = f.Any(func => func.nombre_funcionalidad == "abmHabitacion");
            
        }

        private void cambiar_contraseñaClick(object sender,LinkLabelLinkClickedEventArgs e)
        {
            CambiarPassword edit_pass = new CambiarPassword();
            DialogResult res = edit_pass.ShowDialog();
            if (DialogResult.Cancel == res)
            {
                linkLabelCerrar_LinkClicked(sender, e);
                linkLabel_Login_LinkClicked(sender, e);
            }
        }

        public void ActualizarStatusStrip()
        {
            ToolStripItem status_label = statusStrip1.Items["StatusLabel"];
            status_label.Text = "Usuario: "+ Sesion.user_id + " - Hotel: " + Sesion.id_hotel + ". DB: " + conexion.Database + ". "
                + "Instancia: " + conexion.DataSource;
        }

        #region Panel Reserva
        private void button_GenerarReserva_Click(object sender, EventArgs e)
        {
            FrbaHotel.Generar_Modificar_Reserva.AltaModReservasScreen amr = new FrbaHotel.Generar_Modificar_Reserva.AltaModReservasScreen(Sesion.id_hotel, Sesion.user_id);
            amr.ShowDialog();
        }

        private void button_CancelarReserva_Click(object sender, EventArgs e)
        {
            CancelReservaScreen cr = new CancelReservaScreen();
            cr.ShowDialog();
        }

        private void button_ModificarReserva_Click(object sender, EventArgs e)
        {
            FrbaHotel.Generar_Modificar_Reserva.ModificarReserva mr = new FrbaHotel.Generar_Modificar_Reserva.ModificarReserva(Sesion.id_hotel, Sesion.user_id);
            mr.ShowDialog();
        }
        #endregion

        #region Panel Usuario
        private void button_Roles_Click(object sender, EventArgs e)
        {
            ScreenRol sr = new ScreenRol();
            sr.ShowDialog();
        }

        private void button_Usuarios_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Usuario.ScreenUser su = new FrbaHotel.ABM_de_Usuario.ScreenUser();
            su.ShowDialog();
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.ScreenClientes sc = new FrbaHotel.ABM_de_Cliente.ScreenClientes();
            sc.ShowDialog();
        }

        private void button_Estadisticas_Click(object sender, EventArgs e)
        {
            FrbaHotel.Listado_Estadistico.StatsScreen ss = new FrbaHotel.Listado_Estadistico.StatsScreen();
            ss.ShowDialog();
        }

        #endregion

        #region Menu
        private void estadíaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrbaHotel.Registrar_Estadia.EstadiaScreen es = new FrbaHotel.Registrar_Estadia.EstadiaScreen();
            es.ShowDialog();
        }

        /*
        private void consumibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrbaHotel.Registrar_Consumible.Registrar_Consumibles rc = new FrbaHotel.Registrar_Consumible.Registrar_Consumibles();
            rc.ShowDialog();
        }*/

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrbaHotel.Registrar_Consumible.Facturar_Estadias fe = new FrbaHotel.Registrar_Consumible.Facturar_Estadias();
            fe.ShowDialog();  
        }

        private void seleccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Regimen.ScreenRegimen sr = new FrbaHotel.ABM_de_Regimen.ScreenRegimen();
            sr.ShowDialog();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // NUEVO REGIMEN
        }

        private void seleccionHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Hotel.ScreenHoteles sh = new FrbaHotel.ABM_de_Hotel.ScreenHoteles(Sesion.user_id);
            sh.ShowDialog();
        }

        private void nuevoHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Hotel.AltaDeHotel ah = new FrbaHotel.ABM_de_Hotel.AltaDeHotel(Sesion.user_id);
            ah.ShowDialog();
        }

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Habitacion.ScreenRoom sr = new FrbaHotel.ABM_de_Habitacion.ScreenRoom(Sesion.id_hotel);
            sr.ShowDialog();
        }


        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstadiaScreen es = new EstadiaScreen();
            es.ShowDialog();
        }

        #endregion     

    }
}
