using ADONET.Models;
using Microsoft.Data.SqlClient;
using ADONET.Data;

namespace ADONET.Repositories
{
    public class ProductoRepository
    {
        private readonly DbConnection _db;  // Campo privado para almacenar la conexión a la base de datos 

        // Constructor que recibe la instancia de DbConnection (usado para inyección de dependencias) 
        public ProductoRepository(DbConnection db)
        {
            _db = db;  // Asigna la conexión pasada al campo privado 
        }

        // Método para obtener todos los productos desde la base de datos 
        public List<Producto> ObtenerTodos()
        {
            var productos = new List<Producto>();  // Lista para guardar los productos recuperados 

            try
            {
                using var conn = _db.CreateConnection(); // Crea una nueva conexión usando la clase DbConnection 
                conn.Open();                             // Abre la conexión con la base de datos 

                // Consulta SQL para seleccionar columnas de la tabla Productos 
                var query = "SELECT IdProducto, NombreProducto, Precio, Stock FROM Productos";

                using var cmd = new SqlCommand(query, conn);         // Crea un comando SQL con la consulta 
                using var reader = cmd.ExecuteReader();              // Ejecuta la consulta y obtiene un lector de datos 

                // Lee cada fila devuelta por el lector 
                while (reader.Read())
                {
                    var producto = new Producto
                    {
                        IdProducto = reader.GetInt32(reader.GetOrdinal("IdProducto")), // Lee el ID como entero 
                        NombreProducto = reader["NombreProducto"].ToString(),          // Lee el nombre como string 
                        Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),       // Lee el precio como decimal 

                        Stock = reader.GetInt32(reader.GetOrdinal("Stock"))            // Lee el stock como entero 

                    };



                    productos.Add(producto);  // Agrega el producto a la lista 

                }



                Console.WriteLine($"[INFO] Productos encontrados: {productos.Count}"); // Imprime cuántos productos se encontraron 

            }

            catch (Exception ex)

            {

                Console.WriteLine("[ERROR] Fallo al obtener productos: " + ex.Message); // Muestra mensaje de error si algo falla 

            }



            return productos;  // Retorna la lista de productos obtenida 

        }



        // Método para insertar un nuevo producto en la base de datos 

        public void Crear(Producto producto)

        {

            try

            {

                using var conn = _db.CreateConnection();  // Crea una nueva conexión 

                conn.Open();                              // Abre la conexión 



                // Consulta SQL para insertar un nuevo producto con parámetros 

                var query = "INSERT INTO Productos (NombreProducto, Precio, Stock) VALUES (@nombre, @precio, @stock)";



                using var cmd = new SqlCommand(query, conn);  // Crea el comando SQL 



                // Agrega los parámetros al comando, evitando SQL Injection 

                cmd.Parameters.AddWithValue("@nombre", producto.NombreProducto);

                cmd.Parameters.AddWithValue("@precio", producto.Precio);

                cmd.Parameters.AddWithValue("@stock", producto.Stock);



                cmd.ExecuteNonQuery();  // Ejecuta la consulta sin esperar resultados (es una inserción) 



                Console.WriteLine("[INFO] Producto creado correctamente."); // Mensaje de éxito 

            }

            catch (Exception ex)

            {

                Console.WriteLine("[ERROR] Fallo al crear producto: " + ex.Message); // Muestra mensaje de error si falla 

            }

        }



        // Método para actualizar un producto existente 

        public void Actualizar(Producto producto)

        {

            try

            {

                using var conn = _db.CreateConnection();  // Crea la conexión 

                conn.Open();                              // Abre la conexión 



                // Consulta SQL para actualizar los campos de un producto por su ID 

                var query = "UPDATE Productos SET NombreProducto = @nombre, Precio = @precio, Stock = @stock WHERE IdProducto = @id";



                using var cmd = new SqlCommand(query, conn);  // Crea el comando 



                // Asigna los parámetros al comando 

                cmd.Parameters.AddWithValue("@nombre", producto.NombreProducto);

                cmd.Parameters.AddWithValue("@precio", producto.Precio);

                cmd.Parameters.AddWithValue("@stock", producto.Stock);

                cmd.Parameters.AddWithValue("@id", producto.IdProducto);



                cmd.ExecuteNonQuery();  // Ejecuta la consulta de actualización 



                Console.WriteLine("[INFO] Producto actualizado correctamente."); // Mensaje de éxito 

            }

            catch (Exception ex)

            {

                Console.WriteLine("[ERROR] Fallo al actualizar producto: " + ex.Message); // Muestra error 

            }

        }



        // Método para eliminar un producto de la base de datos por su ID 

        public void Eliminar(int id)

        {

            try

            {

                using var conn = _db.CreateConnection();  // Crea la conexión 

                conn.Open();                              // Abre la conexión 



                // Consulta SQL para eliminar un producto por ID 

                var query = "DELETE FROM Productos WHERE IdProducto = @id";



                using var cmd = new SqlCommand(query, conn);  // Crea el comando SQL 



                cmd.Parameters.AddWithValue("@id", id);  // Agrega el parámetro del ID a eliminar 



                cmd.ExecuteNonQuery();  // Ejecuta la consulta de eliminación 



                Console.WriteLine("[INFO] Producto eliminado correctamente."); // Mensaje de éxito 

            }

            catch (Exception ex)

            {

                Console.WriteLine("[ERROR] Fallo al eliminar producto: " + ex.Message); // Muestra mensaje de error 

            }

        }
    }
}
