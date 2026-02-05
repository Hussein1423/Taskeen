using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Base
{
    public static class SqlConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("Server=.;Database=TaskeenDB;Integrated Security=True;Encrypt=False;");
        }
    }

}
