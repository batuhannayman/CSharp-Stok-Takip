using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLUser
    {
        public static string BLLLogin(string username, string password)
        {
            if (username == "" || password == "")
            {
                return "NullError";
            }
            else
            {
                string login = DALUser.DALLogin(username, password);
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
                string password = DALUser.DALForgotPassword(name, surname, username, code);
                return password;
            }
        }
    }
}
