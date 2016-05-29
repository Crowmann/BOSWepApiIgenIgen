namespace BosWebApiFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KursusType")]
    public partial class KursusType
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
