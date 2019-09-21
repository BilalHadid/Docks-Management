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
    public partial class Login : Form
    {
        public static string type = "";
        public static string user = "";
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Login with Admin crediantials to retrieve Password","Forgot Password",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            LoginQueries a = new LoginQueries();
            type = a.checkType(textBox1.Text, textBox2.Text);
            if (a.checkLogin(textBox1.Text, textBox2.Text))
            {
                this.DialogResult = DialogResult.OK;
                user = textBox1.Text;
            }
            else
            {
                textBox2.Clear();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chkshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshowpass.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}