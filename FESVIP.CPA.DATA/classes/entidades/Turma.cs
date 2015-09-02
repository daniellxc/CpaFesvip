using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_turmas")]
    public class Turma
    {
        [Column("codigo")]
        [Key]
        public  int Codigo { get; set; }

        [Column("periodo")]
        public int Periodo { get; set; }

        [Column("periodo_letivo")]
        public int PERIODO_LETIVO { get; set; }

        [Column("grade")]
        public int GRADE { get; set; }

        #region ForeignKey

        [ForeignKey("PERIODO_LETIVO")]
        public virtual PeriodoLetivo FK_PeriodoLetivo { get; set; }

        [ForeignKey("GRADE")]
        public virtual Grade FK_Grade { get; set; }

        #endregion
    }
}
