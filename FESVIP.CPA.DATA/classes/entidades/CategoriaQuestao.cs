using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cpa_categoria_questao")]
    public class CategoriaQuestao
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("nota_max")]
        public int NotaMax { get; set; }

        public CategoriaQuestao()
        {
                
        }
    }
}
