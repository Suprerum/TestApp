using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Service.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Service ServiceId { get; set; }
        public Appointment AppointmentId { get; set; }

    }
}
