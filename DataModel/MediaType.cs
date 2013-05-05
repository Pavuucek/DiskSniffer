namespace DiskSniffer.DataModel
{
    /// <summary>
    /// Urèuje typ média
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// standardní nízkokapacitní placka datová
        /// </summary>
        DataCd,
        /// <summary>
        /// standardní nízkokapacitní placka s muzikou
        /// </summary>
        AudioCd,
        /// <summary>
        /// standardní nízkokapacitní placka s filmem
        /// </summary>
        VideoCd,
        /// <summary>
        /// standardní nebo dvouvrstvá støednìkapacitní placka
        /// </summary>
        Dvd,
        /// <summary>
        /// vícekapacitní placka modrolejzrová
        /// </summary>
        BluRay,
        /// <summary>
        /// mrtvý format.
        /// </summary>
        HdDvd,
        /// <summary>
        /// disk polovodièový
        /// </summary>
        FlashDisk,
        /// <summary>
        /// disk toèicí :-)
        /// </summary>
        HardDisk
    }
}