using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cpa_tipo_formulario")]
    public class TipoFormulario
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cod_interno")]
        public string CodInterno { get; set; }


        public TipoFormulario()
        {

        }
    }
}
