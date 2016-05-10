namespace BosWebApiFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kursus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kursus()
        {
            Booking = new HashSet<Booking>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }

        public int? Fk_Deltager { get; set; }

        public int? Fk_KursusType { get; set; }

        public int? Fk_Ledere { get; set; }

        public int? Fk_Lokaler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }

        public virtual Deltagere Deltagere { get; set; }

        public virtual KursusType KursusType { get; set; }

        public virtual Ledere Ledere { get; set; }

        public virtual Lokaler Lokaler { get; set; }
    }
}
