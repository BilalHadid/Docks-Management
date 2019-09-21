using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DocksManagementSystem
{
    public partial class Employee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Docks;Integrated Security=True");
        public Employee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Name",150,HorizontalAlignment.Left);
            listView1.Columns.Add("Contact", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Work Type", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Date Of Join", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Address", 200, HorizontalAlignment.Left);

            Sqlqueries a = new Sqlqueries();
            a.displayEmp(listView1);

            comboBox1.SelectedIndex = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != String.Empty && comboBox1.Text != String.Empty && textBox3.Text != String.Empty && richTextBox1.Text != String.Empty)
                {
                    Sqlqueries a = new Sqlqueries();
                    a.addEmp(textBox1.Text, textBox10.Text, textBox9.Text, textBox3.Text, dateTimePicker1.Text, comboBox1.Text, textBox8.Text, richTextBox1.Text, textBox5.Text);
                    button7_Click(sender, e);
                    a.displayEmp(listView1);
                }

                else
                {
                    MessageBox.Show("Please fill required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            
            Sqlqueries a = new Sqlqueries();
            a.displayEmp(listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string name = listView1.SelectedItems[0].Text;
                textBox1.Enabled = false;
                SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeDetails WHERE Name = '"+name+"'",con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox10.Text = rd[1].ToString();
                    textBox9.Text = rd[2].ToString();
                    textBox3.Text = rd[3].ToString();
                    dateTimePicker1.Text = rd[4].ToString();
                    comboBox1.Text = rd[5].ToString();
                    textBox8.Text = rd[6].ToString();
                    richTextBox1.Text = rd[7].ToString();
                    textBox5.Text = rd[8].ToString();
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Select an Entry from List to Fill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    string name = listView1.SelectedItems[0].Text;
                    Sqlqueries a = new Sqlqueries();
                    a.deleteEmp(name);
                    button7_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Select an Entry from List to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (textBox1.Text != "")
                {
                    Sqlqueries a = new Sqlqueries();
                    a.updateEmp(textBox1.Text, textBox10.Text, textBox9.Text, textBox3.Text, dateTimePicker1.Text, comboBox1.Text, textBox8.Text, richTextBox1.Text, textBox5.Text);
                    button7_Click(sender, e);
                    a.displayEmp(listView1);
                }
                else
                {
                    MessageBox.Show("Select an Entry from List to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Enabled = true;
            textBox10.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Text = DateTime.Now.ToLongDateString().ToString();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
