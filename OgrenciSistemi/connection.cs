using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciSistemi
{
    internal class connection
    {
        public SqlConnection sqlConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1F6TS0S\\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;Encrypt=False");
            conn.Open();
            return conn;
        }
    }
}
