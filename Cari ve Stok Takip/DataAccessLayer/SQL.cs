using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class SQL
    {
        public static SqlConnection connection()
        {
            SqlConnection sql = new SqlConnection("Data Source=.;Initial Catalog=db_CST;Integrated Security=True");
            sql.Open();
            return sql;
        }
    }
}
