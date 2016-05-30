namespace BosWebApiFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BosContext : DbContext
    {
        public BosContext()
            : base("name=BosContext2")
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
                .HasMany(e => e.Kursus_Deltager)
                .WithOptional(e => e.Deltagere)
                .HasForeignKey(e => e.Deltagere_id);

            modelBuilder.Entity<Deltagere>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.Deltagere)
                .HasForeignKey(e => e.DeltagerListe);

            modelBuilder.Entity<Kursus>()
                .HasMany(e => e.Kursus_Deltager)
                .WithOptional(e => e.Kursus)
                .HasForeignKey(e => e.Kursus_id);

            modelBuilder.Entity<Lokation>()
                .HasMany(e => e.Booking)
                .WithOptional(e => e.Lokation)
                .HasForeignKey(e => e.BookingLokation);
        }
    }
}
