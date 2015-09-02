using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FESVIP.CPA.WEB.Controllers
{
    public class CustomController : Controller
    {
        //
        // GET: /Custom/

        protected override void OnException(ExceptionContext filterContext)
        {
            
            ModelState.AddModelError("", filterContext.Exception.Message);
            
        }


    }
}
