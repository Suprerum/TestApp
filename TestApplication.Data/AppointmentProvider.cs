using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TestApplication.Data
{
    public class AppointmentProvider: IDataProvider
    {
        private readonly string connectionString;
        public AppointmentProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable Get()
        {
            IEnumerable Appointment = null;
            using (var connection = new SqlConnection(connectionString))
            {
                Appointment = connection.Query<Appointment>("select id, DateTime as DateTime, ServiceId as ServiceId, AppointmentId as AppointmentId");
            }
            return Appointment;
        }
    }
}
