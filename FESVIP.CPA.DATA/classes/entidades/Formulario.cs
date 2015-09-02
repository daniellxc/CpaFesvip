using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cpa_formulario")]
    public class Formulario
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("nome")]
        [Required(ErrorMessage="campo obrigatório")]
        public string Nome { get; set; }

        [Column("TIPO_FORMULARIO")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int TIPO_FORMULARIO { get; set; }

        [Column("CPA")]
        [Required(ErrorMessage = "campo obrigatório")]
        public int CPA { get; set; }

        [Column("instrucao")]
        public string Instrucao { get; set; }


        public virtual ICollection<Questao> Questoes { get; set; }
       
        #region ForeignKeys

        [ForeignKey("CPA")]
        public virtual Cpa FK_Cpa { get; set; }

        [ForeignKey("TIPO_FORMULARIO")]
        public virtual TipoFormulario FK_TipoFormulario { get; set; }

        public Formulario()
        {

        }

        #endregion
    }
}
