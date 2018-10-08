using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel_Commons;
using Data;
using System.Configuration;
using System.ComponentModel;
using System.Data;

namespace FrbaHotel.Business
{
    public class NacionalidadManager : IBuilder<Nacionalidad>
    {
        public BindingList<Nacionalidad> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GET_NACIONALIDADES");
            var lista_nac = new BindingList<Nacionalidad>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    lista_nac.Add(this.Build(row));
                }
            }
            return lista_nac;
        }

        public Nacionalidad Build(DataRow row)
        {
            Nacionalidad nacionalidad = new Nacionalidad();
            nacionalidad.id_nac = Convert.ToInt32(row["ID_Nacionalidad"]);
            nacionalidad.descripcion = Convert.ToString(row["Descripcion"]);

            return nacionalidad;
        }


    }
}
