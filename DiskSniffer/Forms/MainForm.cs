using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiskSniffer.Database;

namespace DiskSniffer.Forms
{
    public partial class MainForm : Form
    {
        public sqlite DB = new sqlite(Program.ATemp.AppDir + sqlite.f_DataFile);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiskNew disknew = new DiskNew();
            disknew.ShowDialog();
        }
    }
}
