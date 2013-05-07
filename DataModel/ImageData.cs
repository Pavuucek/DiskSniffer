namespace DiskSniffer.DataModel
{
    public class ImageData
    {
        public long ImageDataId { get; set; }
        public MediaFile MediaFile { get; set; }
        public Media Media { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContentMimeType { get; set; }
        public byte[] Thumb { get; set; }
    }
}