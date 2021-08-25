using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DALAdmin
    {
        public static string DALLogin(string username, string password)
        {
            string login = "Failed";
            SqlCommand cmd = new SqlCommand("select * from tbl_Admin where Username = @p1 AND Password = @p2", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", username);
            cmd.Parameters.AddWithValue("@p2", password);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                login = "Success";
            }

            return login;
        }

        public static string DALForgotPassword(string name, string surname, string username, string code)
        {
            string password = "FoundError";
            SqlCommand cmd = new SqlCommand("select Password from tbl_Admin where Name = @p1 AND Surname = @p2 AND Username = @p3 AND SecurityCode = @p4", SQL.connection());
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

        public static DataTable DALShowRows()
        {
            SqlCommand cmd = new SqlCommand("Select ID, Name, Surname, Username, Permission from tbl_Personnel", SQL.connection());
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSouce(string name)
        {
            SqlCommand cmd = new SqlCommand("Select ID, Name, Surname, Username, Permission from tbl_Personnel where Name LIKE '%'+@p1+'%'", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static void DALDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from tbl_Personnel where ID = @p1", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", id);
            cmd.ExecuteNonQuery();
        }

        public static string[] DALGetUser(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_Personnel where ID = @p1", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", id);
            SqlDataReader read = cmd.ExecuteReader();

            string[] userinfo = new string[6];

            while (read.Read())
            {
                userinfo[0] = read["Name"].ToString();
                userinfo[1] = read["Surname"].ToString();
                userinfo[2] = read["Username"].ToString();
                userinfo[3] = read["Password"].ToString();
                userinfo[4] = read["Permission"].ToString();
                userinfo[5] = read["SecurityCode"].ToString();
            }

            return userinfo;
        }

        public static string DALUpdateUser(int id, string name, string surname, string username, string password, int permission, string securitycode)
        {
            SqlCommand cmd = new SqlCommand("update tbl_Personnel set Name = @p1, Surname = @p2, Username = @p3, Password = @p4, Permission = @p5, SecurityCode = @p6 WHERE ID = @p7", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", surname);
            cmd.Parameters.AddWithValue("@p3", username);
            cmd.Parameters.AddWithValue("@p4", password);
            cmd.Parameters.AddWithValue("@p5", permission);
            cmd.Parameters.AddWithValue("@p6", securitycode);
            cmd.Parameters.AddWithValue("@p7", id);

            cmd.ExecuteNonQuery();
            string update = "Success";
            return update;
        }

        public static bool DALNewUserAlreadyHave(string username)
        {
            bool alreadyhave = false;

            SqlCommand cmd = new SqlCommand("select * from tbl_Personnel", SQL.connection());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (username == read["Username"].ToString())
                {
                    alreadyhave = true;
                }
            }

            return alreadyhave;
        }

        public static string DALNewUser(string name, string surname, string username, string password, int permission, string securitycode)
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_Personnel (Name, Surname, Username, Password, Permission, SecurityCode) Values (@p1, @p2, @p3, @p4, @p5, @p6)", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", surname);
            cmd.Parameters.AddWithValue("@p3", username);
            cmd.Parameters.AddWithValue("@p4", password);
            cmd.Parameters.AddWithValue("@p5", permission);
            cmd.Parameters.AddWithValue("@p6", securitycode);

            cmd.ExecuteNonQuery();
            string update = "Success";
            return update;
        }

        public static bool DALNewAdminAlreadyHave(string username)
        {
            bool alreadyhave = false;

            SqlCommand cmd = new SqlCommand("select * from tbl_Admin", SQL.connection());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (username == read["Username"].ToString())
                {
                    alreadyhave = true;
                }
            }

            return alreadyhave;
        }

        public static string DALNewAdmin(string name, string surname, string username, string password, string securitycode)
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_Admin (Name, Surname, Username, Password, SecurityCode) Values (@p1, @p2, @p3, @p4, @p5)", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", surname);
            cmd.Parameters.AddWithValue("@p3", username);
            cmd.Parameters.AddWithValue("@p4", password);
            cmd.Parameters.AddWithValue("@p5", securitycode);

            cmd.ExecuteNonQuery();
            string update = "Success";
            return update;
        }
    }
}
