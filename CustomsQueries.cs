using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DocksManagementSystem
{
    class CustomsQueries : Connection
    {
        public void addRecord(int num, string goods, int cont, int weight, string agentn, int totp, string date)
        {
            cmd = new SqlCommand("Insert into Customs (ShipNumber, Goods, Containers, Weight, AgentName, TotalPrice,Date) values (@num,@goods,@cont,@weight,@agentn,@totp,@date)",con);
            SqlCommand cmd1 = new SqlCommand("Update Ship set Status = 'Available' where Number = @num",con);
            SqlCommand cmd2 = new SqlCommand("Update Arrival set Status = 'Approved' where ShipNumber = @num",con);
            cmd1.Parameters.AddWithValue("@num",num);
            cmd2.Parameters.AddWithValue("@num",num);
            cmd.Parameters.AddWithValue("@num",num);
            cmd.Parameters.AddWithValue("@goods", goods);
            cmd.Parameters.AddWithValue("@cont", cont);
            cmd.Parameters.AddWithValue("@weight", weight);
            cmd.Parameters.AddWithValue("@agentn", agentn);
            cmd.Parameters.AddWithValue("@totp", totp);
            cmd.Parameters.AddWithValue("@date",date);
            OpenCon();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            //cmd3.ExecuteNonQuery();
            CloseCon();
            MessageBox.Show("Approved");
        }
        public void displayAwaiting(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("Select * from Arrival where Status = 'Awaiting Customs'",con);
            OpenCon();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListViewItem lv = new ListViewItem(rd["ShipNumber"].ToString());
                lv.SubItems.Add(rd["Goods"].ToString());
                lv.SubItems.Add(rd["Status"].ToString());
                lv.SubItems.Add(rd["AgentName"].ToString());
                a.Items.Add(lv);
            }
            CloseCon();
        }
        public void displayApproved(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("Select * from Customs", con);
            OpenCon();
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
                a.Items.Add(lv);
            }
            CloseCon();
        }
        public void addIntoWarehouse(int num, string goods, int cont, int weight, int totp, string date)
        {
            cmd = new SqlCommand("Insert into Warehouse (ShipNumber,Goods,Containers,Weight,TotalPrice,Status,Date) values (@num,@goods,@cont,@weight,@totp,'Stored',@date)", con);
            cmd.Parameters.AddWithValue("@num", num);
            cmd.Parameters.AddWithValue("@goods", goods);
            cmd.Parameters.AddWithValue("@cont", cont);
            cmd.Parameters.AddWithValue("@weight", weight);
            cmd.Parameters.AddWithValue("@totp", totp);
            cmd.Parameters.AddWithValue("@date", date);
            OpenCon();
            cmd.ExecuteNonQuery();
            CloseCon();
           // MessageBox.Show("Warehouse Added");
        }
    }
}
