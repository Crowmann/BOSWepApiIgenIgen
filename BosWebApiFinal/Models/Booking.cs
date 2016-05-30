namespace BosWebApiFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Lokale { get; set; }

        public DateTime? DateTime { get; set; }

        public int? DeltagerAntal { get; set; }

        public int? BookingLokation { get; set; }

        public virtual Lokation Lokation { get; set; }
    }
}
