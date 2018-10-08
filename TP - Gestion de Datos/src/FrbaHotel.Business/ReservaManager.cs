using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Commons;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using Data;

namespace FrbaHotel.Business
{
    public partial class ReservaManager : IBuilder<Reserva>
    {
        public void InsertClientexReserva(int ID_Reserva, int ID_Cliente)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.INSERTARCLIENTERESERVA", SqlDataAccessArgs.CreateWith("@COD_RESERVA", ID_Reserva)
               .And("@ID_CLIENTE", ID_Cliente).Arguments);
        }       

        public Reserva ExisteReserva(int ID_Reserva, int ID_Hotel)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETRESERVAVIGENTE_HOTEL", SqlDataAccessArgs.CreateWith("@COD_RESERVA", ID_Reserva)
               .And("@ID_HOTEL", ID_Hotel).Arguments);

            Reserva reserva = new Reserva();
            reserva.codigo_reserva = 0;

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    reserva.codigo_reserva = int.Parse(row["Codigo_Reserva"].ToString());
                    reserva.fecha_inicio = Convert.ToDateTime(row["Fecha_Inicio"]);
                    reserva.cant_noches = int.Parse(row["Cant_Noches"].ToString());
                    reserva.fecha_realizada = Convert.ToDateTime(row["Fecha_Realizada"]);
                    reserva.estado = int.Parse(row["ID_Estado"].ToString());
                    reserva.usuario = (row["Usuario"].ToString());
                    reserva.regimen = int.Parse(row["ID_Regimen"].ToString());
                }
            }
            else return null;

            return reserva;
        }

        public BindingList<Habitacion> GetHabitacionPorCodigoReserva(int ID_Reserva)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETHABITACIONPORCODIGORESERVA", SqlDataAccessArgs.CreateWith("@COD_RESERVA", ID_Reserva).Arguments);
            BindingList<Habitacion> lista_habitaciones_codigo = new BindingList<Habitacion>();

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Habitacion get_habitac = new Habitacion();

                    get_habitac.id_habitacion = int.Parse(row["ID_Habitacion"].ToString());
                    get_habitac.id_hotel = int.Parse(row["ID_Hotel"].ToString());
                    get_habitac.id_tipo_hab = int.Parse(row["Codigo_Tipo"].ToString());
                    get_habitac.numero = int.Parse(row["Numero"].ToString());
                    get_habitac.piso = int.Parse(row["Piso"].ToString());
                    get_habitac.baja_logica = Boolean.Parse(row["Baja_Logica"].ToString());
                    get_habitac.frente = (row["Frente"].ToString());
                    get_habitac.descripcion = (row["Descripcion"].ToString());

                    lista_habitaciones_codigo.Add(get_habitac);
                }
            }
            return lista_habitaciones_codigo;
        }

        public void ModificarReserva(DateTime fecha_ini, int cant_dias, DateTime fecha_realizada,
            string regimen_string, string usuario_string, int ID_Reserva)
        {

            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.MODIFICARRESERVA", SqlDataAccessArgs.CreateWith("@FECHA_INICIAL", fecha_ini)
               .And("@CANTIDAD_DIAS", cant_dias).And("@FECHA_REALIZADA", fecha_realizada)
               .And("@REGIMEN", regimen_string).And("@USUARIO", usuario_string).And("@CODIGO_RESERVA", ID_Reserva).Arguments);
        }

        public void QuitarReservaHabitacion(int ID_Habitacion, int Codigo_Reserva)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.QUITARRESERVAXHABITACION", SqlDataAccessArgs.CreateWith("@ID_HABITACION", ID_Habitacion)
               .And("@CODIGO_RESERVA", Codigo_Reserva).Arguments);

            return;
        }

        public int InsertarReserva(DateTime fecha_ini, int cant_dias, DateTime fecha_realizada,
            string regimen_string, string usuario_string)
        {
            int reserva_valor_retorno = 0;

            reserva_valor_retorno = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.INSERTARRESERVA", SqlDataAccessArgs.CreateWith("@FECHA_INICIAL", fecha_ini)
               .And("@CANTIDAD_DIAS", cant_dias).And("@FECHA_REALIZADA", fecha_realizada)
               .And("@REGIMEN", regimen_string).And("@USUARIO", usuario_string).Arguments);

            return reserva_valor_retorno;
        }

        public void InsertarReservaHabitacion(int ID_Habitacion,int Codigo_Reserva)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.INSERTARRESERVAXHABITACION", SqlDataAccessArgs.CreateWith("@ID_HABITACION", ID_Habitacion)
               .And("@CODIGO_RESERVA", Codigo_Reserva).Arguments);

            return ;
        }

        public string cancelarReserva(string motivoBaja, DateTime fechaBaja, string usuario, int Codigo_Reserva)
        {
            return
            SqlDataAccess.ExecuteScalarQuery<string>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.CANCELARRESERVA", SqlDataAccessArgs.CreateWith
               ("@MOTIVO", motivoBaja).And
               ("@FECHA", fechaBaja).And
               ("@USUARIO", usuario).And
               ("@CODIGO_RESERVA", Codigo_Reserva).Arguments);
        }


        public Reserva Build(System.Data.DataRow row)
        {
            Reserva reserva = new Reserva();

            reserva.codigo_reserva = int.Parse(row["Codigo_Reserva"].ToString());
            reserva.fecha_inicio = Convert.ToDateTime(row["Fecha_Inicio"]);
            reserva.cant_noches = int.Parse(row["Cant_Noches"].ToString());
            reserva.fecha_realizada = Convert.ToDateTime(row["Fecha_Realizada"]);
            reserva.estado = int.Parse(row["ID_Estado"].ToString());
            reserva.usuario = (row["Usuario"].ToString());
            reserva.regimen = int.Parse(row["ID_Regimen"].ToString());

            return reserva;

        }

        public Reserva Build(int PK)
        {
            Reserva reserva = null;

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETRESERVA", SqlDataAccessArgs.CreateWith("@COD_RESERVA", PK).Arguments);

            if (resultado != null && resultado.Rows != null)
            {
                reserva = this.Build(resultado.Rows[0]);
            }

            return reserva;
        }

        /*       public DataRow GetReservaCliente(int codigo)
               {

                   string select_query =
                       "select r.Codigo_Reserva,rc.Nro_Cliente,C.Nombre,C.Apellido,r.Fecha_Inicio, r.Cant_Noches,r.ID_Estado from LOS_NULL.reserva r JOIN LOS_NULL.ReservaXCliente rc on (r.Codigo_Reserva=rc.Codigo_Reserva) where r.Codigo_Reserva=@CODIGO";

                   DataRow resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                      select_query, SqlDataAccessArgs.CreateWith("@CODIGO", codigo).Arguments);

                   return resultado;

               }
         */

        public bool esReservaErronea(Reserva reserva, out string mensaje)
        {

            switch (reserva.estado)
            {
                case 3:
                    mensaje = "Reserva Cancelada por Recepción";
                    return true;
                case 4:
                    mensaje = "Reserva Cancelada por Cliente";
                    return true;
                case 5:
                    mensaje = "Reserva Cancelada por No-Show";
                    return true;
                case 6:
                    mensaje = "Reserva finalizada";
                    return false;
                default:
                    mensaje = "Reserva correcta";
                    return false;
            }
        }

        public int CalcularCantidadDePersonas(int id_reserva)
        {
            int cant = 0;
            cant = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.CANTIDADPERSONAS_RESERVA", SqlDataAccessArgs.CreateWith("@RESERVA", id_reserva).Arguments);


            return cant;
        }

        public void updateStatus_NoShow(int id_reserva, int status, string user, DateTime fecha)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString()
              , "LOS_NULL.UPDATESTATUS_NOSHOW",
              SqlDataAccessArgs.CreateWith("@RESERVA", id_reserva)
              .And("@STATUS", status)
              .And("@FECHA",fecha)
              .And("@USER", user)
              .Arguments);

        }

        public int getClienteGenerador(int codigo_reserva)
        {
            int id_cliente = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETCLIENTE_GENERADOR_RESERVA", SqlDataAccessArgs.CreateWith("@RESERVA", codigo_reserva).Arguments);


            return id_cliente;

        }

        public Reserva getReservaHotel(int reserva, int hotel)
        {
            DataRow row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETRESERVAVIGENTE_HOTEL", SqlDataAccessArgs.CreateWith("@COD_RESERVA", reserva)
               .And("@ID_HOTEL", hotel).Arguments);

            if (row == null) return null;
            else return (Build(row));
        }


        public BindingList<Reserva> getAllPorHotel(int hotel)
        {
            BindingList<Reserva> lista = new BindingList<Reserva>();

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETRESERVAS_HOTEL", SqlDataAccessArgs.CreateWith("@HOTEL", hotel).Arguments);

            foreach (DataRow reserva in resultado.Rows)
            {
                lista.Add(Build(reserva));
            }

            return lista;

        }

        public void actualizarNo_Show()
        {
            BindingList<Reserva> lista = getAllPorHotel(Sesion.id_hotel);

            if (lista == null) return;
            DateTime fechaHoy = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            foreach (Reserva r in lista)
            {
                if (fechaHoy > r.fecha_inicio && (r.estado==1 || r.estado==2)) updateStatus_NoShow(r.codigo_reserva, 5, Sesion.user_id,fechaHoy);

            }

        }


    }

   
}
