using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace IU_Web.Controllers
{
    public class ProveedorController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if(HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    IEnumerable<Proveedor> proveedoresLista = s.GetProveedores();
                    return View(proveedoresLista);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Update(int? id)
        {

            if(id != null)
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                    {
                        int? idProv = id;
                        ViewBag.NombreProv = s.GetNombreProvPorId(idProv);
                        ViewBag.ProvId = idProv;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            //if(HttpContext.Session.GetInt32("LogueadoId") != null)
            //{
            //    if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
            //    {
            //        int? idProv = id;
            //        ViewBag.NombreProv = s.GetNombreProvPorId(idProv);
            //        ViewBag.ProvId = idProv;
            //        return View();
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Update(int? idProv, double numDescuento)
        {
            if(idProv != null)
            {
                try
                {
                    if (idProv != null)
                    {
                        Proveedor unProv = s.GetProvForID(idProv);
                        s.SetValorPromocion(unProv, numDescuento);
                        ViewBag.msg = "Descuento modificado correctamente.";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;
                }
                return View();
            }
            return RedirectToAction("Index", "Home");

            //try
            //{
            //    Proveedor unProv = s.GetProvForID(idProv);
            //    s.SetValorPromocion(unProv, numDescuento);
            //    ViewBag.msg = "Descuento modificado correctamente.";
            //}
            //catch (Exception e)
            //{
            //    ViewBag.msg = e.Message;
            //}
            //return View();
        }


    }
}
