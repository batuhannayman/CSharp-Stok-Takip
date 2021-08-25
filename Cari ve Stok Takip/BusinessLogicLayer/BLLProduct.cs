using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLLProduct
    {
        public static DataTable GetRows()
        {
            DataTable dt = new DataTable();
            dt = DALProduct.GetRows();
            return dt;
        }
        static void Main() { }

        public static DataTable BLLSearchWithType(string type)
        {
            DataTable dt = new DataTable();
            dt = DALProduct.DALSearchWithType(type);
            return dt;
        }

        public static DataTable BLLSearchWithBrand(string brand)
        {
            DataTable dt = new DataTable();
            dt = DALProduct.DALSearchWithBrand(brand);
            return dt;
        }

        public static DataTable BLLSearchWithProductNo(string productNo)
        {
            DataTable dt = new DataTable();
            dt = DALProduct.DALSearchWithProductNo(productNo);
            return dt;
        }

        public static string BLLProductAdd(string type, string brand, string productNo, int piece, int price)
        {
            string add;

            if (type == "" || brand == "" || productNo == "")
            {
                add = "NullError";
                return add;
            }
            else
            {
                add = DALProduct.DALProductAddAlreadyHave(type, brand, productNo, piece, price);
                return add;
            }

        }
    }
}
