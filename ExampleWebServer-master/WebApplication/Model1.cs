namespace WebApplication
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<RequestLog> RequestLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>()
                .Property(e => e.ResourceName)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Content1)
                .IsUnicode(false);
        }
    }
}
