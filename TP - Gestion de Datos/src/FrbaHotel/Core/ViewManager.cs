using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FrbaHotel.Core
{
    /// <summary>
    /// Administra los formularios y pantallas en el sistema
    /// </summary>
    class ViewManager
    {
        private static Form _mainWindow;

        /// <summary>
        /// Setea cual sera la ventana principal durante la sesion
        /// </summary>
        /// <param name="mainWindow">El formulario principal que sera el padre de todos los demas</param>
        public static void SetMainWindow(Form mainWindow)
        {
            mainWindow.IsMdiContainer = true;
            _mainWindow = mainWindow;
        }

        /// <summary>
        /// Carga un formulario para su visualizacion en el sistema
        /// </summary>
        /// <param name="form">Formulario a mostrar</param>
        public static void LoadView(Form form)
        {
            ClearViews();

            form.Text = string.Empty;
            form.ShowIcon = false;
            form.ControlBox = false;
            form.Dock = DockStyle.Fill;
            form.ShowInTaskbar = false;
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = _mainWindow;
            form.TopMost = true;
            form.Top = 1;

            form.Show();
        }


        /// <summary>
        /// Cierra todas las ventanas activas en el sistema
        /// </summary>
        public static void ClearViews()
        {
            foreach (var chilren in _mainWindow.MdiChildren)
            {
                chilren.Hide();
            }

            if (_mainWindow.ActiveMdiChild != null)
                _mainWindow.ActiveMdiChild.Hide();
        }


    }
}
