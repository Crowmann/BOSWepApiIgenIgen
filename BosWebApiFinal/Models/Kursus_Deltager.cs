namespace BosWebApiFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kursus_Deltager
    {
        public int Id { get; set; }

        public int? Kursus_id { get; set; }

        public int? Deltagere_id { get; set; }

        public virtual Deltagere Deltagere { get; set; }

        public virtual Kursus Kursus { get; set; }
    }
}
