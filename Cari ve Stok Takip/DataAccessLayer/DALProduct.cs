using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALProduct
    {
        public static DataTable GetRows()
        {
            SqlCommand cmd = new SqlCommand("Select ID, Type, Brand, ProductNo, Piece, Price from tbl_Product", SQL.connection());
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSearchWithType(string type)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Product where Type LIKE '%'+@p1+'%'", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", type);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSearchWithBrand(string brand)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Product where Brand LIKE '%'+@p1+'%'", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", brand);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static DataTable DALSearchWithProductNo(string productNo)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Product where ProductNo LIKE '%'+@p1+'%'", SQL.connection());
            cmd.Parameters.AddWithValue("@p1", productNo);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public static string DALProductAddAlreadyHave(string type, string brand, string productNo, int piece, int price)
        {
            bool alreadyhave = false;

            SqlCommand cmd = new SqlCommand("Select * from tbl_Product", SQL.connection());
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                if (productNo == read["ProductNo"].ToString())
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
                string add = DLLProductAdd(type, brand, productNo, piece, price);
                return add;
            }
        }

        public static string DLLProductAdd(string type, string brand, string productNo, int piece, int price)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_Product (Type, Brand, ProductNo, Piece, Price) values (@p2, @p3, @p4, @p5, @p6)", SQL.connection());
            cmd.Parameters.AddWithValue("@p2", type);
            cmd.Parameters.AddWithValue("@p3", brand);
            cmd.Parameters.AddWithValue("@p4", productNo);
            cmd.Parameters.AddWithValue("@p5", piece);
            cmd.Parameters.AddWithValue("@p6", price);

            cmd.ExecuteNonQuery();

            string productID = "0";
            SqlCommand cmd2 = new SqlCommand("Select * from tbl_Product", SQL.connection());
            SqlDataReader read = cmd2.ExecuteReader();

            while (read.Read())
            {
                if (productNo == read["ProductNo"].ToString())
                {
                    productID = read["ID"].ToString();
                }
            }

            return productID;
        }
    }
}
