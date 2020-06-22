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
    public class AppointmentController : ControllerBase
    {
        string connectionString = "Data Source = test.sqlite;Version=3;";
        // GET api/<AppointmentController>/id
        [HttpGet("{id}")]
        public IEnumerable<Appointment> Get(int id)
        {
            IEnumerable<Appointment> Appointment = null;
            using (var connection = new SQLiteConnection(connectionString))
            {
                Appointment = connection.Query<Appointment>("SELECT Id, PatientId as PatientId, ServiceId as ServiceId FROM Appointment WHERE Id = @Id", new { Id = id }).ToList();
            }
            return Appointment;
        }
        // GET api/<AppointmentController>/name
        [HttpGet("{name}")]
        public IEnumerable<Appointment> Get(string name)
        {
            IEnumerable<Appointment> Appointment = null;
            using (var connection = new SQLiteConnection(connectionString))
            {
                Appointment = connection.Query<Appointment>("SELECT Id, PatientId as PatientId, ServiceId as ServiceId, FROM Appointment" +
                    "INNER JOIN Patient on Appointment.PatientId = Patient.Id" +
                    "WHERE Patient.Name = @Name", new { Name = name }).ToList();
            }
            return Appointment;
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Appointment appointment)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO Appointment(Id, PatientId, ServiceId) VALUES (@Id, @PatientId, @ServiceId)", 
                    new { appointment.Id, appointment.PatientId, appointment.ServiceId });
            }
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Appointment appointment)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE Appointment SET PatientId = @PatientId, ServiceId = @ServiceId) WHERE Id=@Id",
                    new { Id = id, appointment.PatientId, appointment.ServiceId });
            }
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("DELETE FROM Appointment WHERE Id=@Id",
                    new { Id = id });
            }
        }
    }
}
