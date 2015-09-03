using FESVIP.CPA.DATA.classes.business;
using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FESVIP.CPA.WEB.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signin(string login, string senha)
        {
            try
            {
                AcademicoMembership_Users usr = VerificarLogin(login, senha);
                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(usr.Username.ToString(), false);
                    return RedirectToAction("Index", "Home", new { area = "" });

                }

            }
            catch (Exception ex)
            {
                ViewBag.LoginErr = ex.Message;

            }

            return View("Login");
        }

        public AcademicoMembership_Users VerificarLogin(string login, string senha)
        {
            AcademicoMembership_Users usr = new AcademicoMembership_UsersBO().GetUser(login, senha);

            if (usr != null)
            {
               
                    return usr;
            }
                else
                    throw new Exception("Usuário inválido");
            
           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return View("Login");

        }

    }
}
