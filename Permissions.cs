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
    public partial class Permissions : Form
    {
        int tot;
        int allowed;
        int forbid;
        public Permissions()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Permissions_Load(object sender, EventArgs e)
        {
            PermissionsQueries a = new PermissionsQueries();
            a.displayPermisisons(listView1);
            allowed = 0;
            forbid = 0;
            tot = 0;
            
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                tot++;
                if (listView1.Items[i].SubItems[2].Text == "Allowed")
                {
                    allowed++;
                }
                else if (listView1.Items[i].SubItems[2].Text == "Forbid")
                {
                    forbid++;
                }
            }
            toolStripStatusLabel1.Text = "Allowed : " + allowed;
            toolStripStatusLabel2.Text = "Forbid : " + forbid;
            toolStripStatusLabel3.Text = "Total : " + tot;
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PermissionsQueries a = new PermissionsQueries();
                string ask = "can";
                if (textBox1.Text != String.Empty)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (textBox1.Text == listView1.Items[i].SubItems[1].Text)
                        {
                            ask = "can not";
                            MessageBox.Show("Entry can not be same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                    if (ask == "can")
                    {
                        a.addCountry(textBox1.Text, comboBox1.Text);
                        a.displayPermisisons(listView1);
                        Permissions_Load(sender, e);
                    }

                }
            }
            catch (Exception ex)
            {

              
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(listView1.SelectedItems[0].Text);
                PermissionsQueries a = new PermissionsQueries();
                a.updatePermissions(id, textBox1.Text, comboBox1.Text);
                a.displayPermisisons(listView1);
                Permissions_Load(sender, e);
            }
            catch (Exception ex)
            {

               
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(listView1.SelectedItems[0].Text);
                PermissionsQueries a = new PermissionsQueries();
                a.deleteCountry(id);
                a.displayPermisisons(listView1);
                Permissions_Load(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                comboBox1.SelectedIndex = 0;
                listView1.Items.Clear();
                listView1.Refresh();
                PermissionsQueries a = new PermissionsQueries();
                a.displayPermisisons(listView1);

                Permissions_Load(sender, e);
            }
            catch (Exception ex)
            {

                
            }
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                    comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
