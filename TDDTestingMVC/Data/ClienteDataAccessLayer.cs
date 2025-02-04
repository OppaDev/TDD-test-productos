using System.Data.SqlClient;
using TDDTestingMVC.Models;

namespace TDDTestingMVC.Data
{
    public class ClienteDataAccessLayer
    {
        // cadena de connecion 
        string connectionString = "Data Source=OPPADEV; Initial Catalog=dbproducto; Integrated Security=True; User ID=sa; Password=admin";
        public List<Cliente> GetClientes()
        {
            List<Cliente> list = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(rdr["Codigo"]);
                    cliente.Cedula = rdr["Cedula"].ToString();
                    cliente.Apellidos = rdr["Apellidos"].ToString();
                    cliente.Nombres = rdr["Nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    cliente.Mail = rdr["Mail"].ToString();
                    cliente.Telefono = rdr["Telefono"].ToString();
                    cliente.Direccion = rdr["Direccion"].ToString();
                    cliente.Estado = Convert.ToBoolean(rdr["Estado"]);
                    list.Add(cliente);
                }

                con.Close();
            }
            return list;
        }
    }
}
