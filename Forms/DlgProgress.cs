using System;
using System.Windows.Forms;

namespace DiskSniffer.Forms
{
    /// <summary>
    /// Formulář na zobrazování průběhu operací
    /// </summary>
    public partial class DlgProgress : Form
    {
        /// <summary>
        /// konstruktor
        /// </summary>
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

        /// <summary>
        /// Maximální hodnota průběhu
        /// </summary>
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

        /// <summary>
        /// Současný stupeň průběhu
        /// </summary>
        public int CurrentProgress
        {
            get { return progBar.Value; }
            set { progBar.Value = value; }
        }

        /// <summary>
        /// Posune průběh o 1
        /// </summary>
        public void DoProgress()
        {
            progBar.PerformStep();
            lblStatus.Text = string.Format(_progressFormat, progBar.Value, progBar.Maximum);
            Application.DoEvents();
        }

        private string _progressFormat;

        /// <summary>
        /// Řetězec co se bude zobrazovat jako popisek
        /// </summary>
        public string ProgressFormat
        {
            get { return _progressFormat; }
            set { _progressFormat = value; }
        }
    }
}
