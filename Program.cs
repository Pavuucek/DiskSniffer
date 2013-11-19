using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArachNGIN.Components.Console;
using ArachNGIN.Components.Console.Misc;
using DiskSniffer.DataModel;
using DiskSniffer.Forms;
namespace DiskSniffer
{
    static class Program
    {

        public static MainForm MainForm;

        public static DataContext Data = new DataContext();//("providername=System.Data.SQLite;provider connection string='data source=.\\OurDatabase.db'");

        public static DebugConsole Konzole;

        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database.DefaultConnectionFactory = new System.Data.Entity.Infrastructure.SqlCeConnectionFactory(
                "System.Data.SqlServerCe.4.0",
                @".\",
                @"Data Source=.\db.sdf");

            Konzole = new DebugConsole
                          {
                              AutoSave = ConsoleAutoSave.OnLineAdd,
                              Caption = "Konzole",
                              EchoCommands = true,
                              ScreenLocation = ConsoleLocation.TopRight,
                              ProcessInternalCommands = true,
                              UsePlainView = true
                          };
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            Data.Database.CreateIfNotExists();
            Konzole.Show();
            Application.Run(MainForm = new MainForm());
        }
    }
}
