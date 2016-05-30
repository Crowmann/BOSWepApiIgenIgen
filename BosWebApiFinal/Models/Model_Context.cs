namespace BosWebApiFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Context : DbContext
    {
        public Model_Context()
            : base("name=Model_Context")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Deltagere> Deltagere { get; set; }
        public virtual DbSet<Kursus> Kursus { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Lokaler> Lokaler { get; set; }
        public virtual DbSet<Lokation> Lokation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deltagere>()
                .HasMany(e => e.Kursus)
                .WithMany(e => e.Deltagere)
                .Map(m => m.ToTable("Kursus_Deltager").MapLeftKey("Deltagere_id").MapRightKey("Kursus_id"));

            modelBuilder.Entity<Lokation>()
                .HasMany(e => e.Booking)
                .WithOptional(e => e.Lokation)
                .HasForeignKey(e => e.BookingLokation);
        }
    }
}
