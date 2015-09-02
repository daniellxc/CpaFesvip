using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.business
{
  
    public class PeriodoLetivoBO
    {
        #region DAO

        private class PeriodoLetivoDAO : AbstractDao<PeriodoLetivo>
        {

        }

        #endregion

        private PeriodoLetivoDAO DAO = new PeriodoLetivoDAO();

        public PeriodoLetivo GetPeriodoLetivo(int codigo)
        {
            return DAO.Get(codigo);
        }

        public List<PeriodoLetivo> TodosPeriodosLetivos()
        {
            return DAO.GetAll();
        }

      
    }
}
