using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLLCariSatıcılar
    {
        public static DataTable GetRows()
        {
            DataTable dt = new DataTable();
            dt = DALCariSatıcılar.GetRows();
            return dt;
        }
        public static DataTable BLLSearchWithName(string name)
        {
            DataTable dt = new DataTable();
            dt = DALCariSatıcılar.DALSearchWithName(name);
            return dt;
        }

        public static DataTable BLLSearchWithTC(string tc)
        {
            DataTable dt = new DataTable();
            dt = DALCariSatıcılar.DALSearchWithTC(tc);
            return dt;
        }

        public static DataTable BLLSearchWithPhone(string phone)
        {
            DataTable dt = new DataTable();
            dt = DALCariSatıcılar.DALSearchWithPhone(phone);
            return dt;
        }

        public static DataTable BLLSearchWithMail(string mail)
        {
            DataTable dt = new DataTable();
            dt = DALCariSatıcılar.DALSearchWithMail(mail);
            return dt;
        }

        public static string[] BLLGetCari(int id)
        {
            string[] cariinfo = DALCariSatıcılar.DALGetCari(id);
            return cariinfo;
        }

        public static DataTable BLLGetSales(int id)
        {
            DataTable dt = new DataTable();
            dt = DALCariSatıcılar.DALGetSales(id);
            return dt;
        }

        public static int BLLGetSum(int id)
        {
            int sum = DALCariSatıcılar.DALGetSum(id);
            return sum;
        }

        public static int BLLGetPay(int id)
        {
            int pay = DALCariSatıcılar.DALGetPay(id);
            return pay;
        }

        public static DataTable BLLSearchWithDate(int id, DateTime date1, DateTime date2)
        {
            DataTable dt = new DataTable();
            dt = DALCariSatıcılar.DALSearchWithDate(id, date1, date2);
            return dt;
        }

        public static string BLLPayAdd(int id, int price, DateTime date)
        {
            string add = DALCariSatıcılar.DALPayAdd(id, price, date);
            return add;
        }

        public static string BLLProductAdd(int cariID, int productID, int piece, int price, DateTime date, string description)
        {
            string add = DALCariSatıcılar.DALProductAdd(cariID, productID, piece, price, date, description);
            return add;
        }

        public static string BLLStokAdd(int cariID, int productID, int piece, int price, DateTime date, string description)
        {
            string add = DALCariSatıcılar.DALStokAdd(cariID, productID, piece, price, date, description);
            return add;
        }
    }
}
