using System;
using System.Xml;
using System.Data;
using System.Xml.XPath;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Data
{
    public sealed class SqlDataAccess
    {
        private static SqlConnection _connection;

        //Abre una conexion e inicia una transaccion
        public static SqlTransaction OpenTransaction(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            return _connection.BeginTransaction();
        }

        //Ejecuta el commit de una transaccion especifica
        public static void Commit(SqlTransaction transaction)
        {
            transaction.Commit();
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }

        //Realizar un Rollback sobre una transaccion
        public static void Rollback(SqlTransaction transaction)
        {
            transaction.Rollback();
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }


        //Ejecuta una query y devuelve la cantidad de filas afectadas
        public static int ExecuteNonQuery(string connectionString, string text)
        {
            return ExecuteNonQuery(connectionString, text, null);
        }

        //Ejecuta la query pudiendo recibir un Idictionary (la funcion anterior la utiliza)
        public static int ExecuteNonQuery(string connectionString, string text, IDictionary<string, object> args)
        {
            int result = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand(text, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    if (args != null && args.Count > 0)
                        foreach (string key in args.Keys)
                        {
                            com.Parameters.AddWithValue(key, args[key] == null ? DBNull.Value : args[key]);
                        }
                    con.Open();
                    try
                    {
                        result = com.ExecuteNonQuery();
                    }
                    finally
                    {
                        try
                        {
                            con.Close();
                            con.Dispose();
                            com.Dispose();
                        }
                        catch { }
                    }
                }
            }

            return result;
        }


        //Ejecuta la query pudiendo recibir un Idictionary (la funcion anterior la utiliza)
        public static int ExecuteNonQuery(string text, IDictionary<string, object> args, SqlTransaction transaction)
        {
            int result = -1;

            using (SqlCommand com = new SqlCommand(text, _connection, transaction))
            {
                com.CommandType = CommandType.StoredProcedure;
                if (args != null && args.Count > 0)
                    foreach (string key in args.Keys)
                    {
                        com.Parameters.AddWithValue(key, args[key] == null ? DBNull.Value : args[key]);
                    }
                try
                {
                    result = com.ExecuteNonQuery();
                }
                finally
                {
                    try
                    {
                        com.Dispose();
                    }
                    catch { }
                }
            }

            return result;
        }


        // Ejecuta una query y devuelve la primer fila de la primer columna (el resto las ignora)
        public static T ExecuteScalarQuery<T>(string connectionString, string text)
        {
            return (T)Convert.ChangeType(ExecuteScalarQuery(connectionString, text, null, null), typeof(T));
        }


        public static T ExecuteScalarQuery<T>(string connectionString, string text, IDictionary<string, object> args)
        {
            return (T)Convert.ChangeType(ExecuteScalarQuery(connectionString, text, args, null), typeof(T));
        }

        // Ejecuta la query y devuelve la primer fila de la columna que se pasa como nombre en el ultimo parametro
        public static T ExecuteScalarQuery<T>(string connectionString, string text, IDictionary<string, object> args, string field)
        {
            return (T)Convert.ChangeType(ExecuteScalarQuery(connectionString, text, args, field), typeof(T));
        }


        /// Usada por la de arriba
        private static object ExecuteScalarQuery(string connectionString, string text, IDictionary<string, object> args, string field)
        {
            if (field != null)
                return executeDataRowAsScalar(connectionString, text, args, field);

            object result = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand(text, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    if (args != null && args.Count > 0)
                        foreach (string key in args.Keys)
                        {
                            com.Parameters.AddWithValue(key, args[key] == null ? DBNull.Value : args[key]);
                        }
                    con.Open();
                    try
                    {
                        result = com.ExecuteScalar();
                    }
                    finally
                    {
                        try
                        {
                            con.Close();
                            con.Dispose();
                            com.Dispose();
                        }
                        catch { }
                    }
                }
            }

            return result;
        }

        public static T ExecuteScalarQuery<T>(string text, IDictionary<string, object> args, SqlTransaction transaction)
        {
            object result = null;

            using (SqlCommand com = new SqlCommand(text, _connection, transaction))
            {
                com.CommandType = CommandType.StoredProcedure;
                if (args != null && args.Count > 0)
                    foreach (string key in args.Keys)
                    {
                        com.Parameters.AddWithValue(key, args[key] == null ? DBNull.Value : args[key]);
                    }
                try
                {
                    result = com.ExecuteScalar();
                }
                finally
                {
                    try
                    {
                        com.Dispose();
                    }
                    catch { }
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        // Ejecuta un query y devuelve una tabla
        public static DataTable ExecuteDataTableQuery(string connectionString, string text)
        {
            return ExecuteDataTableQuery(connectionString, text, null);
        }


        public static DataTable ExecuteDataTableQuery(string connectionString, string text, IDictionary<string, object> args)
        {
            DataTable result = null;
            int count = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand(text, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    if (args != null && args.Count > 0)
                        foreach (string key in args.Keys)
                        {
                            com.Parameters.AddWithValue(key, args[key] == null ? DBNull.Value : args[key]);
                        }
                    con.Open();
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        if (dr.HasRows)
                        {
                            result = new DataTable();

                            while (dr.Read())
                            {
                                DataRow row = result.NewRow();
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    if (count == 0)
                                        result.Columns.Add(dr.GetName(i));

                                    row[i] = dr[i];
                                }
                                result.Rows.Add(row);
                                count++;
                            }
                        }
                        dr.Close();
                    }
                    finally
                    {
                        try
                        {
                            con.Close();
                            con.Dispose();
                            com.Dispose();
                        }
                        catch { }
                    }
                }
            }

            return result;
        }


        //Ejecuta una query y devuelve una dataRow
        public static DataRow ExecuteDataRowQuery(string connectionString, string text)
        {
            return ExecuteDataRowQuery(connectionString, text, null);
        }

        public static DataRow ExecuteDataRowQuery(string connectionString, string text, IDictionary<string, object> args)
        {
            DataRow result = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand(text, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    if (args != null && args.Count > 0)
                        foreach (string key in args.Keys)
                        {
                            com.Parameters.AddWithValue(key, args[key] == null ? DBNull.Value : args[key]);
                        }
                    con.Open();
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            result = new DataTable().NewRow();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                result.Table.Columns.Add(dr.GetName(i));
                                result[i] = dr[i];
                            }
                        }
                        dr.Close();
                    }
                    finally
                    {
                        try
                        {
                            con.Close();
                            con.Dispose();
                            com.Dispose();
                        }
                        catch { }
                    }
                }
            }

            return result;
        }


        public static DataRow ExecuteDataRowText(string connectionString, string text, IDictionary<string, object> args)
        {
            DataRow result = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand(text, con))
                {
                    com.CommandType = CommandType.Text;
                    if (args != null && args.Count > 0)
                        foreach (string key in args.Keys)
                        {
                            com.Parameters.AddWithValue(key, args[key]);
                        }
                    con.Open();
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            result = new DataTable().NewRow();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                result.Table.Columns.Add(dr.GetName(i));
                                result[i] = dr[i];
                            }
                        }
                        dr.Close();
                    }
                    finally
                    {
                        try
                        {
                            con.Close();
                            con.Dispose();
                            com.Dispose();
                        }
                        catch { }
                    }
                }
            }

            return result;
        }


        private static object executeDataRowAsScalar(string connectionString, string text, IDictionary<string, object> args, string field)
        {
            DataRow row = ExecuteDataRowQuery(connectionString, text, args);
            if (row == null)
                return null;

            if (!row.Table.Columns.Contains(field))
                return null;

            return row[field];
        }

        private SqlDataAccess() { }

        public static XmlDocument ExecuteXmlQuery(string connectionString, string text)
        {
            return ExecuteXmlQuery(connectionString, text, null);
        }

        public static XmlDocument ExecuteXmlQuery(string connectionString, string text, IDictionary<string, object> args)
        {
            XmlDocument result = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand com = new SqlCommand(text, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    if (args != null && args.Count > 0)
                        foreach (string key in args.Keys)
                        {
                            com.Parameters.AddWithValue(key, args[key] == null ? DBNull.Value : args[key]);
                        }
                    con.Open();
                    try
                    {
                        XmlReader xr = com.ExecuteXmlReader();
                        result = new XmlDocument();
                        result.Load(xr);
                        xr.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException.GetType().Equals(typeof(SqlNullValueException)))
                            return null;
                    }
                    finally
                    {
                        try
                        {
                            con.Close();
                            con.Dispose();
                            com.Dispose();
                        }
                        catch { }
                    }
                }
            }

            return result;
        }

    }
}