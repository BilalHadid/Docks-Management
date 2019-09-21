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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            label1.Visible = false;
            LoginQueries a = new LoginQueries();
            a.Displaydb(listView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Sqlqueries a = new Sqlqueries();
            //a.addMessage(richTextBox1.Text,comboBox1.Text,dateTimePicker1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox1.Clear();
            //comboBox1.SelectedIndex = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            this.IsMdiContainer = true;
            LoginMessage a = new LoginMessage();
            a.MdiParent = this;
            a.Show();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            this.IsMdiContainer = false;
            listView1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label1.Visible = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            this.IsMdiContainer = false;
            listView1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == textBox3.Text && textBox2.Text != "" && textBox1.Text != "")
                {
                    LoginQueries a = new LoginQueries();
                    a.Insertdb(textBox1.Text, textBox2.Text, comboBox1.Text);
                    a.Displaydb(listView1);
                    button2_Click(sender, e);
                }

                if (textBox1.Text == String.Empty || textBox2.Text == String.Empty)
                {
                    MessageBox.Show("Please fill required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            if (textBox2.Text == textBox3.Text)
            {
                label5.Text = "\u221A";
                label5.ForeColor = Color.Green;
            }
            else
            {
                label5.Text = "X";
                label5.ForeColor = Color.Red;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                 textBox1.Text = listView1.SelectedItems[0].Text;
                 textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                 textBox3.Text = listView1.SelectedItems[0].SubItems[1].Text;
                 comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                MessageBox.Show("Select an Entry from List to Fill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text == textBox3.Text)
                {
                    LoginQueries a = new LoginQueries();
                    a.Updatedb(textBox1.Text, textBox2.Text, comboBox1.Text);
                    a.Displaydb(listView1);
                    button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Select an Entry from List to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Check it again!");
            }
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3_TextChanged(sender,e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}