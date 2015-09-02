using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_periodos_letivos")]
    public class PeriodoLetivo
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime DataFim { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("fechado")]
        public bool Fechado { get; set; }

        public PeriodoLetivo()
        {

        }

    }
}
