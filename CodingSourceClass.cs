using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainClass
{
    public class CodingSourceClass
    {
        public static int temp = 1;

        public static void ShowWindow(Form openwin, Form closewin, Form MDIwin)
        {
            closewin.Close();

            openwin.MdiParent = MDIwin;

            openwin.WindowState = FormWindowState.Maximized;

            openwin.Show();
        }

        public static void ShowWindow(Form openwin, Form MDIwin)
        {
            try
            {
                openwin.MdiParent = MDIwin;

                openwin.WindowState = FormWindowState.Maximized;

                openwin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void ShowMsg(string msg, string type)
        {
            if (type == "success")
            {
                MessageBox.Show(msg, type, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(msg, type, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static string s;

        public static string connection()
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            s = File.ReadAllText(path + "\\connect");

            return s;

        }

    }
}
