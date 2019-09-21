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
    public partial class LoginMessage : Form
    {
        
        public LoginMessage()
        {
            InitializeComponent();
        }

        private void LoginMessage_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessagesQueries a = new MessagesQueries();
                a.addMessage(richTextBox1.Text, comboBox1.Text, dateTimePicker1.Text);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            comboBox1.SelectedIndex = 0;
        }
    }
}
