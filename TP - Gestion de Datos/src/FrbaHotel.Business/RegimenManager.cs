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
    public partial class RegimenManager : IBuilder<Regimen>
    {
        public void InsertarNuevoRegimenHotel(int id_hotel,string desc_regimen)
        {
           SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.INSERTARNUEVOREGIMENHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel)
                .And("DESCRIPCION",desc_regimen).Arguments);
        }

        public void EliminarRegimenHotel(int id_hotel, string desc_regimen)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                 "LOS_NULL.ELIMINARREGIMENHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel)
                 .And("DESCRIPCION", desc_regimen).Arguments);
        }

        public BindingList<Regimen> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLREGIMENES");
            var lista_regimenes = new BindingList<Regimen>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Regimen regimen = new Regimen();
                    regimen.id_regimen = int.Parse(row["ID_Regimen"].ToString());
                    regimen.descripcion = Convert.ToString(row["Descripcion"]);
                    regimen.precio = decimal.Parse(row["Precio"].ToString());
                    regimen.estado = Convert.ToBoolean(row["Estado"]);
                    lista_regimenes.Add(regimen);
                }
            }
            return lista_regimenes;
        }

        public Regimen Build(System.Data.DataRow row)
        {
            Regimen regimen = new Regimen();

            regimen.id_regimen = int.Parse(row["ID_Regimen"].ToString());
            regimen.descripcion = Convert.ToString(row["Descripcion"]);
            regimen.precio = decimal.Parse(row["Precio"].ToString());
            regimen.estado = Convert.ToBoolean(row["Estado"]);
            return regimen;
        }

        public Regimen Build(UInt32 PK)
        {
            Regimen regimen = null;

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETREGIMEN", SqlDataAccessArgs.CreateWith("@ID_REGIMEN", PK).Arguments);

            if (resultado != null && resultado.Rows != null)
            {
                regimen = this.Build(resultado.Rows[0]);
            }

            return regimen;
        }

        public BindingList<Regimen> GetNoRepetidos(int id_hotel)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETREGIMENFALTANTESHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel).Arguments);
            var lista_regimenes_del_hotel = new BindingList<Regimen>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Regimen regimen = new Regimen();
                    regimen.id_regimen = int.Parse(row["ID_Regimen"].ToString());
                    regimen.descripcion = Convert.ToString(row["Descripcion"]);
                    regimen.precio = decimal.Parse(row["Precio"].ToString());
                    regimen.estado = Convert.ToBoolean(row["Estado"]);
                    lista_regimenes_del_hotel.Add(regimen);
                }
            }
            return lista_regimenes_del_hotel;
        }

        public BindingList<Regimen> GetBorrablesPorHotel(int id_hotel)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETREGIMENBORRABLESHOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel).Arguments);
            var lista_regimenes_del_hotel = new BindingList<Regimen>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Regimen regimen = new Regimen();
                    regimen.id_regimen = int.Parse(row["ID_Regimen"].ToString());
                    regimen.descripcion = Convert.ToString(row["Descripcion"]);
                    regimen.precio = decimal.Parse(row["Precio"].ToString());
                    regimen.estado = Convert.ToBoolean(row["Estado"]);
                    lista_regimenes_del_hotel.Add(regimen);
                }
            }
            return lista_regimenes_del_hotel;
        }
    }
}
