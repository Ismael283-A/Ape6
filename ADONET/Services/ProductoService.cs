using ADONET.Models;
using ADONET.Repositories;

namespace ADONET.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _repo;



        public ProductoService(ProductoRepository repo)

        {

            _repo = repo;

        }



        public List<Producto> ObtenerTodos() => _repo.ObtenerTodos();

        public void Crear(Producto p) => _repo.Crear(p);

        public void Actualizar(Producto p) => _repo.Actualizar(p);

        public void Eliminar(int id) => _repo.Eliminar(id);
    }
}
