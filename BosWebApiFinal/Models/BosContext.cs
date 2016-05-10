namespace BosWebApiFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BosContext : DbContext
    {
        public BosContext()
            : base("name=BosContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Deltagere> Deltagere { get; set; }
        public virtual DbSet<Kalender> Kalender { get; set; }
        public virtual DbSet<Kursus> Kursus { get; set; }
        public virtual DbSet<KursusType> KursusType { get; set; }
        public virtual DbSet<Ledere> Ledere { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Lokaler> Lokaler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deltagere>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.Deltagere)
                .HasForeignKey(e => e.Fk_Deltager);

            modelBuilder.Entity<Kursus>()
                .HasMany(e => e.Booking)
                .WithOptional(e => e.Kursus)
                .HasForeignKey(e => e.Fk_Kursus);

            modelBuilder.Entity<KursusType>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.KursusType)
                .HasForeignKey(e => e.Fk_KursusType);

            modelBuilder.Entity<Ledere>()
                .HasMany(e => e.Booking)
                .WithOptional(e => e.Ledere)
                .HasForeignKey(e => e.Fk_Leder);

            modelBuilder.Entity<Ledere>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.Ledere)
                .HasForeignKey(e => e.Fk_Ledere);

            modelBuilder.Entity<Lokaler>()
                .HasMany(e => e.Booking)
                .WithOptional(e => e.Lokaler)
                .HasForeignKey(e => e.Fk_Lokaler);

            modelBuilder.Entity<Lokaler>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.Lokaler)
                .HasForeignKey(e => e.Fk_Lokaler);
        }
    }
}
