namespace BosWebApiFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ConfigurationModel")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Deltagere> Deltageres { get; set; }
        public virtual DbSet<Kalender> Kalenders { get; set; }
        public virtual DbSet<Kursu> Kursus { get; set; }
        public virtual DbSet<KursusType> KursusTypes { get; set; }
        public virtual DbSet<Ledere> Lederes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Lokaler> Lokalers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deltagere>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.Deltagere)
                .HasForeignKey(e => e.Fk_Deltager);

            modelBuilder.Entity<Kursu>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.Kursu)
                .HasForeignKey(e => e.Fk_Kursus);

            modelBuilder.Entity<KursusType>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.KursusType)
                .HasForeignKey(e => e.Fk_KursusType);

            modelBuilder.Entity<Ledere>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.Ledere)
                .HasForeignKey(e => e.Fk_Leder);

            modelBuilder.Entity<Ledere>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.Ledere)
                .HasForeignKey(e => e.Fk_Ledere);

            modelBuilder.Entity<Lokaler>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.Lokaler)
                .HasForeignKey(e => e.Fk_Lokaler);

            modelBuilder.Entity<Lokaler>()
                .HasMany(e => e.Kursus)
                .WithOptional(e => e.Lokaler)
                .HasForeignKey(e => e.Fk_Lokaler);
        }
    }
}
