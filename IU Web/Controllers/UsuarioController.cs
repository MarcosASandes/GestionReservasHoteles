using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace IU_Web.Controllers
{
    public class UsuarioController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Huesped")
                {
                    int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
                    Huesped huespedEncontrado = s.GetHuespedPorId(idLogueado);

                    if (HttpContext.Session.GetInt32("LogueadoId") == idLogueado)
                    {
                        return View(huespedEncontrado);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
                    Operador operadorEncontrado = s.GetOperadorPorId(idLogueado);
                    if (HttpContext.Session.GetInt32("LogueadoId") == idLogueado)
                    {
                        ViewBag.Op = operadorEncontrado;
                        return View();
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        //Create de huesped, porque operador no necesita crearse, son precargados directamente.
        public IActionResult AltaHuesped()
        {
            if(HttpContext.Session.GetInt32("LogueadoId") == null)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AltaHuesped(Huesped unHuesped)
        {
            try
            {
                s.AltaHuesped(unHuesped);
                ViewBag.msg = "Alta correcta";
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
    }
}
