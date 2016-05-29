namespace BosWebApiFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lokaler")]
    public partial class Lokaler
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Addresse { get; set; }

        public int? LokaleNr { get; set; }
    }
}
