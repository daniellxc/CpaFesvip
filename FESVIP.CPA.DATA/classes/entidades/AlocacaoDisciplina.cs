using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_alocacoes_disciplinas")]
    public class AlocacaoDisciplina
    {
        [Column("codigo")]
        [Key]
        public int Codigo { get; set; }

        [Column("turma")]
        public int TURMA { get; set; }

        #region ForeignKey
        [ForeignKey("TURMA")]
        public virtual Turma  FK_Turma{ get; set; }

        #endregion
    }
}
