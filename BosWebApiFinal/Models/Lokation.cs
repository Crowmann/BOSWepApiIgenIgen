namespace BosWebApiFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lokation")]
    public partial class Lokation
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Addresse { get; set; }

        [StringLength(50)]
        public string ByNavn { get; set; }

        [StringLength(50)]
        public string Land { get; set; }
    }
}
