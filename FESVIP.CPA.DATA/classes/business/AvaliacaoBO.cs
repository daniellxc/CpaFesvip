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
    public class AvaliacaoBO
    {
        #region DAO
        private class AvaliacaoDAO : AbstractDao<Avaliacao>
        {

        }

        #endregion

        private AvaliacaoDAO DAO = new AvaliacaoDAO();

      

        


        public void SalvarAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                if (avaliacao.Codigo == 0)
                {
                    DAO.Add(avaliacao);
                    DAO.CommitChanges();
                }
                else
                {
                    DAO.Update(avaliacao, avaliacao.Codigo);
                }

            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(avaliacao);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroAoSalvar(avaliacao);
            }
        }
    }
}
