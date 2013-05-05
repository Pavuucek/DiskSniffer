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
            //var mediaFiles = Program.Data.MediaFiles.ToList();
            foreach (string filename in filenames)
            {
                var fi = new FileInfo(filename);
                var mf = new MediaFile();
                mf.FileName = fi.Name;
                mf.FilePath = fi.DirectoryName;
                mf.Media = media;
                Program.Data.MediaFiles.Add(mf);
            }
            Program.Data.SaveChanges();
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScanDisk(@"c:\x", new Media());
        }
    }
}
