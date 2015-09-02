using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FESVIP.CPA.DATA.classes.entidades;
namespace FESVIP.CPA.DATA.classes
{
    public class Context : DbContext
    {


        #region DbSets

        public DbSet<AlocacaoDisciplina> AlocacoesDisciplinas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Cpa> Cpas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CategoriaQuestao> CategoriasQuestoes { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<HorarioAlocacaoDisciplina> HorariosAlocacaoDisciplina { get; set; }
        public DbSet<PeriodoLetivo> PeriodosLetivos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Questao> Questao { get; set; }
        //public DbSet<QuestaoFormulario> QuestoesFormularios { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TipoFormulario> TiposFormularios { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                modelBuilder.HasDefaultSchema("public");

                modelBuilder.Entity<Formulario>()
                         .HasMany(s => s.Questoes)
                         .WithMany(c => c.Formularios)
                         .Map(cs => cs.ToTable("acad_cpa_questao_formulario").MapLeftKey("FORMULARIO").MapRightKey("QUESTAO"));
          

        }

        public Context():base("CPA")
        {
          Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer<Context>(null);
        }
    }
}
