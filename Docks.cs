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
    public partial class Docks : Form
    {
        int totship;
        int availship;
        int needrepairship;
        int notavailship;
        public Docks()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.ReadOnly = false;
                Sqlqueries a = new Sqlqueries();
                a.displayShip(listView1);
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox4.SelectedIndex = 0;
                comboBox5.Text = "";
                richTextBox1.Clear();
                Docks_Load(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please Put Some Text Box");
            }
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Government")
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                comboBox5.Enabled = false;
                richTextBox1.Enabled = false;
            }
            else
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox5.Enabled = true;
                richTextBox1.Enabled = true;
            }
        }

        private void Docks_Load(object sender, EventArgs e)
        {

            comboBox4.SelectedIndex = 0;
            Sqlqueries a = new Sqlqueries();
            a.displayShip(listView1);
            a.comboGoods(comboBox2);
            toolStripStatusLabel4.Text = "Date : " + DateTime.Now.ToLongDateString();
            // Status Strip Counts
            totship = 0;
            availship = 0;
            needrepairship = 0;
            notavailship = 0;

             
            
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                totship++;
                if (listView1.Items[i].SubItems[3].Text == "Available")
                {
                    availship++;
                }
                else if (listView1.Items[i].SubItems[3].Text == "Need Repairing")
                {
                    needrepairship++;
                }
                else if (listView1.Items[i].SubItems[3].Text == "Not Available")
                {
                    notavailship++;
                }
                
            }
            toolStripStatusLabel1.Text = "Total : "+totship;
            toolStripStatusLabel2.Text = "Available : " + availship;
            toolStripStatusLabel3.Text = "Need Repairing : "+needrepairship;
            toolStripStatusLabel5.Text = "Not Available : "+notavailship;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != String.Empty)
                {
                    Sqlqueries a = new Sqlqueries();
                    a.InsertShip(int.Parse(textBox1.Text), comboBox1.Text, comboBox2.Text, comboBox4.Text, textBox3.Text, richTextBox1.Text, comboBox5.Text, textBox4.Text);
                    a.displayShip(listView1);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                
                textBox1.ReadOnly = true;
                textBox1.Text = listView1.SelectedItems[0].Text;
                comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                comboBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
                comboBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
                richTextBox1.Text = listView1.SelectedItems[0].SubItems[5].Text;
                comboBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
                textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            }
            else
            {
                MessageBox.Show("Select a field to Fill","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        Sqlqueries a = new Sqlqueries();
                        a.deleteShip(int.Parse(listView1.SelectedItems[0].Text));
                        a.displayShip(listView1);
                    }
                    else
                    {
                        MessageBox.Show("Select a field to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
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
                if (listView1.SelectedItems.Count > 0 && textBox1.Text != String.Empty)
                {
                    Sqlqueries a = new Sqlqueries();
                    a.updateShip(int.Parse(textBox1.Text), comboBox1.Text, comboBox2.Text, comboBox4.Text, textBox3.Text, richTextBox1.Text, comboBox5.Text, textBox4.Text);
                    a.displayShip(listView1);
                    Docks_Load(sender, e);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}