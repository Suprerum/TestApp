using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TestApplication.Data
{
    public class ServiceProvider: IDataProvider<Service>
    {
        private readonly string connectionString;
        public ServiceProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Service> Get()
        {
            IEnumerable<Service> Service = null;
            using (var connection = new SqlConnection(connectionString))
            {
                Service = connection.Query<Service>("select id, Name as Name");
            }
            return Service;
        }
    }
}
