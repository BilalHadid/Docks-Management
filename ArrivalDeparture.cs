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
    public partial class ArrivalDeparture : Form
    {
        public ArrivalDeparture()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void ArrivalDeparture_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 10;
            numericUpDown1.Maximum = 999;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(15);

            ArrivalDepartureQueries q = new ArrivalDepartureQueries();
            q.comboShip(comboBox1);
            q.comboCountries(comboBox2);
            q.comboCaptain(comboBox4);
            q.displayRecord(listView1);
            q.displayArrival(listView2);
        }
        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.Text != String.Empty && textBox1.Text != String.Empty && comboBox2.Text != String.Empty)
                {
                    ArrivalDepartureQueries q = new ArrivalDepartureQueries();
                    q.addRecord(int.Parse(comboBox1.Text), comboBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text, comboBox3.Text, textBox1.Text, int.Parse(numericUpDown1.Value.ToString()), comboBox4.Text);
                    button5_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Please fill all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != String.Empty)
                {
                    ArrivalDepartureQueries q = new ArrivalDepartureQueries();
                    q.markArrived(int.Parse(textBox3.Text), dateTimePicker3.Text, textBox2.Text, comboBox6.Text, textBox4.Text);
                    button5_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    MessageBox.Show("Please fill required fields below", "Ship arrived", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox3.Text = listView1.SelectedItems[0].Text;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ArrivalDepartureQueries q = new ArrivalDepartureQueries();
            q.displayRecord(listView1);
            q.displayArrival(listView2);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
