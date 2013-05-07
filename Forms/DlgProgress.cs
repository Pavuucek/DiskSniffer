using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskSniffer.Forms
{
    public partial class DlgProgress : Form
    {
        public DlgProgress()
        {
            InitializeComponent();
        }

        private void DlgProgressLoad(object sender, EventArgs e)
        {
            foreach (var form in Application.OpenForms)
            {
                if(form is DlgProgress && form!=this)
                {
                    StartPosition = FormStartPosition.Manual;
                    Top += Height+2;
                }
            }
            lblStatus.Text = string.Format(_progressFormat, progBar.Value, progBar.Maximum);
        }

        public int MaxProgress
        {
            get { return progBar.Maximum; }
            set
            {
                progBar.Minimum = 0;
                progBar.Maximum = value;
                progBar.Step = 1;
            }
        }

        public int CurrentProgress
        {
            get { return progBar.Value; }
            set { progBar.Value = value; }
        }

        public void DoProgress()
        {
            progBar.PerformStep();
            lblStatus.Text = string.Format(_progressFormat, progBar.Value, progBar.Maximum);
            Application.DoEvents();
        }

        private string _progressFormat;

        public string ProgressFormat
        {
            get { return _progressFormat; }
            set { _progressFormat = value; }
        }
    }
}
