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
    public class AvaliacaoController : Controller
    {
        //
        // GET: /Avaliacao/

        public AvaliacaoBO DAO = new AvaliacaoBO(); 

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult RegistrarAvaliacao(int codFormulario, List<int> codQuestao, List<int> nota, int? entidade)
        {
            try
            {
                bool redirect = !entidade.HasValue;
                Formulario form = new FormularioBO().GetFormulario(codFormulario);
                if (form.FK_TipoFormulario.CodInterno.ToLower() == "aluno_av_prof")
                    (Session["avaliados"] as ArrayList).Add(entidade);

                Avaliacao avl;
                for (int i = 0; i < codQuestao.Count; i++)
                {
                    avl = new Avaliacao();
                    avl.DataAvaliacao = DateTime.Now;
                    avl.FORMULARIO = codFormulario;
                    avl.IdSessao = Session.LCID.ToString();
                    avl.Nota = nota[i];
                    avl.QUESTAO = codQuestao[i];
                    avl.EntidadeAvaliada = entidade.ToString();
                    
                    DAO.SalvarAvaliacao(avl);



                }
                if(redirect)
                    return View("Index").ComMensagemDeSucesso("Avaliação registrada.");
            return RedirectToAction("MontarQuestionario","Formulario", new { registroFormulario = codFormulario }).ComMensagemDeSucesso("Avaliação registrada.");
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home").ComMensagemDeErro("Não foi possível registrar avaliação. Erro:" + ex.Message);
            }
        }

        public ActionResult ConcluirAvaliacao()
        {
            Session["avaliados"] = null;
            return RedirectToAction("Index");//.ComMensagemDeSucesso("Avalição concluídda com sucesso. Obrigado por participar.");
        }

    }
}
