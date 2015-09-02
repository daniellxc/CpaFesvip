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
    public class CpaBO
    {

        #region DAO

        private class CpaDAO : AbstractDao<Cpa>
        {

        }

        #endregion

        private CpaDAO DAO = new CpaDAO();

        public Cpa GetCpa(int codigo)
        {
            return DAO.Get(codigo);
        }

        public List<Cpa> TodasCPAs()
        {
            return DAO.GetAll();
        }

        public void SalvarCpa(Cpa cpa)
        {
            try
            {
                if (cpa.DataInicio >= cpa.DataFim) throw new Exceptions.ErroDesconhecido("Intervalo de datas inválido");

                if (cpa.Codigo == 0)
                {

                    DAO.Add(cpa);
                    DAO.CommitChanges();
                }
                else
                    DAO.Update(cpa, cpa.Codigo);

            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(cpa);
            }
            catch(Exception)
            {
                throw new Exceptions.ErroAoSalvar(cpa);
            }

        }

        public void ExcluirCpa(Cpa cpa)
        {
            try
            {
                DAO.Delete(cpa);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(cpa);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroDesconhecido();
            }

        }
    }
}
