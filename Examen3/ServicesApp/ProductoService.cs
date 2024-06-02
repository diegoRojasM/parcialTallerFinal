using Examen3.ServiceApp;
using System.Collections.Generic;
using System.Linq;

namespace SPA.ServicesApp
{
    public class ProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public ProductoService()
        {
        }

        // Obtener todos los productos
        public IEnumerable<Producto> GetAll()
        {
            return _context.Productos.ToList();
        }

        // Obtener producto por ID
        public Producto? GetById(int id)
        {
            return _context.Productos?.Find(id);
        }

        // Crear un nuevo producto
        public Producto Create(Producto newProducto)
        {
            _context.Productos?.Add(newProducto);
            _context.SaveChanges(); // Guardar cambios en la base de datos

            return newProducto;
        }

        // Actualizar un producto existente
        public void Update(int id, Producto producto)
        {
            var existingProduct = GetById(id);

            if (existingProduct != null)
            {
                existingProduct.Nombre = producto.Nombre;
                existingProduct.Descripcion = producto.Descripcion;
                existingProduct.Precio = producto.Precio;
                existingProduct.Categoria = producto.Categoria;
                existingProduct.Stock = producto.Stock;

                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
        }

        // Eliminar un producto por ID
        public void Delete(int id)
        {
            var productToDelete = GetById(id);

            if (productToDelete != null)
            {
                _context.Productos?.Remove(productToDelete);
                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
        }
    }
}
