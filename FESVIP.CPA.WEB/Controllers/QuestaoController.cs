using FESVIP.CPA.DATA.classes.business;
using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FESVIP.CPA.WEB.Controllers
{
    public class QuestaoController : Controller
    {
        //
        // GET: /Questao/

        QuestaoBO DAO = new QuestaoBO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroQuestao()
        {
            return View();
        }

        public ActionResult CadastrarQuestao(Questao questao)
        {
            if (!ModelState.IsValid) return View("CadastroQuestao", questao);

            try
            {
                DAO.SalvarCpa(questao);
                return View("Index").ComMensagemDeSucesso();
            }
            catch (Exception ex)
            {

                return View("CadastroQuestao", questao).ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult EditarQuestao(int codigoQuestao)
        {
            return View("CadastroQuestao", DAO.GetQuestao(codigoQuestao));
        }

        public ActionResult ExcluirQuestao(int codigoQuestao)
        {
            try
            {
                DAO.ExcluirQuestao(DAO.GetQuestao(codigoQuestao));
                return View("Index");
            }
            catch (Exception ex)
            {
               
                return View("Index").ComMensagemDeErro(ex.Message);
            }
        }

    }
}
