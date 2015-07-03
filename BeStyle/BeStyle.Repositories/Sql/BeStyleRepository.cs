using BeStyle.Repositories.Abstract;
using BeStyle.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;


namespace BeStyle.Repositories.Sql
{
    public class BeStyleRepository : IBeStyleRepository
    {
        private readonly string _connectionString;

        public BeStyleRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public List<UserInfo> GetUsersAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmd = @"SELECT * FROM tblUser";
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    List<UserInfo> users = new List<UserInfo>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserInfo user = ReadAdmin(reader);
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
        }

        public UserInfo GetUserByLogin(string login)
        {
            using (SqlConnection connection=new SqlConnection(_connectionString))
            {
                connection.Open();
                string command=String.Format(@"SELECT * FROM tblUser WHERE Login='{0}'", login);
                using (SqlCommand cmd=new SqlCommand(command,connection))
                {
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    if (reader.Read())
                    {
                        return ReadAdmin(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public UserInfo GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = String.Format(@"SELECT * FROM tblUser WHERE Email='{0}'", email);
                using (var cmd = new SqlCommand(command, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                        if (reader.Read())
                        {
                            return ReadAdmin(reader);
                        }
                        else
                        {
                            return null;
                        }
                }
            }
        }
        

        public Role GetRole(int id)
        {
            Role role = new Role();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string command = String.Format(@"SELECT * FROM tblUserRole WHERE UserId={0}", id);
                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                       if(reader.Read())
                       {
                           return this.ReadRole(reader);
                       }
                       else
                       {
                           return null;
                       }
                    }
                }
            }
        }
        private UserInfo ReadAdmin(SqlDataReader reader)
        {
            UserInfo admin = new UserInfo();            
            admin.Id = (int)reader["Id"];
            admin.FirstName=(string)reader["FirstName"];
            admin.LastName = (string)reader["LastName"];
            admin.Email = (string)reader["Email"];
            admin.Phone= (string)reader["Phone"];
            admin.Login = (string)reader["Login"];
            admin.Password = (string)reader["Password"];
            admin.Role = GetRole(admin.Id).Value;
            return admin;
       }        

        private Role ReadRole(SqlDataReader reader)
        {
            Role role = new Role();
            role.Id = (int)reader["Id"];
            role.UserId = (int)reader["UserId"];
            role.Value = (string)reader["Role"];
            return role;
        }
    }
}