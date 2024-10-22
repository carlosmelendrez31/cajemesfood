using Microsoft.AspNetCore.Mvc;
using integradorforever.Datos;
using integradorforever.Models;
namespace proyectoint.Controllers
{
    public class MantenedorController : Controller
    {
        Usuariodatos _Usuariodatos = new Usuariodatos();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oLista = _Usuariodatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Usuariomodel ousuario)
        {
            var respuesta = _Usuariodatos.Guardar(ousuario);
            if (respuesta)

                return RedirectToAction("Index", "Home");


            else

                return View();



        }
        public IActionResult Editar(int id_usuario)
        {
            var ousuario = _Usuariodatos.Obtener(id_usuario);
            return View(ousuario);
        }
        [HttpPost]
        public IActionResult Editar(Usuariomodel ousuario)
        {
            if (!ModelState.IsValid)
                return View();

            var repuesta = _Usuariodatos.Editar(ousuario);
            if (repuesta)
                return RedirectToAction("Listar");
            else
                return View();
            
        }
        public IActionResult Eliminar(int id_usuario)
        {
            var ousuario = _Usuariodatos.Obtener(id_usuario);
            return View(ousuario);
        }
        [HttpPost]
        public IActionResult Eliminar(Usuariomodel ousuario)
        {
            if (!ModelState.IsValid)
                return View();

            var repuesta = _Usuariodatos.Eliminar(ousuario.id_usuario);
            if (repuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }
    }
}
