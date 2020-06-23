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
    public class AppointmentController : ControllerBase
    {
        public ILogger Logger { get; }
        public AppointmentController(ILogger<AppointmentController> logger)
        {
            Logger = logger;
        }

        string connectionString = "Data Source=test.sqlite;Version=3;Pooling=True;Max Pool Size=100;";
        // GET api/AppointmentController/id
        [HttpGet("{id}")]
        public IEnumerable<Appointment> Get(int id)
        {
            IEnumerable<Appointment> Appointment = null;
            using (var connection = new SQLiteConnection(connectionString, true))
            {
                Appointment = connection.Query<Appointment>("SELECT Appointment.Id FROM Appointment" +
                    "INNER JOIN Patient on Appointment.PatientId = Patient.Id" +
                    "WHERE Patient.Id = @Id", new { Id = id }).ToList();
            }
            return Appointment;
        }
        //GET api/<AppointmentController>/name
        [HttpGet("{name}")]
        public IEnumerable<Appointment> Get(string name)
        {
            IEnumerable<Appointment> Appointment = null;
            using (var connection = new SQLiteConnection(connectionString))
            {
                Appointment = connection.Query<Appointment>("SELECT Appointment.Id FROM Appointment" +
                    "INNER JOIN Patient on Appointment.PatientId = Patient.Id" +
                    "WHERE Patient.Name = @Name", new { Name = name }).ToList();
            }
            return Appointment;
        }
    } 
}
