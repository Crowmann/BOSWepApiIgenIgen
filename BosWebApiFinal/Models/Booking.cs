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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public int? Fk_Kursus { get; set; }

        public int? Fk_Leder { get; set; }

        public int? Fk_Lokaler { get; set; }

        public virtual Kursu Kursu { get; set; }

        public virtual Ledere Ledere { get; set; }

        public virtual Lokaler Lokaler { get; set; }
    }
}
