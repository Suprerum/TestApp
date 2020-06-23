using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestApplication.Service.Models;


namespace TestApplication.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public ILogger Logger { get; }
        public EventController(ILogger<EventController> logger)
        {
            Logger = logger;
        }

        string connectionString = "Data Source=test.sqlite;Version=3;Pooling=True;Max Pool Size=100;";
        
        [HttpGet("{id}")]
        public IEnumerable<Event> Get(int id)
        {
            IEnumerable<Event> Event = null;
            using (var connection = new SQLiteConnection(connectionString, true))
            {
                Event = connection.Query<Event>("SELECT DISTINCT strftime('%Y %M %d',Event.DateTime), AppointmentId FROM Event" + 
                                                "INNER JOIN Appointment on Event.AppointmentId = Appointment.Id"+
                                                "INNER JOIN Patient on Appointment.PatientId = Patient.Id"+
                                                "WHERE Patient.Id = @Id", new { Id = id }).ToList();
            }
            return Event;
        }
                
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event @event)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE Event SET AppointmentId = @AppointmentId WHERE Id=@Id",
                    new { Id = id, @event.AppointmentId });
            }
        }
    }
}
