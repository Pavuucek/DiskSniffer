using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArachNGIN.Files.Streams;
using DiskSniffer.DataModel;

namespace DiskSniffer.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RefreshMainData()
        {
            lsbMedias.DataSource = Program.Data.Medias.ToList();
            lsbMedias.ValueMember = "MediaId";
            lsbMedias.DisplayMember = "Name";
        }

        private void AddToolStripMenuItemClick(object sender, EventArgs e)
        {
            var diskAdd = new DiskAdd();
            diskAdd.Execute();
            //RefreshMainData();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            RefreshMainData();
        }

        private void lsbMedias_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lsbMedias.SelectedValue == null) return;
            if (!(lsbMedias.SelectedValue is long)) return; // proc proboha c# neumi operator "is not" srsly wtf?
            MessageBox.Show(lsbMedias.SelectedValue.ToString());
            lstFiles.Nodes.Clear();
            var mediafiles = Program.Data.MediaFiles.ToList();
            var filelist = from l in Program.Data.MediaFiles
                           where l.Media.MediaId == (long)lsbMedias.SelectedValue
                           select l;
            var pathlist = new List<string>();
            foreach (var m in filelist)
            {
                pathlist.Add(StringUtils.NoStartingSlash(m.Path + "\\" + m.Name));
            }
            StringUtils.PopulateTreeViewByFiles(lstFiles, pathlist, '\\');
        }

    }
}
