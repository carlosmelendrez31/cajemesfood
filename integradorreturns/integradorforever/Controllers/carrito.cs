using integradorforever.Datos;
using integradorforever.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace integradorforever.Controllers
{
    public class Carrito : Controller
    {
        Comprardatos _Comprardatos = new Comprardatos();

        
        private static List<carritomodel> carrito = new List<carritomodel>();

      

        public IActionResult Index()
        {
            
            var products = _Comprardatos.obtenerproducto();

            
            ViewBag.Carrito = carrito;

            return View(products);
        }

        [HttpPost]
        public IActionResult AñadirAlCarrito(int productId, int cantidad)
        {
            var products = _Comprardatos.obtenerproducto();
            var product = products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                var itemCarrito = carrito.FirstOrDefault(item => item.ProductId == productId);

                if (itemCarrito != null)
                {
                    itemCarrito.Cantidad += cantidad;
                }
                else
                {
                    carrito.Add(new carritomodel
                    {
                        ProductId = product.Id,
                        Nombre = product.Nombre,
                        Precio = product.Precio,
                        Cantidad = cantidad
                    });
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ComprarTodo()
        {
            foreach (var item in carrito)
            {
                _Comprardatos.comprarproducto(item.ProductId, item.Precio * item.Cantidad, item.Cantidad,item.Nombre);
            }

            carrito.Clear(); 

            return RedirectToAction("Gracias","Home");
        }
          public IActionResult Listarcompra()
        {
            var oLista = _Comprardatos.ListarCompras();
            return View(oLista);
        }
      
    }

}
