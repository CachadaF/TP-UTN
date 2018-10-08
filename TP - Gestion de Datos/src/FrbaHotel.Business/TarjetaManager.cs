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
    public partial class TarjetaManager : IBuilder<Tarjeta>
    {
        
        public void InsertarTarjeta(Tarjeta tarj)
        {
            SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                 "LOS_NULL.INSERTARTARJETA", SqlDataAccessArgs.CreateWith("@NUMERO", tarj.numero)
                 .And("@TIPO", tarj.tipo).And("@DESCRIPCION", tarj.descripcion).Arguments);

            return;
        }

        public bool ExisteTarjeta(int numero,string tipo)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                 "LOS_NULL.GETTARJETA", SqlDataAccessArgs.CreateWith("@NUMERO", numero)
                 .And("@TIPO", tipo).Arguments);

            bool boolean_tarjeta = false;

            if (resultado != null && resultado.Rows != null)
            {
                boolean_tarjeta = true;
            }
            else
            {
                boolean_tarjeta = false;
            }
            return boolean_tarjeta;
        }
        
        
        public BindingList<Tarjeta> GetAllTarjeta()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                 "LOS_NULL.GETALLTARJETAS");
            var lista_tarjetas = new BindingList<Tarjeta>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Tarjeta tarj = new Tarjeta();

                    tarj.id_tarjeta = int.Parse(row["ID_Tarjeta"].ToString());
                    tarj.numero = int.Parse(row["Numero"].ToString());
                    tarj.tipo = row["Tipo"].ToString();
                    tarj.descripcion = row["Descripcion"].ToString();

                    lista_tarjetas.Add(tarj);
                }
            }
            return lista_tarjetas;
        }
       
        public Tarjeta Build(System.Data.DataRow row)
        {
            Tarjeta tarj = new Tarjeta();

            tarj.id_tarjeta = int.Parse(row["ID_Tarjeta"].ToString());
            tarj.numero = int.Parse(row["Numero"].ToString());
            tarj.tipo = row["Tipo"].ToString();
            tarj.descripcion = row["Descripcion"].ToString();

            return tarj;
        }
    }
}
