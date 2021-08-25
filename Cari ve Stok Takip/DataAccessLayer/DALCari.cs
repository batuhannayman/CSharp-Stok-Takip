using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DALCari
    {
        public static DataTable GetRows()
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Person where Value = @p1", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", "Alıcı");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSearchWithName(string name)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Person where Name LIKE '%'+@p1+'%' AND Value = @p2", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", "Alıcı");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSearchWithTC(string tc)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Person where TC LIKE '%'+@p1+'%' AND Value = @p2", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", tc);
            cmd.Parameters.AddWithValue("@p2", "Alıcı");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSearchWithPhone(string phone)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Person where Phone LIKE '%'+@p1+'%' AND Value = @p2", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", phone);
            cmd.Parameters.AddWithValue("@p2", "Alıcı");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSearchWithMail(string mail)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Person where Mail LIKE '%'+@p1+'%' AND Value = @p2", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", mail);
            cmd.Parameters.AddWithValue("@p2", "Alıcı");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static string DALCariAddAlreadyHave(string name, string surname, string tc, string adress, string phone, string postcode, string mail, string aors)
        {
            bool alreadyhave = false;

            SqlCommand cmd = new SqlCommand("Select * from tbl_Person where Value = @p2", SQL.connection());
            cmd.Parameters.AddWithValue("@p2", "Alıcı");
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                if (tc == read["TC"].ToString())
                {
                    alreadyhave = true;
                }
            }

            if (alreadyhave == true)
            {
                string add = "AlreadyHave";
                return add;
            }
            else
            {
                string add = DLLCariAdd(name, surname, tc, adress, phone, postcode, mail, aors);
                return add;
            }
        }

        public static string DLLCariAdd(string name, string surname, string tc, string adress, string phone, string postcode, string mail, string aors)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_Person (Name, Surname, TC, Adress, Phone, PostCode, Mail, Value) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", surname);
            cmd.Parameters.AddWithValue("@p3", tc);
            cmd.Parameters.AddWithValue("@p4", adress);
            cmd.Parameters.AddWithValue("@p5", phone);
            cmd.Parameters.AddWithValue("@p6", postcode);
            cmd.Parameters.AddWithValue("@p7", mail);
            cmd.Parameters.AddWithValue("@p8", aors);

            cmd.ExecuteNonQuery();

            string add = "Success";
            return add;
        }

        public static string[] DALGetCari(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_Person where ID = @p1", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", id);
            SqlDataReader read = cmd.ExecuteReader();

            string[] cariinfo = new string[7];

            while (read.Read())
            {
                cariinfo[0] = read["Name"].ToString();
                cariinfo[1] = read["Surname"].ToString();
                cariinfo[2] = read["TC"].ToString();
                cariinfo[3] = read["Mail"].ToString();
                cariinfo[4] = read["Phone"].ToString();
                cariinfo[5] = read["PostCode"].ToString();
                cariinfo[6] = read["Adress"].ToString();
            }

            return cariinfo;
        }

        public static DataTable DALGetSales(int id)
        {
            SqlCommand cmd = new SqlCommand("select tbl_Sales.Date, tbl_Sales.Piece, tbl_Sales.Price, tbl_Product.Type, tbl_Product.Brand, tbl_Product.ProductNo, tbl_Sales.Description from tbl_Sales join tbl_Product on tbl_Product.ID = tbl_Sales.ProductID where PersonID = @p1", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static int DALGetSum(int id)
        {
            try
            {
                int sum = 0;
                SqlCommand cmd = new SqlCommand("select Sum(Price) from tbl_Sales where PersonID = @p1 AND Description <> 'ÖDEME' AND Value = @p2", SQL.connection());
                cmd.Parameters.AddWithValue("@p1", id);
                cmd.Parameters.AddWithValue("@p2", "Alıcı");
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    sum = Convert.ToInt32(read[0]);
                }

                return sum;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public static int DALGetPay(int id)
        {
            try
            {
                int pay = 0;
                SqlCommand cmd = new SqlCommand("select Sum(Price) from tbl_Sales where PersonID = @p1 AND Description = 'ÖDEME' AND Value = @p2", SQL.connection());
                cmd.Parameters.AddWithValue("@p1", id);
                cmd.Parameters.AddWithValue("@p2", "Alıcı");
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    pay = Convert.ToInt32(read[0]);
                }

                return pay;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static DataTable DALSearchWithDate(int id, DateTime date1, DateTime date2)
        {
            SqlCommand cmd = new SqlCommand("select tbl_Sales.Date, tbl_Sales.Piece, tbl_Sales.Price, tbl_Product.Type, tbl_Product.Brand, tbl_Product.ProductNo, tbl_Sales.Description from tbl_Sales join tbl_Product on tbl_Product.ID = tbl_Sales.ProductID where PersonID = @p1 AND Date BETWEEN @p2 and @p3", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", id);
            cmd.Parameters.AddWithValue("@p2", date1);
            cmd.Parameters.AddWithValue("@p3", date2);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static string DALCariUpdate(int id, string name, string surname, string tc, string mail, string phone, string postcode, string adress)
        {
            SqlCommand cmd = new SqlCommand("update tbl_Person set Name = @p1, Surname = @p2, TC = @p3, Mail = @p4, Phone = @p5, PostCode = @p6, Adress = @p7 WHERE ID = @p8", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", surname);
            cmd.Parameters.AddWithValue("@p3", tc);
            cmd.Parameters.AddWithValue("@p4", mail);
            cmd.Parameters.AddWithValue("@p5", phone);
            cmd.Parameters.AddWithValue("@p6", postcode);
            cmd.Parameters.AddWithValue("@p7", adress);
            cmd.Parameters.AddWithValue("@p8", id);

            cmd.ExecuteNonQuery();
            string update = "Success";
            return update;
        }

        public static string DALSalesAdd(int cariID, int productID, int piece, int price, DateTime date, string description)
        {
            SqlCommand cmd2 = new SqlCommand("select * from tbl_Product where ID = @p7", SQL.connection());
            cmd2.Parameters.AddWithValue("@p7", productID);
            SqlDataReader read = cmd2.ExecuteReader();
            int productPiece = 0;
            while (read.Read())
            {
                productPiece = Convert.ToInt32(read["Piece"]);
            }

            if (productPiece == 0 || productPiece < piece)
            {
                return "PieceError";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into tbl_Sales (PersonID, ProductID, Piece, Price, Date, Description) values (@p1, @p2, @p3, @p4, @p5, @p6)", SQL.connection());
                cmd.Parameters.AddWithValue("@p1", cariID);
                cmd.Parameters.AddWithValue("@p2", productID);
                cmd.Parameters.AddWithValue("@p3", piece);
                cmd.Parameters.AddWithValue("@p4", price);
                cmd.Parameters.AddWithValue("@p5", date);
                cmd.Parameters.AddWithValue("@p6", description);

                SqlCommand cmd3 = new SqlCommand("update tbl_Product set Piece = @p8 WHERE ID = @p9", SQL.connection());
                int newPiece = productPiece - piece;
                cmd3.Parameters.AddWithValue("@p8", newPiece);
                cmd3.Parameters.AddWithValue("@p9", productID);

                cmd.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                string add = "Success";
                return add;
            }
        }

        public static string DALPayAdd(int id, int price, DateTime date)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_Sales (PersonID, ProductID, price, date, Description) values (@p1, 1, @p2, @p3, 'ÖDEME')", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", id);
            cmd.Parameters.AddWithValue("@p2", price);
            cmd.Parameters.AddWithValue("@p3", date);
            cmd.ExecuteNonQuery();

            return "Success";
        }
    }
}
