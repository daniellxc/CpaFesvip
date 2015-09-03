using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.business
{
    public class AcademicoMembership_UsersBO
    {

        #region DAO

        public class UsersDAO:AbstractMembershipDAO<AcademicoMembership_Users>{}

        UsersDAO DAO = new UsersDAO();
        #endregion


        public AcademicoMembership_Users GetUser(string username, string password)
        {
            try
            {

                return DAO.Find(u => u.Password == password && u.Username == username).First();

            }
            catch
            {
                return null;
            }
           
        }
    }
}
