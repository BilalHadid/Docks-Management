using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DocksManagementSystem
{
    class LoginQueries:Connection
    {
        public void Insertdb(string uname, string pw, string type)
        {
            cmd = new SqlCommand("INSERT INTO Login (UserName, Password, AccountType) values ('" + uname + "','" + pw + "','" + type + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("User ID Creation Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Updatedb(string uname, string pw, string type)
        {
            cmd = new SqlCommand("UPDATE Login set Password = '" + pw + "', AccountType = '" + type + "' where UserName = '" + uname + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Account has been Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Deletedb(string uname)
        {
            cmd = new SqlCommand("DELETE FROM Login Where UserName = '" + uname + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool checkLogin(string uname, string pass)
        {
            cmd = new SqlCommand("SELECT * from Login Where UserName = '" + uname + "' AND Password = '" + pass + "'", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                MessageBox.Show("INCORRECT LOGIN");
                return false;
            }

        }
        public string checkType(string u, string p)
        {
            cmd = new SqlCommand("SELECT Login.AccountType FROM Login WHERE UserName = '" + u + "' AND Password = '" + p + "'", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                string type = rd[0].ToString();
                con.Close();
                return type;
            }
            else
            {
                con.Close();
                return null;
            }
        }
        public void Displaydb(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("SELECT * FROM Login", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListViewItem lv = new ListViewItem(rd[0].ToString());
                lv.SubItems.Add(rd[1].ToString());
                lv.SubItems.Add(rd[2].ToString());
                a.Items.Add(lv);
            }
            con.Close();
        }

    }
}
