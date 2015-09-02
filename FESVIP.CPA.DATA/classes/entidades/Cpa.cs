using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cpa")]
    public class Cpa
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Required(ErrorMessage="Informe o período de referência da CPA")]
        public int PERIODO_LETIVO { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("data_inicio")]
        [Required(ErrorMessage="Informe a data de início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        [Required(ErrorMessage = "Informe a data de término")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

     
        #region ForeignKeys

        [ForeignKey("PERIODO_LETIVO")]
        public virtual PeriodoLetivo FK_PeriodoLetivo { get; set; }

        #endregion


        public Cpa()
        {

        }
    }
}
