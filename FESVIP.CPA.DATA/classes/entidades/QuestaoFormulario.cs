using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cpa_questao_formulario")]
    public class QuestaoFormulario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("FORMULARIO")]
        [Required(ErrorMessage="campo obrigatório")]
        public int FORMULARIO { get; set; }

        [Column("QUESTAO")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int QUESTAO { get; set; }

        #region ForeignKeys

        [ForeignKey("FORMULARIO")]
        public virtual Formulario FK_Formulario { get; set; }

        [ForeignKey("QUESTAO")]
        public virtual Questao FK_Questao { get; set; }

        #endregion

        public QuestaoFormulario()
        {
                
        }

    }
}
