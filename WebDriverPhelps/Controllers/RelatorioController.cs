using Microsoft.AspNetCore.Mvc;
using WebDriverPhelps.Repository;

namespace WebDriverPhelps.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ISeleniumWeb _seleniumWeb;

        public RelatorioController(ISeleniumWeb seleniumWeb)
        {
            _seleniumWeb = seleniumWeb;
        }

        public IActionResult Index()
        {
            var ars = _seleniumWeb.BuscarTodos();
            return View(ars);
        }

        public IActionResult ExtrairPlanilha(int arId, DateTime dataini, DateTime datafim)
        {
            try
            {
                _seleniumWeb.ExtrairRelatorioIndividual(arId, dataini, datafim);
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

        public IActionResult ExtrairPlanilhaPorAC(int arId, DateTime dataini, DateTime datafim)
        {
            try
            {
                _seleniumWeb.RelatorioCompletoPorAC(arId, dataini, datafim);
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

    }
}
