using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace DocksManagementSystem
{
    class Sqlqueries
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-396O81C\\SQLSERVER;Initial Catalog=Docks;Integrated Security=True");
        SqlCommand cmd;
        public void addEmp(string n, string fn, string age, string con, string doj, string wt, string exp, string add, string rem)
        {
            cmd = new SqlCommand("INSERT INTO First (Name,FatherName,Age,Contact,DateOfJoin,WorkType,Experience,Address,Remarks) values ('" + n+"','"+fn+"','"+age+"','"+con+"','"+doj+"','"+wt+"','"+exp+"','"+add+"','"+rem+"')",this.con);
            this.con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Hired","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.con.Close();
        }
        public void displayEmp(ListView a)
        {   
            a.Items.Clear();
            cmd = new SqlCommand("SELECT * FROM First", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListViewItem lv = new ListViewItem(rd[0].ToString());
                lv.SubItems.Add(rd[3].ToString());
                lv.SubItems.Add(rd[5].ToString());
                lv.SubItems.Add(rd[4].ToString());
                lv.SubItems.Add(rd[7].ToString());
                a.Items.Add(lv);
            }
            con.Close();
        }
        public void deleteEmp(string name)
        {
            cmd = new SqlCommand("Delete FROM First Where Name = '" + name+"'",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateEmp(string n, string fn, string age, string con, string doj, string wt, string exp, string add, string rem)
        {
            cmd = new SqlCommand("UPDATE First SET FatherName='" + fn+"',Age='"+age+"',Contact='"+con+"',DateOfJoin='"+doj+"',WorkType='"+wt+"',Experience='"+exp+"',Address='"+add+"',Remarks='"+rem+"' Where Name='"+n+"'",this.con);
            this.con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Info Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.con.Close();
        }

        
        public void InsertShip(int num, string type, string cont, string status,string name,string address,string gender,string comments)
        {
            cmd = new SqlCommand("Insert into Ship (Number,Type,Container,Status,Name,Address,Gender,Comments) values (@num,@type,@cont,@status,@name,@address,@gender,@comments)",con);
            cmd.Parameters.AddWithValue("@num",num);
            cmd.Parameters.AddWithValue("@type",type);
            cmd.Parameters.AddWithValue("@cont", cont);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@comments", comments);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Added!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void displayShip(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("Select * from Ship",con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListViewItem lv = new ListViewItem(rd[0].ToString());
                lv.SubItems.Add(rd[1].ToString());
                lv.SubItems.Add(rd[2].ToString());
                lv.SubItems.Add(rd[3].ToString());
                lv.SubItems.Add(rd[4].ToString());
                lv.SubItems.Add(rd[5].ToString());
                lv.SubItems.Add(rd[6].ToString());
                lv.SubItems.Add(rd[7].ToString());
                a.Items.Add(lv);
            }
            con.Close();

            for (int i = 0; i < a.Items.Count; i++)
            {
                if (a.Items[i].SubItems[3].Text == "Available")
                {
                    a.Items[i].BackColor = Color.Yellow;
                }
                else if (a.Items[i].SubItems[3].Text == "Need Repairing")
                {
                    a.Items[i].BackColor = Color.Red;
                }
                else if (a.Items[i].SubItems[3].Text == "Not Available")
                {
                    a.Items[i].BackColor = Color.Orange;
                }
            }
        }
        public void deleteShip(int num)
        {
            cmd = new SqlCommand("Delete from Ship where Number = "+num,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void updateShip(int num, string type, string cont, string status, string name, string address, string gender, string comments)
        {
            cmd = new SqlCommand("Update Ship set Type = @type, Container = @cont, Status = @status, Name = @name, Address = @address, Gender = @gender, Comments = @comments Where Number = @num", con);
            cmd.Parameters.AddWithValue("@num", num);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@cont", cont);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@comments", comments);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public void comboCountries(ComboBox a)
        {
            cmd = new SqlCommand("Select * from Permissions Where Permission = 'Allowed'",con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a.Items.Add(rd["Name"].ToString());
            }
            con.Close();
        }

        public void comboGoods(ComboBox b)
        {
            cmd = new SqlCommand("Select * from Goods", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                b.Items.Add(rd[1].ToString());
            }
            con.Close();
        }

        
    }
}