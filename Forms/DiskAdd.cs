using System.Drawing.Imaging;
using ArachNGIN.Files.Graphics;
using ArachNGIN.Files.Mime;
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
            Program.Konzole.Write("Disk Scan: " + strPath);
            string[] filenames = Directory.GetFiles(strPath, "*.*", SearchOption.AllDirectories);
            //var mediaFiles = Program.Data.MediaFiles.ToList();
            foreach (string filename in filenames)
            {
                var fi = new FileInfo(filename);
                var mf = new MediaFile();
                mf.Name = fi.Name;
                mf.Path = fi.DirectoryName.Replace(strPath, string.Empty);
                mf.Media = media;
                mf.Size = fi.Length;
                mf.MimeType = GetMimeTypeFromExtension.GetMimeType(filename);
                switch (fi.Extension.ToLower())
                {
                    case ".7z":
                    case ".rar":
                    case ".zip":
                        mf.Type = MediaFileType.ArchiveParent;
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
                Program.Konzole.Write("Disk Scan: Added " + mf.Path + "\\" + mf.Name);
                Program.Data.MediaFiles.Add(mf);
            }
            Program.Data.SaveChanges();
            MessageBox.Show("a");
            Program.Konzole.Write("Disk Scan Finished");
            return true;
        }

        private ImageData ScanImage(string strFile, Media media, MediaFile mediaFile)
        {
            
            var data = new ImageData {Media = media, MediaFile = mediaFile};
            var img = (Bitmap) Image.FromFile(strFile);
            data.MimeType = GetMimeTypeFromContent.GetMimeType(strFile);
            Program.Konzole.Write("Image Scan: " + data.MimeType);
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

        private void Button1Click(object sender, EventArgs e)
        {
            ScanDisk(@"c:\x", new Media());
        }
    }
}
