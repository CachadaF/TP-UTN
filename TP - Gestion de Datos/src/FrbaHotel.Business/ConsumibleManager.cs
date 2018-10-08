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
    public class ConsumibleManager : IBuilder<Consumible>
    {     

        public BindingList<Item_factura> GetAllItemsFacturaEstadia(int id_estadia)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                 "LOS_NULL.GETALLITEMSFACTURADEESTADIA",SqlDataAccessArgs.CreateWith("@ID_ESTADIA",id_estadia).Arguments);
            var lista_items_factura = new BindingList<Item_factura>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Item_factura item_fact = new Item_factura();
                    item_fact.monto = decimal.Parse(row["Monto"].ToString());
                    item_fact.cantidad = int.Parse(row["Cantidad"].ToString());
                    item_fact.descripcion = row["Detalle"].ToString();
                    item_fact.consumible = int.Parse(row["Codigo_Consumible"].ToString());
                    item_fact.factura = int.Parse(row["Nro_Factura"].ToString());
                    lista_items_factura.Add(item_fact);
                }
            }
            return lista_items_factura;

        }

        public BindingList<Consumible> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLCONSUMIBLES");
            var lista_consumibles = new BindingList<Consumible>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Consumible consumible = new Consumible();
                    consumible.id_consumible = int.Parse(row["ID_Consumible"].ToString());
                    consumible.descripcion = Convert.ToString(row["Descripcion"]);
                    consumible.precio = decimal.Parse(row["Precio"].ToString());

                    lista_consumibles.Add(consumible);
                }
            }
            return lista_consumibles;
        }

        public BindingList<Consumible> GetConsumiblesDeReserva(int cod_reserva)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETCONSUMIBLESXRESERVA", SqlDataAccessArgs.CreateWith("@COD_RESERVA", cod_reserva).Arguments);
            var lista_consumibles = new BindingList<Consumible>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    Consumible consumible = this.Build(row);
                    lista_consumibles.Add(consumible);
                }
            }
            return lista_consumibles;
        }

        public void Insertar_Items_Factura(BindingList<Item_factura> lista_itemsfacturas)
        {
            foreach (Item_factura items_a_ingresar in lista_itemsfacturas)
            {                
                SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.INGRESARCONSUMIBLESITEMSFACTURA", SqlDataAccessArgs.CreateWith("ID_ESTADIA", items_a_ingresar.estadia)
                .And("@MONTO",items_a_ingresar.monto).And("@ID_CONSUMIBLE",items_a_ingresar.consumible)
                .And("@CANTIDAD",items_a_ingresar.cantidad).Arguments);       
            }

            return;
        }

        public decimal GetPrecioParaConsumible(string consumible)
        {
            decimal precio = 0;

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETPRECIOCONSUMIBLE", SqlDataAccessArgs.CreateWith("@CONSUMIBLE",consumible).Arguments);            
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    precio = decimal.Parse(row["Precio"].ToString());
                }
            }
            return precio;
        }

        public int GetNumeroConsumible(string consumible)
        {
            int id_consumible = 0;

            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETNUMEROCONSUMIBLE", SqlDataAccessArgs.CreateWith("@CONSUMIBLE", consumible).Arguments);
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    id_consumible = int.Parse(row["ID_Consumible"].ToString());
                }
            }
            return id_consumible;
        }

        public Consumible Build(System.Data.DataRow row)
        {
            Consumible consumible = new Consumible();
            consumible.id_consumible = int.Parse(row["ID_Consumible"].ToString());
            consumible.descripcion = Convert.ToString(row["Descripcion"]);
            consumible.precio = decimal.Parse(row["Precio"].ToString());
            return consumible;
        }

        public Consumible Build(int PK)
        {
            Consumible consumible = null;

            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETCONSUMIBLE", SqlDataAccessArgs.CreateWith("@ID_CONSUMIBLE", PK).Arguments);

            if (resultado != null)
            {
                consumible = this.Build(resultado);
            }

            return consumible;
        }

    }
}
