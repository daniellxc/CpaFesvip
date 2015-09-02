using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cpa_avaliacao")]
    public class Avaliacao
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("id_sessao")]
        public string IdSessao { get; set; }

        [Column("data")]
        [Required(ErrorMessage="campo obrigatório")]
        public DateTime DataAvaliacao { get; set; }

        [Column("QUESTAO")]
        public  int QUESTAO { get; set; }

        [Column("FORMULARIO")]
        public int FORMULARIO { get; set; }
        
        [Column("nota")]
        public int Nota { get; set; }

        
        [Column("entidade_avaliada")]
        public string EntidadeAvaliada { get; set; }


       

        #region ForeignKey

        [ForeignKey("QUESTAO")]
        public virtual Questao FK_Questao { get; set; }

        [ForeignKey("FORMULARIO")]
        public virtual Formulario FK_Formulario { get; set; }


      
        #endregion

        public Avaliacao()
        {

        }
    }
}
