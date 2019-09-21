using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;

namespace DocksManagementSystem
{
    class Connection
    {
       protected SqlConnection con = new SqlConnection("Data Source=DESKTOP-396O81C\\SQLSERVER;Initial Catalog=Docks;Integrated Security=True");
       protected SqlCommand cmd;

        public void OpenCon()
        {
            con.Open();
        }
        public void CloseCon()
        {
            con.Close();
        }
    }
}
