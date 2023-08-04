namespace Cons.Promerica
{
    using System;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            ControllerProducto controllerProducto = new ControllerProducto();

            ///[Inicio][Consulta Productos][Se encarga de la consulta de productos, retorna un dataset.
            DataSet dsProductos = controllerProducto.ObtenerProducto();

            if (dsProductos != null && dsProductos.Tables[0].Rows.Count > 0)
            {
                Console.WriteLine(dsProductos.ToStringDataSet());
            }
            ///[Fin][Consulta Productos]


            ///[Inicio][Insercion Productos][Se encarga de insertar un producto a la base de datos]
            int registrosInsertados = controllerProducto.AgregarProducto("TEXTO");
            Console.WriteLine($"Registros Insertados = : {registrosInsertados}");
            ///[Fin][Insercion Productos]

            ///[Inicio][Actualizacion Productos][Se encarga de actualizar un producto existente en base de datos]
            int registrosActualizados = controllerProducto.ActualizarProducto("TEXTO", 1);
            Console.WriteLine($"Registros Actualizados = : {registrosActualizados}");
            ///[Fin][Actualizacion Productos]

            ///[Inicio][Eliminacion Productos][Se encarga de eliminar un producto existente en base de datos]
            int registrosEliminados = controllerProducto.EliminarProducto(5);
            Console.WriteLine($"Registros Eliminados = : {registrosEliminados}");
            ///[Fin][Eliminacion Productos]

            Console.ReadLine();
        }
    }
}
