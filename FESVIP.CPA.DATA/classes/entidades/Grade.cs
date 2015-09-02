using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_grades")]
    public class Grade
    {
        [Column("codigo")]
        [Key]
        public int Codigo { get; set; }

        [Column("curso")]
        public int CURSO { get; set; }

        #region ForeignKeys

        [ForeignKey("CURSO")]
        public virtual Curso FK_Curso { get; set; }

        #endregion
    }
}
