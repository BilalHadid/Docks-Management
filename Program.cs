using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DocksManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoadingScreen ls = new LoadingScreen();
            if (ls.ShowDialog() == DialogResult.OK)
            {
                Login form = new Login();
                if (form.ShowDialog() == DialogResult.OK)
                {

                    Application.Run(new MainForm());
                }
                else
                {
                    Application.Exit();
                }
            }


        }
    }
}
