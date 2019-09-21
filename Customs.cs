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
    public partial class Customs : Form
    {
        public Customs()
        {
            InitializeComponent();
        }

        private void Customs_Load(object sender, EventArgs e)
        { 
            
            numericUpDown1.Controls[0].Visible = false;
            numericUpDown2.Controls[0].Visible = false;
            numericUpDown3.Controls[0].Visible = false;
            //numericUpDown1.Value = 100;
            numericUpDown1.Minimum = 10;
            numericUpDown1.Maximum = 999;
            numericUpDown2.Minimum = 10;
            numericUpDown2.Maximum = 999;
            numericUpDown3.Minimum = 100;
            numericUpDown3.Maximum = 99999;
           // numericUpDown1.Maximum = 9999;

            CustomsQueries q = new CustomsQueries();
            q.displayAwaiting(listView1);
            q.displayApproved(listView2);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            int price = int.Parse(numericUpDown1.Value.ToString()) * int.Parse(numericUpDown3.Value.ToString());
            label6.Text = "Total Price : " + price+ " r.s";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != String.Empty && checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                {
                    int shipnum = int.Parse(listView1.SelectedItems[0].Text);
                    string goods = listView1.SelectedItems[0].SubItems[1].Text;
                    int container = int.Parse(numericUpDown2.Value.ToString());
                    int weight = int.Parse(numericUpDown3.Value.ToString());
                    string agentn = listView1.SelectedItems[0].SubItems[3].Text;
                    int totprice = int.Parse(numericUpDown1.Value.ToString()) * int.Parse(numericUpDown3.Value.ToString());
                    CustomsQueries q = new CustomsQueries();
                    q.addRecord(shipnum, goods, container, weight, agentn, totprice, DateTime.Now.ToShortDateString());
                    q.addIntoWarehouse(shipnum, goods, container, weight, totprice, DateTime.Now.ToShortDateString());
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                numericUpDown1.Value = numericUpDown1.Minimum;
                numericUpDown2.Value = numericUpDown2.Minimum;
                numericUpDown3.Value = numericUpDown3.Minimum;
                CustomsQueries q = new CustomsQueries();
                q.displayApproved(listView2);
                q.displayAwaiting(listView1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int price = int.Parse(numericUpDown1.Value.ToString()) * int.Parse(numericUpDown3.Value.ToString());
            label6.Text = "Total Price : " + price + " r.s";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].Text;
        }
    }
}
