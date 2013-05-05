namespace DiskSniffer.DataModel
{
    /// <summary>
    /// Ur�uje typ m�dia
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// standardn� n�zkokapacitn� placka datov�
        /// </summary>
        DataCd,
        /// <summary>
        /// standardn� n�zkokapacitn� placka s muzikou
        /// </summary>
        AudioCd,
        /// <summary>
        /// standardn� n�zkokapacitn� placka s filmem
        /// </summary>
        VideoCd,
        /// <summary>
        /// standardn� nebo dvouvrstv� st�edn�kapacitn� placka
        /// </summary>
        Dvd,
        /// <summary>
        /// v�cekapacitn� placka modrolejzrov�
        /// </summary>
        BluRay,
        /// <summary>
        /// mrtv� format.
        /// </summary>
        HdDvd,
        /// <summary>
        /// disk polovodi�ov�
        /// </summary>
        FlashDisk,
        /// <summary>
        /// disk to�ic� :-)
        /// </summary>
        HardDisk
    }
}