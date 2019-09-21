using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace DocksManagementSystem
{
    class PermissionsQueries:Connection
    {
        public void addCountry(string name, string status)
        {
            cmd = new SqlCommand("Insert into Permissions (Name, Permission) values (@name,@status)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@status", status);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Country Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void updatePermissions(int id, string name, string status)
        {
            cmd = new SqlCommand("update Permissions set Name = @name , Permission = @status Where ID = " + id, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@status", status);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Status Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void deleteCountry(int id)
        {
            cmd = new SqlCommand("Delete from Permissions where ID = " + id, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Country Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void displayPermisisons(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("Select * from Permissions", con);
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

            for (int i = 0; i < a.Items.Count; i++)
            {
                if (a.Items[i].SubItems[2].Text == "Allowed")
                {
                    a.Items[i].BackColor = Color.Yellow;
                }
                else if (a.Items[i].SubItems[2].Text == "Forbid")
                {
                    a.Items[i].BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
