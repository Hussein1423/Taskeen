using DataAccessTaskeen.Base;
using Domain.Mappers.Users;
using Domain.DTOs.User;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.IUser;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Repositories
{
    public class UserRepository : IUserRepository,IUserAuthRepository
    {
        public async Task<int?> CreateAsync(User user, string Salt)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_CreateUser", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", (object)user.SecondName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@PasswordSalt", Salt);


                await conn.OpenAsync();
                object result = await cmd.ExecuteScalarAsync();
                return result != null ? Convert.ToInt32(result) : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // أو يمكنك إعادة رمي الاستثناء حسب تصميمك
            }
        }


        public async Task<bool> UpdateAsync(User user, string? Salt)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_UpdateUser", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // تمرير باقي البيانات العادية
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", (object?)user.FirstName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SecondName", (object?)user.SecondName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", (object?)user.LastName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Username", (object?)user.Username ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object?)user.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", (object?)user.Role ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordHash", (object?)user.PasswordHash ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordSalt", (object?)Salt ?? DBNull.Value);

                await conn.OpenAsync();
                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false; // فشل التحديث
            }
        }




        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_SoftDeleteUser", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", id);

                await conn.OpenAsync();
                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false; // فشل الحذف
            }
        }


        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetUserById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", id);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync() ? UserMapper.Map(reader) : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // فشل الاستعلام
            }
        }



        public async Task<List<User>?> GetAllAsync()
        {
            try
            {
                List<User> users = new List<User>();

                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetAllUsers", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    users.Add(UserMapper.Map(reader));
                }

                return users;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // فشل الاستعلام
            }
        }
        public async Task<string?> GetSaltByUsernameOrEmailAsync(string usernameOrEmail)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetPasswordSalt", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Input", usernameOrEmail);

                await conn.OpenAsync();
                object result = await cmd.ExecuteScalarAsync();

                return result?.ToString();
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }


        public async Task<User?> GetUserByCredentialsAsync(string UsernameOrEmail, string HashPassword)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_AuthenticateUser", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Input", UsernameOrEmail);
                cmd.Parameters.AddWithValue("@PasswordHash", HashPassword);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? UserMapper.Map(reader)
                    : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }




        public async Task<List<User>?> GetUsersPagedAsync(int pageNumber, int pageSize = 30)
        {
            try
            {
                List<User> users = new List<User>();

                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetUsersPaged", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    users.Add(UserMapper.Map(reader));
                }

                return users;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // فشل الاستعلام
            }
        }


    }

}
