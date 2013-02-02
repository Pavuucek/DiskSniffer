using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiskSniffer.DiskScanner;

namespace DiskSniffer.Forms
{
    public partial class DiskNew : Form
    {
        public DiskNew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiskScanner.DiskScanner.Scan(@"c:\x");
        }
    }
}
