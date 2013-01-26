using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DiskSniffer.DiskScanner
{
    public static class DiskScanner
    {

        public static void Scan(string strPath)
        {
            string[] filenames = Directory.GetFiles(strPath, "*.*", SearchOption.AllDirectories);
            foreach (string filename in filenames)
            {
                FileInfo fi = new FileInfo(filename);
                MessageBox.Show(fi.Attributes.ToString());
            }
        }
    }
}