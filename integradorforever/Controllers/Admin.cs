using Microsoft.AspNetCore.Mvc;
using integradorforever.Datos;
using integradorforever.Models;
using NuGet.Protocol.Core.Types;
using YourNamespace.Data;


namespace integradorforever.Controllers
{
    public class Admin : Controller
    {
        Admindatos _Admindatos = new Admindatos();
       AuthDatos _AuthDatos = new AuthDatos();
        
        public IActionResult Listaradmin()
        {
            var uLista = _Admindatos.ListarADMIN();
            return View(uLista);
        }

        public IActionResult Guardaradmin()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Guardaradmin(Adminmodel oadmin)
        {
            var respuesta = _Admindatos.GuardarADMIN(oadmin);
                if (respuesta)
                return RedirectToAction("Listaradmin");

                else
                return View();
        }
        public IActionResult Editaradmin(int Matricula)
        {
            var oadmin = _Admindatos.ObtenerADMIN(Matricula);
            return View(oadmin);
        }
        [HttpPost]
        public IActionResult Editaradmin (Adminmodel oadmin)
        {
            if(!ModelState.IsValid)
                return View();

            var respuesta = _Admindatos.EditarADMIN(oadmin);
                if (respuesta)
                return RedirectToAction("Listaradmin");
                else
                return View();
        }

        public IActionResult EliminarADMIN(int Matricula)
        {
            var oadmin = _Admindatos.ObtenerADMIN (Matricula);
            return View(oadmin);
        }
        [HttpPost]
        public IActionResult EliminarADMIN(Adminmodel oadmin)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _Admindatos.EliminarADMINS(oadmin.Matricula);
            if (respuesta)
                return RedirectToAction("Listaradmin");
            else
                return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _AuthDatos.obtenerAdmini(model.Nombre);
                if (admin != null && admin.contrasena == model.contrasena)
                {
                    // Redirige a la página de Administrador
                    return RedirectToAction("Index", "Mantenedor");
                }

                ModelState.AddModelError("", "Nombre de administrador o contraseña inválidos.");
            }

            return View(model);
        }

        // GET: /Admin/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        public IActionResult usuarioviews () 
       
            {
            return View();
            }
}
}
