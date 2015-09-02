using FESVIP.CPA.DATA.classes.business;
using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FESVIP.CPA.WEB.Controllers
{
    public class CpaController : Controller
    {
        private CpaBO DAO = new CpaBO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult CadastrarCpa(Cpa cpa)
        {
            if (!ModelState.IsValid) return View("Cadastro", cpa);

            try
            {
                DAO.SalvarCpa(cpa);
                cpa = null;
                
                return View("Index").ComMensagemDeSucesso();
            }
            catch (Exception ex)
            {
                return View("Cadastro", cpa).ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult ExcluirCpa(int codigoCpa)
        {
      
            try
            {
                DAO.ExcluirCpa(DAO.GetCpa(codigoCpa));
            
                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Index").ComMensagemDeErro(ex.Message);
            }
        }


        public ActionResult EditarCpa(int codigoCpa)
        {

            try
            {
                return View("Cadastro",DAO.GetCpa(codigoCpa));
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }


    }
}
