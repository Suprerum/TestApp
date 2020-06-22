using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace TestApplication.Data
{
    public class AppointmentProcessor : IDataProcessor
    {
        private readonly string connectionString;

        public AppointmentProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Create(IDatable appointment)
        {
            var variable = appointment as Appointment;
            if (variable != null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute("INSERT INTO Appointment(Id, PatientId, ServiceId) VALUES (@Id, @PatientId, @ServiceId)", new { variable.Id, variable.PatientId, variable.ServiceId });
                }
            }
            else
            {
                throw new Exception();
            }

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update(IDatable appointment)
        {
            var variable = appointment as Appointment;
            if (variable != null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute("INSERT INTO Appointment(Id, PatientId, ServiceId) VALUES (@Id, @PatientId, @ServiceId)", new { variable.Id, variable.PatientId, variable.ServiceId });
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
