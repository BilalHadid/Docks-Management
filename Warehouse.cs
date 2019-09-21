using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocksManagementSystem
{
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            WarehouseQueries q = new WarehouseQueries();
            q.displayWarehouse(listView2);

            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].SubItems[7].Text == "Sent to Auction")
                {
                    listView2.Items[i].BackColor = Color.OrangeRed;
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                WarehouseQueries q = new WarehouseQueries();
                int id = int.Parse(listView2.SelectedItems[0].Text);
                q.UpdateWarehouse(id, textBox1.Text, "Delivered");
                q.displayWarehouse(listView2);
                Warehouse_Load(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    WarehouseQueries q = new WarehouseQueries();
                    int id = int.Parse(listView2.SelectedItems[0].Text);
                    q.UpdateWarehouse(id, "", "Sent to Auction");
                    q.displayWarehouse(listView2);
                    Warehouse_Load(sender, e);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
