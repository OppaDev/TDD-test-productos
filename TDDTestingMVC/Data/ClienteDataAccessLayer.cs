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
                    cliente.Cedula = rdr["cedula"].ToString();
                    cliente.Apellidos = rdr["apellidos"].ToString();
                    cliente.Nombres = rdr["nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    cliente.Mail = rdr["mail"].ToString();
                    cliente.Telefono = rdr["telefono"].ToString();
                    cliente.Direccion = rdr["direccion"].ToString();
                    cliente.Estado = rdr["estado"].ToString();
                    listClientes.Add(cliente);


                }
                con.Close();                

            }
            return listClientes;
        }
        //Implemntar el metodo agregar cliente
        public void AddCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

    }
}
