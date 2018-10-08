using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Commons;
using System.Data;
using System.Data.SqlClient;
using Data;
using System.Configuration;


namespace FrbaHotel.Business
{
    public class Estado_reservaManager : IBuilder<Estado_reserva>
    {
        public Estado_reserva Build(System.Data.DataRow row)
        {
            Estado_reserva estado = new Estado_reserva();

            estado.id_estado = int.Parse(row["ID_Estado"].ToString());
            estado.descripcion = Convert.ToString(row["Descripcion"]);    
            
            return estado;
        }

        public Estado_reserva Build(UInt32 PK)
        {
            Estado_reserva estado = null;

            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETESTADORESERVA", SqlDataAccessArgs.CreateWith("@ID_ESTADO", PK).Arguments);

            if (resultado != null)
            {
                estado = this.Build(resultado);
            }

            return estado;
        }

    }
}
