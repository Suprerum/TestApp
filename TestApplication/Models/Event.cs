using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Service.Models
{
    public class Event
    {
        public int Id { get; set; }
        public List<DateTime> DateTime { get; set; }
        public List<Service> ServiceId { get; set; }
        public List<Appointment> AppointmentId { get; set; }

    }
}
