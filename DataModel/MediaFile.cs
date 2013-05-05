namespace DiskSniffer.DataModel
{
    public class MediaFile
    {
        public long MediaFileId { get; set; }
        public Media Media { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}