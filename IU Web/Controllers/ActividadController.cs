using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace IU_Web.Controllers
{
    public class ActividadController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            IEnumerable<Actividad> actAux = s.GetActividadesDeHoy();
            //IEnumerable<Actividad> actAux = s.GetActividades();
            return View(actAux);
        }

        [HttpPost]
        public IActionResult Index(DateTime dateActividades)
        {
            List<Actividad> actividadesConFiltro = s.GetActividadesConFltroDate(dateActividades);

            return View(actividadesConFiltro);
        }




        public IActionResult Details(int? id)
        {
            if(id != null)
            {
                Actividad actBuscada = s.GetActPorId(id);
                return View(actBuscada);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
