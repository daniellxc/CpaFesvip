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
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
          //1513112379
          //26041968

            AcademicoMembership_Users u = new AcademicoMembership_UsersBO().GetUser("131315770", "1234");

            return View();
        }

    }
}
