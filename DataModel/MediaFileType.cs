namespace DiskSniffer.DataModel
{
    /// <summary>
    /// Urèuje typ souboru
    /// </summary>
    public enum MediaFileType
    {
        /// <summary>
        /// Normální soubor jako každý jiný.
        /// </summary>
        NormalFile,
        /// <summary>
        /// Archiv (zip, rar, 7z, atd.)
        /// Projdeme ho celý.
        /// </summary>
        Archive,
        /// <summary>
        /// Obrázek.
        /// Uložíme náhled.
        /// </summary>
        Image
    }
}