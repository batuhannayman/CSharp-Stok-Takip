using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLLCari
    {
        public static DataTable GetRows()
        {
            DataTable dt = new DataTable();
            dt = DALCari.GetRows();
            return dt;
        }
        public static DataTable BLLSearchWithName(string name)
        {
            DataTable dt = new DataTable();
            dt = DALCari.DALSearchWithName(name);
            return dt;
        }

        public static DataTable BLLSearchWithTC(string tc)
        {
            DataTable dt = new DataTable();
            dt = DALCari.DALSearchWithTC(tc);
            return dt;
        }

        public static DataTable BLLSearchWithPhone(string phone)
        {
            DataTable dt = new DataTable();
            dt = DALCari.DALSearchWithPhone(phone);
            return dt;
        }

        public static DataTable BLLSearchWithMail(string mail)
        {
            DataTable dt = new DataTable();
            dt = DALCari.DALSearchWithMail(mail);
            return dt;
        }

        public static string BLLCariAdd(string name, string surname, string tc, string adress, string phone, string postcode, string mail, string aors)
        {
            string add;

            if (name == "" || surname == "" || tc == "" || adress == "" || phone == "" || postcode == "" || mail == "")
            {
                add = "NullError";
                return add;
            }
            else if (aors != "Alıcı" && aors != "Satıcı")
            {
                add = "AorSError";
                return add;
            }
            else
            {
                add = DALCari.DALCariAddAlreadyHave(name, surname, tc, adress, phone, postcode, mail, aors);
                return add;
            }
        }

        public static string[] BLLGetCari(int id)
        {
            string[] cariinfo = DALCari.DALGetCari(id);
            return cariinfo;
        }

        public static DataTable BLLGetSales(int id)
        {
            DataTable dt = new DataTable();
            dt = DALCari.DALGetSales(id);
            return dt;
        }

        public static int BLLGetSum(int id)
        {
            int sum = DALCari.DALGetSum(id);
            return sum;
        }

        public static int BLLGetPay(int id)
        {
            int pay = DALCari.DALGetPay(id);
            return pay;
        }

        public static DataTable BLLSearchWithDate(int id, DateTime date1, DateTime date2)
        {
            DataTable dt = new DataTable();
            dt = DALCari.DALSearchWithDate(id, date1, date2);
            return dt;
        }

        public static string BLLCariUpdate(int id, string name, string surname, string tc, string mail, string phone, string postcode, string adress)
        {
            string update;
            if (name == "" || surname == "" || tc == "" || mail == "" || phone == "" || postcode == "" || adress == "")
            {
                update = "NullError";
                return update;
            }
            else
            {
                update = DALCari.DALCariUpdate(id, name, surname, tc, mail, phone, postcode, adress);
                return update;
            }
        }

        public static string BLLSalesAdd(int cariID, int productID, int piece, int price, DateTime date, string description)
        {
            string add = DALCari.DALSalesAdd(cariID, productID, piece, price, date, description);
            return add;
        }

        public static string BLLPayAdd(int id, int price, DateTime date)
        {
            string add = DALCari.DALPayAdd(id, price, date);
            return add;
        }
    }
}
