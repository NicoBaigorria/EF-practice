using System;
using System.Collections.Generic;

namespace EF_practice.Models
{
    public partial class Ticket
    {
        public int Idticket { get; set; }
        public int? Idevent { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityAvailable { get; set; }
        public bool? Avaliable { get; set; }
        public int? PlaceNumber { get; set; }

        public virtual Event? IdeventNavigation { get; set; }
    }
}
