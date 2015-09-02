using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_horarios_alocacao_disciplina")]
    public class HorarioAlocacaoDisciplina
    {
        [Column("codigo")]
        [Key]
        public int Codigo { get; set; }

        [Column("alocacao_disciplina")]
        public int ALOCACAO_DISCIPLINA { get; set; }

        [Column("professor")]
        public int PROFESSOR { get; set; }

        #region ForeignKeys

        [ForeignKey("ALOCACAO_DISCIPLINA")]
        public virtual AlocacaoDisciplina FK_AlocacaoDisciplina { get; set; }

        [ForeignKey("PROFESSOR")]
        public virtual Professor FK_Professor { get; set; }

        #endregion
    }
}
