using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace TestApplication.Data
{
    public class EventProvider : IDataProvider
    {
        private readonly string connectionString;
        public EventProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable Get()
        {
            IEnumerable<Event> Event = null;
            using (var connection = new SqlConnection(connectionString))
            {
                Event = connection.Query<Event>("select id, DateTime as DateTime, ServiceId as ServiceId, AppointmentId as AppointmentId");
            }
            return Event;
        }
    }
}
