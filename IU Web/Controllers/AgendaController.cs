using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace IU_Web.Controllers
{
    public class AgendaController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                {
                    IEnumerable<Agenda> agendasAux = s.GetAgendas();
                    return View(agendasAux);
                }

                if (HttpContext.Session.GetString("LogueadoRol") == "Huesped")
                {
                    int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
                    List<Agenda> agendasAux = s.GetAgendasDeHuesped(idLogueado);
                    return View(agendasAux);
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Index(int numDocumento, TipoDoc slcTipo, DateTime dateAgenda, bool checkUnir)
        {
            if (checkUnir == true)
            {
                if(slcTipo != TipoDoc.Defecto)
                {
                    List<Agenda> AgendasPorFechaYDoc = s.GetAgendasPorDocumentoHuespedYFecha(numDocumento, slcTipo, dateAgenda);
                    return View(AgendasPorFechaYDoc);
                }
                else
                {
                    ViewBag.msg = "Ha habido un error.";
                    return View();
                }
            }
            else
            {
                if (numDocumento != 0 && slcTipo != TipoDoc.Defecto)
                {
                    List<Agenda> AgendasPorDoc = s.GetAgendasPorDocumentoHuesped(numDocumento, slcTipo);
                    return View(AgendasPorDoc);
                }
                else
                {
                    List<Agenda> AgendasPorFecha = s.GetAgendasPorFecha(dateAgenda);
                    return View(AgendasPorFecha);
                }
            }
        }

        

        public IActionResult Create(int? id)
        {
            if(HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    if(id != null && HttpContext.Session.GetString("LogueadoRol") != "Operador")
                    {
                        int? idLogueado = HttpContext.Session.GetInt32("LogueadoId");
                        Actividad actBuscada = s.GetActPorId(id);
                        Huesped? huespedEncontrado = s.GetHuespedPorId(idLogueado);

                        if (actBuscada.CupoDisponible > 0)
                        {
                            Agenda nuevaAgenda = new Agenda(huespedEncontrado, actBuscada);
                            nuevaAgenda.CerrarCosto();
                            nuevaAgenda.Estado = nuevaAgenda.GetEstado();
                            s.AltaAgenda(nuevaAgenda);
                            TempData["msg"] = "Agenda creada.";
                            return RedirectToAction("Index", "Actividad");
                        }
                        else
                        {
                            throw new Exception("No hay cupos disponibles.");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception e)
                {
                    TempData["msg"] = e.Message;
                }
            }
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Confirm(int? id)
        {


            if(id != null)
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    if (HttpContext.Session.GetString("LogueadoRol") == "Operador")
                    {
                        Agenda agendaEncontrada = s.GetAgendaPorId(id);
                        agendaEncontrada.Estado = "CONFIRMADA";
                        return RedirectToAction("Index", "Agenda");
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
            //        Agenda agendaEncontrada = s.GetAgendaPorId(id);
            //        agendaEncontrada.Estado = "CONFIRMADA";
            //        return RedirectToAction("Index", "Agenda");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //return RedirectToAction("Index", "Home");
        }
    }

}
 