using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenDataAccessLayer.Base
{
    public class SqlConnectionFactory
    {
            private static readonly string _connectionString =
                "Data Source=.;Initial Catalog=TaskeenDB;Integrated Security=True"; // أو اجعلها من config

            public static SqlConnection CreateConnection()
            {
                return new SqlConnection(_connectionString);
            }
    }
}
