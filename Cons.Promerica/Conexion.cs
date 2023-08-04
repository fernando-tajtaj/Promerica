namespace Cons.Promerica
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    internal class Conexion
    {
        public SqlConnection sqlConnection = new SqlConnection();

        public Conexion()
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Promerica"].ToString();
        }

        public void AbrirConexion()
        {
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un error al abrir la conexion {ex.Message}");
            }
        }

        public void CerrarConexion()
        {
            if (sqlConnection == null && sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                return;

            }

            sqlConnection.Close();
            sqlConnection.Dispose();
        }
    }
}
