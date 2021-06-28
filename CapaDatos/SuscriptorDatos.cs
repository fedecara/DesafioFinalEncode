using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{


    public class SuscriptorDatos
    {
        SqlConnection cnx;
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        
        public SuscriptorDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }
        public bool InsertarSuscriptor(CapaEntidades.Suscriptor sus)
        {
            bool vexito = false;
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_insertar";
            try
            {
                
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50));
                cmd.Parameters["@Nombre"].Value = sus.Nombre;
                cmd.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar, 100));
                cmd.Parameters["@Apellido"].Value = sus.Apellido;
                cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", SqlDbType.BigInt));
                cmd.Parameters["@NumeroDocumento"].Value = sus.NumeroDocumento;
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", SqlDbType.Int));
                cmd.Parameters["@TipoDocumento"].Value = sus.TipoDocumento;
                cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 100));
                cmd.Parameters["@Direccion"].Value = sus.Direccion;
                cmd.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 100));
                cmd.Parameters["@Telefono"].Value = sus.Telefono;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100));
                cmd.Parameters["@Email"].Value = sus.Email;
                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar, 100));
                cmd.Parameters["@NombreUsuario"].Value = sus.NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 100));
                cmd.Parameters["@Password"].Value = sus.Password;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }


        public bool InsertarSuscripcion(CapaEntidades.Suscriptor sus, string FechaAlta)
        {
            bool vexito = false;
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_insertar_Suscripcion";
            try
            {

                cmd.Parameters.Add(new SqlParameter("@IdSuscriptor", SqlDbType.VarChar, 50));
                cmd.Parameters["@IdSuscriptor"].Value = sus.IdSuscriptor;
                cmd.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.VarChar, 50));
                cmd.Parameters["@FechaAlta"].Value = FechaAlta;

                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;

            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }

        public bool ActualizarSuscriptor(CapaEntidades.Suscriptor sus)
        {
            bool vexito = true;
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_actualizar";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50));
                cmd.Parameters["@Nombre"].Value = sus.Nombre;
                cmd.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar, 100));
                cmd.Parameters["@Apellido"].Value = sus.Apellido;
                cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 100));
                cmd.Parameters["@Direccion"].Value = sus.Direccion;
                cmd.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 100));
                cmd.Parameters["@Telefono"].Value = sus.Telefono;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100));
                cmd.Parameters["@Email"].Value = sus.Email;
                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar, 100));
                cmd.Parameters["@NombreUsuario"].Value = sus.NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 100));
                cmd.Parameters["@Password"].Value = sus.Password;
                cmd.Parameters.Add(new SqlParameter("@IdSuscriptor", SqlDbType.Int));
                cmd.Parameters["@IdSuscriptor"].Value = sus.IdSuscriptor;



                cnx.Open();
                cmd.ExecuteNonQuery();
              
            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }

        
        public CapaEntidades.Suscriptor ConsultarSuscriptor(int TipoDocumento, long NumeroDocumento)
        {
            CapaEntidades.Suscriptor SuscriptorBD = null;
            try
            {
                SuscriptorBD = new CapaEntidades.Suscriptor();
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_consultar";
                cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", SqlDbType.BigInt));
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", SqlDbType.Int));
                cmd.Parameters["@NumeroDocumento"].Value = NumeroDocumento;
                cmd.Parameters["@TipoDocumento"].Value = TipoDocumento;
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    SuscriptorBD.IdSuscriptor = int.Parse(Convert.ToString(dtr["IdSuscriptor"]));
                    SuscriptorBD.Nombre = Convert.ToString(dtr["Nombre"]);
                    SuscriptorBD.Apellido = Convert.ToString(dtr["Apellido"]);
                    SuscriptorBD.Direccion = Convert.ToString(dtr["Direccion"]);
                    SuscriptorBD.Email = Convert.ToString(dtr["Email"]);
                    SuscriptorBD.Telefono = Convert.ToString(dtr["Telefono"]);
                    SuscriptorBD.NombreUsuario = Convert.ToString(dtr["NombreUsuario"]);
                    SuscriptorBD.Password = Convert.ToString(dtr["Password"]);
                }
                cnx.Close();
                cmd.Parameters.Clear();
                
            }
            catch (SqlException)
            {
                throw new Exception();
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return SuscriptorBD;
        }


        public bool ExisteSuscriptor(CapaEntidades.Suscriptor sus)
        {
            bool vexito = false;
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_ExisteBD";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", SqlDbType.BigInt));
                cmd.Parameters["@NumeroDocumento"].Value = sus.NumeroDocumento;
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", SqlDbType.Int));
                cmd.Parameters["@TipoDocumento"].Value = sus.TipoDocumento;
              


                cnx.Open();
                cmd.ExecuteNonQuery();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    vexito = false;
                }
                else
                {
                    vexito = true;
                }


            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }

        public bool ExisteSuscripcion(CapaEntidades.Suscriptor sus)
        {
            bool vexito = false;
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_ExisteSuscripcion";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@IdSuscriptor", SqlDbType.Int));
                cmd.Parameters["@IdSuscriptor"].Value = sus.IdSuscriptor;

                cnx.Open();
                cmd.ExecuteNonQuery();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                
                if (count == 0)
                {
                    vexito = false;
                }
                else
                {
                    vexito = true;
                }


            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }

        public List<CapaEntidades.Suscriptor> ListarSuscriptor()
        {
            CapaEntidades.Suscriptor SuscriptorBD = null;
            CapaEntidades.Suscripcion SuscripcionBD = null;
            List<Suscriptor> lista = new List<Suscriptor>();
            try
            {
                SuscriptorBD = new CapaEntidades.Suscriptor();
                SuscripcionBD = new CapaEntidades.Suscripcion();
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_ListarSuscriptores";
            
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    SuscriptorBD.IdSuscriptor = int.Parse(Convert.ToString(dtr["IdSuscriptor"]));
                    SuscriptorBD.Nombre = Convert.ToString(dtr["Nombre"]);
                    SuscriptorBD.Apellido = Convert.ToString(dtr["Apellido"]);
                    SuscriptorBD.NumeroDocumento = int.Parse(Convert.ToString(dtr["NumeroDocumento"]));
                    SuscripcionBD.FechaAlta = Convert.ToString(dtr["FechaAlta"]);
                    lista.Add(SuscriptorBD);
                 
                }
                cnx.Close();
                cmd.Parameters.Clear();

            }
            catch (SqlException)
            {
                throw new Exception();
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return lista;
        }




    }


}

