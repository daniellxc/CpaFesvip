using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.entidades
{
    [Table("acad_cursos")]
    public class Curso
    {
        [Column("codigo")]
        [Key]
        public int Codigo { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

    }
}
