using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DocksManagementSystem
{
    class WarehouseQueries : Connection
    {
        public void displayWarehouse(ListView a)
        {
            a.Items.Clear();
            a.Refresh();
            cmd = new SqlCommand("Select * from Warehouse",con);
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
                lv.SubItems.Add(rd[7].ToString());
                lv.SubItems.Add(rd[8].ToString());
                a.Items.Add(lv);
            }
            CloseCon();
        }
        public void UpdateWarehouse(int id, string customername, string status)
        {
            cmd = new SqlCommand("Update Warehouse set CustomerName = @custn , Status = @status Where ID = "+id,con);
            cmd.Parameters.AddWithValue("@custn",customername);
            cmd.Parameters.AddWithValue("@status",status);
            OpenCon();
            cmd.ExecuteNonQuery();
            CloseCon();
            MessageBox.Show(status);
        }
    }
}
