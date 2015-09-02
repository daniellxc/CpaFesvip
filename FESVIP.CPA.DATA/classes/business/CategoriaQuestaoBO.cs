using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.business
{
    public class CategoriaQuestaoBO
    {

        #region DAO

        public class CategoriaQuestaoDAO : AbstractDao<CategoriaQuestao>
        {


        }

        #endregion

        private CategoriaQuestaoDAO DAO = new CategoriaQuestaoDAO();


        public List<CategoriaQuestao> TodasCategoriasQuestao()
        {
            return DAO.GetAll();
        }
    }
}
