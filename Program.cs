using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiskSniffer.DataModel;
using DiskSniffer.Forms;
namespace DiskSniffer
{
    static class Program
    {

        public static MainForm MainForm;
        public static DataContext Data = new DataContext();

        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm = new MainForm());
        }
    }
}
