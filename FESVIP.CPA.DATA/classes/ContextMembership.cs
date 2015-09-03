using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESVIP.CPA.DATA.classes
{
    public class ContextMembership: DbContext
    {

        #region DbSets

        public DbSet<AcademicoMembership_Users> Users { get; set; }

        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public ContextMembership() : base("SEG") 
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ContextMembership>());
        }
    }
}
