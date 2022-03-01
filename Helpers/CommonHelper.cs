using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentManagement21A2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Helpers
{
    public class CommonHelper
    {
        private IConfiguration _config;

        public CommonHelper(IConfiguration config)
        {
            _config = config;
        }


        public int DMLTransaction(string Query)
        {
            int Result;
            string connectionString = _config["ConnectionStrings:StudentDBConnection2"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                connection.Close();
            }
            return Result;
        }


        public bool UserAlreadyExists(string query)
        {
            bool flag = false;
            string connectionString = _config["ConnectionStrings:StudentDBConnection2"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader rd = command.ExecuteReader();
                if (rd.HasRows)
                {
                    flag = true;
                }
                connection.Close();

            }
            return flag;
        }
        public UserViewModel GetUserByUserName(string query)
        {
            UserViewModel user = new UserViewModel();

            string connectionString = _config["ConnectionStrings:StudentDBConnection2"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        user.Id_user = Convert.ToInt32(dataReader["Id_user"]);
                        user.UserName = dataReader["UserName"].ToString();
                        user.Password = dataReader["Password"].ToString();
                    }
                }
                connection.Close();
            }
            return user;
        }
    }
}
