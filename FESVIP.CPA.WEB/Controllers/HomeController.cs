using FESVIP.CPA.DATA.classes;
using FESVIP.CPA.DATA.classes.business;
using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FESVIP.CPA.WEB.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            int periodos = new CursoBO().QuantidadePeriodo(1);
           // List<Professor> profs = new ProfessorBO().PegarProfessoresDoPeriodo(1, 22,1);
            return View();
        }

    }
}
