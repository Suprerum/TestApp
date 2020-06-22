using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Service.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public List<Patient> PatientId { get; set; }
        public List<Service> ServiceId { get; set; }
    }
}
