using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TestApplication.Data
{
    public class PatientProvider: IDataProvider
    {
        private readonly string connectionString;
        public PatientProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable Get()
        {
            IEnumerable Patient = null;
            using (var connection = new SqlConnection(connectionString))
            {
                Patient = connection.Query<Patient>("select id, Name as Name");
            }
            return Patient;
        }
    }
}
