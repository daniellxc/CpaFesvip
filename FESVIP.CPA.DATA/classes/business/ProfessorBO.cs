using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes.business
{
    public class ProfessorBO
    {
        #region DAO

        private class ProfessorDAO : AbstractDao<Professor> { }

        private ProfessorDAO DAO = new ProfessorDAO();
        #endregion

        #region Consultas

        public List<Professor> PegarProfessoresDoPeriodo(int codigoCurso, int codigoPeriodoLetivo)
        {
            using (Context ctx = new Context())
            {
                var query = from prof in ctx.Professores
                            join hr_al_disc in ctx.HorariosAlocacaoDisciplina
                            on prof.Codigo equals hr_al_disc.PROFESSOR
                            join al_disc in ctx.AlocacoesDisciplinas
                            on hr_al_disc.ALOCACAO_DISCIPLINA equals al_disc.Codigo
                            join turma in ctx.Turmas
                            on al_disc.TURMA equals turma.Codigo
                            join grade in ctx.Grades
                            on turma.GRADE equals grade.Codigo
                            where grade.CURSO == codigoCurso &&
                                  turma.PERIODO_LETIVO == codigoPeriodoLetivo 
                            select prof;
                return query.ToList<Professor>().Distinct().OrderBy(p => p.Nome).ToList();

            }
        }

        public List<Professor> PegarProfessoresDoPeriodo(int codigoCurso, int codigoPeriodoLetivo, int periodo)
        {
            using (Context ctx = new Context())
            {
                var query = from prof in ctx.Professores
                            join hr_al_disc in ctx.HorariosAlocacaoDisciplina
                            on prof.Codigo equals hr_al_disc.PROFESSOR
                            join al_disc in ctx.AlocacoesDisciplinas
                            on hr_al_disc.ALOCACAO_DISCIPLINA equals al_disc.Codigo
                            join turma in ctx.Turmas
                            on al_disc.TURMA equals turma.Codigo
                            join grade in ctx.Grades
                            on turma.GRADE equals grade.Codigo
                            where grade.CURSO == codigoCurso &&
                                  turma.PERIODO_LETIVO == codigoPeriodoLetivo &&
                                  turma.Periodo == periodo
                            select prof;
                return query.ToList<Professor>().Distinct().OrderBy(p=>p.Nome).ToList();

            }
        }

        #endregion
    }
}
