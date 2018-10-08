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
    public class EstadiaManager : IBuilder<Estadia>
    {
        ReservaManager _resMan = new ReservaManager();

        public decimal GetValorEstadiaFinal(string formadepago, int id_estadia, int cuotas, int id_tarjeta)
        {
            decimal valor_final_estadia = 0;

            DateTime fechadia = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.INSERTARESTADIAITEMFACTURA", SqlDataAccessArgs.CreateWith("@ID_ESTADIA", id_estadia)
               .And("@FORMA_DE_PAGO", formadepago).And("@FECHA",fechadia).And("@CUOTAS",cuotas)
               .And("@ID_TARJETA",id_tarjeta).Arguments);  ////
            
            var resultado_final_estadia = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.DAMEVALORFINALESATADIA", SqlDataAccessArgs.CreateWith("@ID_ESTADIA", id_estadia).Arguments);

            if (resultado_final_estadia != null && resultado_final_estadia != null)
            {
                foreach (DataRow row_final in resultado_final_estadia.Rows)
                { 
                    valor_final_estadia = decimal.Parse(row_final[0].ToString());                 
                }
            }
            return valor_final_estadia;
        }

         public BindingList<Estadia> GetAllEstadiasSinFacturarPorHotel(int id_hotel_que_quiero)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLESTADIASSINFACTURAR", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel_que_quiero).Arguments);

            var lista_estadias_del_hotel = new BindingList<Estadia>();

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Estadia estadia = new Estadia();
                    estadia.id_estadia = int.Parse(row["ID_Estadia"].ToString());
                    estadia.fecha_inicio = Convert.ToDateTime(row["Fecha_Inicio"]);
                    estadia.cant_noches = int.Parse(row["Cant_Noches"].ToString());
                    estadia.reserva = int.Parse(row["Codigo_Reserva"].ToString());
                    estadia.user_ingreso = (row["Usuario_Ingreso"].ToString());
                    estadia.user_egreso = (row["Usuario_Egreso"].ToString());

                    lista_estadias_del_hotel.Add(estadia);
                }
            }
            return lista_estadias_del_hotel;
        }

        public BindingList<Estadia> GetAllPorHotel(int id_hotel_que_quiero)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLESTADIASPORHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel_que_quiero).Arguments);

            var lista_estadias_del_hotel = new BindingList<Estadia>();

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Estadia estadia = new Estadia();
                    estadia.id_estadia = int.Parse(row["ID_Estadia"].ToString());
                    estadia.fecha_inicio = Convert.ToDateTime(row["Fecha_Inicio"]);
                    estadia.cant_noches = int.Parse(row["Cant_Noches"].ToString());
                    estadia.reserva = int.Parse(row["Codigo_Reserva"].ToString());
                    estadia.user_ingreso = (row["Usuario_Ingreso"].ToString());
                    estadia.user_egreso = (row["Usuario_Egreso"].ToString());

                    lista_estadias_del_hotel.Add(estadia);
                }
            }
            return lista_estadias_del_hotel;
        }

        public Estadia Build(System.Data.DataRow row)
        {
            Estadia estadia = new Estadia();
            estadia.id_estadia = int.Parse(row["ID_Estadia"].ToString());
            estadia.fecha_inicio = Convert.ToDateTime(row["Fecha_Inicio"]);
            estadia.cant_noches = int.Parse(row["Cant_Noches"].ToString());
            estadia.reserva = int.Parse(row["Codigo_Reserva"].ToString());
            estadia.user_ingreso = (row["Usuario_Ingreso"].ToString());
            estadia.user_egreso = (row["Usuario_Egreso"].ToString());
            return estadia;
        }

        public Estadia Build(int PK)
        {
            Estadia estadia = null;
            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETESTADIA", SqlDataAccessArgs.CreateWith("@ID_ESTADIA", PK).Arguments);
            if (resultado != null)
            {
                estadia = this.Build(resultado);
            }
            return estadia;
        }

        public void insertarNuevaEstadia(Reserva reserva)
        {
          
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString()
                ,"LOS_NULL.INSERTARESTADIA",
                SqlDataAccessArgs.CreateWith("@FECHA",reserva.fecha_inicio)
                .And("@NOCHES",reserva.cant_noches)
                .And ("@RES",reserva.codigo_reserva)
                .And ("@USER",Sesion.user_id).Arguments);

          //  _resMan.updateStatus(reserva.codigo_reserva, 6,Sesion.user_id);
        }

        public int getIdPorReserva(int id_reserva)
        {
           
            int id_estadia = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString()
                ,"LOS_NULL.GETESTADIA_X_RESERVA",
                SqlDataAccessArgs.CreateWith("@RESERVA", id_reserva).Arguments);

            return id_estadia;
        }

        public void cerrarEstadia(int id_estadia, int dias_estadia)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString() 
                ,"LOS_NULL.CERRAR_ESTADIA",
                SqlDataAccessArgs.CreateWith("@ESTADIA", id_estadia)
                .And("@CANT",dias_estadia)
                .And("@USER",Sesion.user_id)
                .Arguments);

        }
            
    }
}
