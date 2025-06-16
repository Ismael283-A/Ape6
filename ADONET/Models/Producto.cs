using System.ComponentModel.DataAnnotations;

namespace ADONET.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }



        [Required]  // Asegúrate de importar System.ComponentModel.DataAnnotations 

        public string NombreProducto { get; set; }



        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}
