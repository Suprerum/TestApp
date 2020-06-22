using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApplication.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public readonly IDataProvider appointmentProvider = null;
        private readonly IDataProcessor appointmentProcessor;

        public AppointmentController(IDataProvider appointmentProvider, IDataProcessor appointmentProcessor)
        {
            this.appointmentProvider = appointmentProvider;
            this.appointmentProcessor = appointmentProcessor;
        }
        
        // GET api/<AppointmentController>/name
        [HttpGet("{id}")]
        public List<Appointment> Get(int id)
        {
            return 
        }

        [HttpGet("{name}")]
        public List<Appointment> Get(string name)
        {

            return
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Appointment appointment)
        {
            appointmentProcessor.Create(appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
