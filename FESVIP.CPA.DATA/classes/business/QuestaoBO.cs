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
    public class QuestaoBO
    {
        #region DAO

        private class QuestaoDAO : AbstractDao<Questao>
        {

        }

        #endregion

        private QuestaoDAO DAO = new QuestaoDAO();

        public Questao GetQuestao(int codigo)
        {
            return DAO.Get(codigo);
        }

        public List<Questao> TodaQuestoes()
        {
            return DAO.GetAll();
        }

        public void SalvarCpa(Questao questao)
        {
            try
            {
                if (questao.Codigo == 0)
                {
                    DAO.Add(questao);
                    DAO.CommitChanges();
                }
                else
                    DAO.Update(questao, questao.Codigo);

            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(questao);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroAoSalvar(questao);
            }

        }

        public void ExcluirQuestao(Questao questao)
        {
            try
            {
                DAO.Delete(questao);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(questao);
            }
            catch
            {
                throw new Exceptions.ErroDesconhecido();
            }
        }

        #region Consultas

        public List<Questao> QuestoesDoFormulario(int codigoFormulario)
        {
            return DAO.Find(q => q.Formularios.Any(f => f.Codigo == codigoFormulario)).ToList();
        }

        public List<int> getNotas(int max)
        {
           
            List<int> values = new List<int>();

            for (int i = 1; i <= max; i++)
            {
                values.Add(i);

            }
            return values;
        }

        #endregion
    }
}
