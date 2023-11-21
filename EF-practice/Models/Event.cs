using System;
using System.Collections.Generic;

namespace EF_practice.Models
{
    public partial class Event
    {
        public Event()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Idevent { get; set; }
        public string? NameEvent { get; set; }
        public DateTime? DateEvent { get; set; }
        public string? PlaceEvent { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
