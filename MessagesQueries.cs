using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DocksManagementSystem 
{
    class MessagesQueries:Connection
    {
        public void addMessage(string m, string to, string d)
        {
            cmd = new SqlCommand("INSERT INTO Messages (Message,ToDeliver,Date) values ('" + m + "','" + to + "','" + d + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Message Sent");
           // count++;
        }
        public string checkMessage(string type, string date)
        {
            if (type == "Admin")
            {
                cmd = new SqlCommand("SELECT Messages.Message FROM Messages WHERE ToDeliver = 'Admin' OR ToDeliver = 'Everyone' AND Date = '" + date + "'", con);
            }
            else
            {
                cmd = new SqlCommand("SELECT Messages.Message FROM Messages WHERE ToDeliver = 'Staff' OR ToDeliver = 'Everyone' AND Date = '" + date + "'", con);
            }
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            string message = "";
            while (rd.Read())
            {
                message = rd[0].ToString();
            }
            con.Close();
            return message;
        }
    }
}
