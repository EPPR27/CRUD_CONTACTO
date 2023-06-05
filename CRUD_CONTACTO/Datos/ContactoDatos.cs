using CRUD_CONTACTO;
using System.Data.SqlClient;
using System.Data;
using CRUD_CONTACTO.Models;

namespace CRUD_CONTACTO.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar(string dato)
        {
            var oLista = new List<ContactoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                if (string.IsNullOrEmpty(dato))
                {
                    dato = "";
                }

                conexion.Open();
                SqlCommand cmd = new SqlCommand("pa_listarr", conexion);
                cmd.Parameters.AddWithValue("dato", dato);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    { 
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombres = dr["NOM_CON"].ToString(),
                            Apellidos = dr["APE_CON"].ToString(),
                            Telefono = dr["TEL_CON"].ToString(),
                            Correo = dr["MAIL_CON"].ToString()
                         });
                    }
                }
            }
            return oLista;
        }


        public ContactoModel Obtener(int idContacto)
        {
            var oContacto = new ContactoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("pa_Obtener", conexion);
                cmd.Parameters.AddWithValue("idcontacto", idContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombres = dr["NOM_CON"].ToString();
                        oContacto.Apellidos = dr["APE_CON"].ToString();
                        oContacto.Telefono = dr["TEL_CON"].ToString();
                        oContacto.Correo = dr["MAIL_CON"].ToString();
                    }
                }
            }
            return oContacto;
        }

        //Metodo para registrar un nuevo contacto
        public bool guardar (ContactoModel oContacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("pa_Registrar", conexion);
                    cmd.Parameters.AddWithValue("nombres", oContacto.Nombres);
                    cmd.Parameters.AddWithValue("apellidos", oContacto.Apellidos);
                    cmd.Parameters.AddWithValue("telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("mail", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        //Metodo para editar un contacto
        public bool editar(ContactoModel oContacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("pa_Editar", conexion);
                    cmd.Parameters.AddWithValue("idcontacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("nombres", oContacto.Nombres);
                    cmd.Parameters.AddWithValue("apellidos", oContacto.Apellidos);
                    cmd.Parameters.AddWithValue("telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("mail", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        //Metodo para eliminar un contacto
        public bool eliminar(int IdContacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("pa_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("idcontacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
