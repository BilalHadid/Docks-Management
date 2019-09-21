using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DocksManagementSystem
{
    class ArrivalDepartureQueries : Connection
    {
        public void comboShip(ComboBox a)
        {
            cmd = new SqlCommand("Select Ship.Number from Ship Where Status = 'Available'",con);
            OpenCon();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a.Items.Add(rd["Number"].ToString());
            }
            CloseCon();
        }
        public void comboCountries(ComboBox a)
        {
            cmd = new SqlCommand("Select Permissions.Name from Permissions where Permission = 'Allowed'",con);
            OpenCon();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a.Items.Add(rd["Name"].ToString());
            }
            CloseCon();
        }
        public void comboCaptain(ComboBox a)
        {
            cmd = new SqlCommand("Select EmployeeDetails.Name from EmployeeDetails Where WorkType = 'Captain'",con);
            OpenCon();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a.Items.Add(rd["Name"].ToString());
            }
            CloseCon();
        }
        public void addRecord(int num, string expc, string depdate, string arrdate, string goods, string portn, int seamen, string captn)
        {
            cmd = new SqlCommand("Insert into Departure (ShipNumber,ExportCountry,DepartureDate,ExpectedArrival,Goods,PortName,SeaMen,CaptainName) values (@num,@expc,@depdate,@arrdate,@goods,@portn,@seamen,@captn)",con);
            SqlCommand cmd1 = new SqlCommand("Update Ship set Status = 'Departed' Where Number = @num1",con);
            cmd1.Parameters.AddWithValue("@num1",num);
            cmd.Parameters.AddWithValue("@num",num);
            cmd.Parameters.AddWithValue("@expc", expc);
            cmd.Parameters.AddWithValue("@depdate", depdate);
            cmd.Parameters.AddWithValue("@arrdate", arrdate);
            cmd.Parameters.AddWithValue("@goods", goods);
            cmd.Parameters.AddWithValue("@portn", portn);
            cmd.Parameters.AddWithValue("@seamen", seamen);
            cmd.Parameters.AddWithValue("@captn", captn);
            OpenCon();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            CloseCon();
            MessageBox.Show("Ship Departed","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void displayRecord(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("Select * from Departure",con);
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
                lv.SubItems.Add(rd[7].ToString());
                lv.SubItems.Add(rd[6].ToString());
                a.Items.Add(lv);
            }
            CloseCon();
        }
        public void markArrived(int num,string arrdate, string agentn, string goods, string portn)
        {
            cmd = new SqlCommand("Insert into Arrival (ShipNumber,ArrivalDate,AgentName,Goods,PortName,Status) values (@num,@arrdate,@agentn,@goods,@portn,'Awaiting Customs')",con);
            SqlCommand cmd1 = new SqlCommand("Update Ship set Status = 'Awaiting Customs' Where Number = @num",con);
            cmd1.Parameters.AddWithValue("@num",num);
            SqlCommand cmd2 = new SqlCommand("Delete from Departure where ShipNumber = @num",con);
            cmd2.Parameters.AddWithValue("@num",num);
            cmd.Parameters.AddWithValue("@num",num);
            cmd.Parameters.AddWithValue("@arrdate", arrdate);
            cmd.Parameters.AddWithValue("@agentn", agentn);
            cmd.Parameters.AddWithValue("@goods", goods);
            cmd.Parameters.AddWithValue("@portn", portn);
            OpenCon();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            CloseCon();
            MessageBox.Show("Ship Marked as Arrived!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void displayArrival(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("Select * from Arrival",con);
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
                a.Items.Add(lv);
            }
            CloseCon();
        }
    }
}
