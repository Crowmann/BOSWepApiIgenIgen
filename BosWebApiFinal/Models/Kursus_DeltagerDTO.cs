using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BosWebApiFinal.Models
{
    public class Kursus_DeltagerDTO
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int? TelefonNr { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public List<Kursus_DeltagerDTO> DeltagerListe { get; set; }
    }
}