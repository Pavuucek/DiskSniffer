namespace DiskSniffer.DataModel
{
    /// <summary>
    /// Ur�uje typ souboru
    /// </summary>
    public enum MediaFileType
    {
        /// <summary>
        /// Norm�ln� soubor jako ka�d� jin�.
        /// </summary>
        NormalFile,
        /// <summary>
        /// Archiv (zip, rar, 7z, atd.)
        /// Projdeme ho cel�.
        /// </summary>
        Archive,
        /// <summary>
        /// Obr�zek.
        /// Ulo��me n�hled.
        /// </summary>
        Image
    }
}