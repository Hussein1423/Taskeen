using TaskeenDataAccessLayer.Base;
using TaskeenDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenDataAccessLayer.Repositories
{
    public class UserRepository : IMutableRepository<User>
    {

        public static readonly UserRepository Instance = new UserRepository();
        public async Task<int?> CreateAsync(User user)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            INSERT INTO Users (FirstName, SecondName, LastName, Username, PasswordHash, Email, Role)
            VALUES (@FirstName, @SecondName, @LastName, @Username, @PasswordHash, @Email, @Role);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", (object)user.SecondName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", user.Role);

                    await conn.OpenAsync();
                    object result = await cmd.ExecuteScalarAsync();

                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        return value;
                    }

                    return null;
                }
            }
        }


        public async Task<bool> UpdateAsync(User user)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            UPDATE Users SET
                FirstName = @FirstName,
                SecondName = @SecondName,
                LastName = @LastName,
                Username = @Username,
                PasswordHash = @PasswordHash,
                Email = @Email,
                Role = @Role
            WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", (object)user.SecondName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();

                    return affectedRows > 0;
                }
            }
        }


        public async Task<bool> DeleteAsync(int userId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "DELETE FROM Users WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();

                    return affectedRows > 0;
                }
            }
        }


        public async Task<User> GetByIdAsync(int userId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Users WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToUser(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }



        public async Task<List<User>> GetAllAsync()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Users";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            users.Add(MapReaderToUser(reader));
                        }
                    }
                }
            }

            return users;
        }
        public async Task<User> AuthenticateAsync(string usernameOrEmail, string password)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            SELECT * FROM Users 
            WHERE (Username = @Input OR Email = @Input) 
              AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Input", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@Password", password);

                    await conn.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToUser(reader);
                        }
                    }

                    return null; // لا يوجد مستخدم أو كلمة المرور غير صحيحة
                }
            }
        }


        private User MapReaderToUser(SqlDataReader reader)
        {
            return new User
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                FirstName = reader["FirstName"].ToString() ?? "",
                SecondName = reader["SecondName"] == DBNull.Value ? null : reader["SecondName"].ToString(),
                LastName = reader["LastName"].ToString() ?? "",
                Username = reader["Username"].ToString() ?? "",
                PasswordHash = reader["PasswordHash"].ToString() ?? "",
                Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                Role = reader["Role"].ToString() ?? ""
            };
        }
    }
}
