using System.Drawing.Imaging;
using System.Globalization;
using System.Transactions;
using ArachNGIN.Files.Graphics;
using ArachNGIN.Files.Mime;
using ArachNGIN.Files.Streams;
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
using System.Management;
using System.Management.Instrumentation;
using SharpCompress.Archive;

namespace DiskSniffer.Forms
{
    public partial class DiskAdd : Form
    {
        public DiskAdd()
        {
            InitializeComponent();
        }

        private Media _currentMedia;

        public bool ScanDisk(string strPath, Media media)
        {
            Program.Konzole.Write("Disk Scan: " + strPath);
            string[] filenames = Directory.GetFiles(strPath, "*.*", SearchOption.AllDirectories);
            //var mediaFiles = Program.Data.MediaFiles.ToList();
            var progress = new DlgProgress();
            progress.MaxProgress = filenames.Count();
            progress.ProgressFormat = "Scanning disk... {0} of {1} files processed.";
            progress.Show();
            foreach (string filename in filenames)
            {
                var fi = new FileInfo(filename);
                var mf = new MediaFile();
                mf.Name = fi.Name;
                mf.Path = fi.DirectoryName.Replace(strPath, string.Empty);
                mf.Media = media;
                mf.Size = fi.Length;
                mf.MimeType = GetMimeTypeFromExtension.GetMimeType(filename);
                Program.Konzole.Write("Disk Scan: Adding " + StringUtils.NoSlashesOnEnds(mf.Path + "\\" + mf.Name));
                switch (fi.Extension.ToLower())
                {
                    case ".7z":
                    case ".rar":
                    case ".zip":
                        mf.Type = MediaFileType.ArchiveParent;
                        if (chkScanArchives.Checked) ScanArchive(fi.FullName, media, mf);
                        break;
                    case ".bmp":
                    case ".png":
                    case ".gif":
                    case ".jpeg":
                    case ".jpg":
                        mf.Type = MediaFileType.Image;
                        var imgdata = ScanImage(fi.FullName, media, mf);
                        Program.Data.ImageDatas.Add(imgdata);
                        break;
                    default:
                        mf.Type = MediaFileType.NormalFile;
                        break;
                }
                Program.Data.MediaFiles.Add(mf);
                progress.DoProgress();
            }
            Program.Konzole.Write("Validating...");
            Program.Data.Configuration.ValidateOnSaveEnabled = true;
            Program.Data.Configuration.AutoDetectChangesEnabled = true;
            //Program.Data.SaveChanges();
            progress.Close();
            Program.Konzole.Write("Disk Scan Finished");
            return true;
        }

        private static void ScanArchive(string strArchive, Media media, MediaFile parentFile)
        {
            var archive = ArchiveFactory.Open(strArchive);
            Program.Konzole.Write(string.Format("Archive Scan: {0} files, type: {1}", archive.Entries.Count(),archive.Type));
            var progress = new DlgProgress();
            progress.MaxProgress = archive.Entries.Count();
            progress.ProgressFormat = string.Format("Scanning Archive \"{0}\"... {1}",Path.GetFileName(strArchive), "{0} of {1} files processed.");
            progress.Show();
            Program.Data.Configuration.ValidateOnSaveEnabled = false;
            Program.Data.Configuration.AutoDetectChangesEnabled = false;
            foreach(var subFile in archive.Entries)
            {
                if(!subFile.IsDirectory)
                {
                    //Program.Konzole.WriteNoTime(subFile.FilePath);
                    var mf = new MediaFile
                                 {
                                     Media = media,
                                     Type = MediaFileType.InsideArchive,
                                     Name = Path.GetFileName(subFile.FilePath),
                                     Path =
                                         StringUtils.NoSlashesOnEnds(parentFile.Path + "\\" + parentFile.Name + "\\" +
                                                                     Path.GetDirectoryName(subFile.FilePath).Replace(
                                                                         "/", "\\")),
                                     Size = subFile.Size,
                                     MimeType = GetMimeTypeFromExtension.GetMimeType(subFile.FilePath)
                                 };
                    //Path.GetDirectoryName(parentFile.Path + parentFile.Name + "\\" + subFile.FilePath);
                    Program.Data.MediaFiles.Add(mf);
                }
                progress.DoProgress();
                Application.DoEvents();
            }
            progress.Close();
            Program.Data.Configuration.ValidateOnSaveEnabled = true;
            Program.Data.Configuration.AutoDetectChangesEnabled = true;
            Application.DoEvents();
            //Program.Data.SaveChanges();
        }

        private static ImageData ScanImage(string strFile, Media media, MediaFile mediaFile)
        {
            var data = new ImageData {Media = media, MediaFile = mediaFile};
            var img = (Bitmap) Image.FromFile(strFile);
            data.ContentMimeType = GetMimeTypeFromContent.GetMimeType(strFile);
            Program.Konzole.Write("Image Scan: " + data.ContentMimeType);
            data.Width = img.Width;
            data.Height = img.Height;
            // zkouknout na velikost, pripadne zmensit na max 100x100;
            if (img.Width > 100 || img.Height > 100)
            {
                ImageResizer.ResizeImage(img, 100, 100);
            }
            data.Thumb = ByteArrayConverters.ImageToByteArray(img, ImageFormat.Jpeg);
            return data;
        }

        private static string GetHdSerialNumber(string drive)
        {
            var disk = new
                ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            return disk.Properties["VolumeSerialNumber"].Value.ToString();
        }
        private static string GetHdLabel(string drive)
        {
            var disk = new
                ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            return disk.Properties["VolumeName"].Value.ToString();
        }

        private void BtnScanMediaClick(object sender, EventArgs e)
        {
            if (dlgScanPath.ShowDialog() != DialogResult.OK) return;
            txtMediaPath.Text = dlgScanPath.SelectedPath;
            var volume = Directory.GetDirectoryRoot(dlgScanPath.SelectedPath)[0].ToString(CultureInfo.InvariantCulture);
            txtSerialNumber.Text = GetHdSerialNumber(volume);
            txtDiskName.Text = GetHdLabel(volume);
        }

        private void BtnScanClick(object sender, EventArgs e)
        {
            ScanDisk(txtMediaPath.Text, _currentMedia);
        }

        /// <summary>
        /// Vyvolá tento dialog
        /// </summary>
        /// <returns>výsledek</returns>
        public DialogResult Execute()
        {
            //var scope = new TransactionScope(TransactionScopeOption.Required);
            _currentMedia = new Media();
            _currentMedia = Program.Data.Medias.Add(_currentMedia);
            var dr = ShowDialog();
            if(DialogResult==DialogResult.OK)
            {
                _currentMedia.Name = txtDiskName.Text;
                _currentMedia.Type = (MediaType)comboBox1.SelectedIndex;
                _currentMedia.Created = dtpCreated.Value.Date;
                Program.Data.SaveChanges();
                //scope.Complete();
            }
            else
            {
                Program.Data=new DataContext();
                //Program.Data.SaveChanges();
                //scope.Dispose();
            }
            return dr;
        }
    }
}
