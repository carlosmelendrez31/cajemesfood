using integradorforever.Datos;
using Microsoft.AspNetCore.Mvc;

namespace integradorforever.Controllers
{
    public class producto : Controller
    {
        Comprardatos _Comprardatos = new Comprardatos();

        public IActionResult Index()
        {
            var products = _Comprardatos.obtenerproducto();
            return View(products);
        }

        [HttpPost]
        public IActionResult Comprar(string Nombre, int productId, int total, int cantidad)
        {
            var result = _Comprardatos.comprarproducto(productId, total , cantidad,Nombre);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Puedes agregar un mensaje de error aquí si lo deseas
                return View("Error"); // Asegúrate de tener una vista "Error" si decides redirigir allí
            }
        }
    }
}

