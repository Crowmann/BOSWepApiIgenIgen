namespace BosWebApiFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kursus
    {
        public int KursusId { get; set; }

        [StringLength(50)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }

        public int? DeltagerListe { get; set; }

        public virtual Deltagere Deltagere { get; set; }
    }
}
