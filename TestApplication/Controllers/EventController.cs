using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Service.Models;


namespace TestApplication.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        string connectionString = "Data Source = test.sqlite;Version=3";
        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IEnumerable<Event> Get(int id)
        {
            IEnumerable<Event> @event = null;
            using (var connection = new SQLiteConnection(connectionString))
            {
                @event = connection.Query<Event>("SELECT Id, DateTime as DateTime, ServiceId as ServiceId, AppointmentId as AppointmentId FROM Appointment").ToList();
            }
            return @event;
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event @event)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO Event(Id, DateTime, ServiceId, AppointmentId) VALUES (@Id, @DateTime, @ServiceId, @AppointmentId)",
                    new { @event.Id, @event.DateTime, @event.ServiceId, @event.AppointmentId });
            }
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event @event)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE Event SET DateTime = @DateTime, ServiceId = @ServiceId, AppointmentId = @AppointmentId) WHERE Id=@Id",
                    new { Id = id, @event.DateTime, @event.ServiceId, @event.AppointmentId });
            }
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("DELETE FROM Event WHERE Id=@Id",
                    new { Id = id });
            }
        }
    }
}
