using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DALUser
    {
        public static string DALLogin(string username, string password)
        {
            string login = "Failed";
            SqlCommand cmd = new SqlCommand("select Permission from tbl_Personnel where Username = @p1 AND Password = @p2", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", username);
            cmd.Parameters.AddWithValue("@p2", password);
            SqlDataReader read = cmd.ExecuteReader();
            
            while (read.Read())
            {
                login = "Success";
                EntityUser.userPermission = Convert.ToInt32(read["Permission"]);
            }

            return login;
        }

        public static string DALForgotPassword(string name, string surname, string username, string code)
        {
            string password = "FoundError";
            SqlCommand cmd = new SqlCommand("select Password from tbl_Personnel where Name = @p1 AND Surname = @p2 AND Username = @p3 AND SecurityCode = @p4", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", surname);
            cmd.Parameters.AddWithValue("@p3", username);
            cmd.Parameters.AddWithValue("@p4", code);

            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                password = read["Password"].ToString();
            }

            return password;
        }
    }
}
