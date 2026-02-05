using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Mappers.Users
{
    public static class UserMapper
    {
        public static User Map(SqlDataReader reader)
        {
            return new User
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                FirstName = reader["FirstName"].ToString(),
                SecondName = reader["SecondName"] == DBNull.Value ? null : reader["SecondName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                Role = reader["Role"].ToString(),
            };
        }
    }

}
