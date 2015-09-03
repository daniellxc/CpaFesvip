using FESVIP.CPA.DATA.classes.business;
using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FESVIP.CPA.WEB.Controllers
{
   
    public class FormularioController : Controller
    {
        //
        // GET: /Formulario/
        FormularioBO DAO = new FormularioBO();
         [Authorize]
        public ActionResult Index()
        {
            return View();
        }
         [Authorize]
        public ActionResult CadastroFormulario()
        {
            return View();
        }

        public ActionResult MontarQuestionario(int registroFormulario)
        {
            try
            {
                Formulario form = DAO.GetFormulario(registroFormulario);
                if (DateTime.Now >= form.FK_Cpa.DataInicio && DateTime.Now <= form.FK_Cpa.DataFim)
                    return View(DAO.GetFormulario(registroFormulario));
                throw new Exception("Sistema fora do período de avaliação.");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Avaliacao").ComMensagemDeErro(ex.Message);
            }
        }

         [Authorize]
        public ActionResult CadastrarFormulario(Formulario formulario)
        {
            if (!ModelState.IsValid) return View("CadastroFormulario", formulario);

            try
            {
                DAO.SalvarFormulario(formulario);
                return View("Index").ComMensagemDeSucesso();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return View("CadastroFormulario", formulario).ComMensagemDeErro(ex.Message);
            }
        }
         [Authorize]
        public ActionResult EditarFormulario(int codigoFormulario)
        {
            return View("CadastroFormulario", DAO.GetFormulario(codigoFormulario));
        }
         [Authorize]
        public ActionResult ExcluirFormulario(int codigoFormulario)
        {
            try
            {
                DAO.ExcluirFormulario(DAO.GetFormulario(codigoFormulario));
                return View("Index");
            }
            catch (Exception ex)
            {
               
                return View("Index").ComMensagemDeErro(ex.Message);
            }
        }
         [Authorize]
        public ActionResult GerenciarQuestoes(int codigoFormulario)
        {
            return View(DAO.GetFormulario(codigoFormulario));
        }
         [Authorize]
        public ActionResult AddQuestaoFormulario(int codigoQuestao, int codigoFormulario)
        {
            try
            {
                DAO.AdicionarQuestaoAoFormulario(codigoQuestao, codigoFormulario);
                return View("GerenciarQuestoes", DAO.GetFormulario(codigoFormulario));
            }
            catch (Exception ex)
            {
                return View("GerenciarQuestoes", DAO.GetFormulario(codigoFormulario)).ComMensagemDeErro(ex.Message);
            }
        }
         [Authorize]
        public ActionResult RemoverQuestaoFormulario(int codigoQuestao, int codigoFormulario)
        {
            try
            {
                DAO.RemoverQuestaoDoFormulario(codigoQuestao, codigoFormulario);
                return View("GerenciarQuestoes", DAO.GetFormulario(codigoFormulario));
            }
            catch (Exception ex)
            {
                return View("GerenciarQuestoes", DAO.GetFormulario(codigoFormulario)).ComMensagemDeErro(ex.Message);
            }
        }

        public JsonResult GetProfessoresCursoPeriodo(int idCurso, int idPeriodo, int periodo)
        {
            List<Professor> lista = new ProfessorBO().PegarProfessoresDoPeriodo(idCurso, idPeriodo,periodo);

            foreach(int i in ((ArrayList)Session["avaliados"]))
            {
                Professor p = lista.Find(pr=>pr.Codigo == i);

                lista.Remove(p);
            }
            return Json(new SelectList(lista, "Codigo", "Nome"));

        }

        public JsonResult GetPeriodosCurso(int idCurso)
        {
            int max = new CursoBO().QuantidadePeriodo(idCurso);

            int[] periodos = new int[max];
            for (int i = 0; i < max; i++)
                periodos[i] = i+1;

            return Json(new SelectList(periodos));
        }



    }
}
