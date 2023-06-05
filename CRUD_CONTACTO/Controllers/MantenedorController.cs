using Microsoft.AspNetCore.Mvc;
using CRUD_CONTACTO.Datos;
using CRUD_CONTACTO.Models;

namespace CRUD_CONTACTO.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos cd = new ContactoDatos();
        public IActionResult Index(string? dato)
        {
            var oLista = cd.Listar(dato);
            return View(oLista);
        }


        [HttpGet]
        public IActionResult guardar()
        {
            //no devuelve ningun resultado
            return View();
        }
        [HttpPost]
        public IActionResult guardar(ContactoModel oContacto)
        {
            //Metodo que recibe el objeto para guardarlo en la BD
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = cd.guardar(oContacto);
            if(respuesta)
                return RedirectToAction("Index");
            else 
                return View();
        }
        public IActionResult editar(int IdContacto)
        {
            //Método que devolverá la vista
            var oContacto = cd.Obtener(IdContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult editar(ContactoModel oContacto)
        {
            //Metodo que recibe el objeto para editarlo en la BD
            //Metodo que recibe el objeto para guardarlo en la BD
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = cd.editar(oContacto);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return View();
        }
        public IActionResult eliminar(int IdContacto)
        {
            //Método que devolverá la vista
            var oContacto = cd.Obtener(IdContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult eliminar(ContactoModel oContacto)
        {
            //Metodo que recibe el objeto para eliminarlo en la BD
            var respuesta = cd.eliminar( oContacto.IdContacto);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return View();
        }
    }
}
