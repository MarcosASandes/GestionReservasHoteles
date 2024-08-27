using Dominio;
using IU_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IU_Web.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.Instancia;

        public IActionResult Index()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
            string? nombreLogueado = HttpContext.Session.GetString("LogueadoNombre");

            if (idLogueado != null)
            {
                ViewBag.MensajeBienvenida = $"Bienvenido {nombreLogueado}, ingreso correcto";
            }
            else
            {
                ViewBag.MensajeBienvenida = "Por favor inicie sesion o registrese.";
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") == null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Login(string correo, string clave)
        {
            //if (HttpContext.Session.GetInt32("LogueadoId") == null)
            //{
            //    Usuario usBuscado = s.Login(correo, clave);
            //    if (usBuscado != null)
            //    {
            //        HttpContext.Session.SetInt32("LogueadoId", usBuscado.Id);
            //        HttpContext.Session.SetString("LogueadoRol", usBuscado.GetTipo());
            //        if (usBuscado.GetTipo() == "Huesped")
            //        {
            //            Huesped aux = usBuscado as Huesped;
            //            HttpContext.Session.SetString("LogueadoNombre", aux.Nombre);
            //        }
            //        else if (usBuscado.GetTipo() == "Operador")
            //        {
            //            Operador aux = usBuscado as Operador;
            //            HttpContext.Session.SetString("LogueadoNombre", aux.Nombre);
            //        }

            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        ViewBag.msg = "Datos incorrectos";
            //        return View();
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}

            Usuario usBuscado = s.Login(correo, clave);
            if (usBuscado != null)
            {
                HttpContext.Session.SetInt32("LogueadoId", usBuscado.Id);
                HttpContext.Session.SetString("LogueadoRol", usBuscado.GetTipo());
                if (usBuscado.GetTipo() == "Huesped")
                {
                    Huesped aux = usBuscado as Huesped;
                    HttpContext.Session.SetString("LogueadoNombre", aux.Nombre);
                }
                else if (usBuscado.GetTipo() == "Operador")
                {
                    Operador aux = usBuscado as Operador;
                    HttpContext.Session.SetString("LogueadoNombre", aux.Nombre);
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Datos incorrectos";
                return View();
            }
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index");
        }


    }
}