using FESVIP.CPA.DATA.classes.acessorio;
using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.business
{
    
    public class FormularioBO
    {
        #region DAO

        private class FormularioDAO : AbstractDao<Formulario>
        {

        }

        #endregion

        private FormularioDAO DAO = new FormularioDAO();

        public Formulario GetFormulario(int codigo)
        {
            return DAO.Get(codigo);
        }

        public List<Formulario> TodosFormularios()
        {
            return DAO.GetAll();
        }

        public void SalvarFormulario(Formulario formulario)
        {
            try
            {
                if (formulario.Codigo == 0)
                {
                    DAO.Add(formulario);
                    DAO.CommitChanges();
                }
                else
                    DAO.Update(formulario, formulario.Codigo);

            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(formulario);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroAoSalvar(formulario);
            }

        }

        public void ExcluirFormulario(Formulario formulario)
        {
            try
            {
                DAO.Delete(formulario);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(formulario);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroDesconhecido();
            }

        }

       public void AdicionarQuestaoAoFormulario(int codigoQuestao, int codigoFormulario)
       {
           try
           {
               using (Context ctx = new Context())
               {
                   Formulario f = ctx.Formularios.Find(codigoFormulario);
                   f.Questoes.Add(ctx.Questao.Find(codigoQuestao));
                   ctx.SaveChanges();

               }

           }
           catch (DbUpdateException) { throw new Exceptions.ErroDesconhecido("Erro ao adicionar questão ao formulário."); }
           catch (Exception ex) { throw new Exceptions.ErroDesconhecido("Erro de sistema: " + ex.Message); }
        }

        public void RemoverQuestaoDoFormulario(int codigoQuestao, int codigoFormulario)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    Formulario f = ctx.Formularios.Find(codigoFormulario);
                    f.Questoes.Remove(ctx.Questao.Find(codigoQuestao));
                    ctx.SaveChanges();

                }

            }
            catch (DbUpdateException) { throw new Exceptions.ErroDesconhecido("Erro ao adicionar questão ao formulário."); }
            catch (Exception ex) { throw new Exceptions.ErroDesconhecido("Erro de sistema: " + ex.Message); }
        }


        /// <summary>
        /// Retorna uma lista com os formulários da cpa informada como parâmetro
        /// </summary>
        /// <param name="registroCPA"></param>
        /// <returns></returns>
        public List<Formulario> FormulariosDeUmaCpa(int registroCPA)
        {
            return DAO.Find(f => f.CPA == registroCPA).ToList();
        }

        /// <summary>
        /// Retorna uma lista com os formulários das cpas ativas
        /// </summary>
        /// <returns></returns>
        public List<Formulario> FormulariosDeCpasAtivas()
        {
            return DAO.Find(f => f.FK_Cpa.Ativo == true).ToList();
        }
    }
}
