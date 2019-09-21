using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;

namespace DocksManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Width = this.Width;

            // Opacity
            label1.BackColor = Color.FromArgb(150,Color.Black);
            label1.ForeColor = Color.White;
            toolStrip1.BackColor = Color.FromArgb(230,SystemColors.Control);
            // ----

            //toolStrip1.BackColor = Color.FromArgb(200,Color.Black);
            //toolStrip1.ForeColor = Color.White;

            adminPanelToolStripMenuItem.Enabled = false;
            toolStripButton7.Visible = false;
            if (Login.type == "Admin")
            {
                adminPanelToolStripMenuItem.Enabled = true;
                toolStripButton7.Visible = true;
            }
            toolStripStatusLabel2.Text = "Logged in as : "+Login.user;
            toolStripStatusLabel3.Text = "Date : "+DateTime.Today.ToLongDateString().ToString();
            toolStripStatusLabel4.Text = "Time : " + DateTime.Now.ToShortTimeString().ToString();

            MessagesQueries a = new MessagesQueries();
            string message = a.checkMessage(Login.type,DateTime.Now.ToLongDateString().ToString());
            if (message != "")
            {
                MessageBox.Show(message,"TODAY's Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            timer1.Start();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = "Time : "+DateTime.Now.ToShortTimeString().ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your work has been Saved!","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?","Confimation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           
                Employee emp = new Employee();
                emp.Show();
            
            
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                Employee emp = new Employee();
                emp.Show();
           
           
            
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.Show();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                AdminPanel a = new AdminPanel();
                a.Show();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private void adminPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AdminPanel a = new AdminPanel();
                a.Show();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Docks d = new Docks();
                d.Show();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private void shipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Docks d = new Docks();
                d.Show();
            
           
           
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
              
            
           
            
        }

        private void navalPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Permissions p = new Permissions();
                p.Show();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ArrivalDeparture ad = new ArrivalDeparture();
                ad.Show();
            }
            catch (Exception ex)
            {

                
            }
           

            //SpeechRecognitionEngine sr = new SpeechRecognitionEngine();

            //Grammar gr = new DictationGrammar();

            //sr.LoadGrammar(gr);

            
            //    toolStrip1.Text = "Arrivals";
            //    sr.SetInputToDefaultAudioDevice();
            //    RecognitionResult result = sr.Recognize();
            //    toolStrip1.Text = result.Text;
            
        }

        private void arrivalsDepartureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ArrivalDeparture ad = new ArrivalDeparture();
                ad.Show();
            }
            catch (Exception ex)
            {

              
            }
           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Customs c = new Customs();
                c.Show();
            }
            catch (Exception ex)
            {

                
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Warehouse w = new Warehouse();
                w.Show();
            }
            catch (Exception ex)
            {


            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        { }
            //{
        //    SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        //    Choices c = new Choices();
        //    c.Add("arrival");
        //    c.Add("departure");
        //    c.Add("docks");
        //    c.Add("warehouse");
        //    c.Add("permissions");
        //    c.Add("customs");
        //    c.Add("employee");
        //    c.Add("exit");


        //    GrammarBuilder gb = new GrammarBuilder(c);
        //    Grammar g = new DictationGrammar();
        //    rec.LoadGrammar(g);
        //    try
        //    {
        //        button1.Text = "Speak Now";
        //        rec.SetInputToDefaultAudioDevice();
        //        RecognitionResult result = rec.Recognize();
        //        string res = result.Text;
        //        button1.Text = res;
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        MessageBox.Show("Could not recognize input");
        //        throw;
        //    }
        //    finally
        //    {
        //        rec.UnloadAllGrammars();
        //    }

        //        rec.SpeechRecognized +=
        //            new EventHandler<SpeechRecognizedEventArgs>(sre_speechrecognized);

        //    }

        //    void sre_speechrecognized(object sender, SpeechRecognizedEventArgs e)
        //    {
        //        MessageBox.Show("Speech Recognized: " + e.Result.Text);
        //    }
        

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void todaysMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessagesQueries a = new MessagesQueries();
            string message = a.checkMessage(Login.type, DateTime.Now.ToLongDateString().ToString());
            if (message != "")
            {
                MessageBox.Show(message, "TODAY's Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void docksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Docks d = new Docks();
                d.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Warehouse w = new Warehouse();
                w.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about = "This Docks (Shipyard) Management System has been developed mainly for our project. \nThis Software includes many main features which u can find while running the program as well as some optional features like Admin Panel";
            MessageBox.Show(about,"About Software",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void aboutDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about = "This Software has been made by \n Bilal Hadid (03482091349)";
            MessageBox.Show(about,"About Developer",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void termsConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string terms = "Terms & Conditions of Software is : \nThis Software should not be copied on any third party site. \nCredits should be given to the original Developer if used elsewhere.";
            MessageBox.Show(terms, "Terms & Conditions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
