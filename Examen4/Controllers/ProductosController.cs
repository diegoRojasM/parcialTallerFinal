// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Examen3.ServiceApp;

// namespace Examen3.Controllers
// {
//     [ApiController]
//     [Route("productos")] 

//     public class ProductosController : ControllerBase
//     {
//         private readonly AppDbContext _context;

//         public ProductosController(AppDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Productos
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
//         {
//             return new List<Producto>()
//             {
//                 new Producto(){Id=1,Nombre="nombre",Descripcion="descripcion",Precio=12.5M,Categoria="categoria",Stock=5}
//             };
//             //return await _context.Productos.ToListAsync();
//         }

//         // GET: api/Productos/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Producto>> GetProducto(int id)
//         {
//             var producto = await _context.Productos.FindAsync(id);

//             if (producto == null)
//             {
//                 return NotFound();
//             }

//             return producto;
//         }

//         // PUT: api/Productos/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutProducto(int id, Producto producto)
//         {
//             if (id != producto.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(producto).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!ProductoExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/Productos
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<Producto>> PostProducto(Producto producto)
//         {
//             _context.Productos.Add(producto);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
//         }

//         // DELETE: api/Productos/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteProducto(int id)
//         {
//             var producto = await _context.Productos.FindAsync(id);
//             if (producto == null)
//             {
//                 return NotFound();
//             }

//             _context.Productos.Remove(producto);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool ProductoExists(int id)
//         {
//             return _context.Productos.Any(e => e.Id == id);
//         }
//     }
// }

using Examen3.ServiceApp;
using Microsoft.AspNetCore.Mvc;
using SPA.ServicesApp;

namespace SPA.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService productoService)
        {
            _service = productoService;
        }

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _service.GetById(id);

            if (producto == null)
                return NotFound();

            return producto;
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            var newProduct = _service.Create(producto);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Producto producto)
        {
            if (id != producto.Id)
                return BadRequest();

            var productToUpdate = _service.GetById(id);
            if (productToUpdate != null)
            {
                _service.Update(id, producto);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productToDelete = _service.GetById(id);
            if (productToDelete != null)
            {
                _service.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
