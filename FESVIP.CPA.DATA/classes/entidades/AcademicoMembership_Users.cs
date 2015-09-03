using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{

    [Table("Users")]
    public class AcademicoMembership_Users
    {
        [Key]
        public string pId { get; set; }


        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
