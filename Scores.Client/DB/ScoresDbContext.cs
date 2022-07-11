namespace Scores.Client
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ScoresDbContext : DbContext
    {
        public ScoresDbContext()
            : base("name=ScoresDbContext")
        {
        }

        public virtual DbSet<SourceLocation> SourceLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SourceLocation>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<SourceLocation>()
                .Property(e => e.LocationOnDisk)
                .IsUnicode(false);
        }
    }
}
