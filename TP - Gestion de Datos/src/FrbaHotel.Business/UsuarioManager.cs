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
    public partial class UsuarioManager : IBuilder<Usuario>
    {

        public Usuario Build(System.Data.DataRow row)
        {
            Usuario usuario = new Usuario();
            usuario.id_usuario = Convert.ToString(row["ID_Usuario"]);
            usuario.password = Convert.ToString(row["Password"]);
            usuario.intentos = Convert.ToInt32(row["Intentos"]);
            usuario.baja_logica = Convert.ToBoolean(row["Baja_Logica"]);
            return usuario;
        }

        public Usuario Build(string PK)
        {
            Usuario usuario = null;

            var resultado = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETUSUARIO", SqlDataAccessArgs.CreateWith("@ID_USUARIO", PK).Arguments);

            if (resultado != null)
            {
                usuario = this.Build(resultado);
            }

            return usuario;
        }

        public BindingList<Usuario> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.GETALLUSUARIOS");
            var lista_usuarios = new BindingList<Usuario>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var usuario = Build(row);

                    lista_usuarios.Add(usuario);
                }
            }
            return lista_usuarios;
        }

        public bool Insertar(Usuario user)
        {

            var usuario = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
          "LOS_NULL.GETUSUARIO", SqlDataAccessArgs.CreateWith("@ID_USUARIO", user.id_usuario).Arguments);

            if (usuario != null) return false;
           
            
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "LOS_NULL.INSERTARUSER", SqlDataAccessArgs.CreateWith("@ID_USER", user.id_usuario)
                    .And("@PASS", Encriptacion.get_hash(user.password))
                    .And("@TRIES", user.intentos)
                    .And("@BAJA_LOGICA", user.baja_logica).Arguments);
            
            return true;
        }

        public void Modificar(Usuario user, string pre_id)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.MODIFICARUSER", SqlDataAccessArgs.CreateWith("@ID_USER", pre_id)
                .And("@PASS", Encriptacion.get_hash(user.password))
                .And("@TRIES", user.intentos)
                .And("@BAJA_LOGICA",user.baja_logica)
                .And("@NUEVO_USER", user.id_usuario).Arguments);

            return;
        }

        public bool pertenece_aHotel(int id_hotel, BindingList<int> hoteles_user)
        {

            if (hoteles_user == null) return false;

            bool ret = false;

            foreach (int id in hoteles_user)
            {
                ret = ret || (id_hotel == id);
            }

            return ret;
         
        }

        public void agregarEnHotel(int id_hotel, string id_user)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
           "LOS_NULL.AGREGARHOTEL_A_USER", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel)
           .And("@ID_USER", id_user).Arguments);

            return;

        }

        public void EliminarDeHotel(int id_hotel, string id_user)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
           "LOS_NULL.ELIMINARUSER_DE_HOTEL", SqlDataAccessArgs.CreateWith("@ID_HOTEL", id_hotel)
           .And("@ID_USER", id_user).Arguments);

            return;

        }

        public PersonaDeUser getDatosPersonales(string id_user)
        {
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "LOS_NULL.GETDATOSPERS_USER", SqlDataAccessArgs.CreateWith("@ID_USER",id_user).Arguments);


            PersonaDeUser datos_pers = new PersonaDeUser();

            datos_pers.tipo_doc = Convert.ToString(row["Tipo_Documento"]);
            datos_pers.documento = Convert.ToInt32(row["Nro_Documento"]);
            datos_pers.nombre = Convert.ToString(row["Nombre"]);
            datos_pers.apellido = Convert.ToString(row["Apellido"]);
            datos_pers.mail = Convert.ToString(row["Mail"]);
           // datos_pers.nacionalidad = Convert.ToString(row["Nacionalidad"]);
            datos_pers.telefono = Convert.ToString(row["Telefono"]);
            datos_pers.fecha_nac = Convert.ToDateTime(row["Fecha_Nac"]);

            datos_pers.dom_calle = Convert.ToString(row["Direccion"]);

            datos_pers.dom_numero = Convert.ToInt32(row["Numero"]);
            datos_pers.piso = Convert.ToInt32(row["Piso"]);
            datos_pers.nro_depto = Convert.ToString(row["Depto"]);
            datos_pers.localidad = Convert.ToString(row["Localidad"]);

            return datos_pers;

         }

        public void insertarDatosPersonales(string user, PersonaDeUser persona, bool es_mod)
        {


            if (es_mod)
            {
                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                  "LOS_NULL.MODIFICARDATOSPERS_USER", SqlDataAccessArgs.CreateWith("@ID_USER", user)
                  .And("@NOM", persona.nombre)
                  .And("@TDOC", persona.tipo_doc)
                  .And("@AP", persona.apellido)
                  .And("@DOC", persona.documento)
                  .And("@FEC", persona.fecha_nac)
                  .And("@DOM", persona.dom_calle)
                  .And("@NRO", persona.dom_numero)
                  .And("@PISO", persona.piso)
                  .And("@DPTO", persona.nro_depto)
                   .And("@LOC", persona.localidad)
                  .And("@TEL", persona.telefono)
                  .And("@MAIL", persona.mail).Arguments);
            }
            else
            {
                var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                  "LOS_NULL.INSERTARDATOSPERS_USER", SqlDataAccessArgs.CreateWith("@ID_USER", user)
                  .And("@NOM", persona.nombre)
                  .And("@AP", persona.apellido)
                  .And("@TDOC", persona.tipo_doc)
                  .And("@DOC", persona.documento)
                  .And("@FEC", persona.fecha_nac)
                  .And("@DOM", persona.dom_calle)
                  .And("@NRO", persona.dom_numero)
                  .And("@PISO", persona.piso)
                  .And("@DPTO", persona.nro_depto)
                  .And("@LOC", persona.localidad)
                  .And("@TEL", persona.telefono)
                  .And("@MAIL", persona.mail).Arguments);
            }

        }

        public void cambiarPassword(string user, string nueva_pass)
        {
               SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "LOS_NULL.CAMBIAR_PASSWORD", SqlDataAccessArgs.CreateWith("@ID_USER", user)
                 .And("@PASS", Encriptacion.get_hash(nueva_pass)).Arguments);

        }
     
    }
}
