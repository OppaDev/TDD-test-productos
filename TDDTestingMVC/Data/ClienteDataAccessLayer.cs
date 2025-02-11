using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace TDDTestingMVC.data
{
    public class ClienteDataAccessLayer
    {
        string connectionString = "Server=OPPADEV; database=DBProductos; User ID=sa; Password=admin; TrustServerCertificate=true; MultipleActiveResultSets=True";

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> listClientes = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(rdr["codigo"]);
                    cliente.Cedula = rdr["cedula"]?.ToString() ?? string.Empty;
                    cliente.Apellidos = rdr["apellidos"]?.ToString() ?? string.Empty;
                    cliente.Nombres = rdr["nombres"]?.ToString() ?? string.Empty;
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    cliente.Mail = rdr["mail"]?.ToString() ?? string.Empty;
                    cliente.Telefono = rdr["telefono"]?.ToString() ?? string.Empty;
                    cliente.Direccion = rdr["direccion"]?.ToString() ?? string.Empty;
                    cliente.Estado = rdr["estado"]?.ToString() ?? string.Empty;
                    listClientes.Add(cliente);
                }
                con.Close();
            }
            return listClientes;
        }

        public void AddCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Cliente GetClienteData(int? id)
        {
            Cliente cliente = new Cliente();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Cliente WHERE Codigo= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cliente.Codigo = Convert.ToInt32(rdr["codigo"]);
                    cliente.Cedula = rdr["cedula"]?.ToString() ?? string.Empty;
                    cliente.Apellidos = rdr["apellidos"]?.ToString() ?? string.Empty;
                    cliente.Nombres = rdr["nombres"]?.ToString() ?? string.Empty;
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    cliente.Mail = rdr["mail"]?.ToString() ?? string.Empty;
                    cliente.Telefono = rdr["telefono"]?.ToString() ?? string.Empty;
                    cliente.Direccion = rdr["direccion"]?.ToString() ?? string.Empty;
                    cliente.Estado = rdr["estado"]?.ToString() ?? string.Empty;
                }
                con.Close();
            }
            return cliente;
        }

        public void UpdateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteCliente(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
