using DiskSniffer.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskSniffer.Forms
{
    public partial class DiskAdd : Form
    {
        public DiskAdd()
        {
            InitializeComponent();
        }

        public bool ScanDisk(string strPath, Media media)
        {
            string[] filenames = Directory.GetFiles(strPath, "*.*", SearchOption.AllDirectories);
            foreach (string filename in filenames)
            {
                var fi = new FileInfo(filename);

            }
            return true;
        }
    }
}
