namespace DiskSniffer.DataModel
{
    public class MediaFile
    {
        public long MediaFileId { get; set; }
        public Media Media { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public MediaFileType Type { get; set; }
    }

    //public class ArchiveFile
}