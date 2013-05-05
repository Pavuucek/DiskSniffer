using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.SqlClient;
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

        public static DataContext Data = new DataContext();//("providername=System.Data.SQLite;provider connection string='data source=.\\OurDatabase.db'");
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm = new MainForm());
        }
    }
}
