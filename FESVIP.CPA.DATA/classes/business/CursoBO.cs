using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.business
{
    public class CursoBO
    {
        #region DAO
        private class CursoDAO : AbstractDao<Curso> { }

        private CursoDAO DAO = new CursoDAO();
        #endregion

        public List<Curso> TodosCursosAtivos()
        {
            return DAO.Find(c => c.Ativo);
        }

        public int QuantidadePeriodo(int codCurso)
        {
            using (Context context = new Context())
            {
                var query = from curso in context.Cursos
                            join grade in context.Grades
                            on curso.Codigo equals grade.CURSO
                            join turma in context.Turmas
                            on grade.Codigo equals turma.GRADE
                            where
                            curso.Codigo == codCurso
                            select turma.Periodo;
                return query.Max();
            }
        }
    }
}
