using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.business
{
   
    public class TipoFormularioBO
    {
        #region DAO

        private class TipoFormularioDAO : AbstractDao<TipoFormulario>
        {

        }

        #endregion

        TipoFormularioDAO DAO = new TipoFormularioDAO();

        public List<TipoFormulario> TodosTiposFormularios()
        {
            return DAO.GetAll();
        }
    }
}
