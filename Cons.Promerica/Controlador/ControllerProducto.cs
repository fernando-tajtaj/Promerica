namespace Cons.Promerica.Controlador
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    internal class ControllerProducto
    {
        /// <summary>
        /// Metodo que se encarga de consultar todos los productos que estan en la tabla productos de base de datos
        /// </summary>
        /// <returns>El listado de productos</returns>
        public DataSet ObtenerProducto()
        {
            DataSet dsProductos = new DataSet();
            Conexion conexion = new Conexion();
            conexion.AbrirConexion();

            SqlCommand consulta = new SqlCommand("SELECT ProductoId, Descripcion FROM Producto", conexion.sqlConnection);

            using (SqlDataReader consultaProducto = consulta.ExecuteReader())
            {
                if (consultaProducto.HasRows)
                {
                    dsProductos.Tables.Add("Productos");
                    dsProductos.Tables[0].Load(consultaProducto);
                }
            }
            conexion.CerrarConexion();

            return dsProductos;
        }

        /// <summary>
        /// Metodo que se encargara de agregar un registro en la tabla producto
        /// </summary>
        /// <param name="descripcion">Valor de columna descripcion</param>
        /// <returns>La cantidad de filas insertadas</returns>
        /// <exception cref="Exception">Indica que ocurrio un error al intentar agregar el registro</exception>
        public int AgregarProducto(string descripcion)
        {
            int registrosInsertados = 0;

            Conexion conexion = new Conexion();
            conexion.AbrirConexion();

            string agregarProducto = $"INSERT INTO Producto(Descripcion) VALUES ('{descripcion}')";
            SqlCommand comando = new SqlCommand(agregarProducto, conexion.sqlConnection);

            conexion.CerrarConexion();

            if (!int.TryParse(comando.ExecuteNonQuery().ToString(), out registrosInsertados))
            {
                throw new Exception("Ocurrio un error, no se inserto el registro");
            }

            return registrosInsertados;
        }

        /// <summary>
        /// Metodo que se encargara de actualizar un registro en la tabla producto
        /// </summary>
        /// <param name="productoId">Id de producto/registro a actualizar</param>
        /// <returns>La cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Indica que ocurrio un error al intentar actualizar el registro</exception>
        public int ActualizarProducto(string pDescripcion, int pIdProducto)
        {
            int registrosActualizados = 0;

            Conexion conexion = new Conexion();
            conexion.AbrirConexion();

            string actualizarProducto = $"UPDATE Producto SET Descripcion = '{pDescripcion}' WHERE ProductoId = {pIdProducto}";
            SqlCommand comando = new SqlCommand(actualizarProducto, conexion.sqlConnection);

            conexion.CerrarConexion();

            if (!int.TryParse(comando.ExecuteNonQuery().ToString(), out registrosActualizados))
            {
                throw new Exception("Ocurrio un error, no se actualizo el registro");
            }

            return registrosActualizados;
        }

        /// <summary>
        /// Metodo que se encargara de eliminar un registro en la tabla producto
        /// </summary>
        /// <param name="productoId">Id de producto/registro a eliminar</param>
        /// <returns>La cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Indica que ocurrio un error al intentar eliminar el registro</exception>
        public int EliminarProducto(int pIdProducto)
        {
            int registrosEliminados = 0;

            Conexion conexion = new Conexion();
            conexion.AbrirConexion();

            string eliminarProducto = $"DELETE FROM Producto WHERE ProductoId = {pIdProducto}";
            SqlCommand comando = new SqlCommand(eliminarProducto, conexion.sqlConnection);

            conexion.CerrarConexion();

            if (!int.TryParse(comando.ExecuteNonQuery().ToString(), out registrosEliminados))
            {
                throw new Exception("Ocurrio un error, no se elimino el registro");
            }

            return registrosEliminados;
        }
    }
}
