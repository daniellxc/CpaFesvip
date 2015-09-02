using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cpa_questao")]
    public class Questao
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public  int Codigo { get; set; }

        [Column("CATEGORIA_QUESTAO")]
        public int CATEGORIA_QUESTAO { get; set; }

        [Column("enredo")]
        [Required(ErrorMessage="campo obrigatório")]
        public string Enredo { get; set; }


        #region ForeignKeys

       public virtual ICollection<Formulario> Formularios { get; set; }

       public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
       

        [ForeignKey("CATEGORIA_QUESTAO")]
        public virtual CategoriaQuestao FK_CategoriaQuestao { get; set; }

        #endregion

        public Questao()
        {
         //this.Formularios = new HashSet<Formulario>();
        }
    }
}
