using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLLAdmin
    {
        public static string BLLLogin(string username, string password)
        {
            if (username == "" || password == "")
            {
                return "NullError";
            }
            else
            {
                string login = DALAdmin.DALLogin(username, password);
                return login;
            }
        }

        public static string BLLForgotPassword(string name, string surname, string username, string code)
        {
            if (name == "" || surname == "" || username == "" || code == "")
            {
                return "NullError";
            }
            else
            {
                string password = DALAdmin.DALForgotPassword(name, surname, username, code);
                return password;
            }
        }

        public static DataTable BLLShowRows()
        {
            DataTable dt = new DataTable();
            dt = DALAdmin.DALShowRows();
            return dt;
        }

        public static DataTable BLLSouce(string name)
        {
            DataTable dt = new DataTable();
            dt = DALAdmin.DALSouce(name);
            return dt;
        }

        public static void BLLDelete(int id)
        {
            DALAdmin.DALDelete(id);
        }

        public static string[] BLLGetUser(int id)
        {
            string[] userinfo = DALAdmin.DALGetUser(id);
            return userinfo;
        }

        public static string BLLUpdateUser(int id, string name, string surname, string username, string password, int permission, string securitycode)
        {
            string update;
            if (name == "" || surname == "" || username == "" || password == "" || securitycode == "")
            {
                update = "NullError";
                return update;
            }
            else
            {
                update = DALAdmin.DALUpdateUser(id, name, surname, username, password, permission, securitycode);
                return update;
            }
        }

        public static string BLLNewUser(string name, string surname, string username, string password, int permission, string securitycode)
        {
            bool alreadyhave = DALAdmin.DALNewUserAlreadyHave(username);
            string update;

            if (alreadyhave == true)
            {
                update = "AlreadyError";
                return update;
            }
            else
            {
                if (name == "" || surname == "" || username == "" || password == "" || securitycode == "")
                {
                    update = "NullError";
                    return update;
                }
                else
                {
                    update = DALAdmin.DALNewUser(name, surname, username, password, permission, securitycode);
                    return update;
                }
            }
        }

        public static string BLLNewAdmin(string name, string surname, string username, string password, string securitycode)
        {
            bool alreadyhave = DALAdmin.DALNewAdminAlreadyHave(username);
            string update;

            if (alreadyhave == true)
            {
                update = "AlreadyError";
                return update;
            }
            else
            {
                if (name == "" || surname == "" || username == "" || password == "" || securitycode == "")
                {
                    update = "NullError";
                    return update;
                }
                else
                {
                    update = DALAdmin.DALNewAdmin(name, surname, username, password, securitycode);
                    return update;
                }
            }
        }
    }
}
