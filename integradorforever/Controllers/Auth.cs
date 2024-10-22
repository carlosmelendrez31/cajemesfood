

using YourNamespace.Data;
using integradorforever.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace YourNamespace.Controllers
{
    public class AuthController : Controller
    {
        AuthDatos _AuthDatos = new AuthDatos();

        // GET: /Auth/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _AuthDatos.ObtenerNombreUsuario(model.Nombre);
                if (user != null && user.contrasena == model.contrasena)
                {
                    // Redirige a la página de Usuario
                    return RedirectToAction("Index", "Home");
                }

                // Verifica en la tabla Administrador si es necesario...
            }

            ModelState.AddModelError("", "Nombre de usuario o contraseña inválidos.");
            return View(model);
        }

        // Otros métodos...
    }
}
