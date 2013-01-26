using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiskSniffer.Forms;
using ArachNGIN.Files;
namespace DiskSniffer
{
    static class Program
    {
        /// <summary>
        /// TempManager
        /// </summary>
        public static TempManager ATemp = new TempManager();
        /// <summary>
        /// Pak Filesystem
        /// </summary>
        public static QuakePAKFilesystem PakFS;

        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PakFS = new QuakePAKFilesystem(ATemp.AppDir, ATemp.AppTempDir);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
