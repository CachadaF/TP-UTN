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
    public class ClienteManager : IBuilder<Cliente>
    {
        public BindingList<Cliente> listado_cliente_por_datos(Int32 Nropasaporte_buscar, String nombre_buscar, String apellido_buscar, String mail)
        {
            DataTable resultado;
            BindingList<Cliente> clientes_listados = new BindingList<Cliente>();
            if (Nropasaporte_buscar == 0)
                resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                   "LOS_NULL.LISTADO_CLIENTES_POR_CAMPOS", SqlDataAccessArgs.CreateWith("@NRO_PASAPORTE", DBNull.Value)
                   .And("@EMAIL", mail).And("@NOMBRE", nombre_buscar).And("@APELLIDO", apellido_buscar).Arguments);
            else
                resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                   "LOS_NULL.LISTADO_CLIENTES_POR_CAMPOS", SqlDataAccessArgs.CreateWith("@NRO_PASAPORTE", Nropasaporte_buscar)
                   .And("@EMAIL", mail).And("@NOMBRE", nombre_buscar).And("@APELLIDO", apellido_buscar).Arguments);

            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                    clientes_listados.Add(this.Build(row));
            }

            return clientes_listados;
        }


        public string ActualizarCliente(Cliente c)
        {
            return SqlDataAccess.ExecuteScalarQuery<string>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.modificarCliente", SqlDataAccessArgs
                .CreateWith("@NRO_CLIENTE", c.id_cliente).And("@ID_NACIONALIDAD", c.nacionalidad)
                .And("@NRO_PASAPORTE", c.pasaporte).And("@APELLIDO", c.apellido).And("@NOMBRE", c.nombre)
                .And("@FECHA_NAC", c.fecha_nac).And("@MAIL", c.mail).And("@DOM_CALLE", c.dom_calle)
                .And("@NRO_CALLE", c.dom_numero).And("@PISO", c.piso).And("@DEPTO", c.nro_depto)
                .And("@BAJA_LOGICA", c.baja_logica).Arguments);
        }


        public string AgregarCliente(Cliente c)
        {
            return SqlDataAccess.ExecuteScalarQuery<string>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.ClienteNuevo", SqlDataAccessArgs
                .CreateWith("@ID_NACIONALIDAD", c.nacionalidad)
                .And("@NRO_PASAPORTE", c.pasaporte).And("@APELLIDO", c.apellido).And("@NOMBRE", c.nombre)
                .And("@FECHA_NAC", c.fecha_nac).And("@MAIL", c.mail).And("@DOM_CALLE", c.dom_calle)
                .And("@NRO_CALLE", c.dom_numero).And("@PISO", c.piso).And("@DEPTO", c.nro_depto)
                .And("@BAJA_LOGICA", c.baja_logica).Arguments);
        }

        public Cliente Build(System.Data.DataRow row)
        {
            Cliente cliente = new Cliente();

            cliente.id_cliente = Convert.ToInt32(row["Nro_Cliente"]);
            cliente.nombre = Convert.ToString(row["Nombre"]);
            cliente.apellido = Convert.ToString(row["Apellido"]);
            cliente.pasaporte = Convert.ToInt32(row["Nro_Pasaporte"]);
            cliente.nacionalidad = Convert.ToInt32(row["ID_Nacionalidad"]);
            cliente.fecha_nac = Convert.ToDateTime(row["Fecha_nac"]);
            cliente.mail = Convert.ToString(row["Mail"]);
            cliente.nro_depto = Convert.ToString(row["Depto"]);
            cliente.dom_calle = Convert.ToString(row["Dom_Calle"]);
            cliente.dom_numero = Convert.ToInt32(row["Nro_Calle"]);
            //cliente.piso = Convert.ToInt32(row["Piso"]);
            cliente.baja_logica = Convert.ToBoolean(row["Baja_Logica"]);
            cliente.Duplicado_Pasaporte = Convert.ToBoolean(row["Duplicado_Pasaporte"]);
            cliente.Duplicado_Mail = Convert.ToBoolean(row["Duplicado_Mail"]);

            return cliente;

        }

        public Cliente Build(int PK)
        {
            Cliente cliente = null;

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETCLIENTE", SqlDataAccessArgs.CreateWith("@ID_CLIENTE", PK).Arguments);

            if (resultado != null && resultado.Rows != null)
            {
                cliente = this.Build(resultado.Rows[0]);
            }

            return cliente;
        }

        public DataRow getCliente(int id)
        {
            DataRow resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETCLIENTE", SqlDataAccessArgs.CreateWith("@ID_CLIENTE", id).Arguments);

            return resultado;
        }
    }
}
