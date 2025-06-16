using ADONET.Models;
using ADONET.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADONET.Controllers
{
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.ObtenerTodos());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Producto p)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _service.Crear(p);
            return Ok("Producto creado.");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Producto p)
        {
            _service.Actualizar(p);
            return Ok("Producto actualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Eliminar(id);
            return Ok("Producto eliminado.");
        }
    }
}
