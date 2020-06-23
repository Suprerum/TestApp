using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Service.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient PatientId { get; set; }
        public Service ServiceId { get; set; }
    }
}
