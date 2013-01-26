using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ArachNGIN.Files.Torrents
{
    public class TorrentParser
    {
        public struct stFile
        {
            public long Length;
            public string Name;
            public string Path;
            public long PieceLength;
            public byte[] Pieces;
            public string md5sum;
            public byte[] ed2k;
            public byte[] sha1;
        }

        #region Privátní variábly
        private string p_Anounce;
        private string p_Comment;
        private DateTime p_CreationDate;
        private string p_Encoding;
        public stFile[] p_Files;
        public string p_InfoHash;
        public Boolean p_IsSingleFile = true;
        public string[] p_AnnounceList;
        #endregion

        private stFile infoFile;

        public TorrentParser(BinaryReader torrentFile)
        {
            if (torrentFile == null)
            {
                throw new Exception("Torrent File invalid (null)");
            }
            else
            {
                ProcessFile(torrentFile);
            }
        }

        private void ProcessFile(BinaryReader torrentFile)
        {
            while (torrentFile.ReadChar().ToString()!="e")
            {
                if (torrentFile.ReadChar().ToString() == "d")
                {
                    processDictionary(torrentFile, false, false);
                }
                else
                {
                    throw new Exception("Torrent file invalid (character 'd' expected)");
                }
            }
        }

        private int getStringLength(BinaryReader torrentFile)
        {
            int stringLength = 0;
            while (char.IsDigit((char)torrentFile.PeekChar()))
            {
                stringLength = stringLength * 10;
                stringLength += Convert.ToInt32(torrentFile.ReadChar()) - Convert.ToInt32("0");

            }
            if (torrentFile.ReadChar().ToString() == ":")
            {
                return stringLength;
            }
            else
            {
                throw new Exception("Invalid character. expecting ':'");
            }
        }

        private string getItemValue(BinaryReader torrentFile, int stringLength)
        {
            return torrentFile.ReadChars(stringLength).ToString();
        }

        private byte[] getItemValueByte(BinaryReader torrentFile, int stringLength)
        {
            return torrentFile.ReadBytes(stringLength);
        }

        private string getItemName(BinaryReader torrentFile, int stringLength)
        {
            return torrentFile.ReadChars(stringLength).ToString();
        }

        private long getIntegerNumber(BinaryReader torrentFile)
        {
            torrentFile.ReadChar();
            bool IsNegative = (torrentFile.PeekChar().ToString() == "-");
            long IntegerNumber = 0;
            while (char.IsDigit((char)torrentFile.PeekChar()))
            {
                IntegerNumber *= 10;
                IntegerNumber = Convert.ToInt32(torrentFile.ReadChar()) - Convert.ToInt32("0");
            }
            if (torrentFile.ReadChar().ToString() == "e")
            {
                if (IsNegative)
                {
                    if (IntegerNumber > 0)
                    {
                        return -IntegerNumber;
                    }
                    else
                    {
                        throw new Exception("-0 not allowed!");
                    }
                }
                else
                {
                    return IntegerNumber;
                }
            }
            else
            {
                throw new Exception("expected 'e'");
            }
        }

        private string getHashInfo(BinaryReader torrentFile, int infoStart, int infoLength)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] infoValueBytes;
            torrentFile.BaseStream.Position = infoStart;
            infoValueBytes = torrentFile.ReadBytes(infoLength);
            return BitConverter.ToString(sha1.ComputeHash(infoValueBytes)).Replace("-", "").ToLower();
        }

        private void processDictionary(BinaryReader torrentFile, bool isInfo, bool isFiles)
        {
            int stringLength = 0;
            string itemName = "";
            string itemValueString = "";
            long itemValueInteger = 0;
            byte[] itemValueByte=new byte[0];

            while (Convert.ToChar(torrentFile.PeekChar()).ToString() != "e")
            {
                if (char.IsDigit(Convert.ToChar(torrentFile.PeekChar())))
                {
                    stringLength = getStringLength(torrentFile);
                    itemName = getItemName(torrentFile, stringLength);
                    if (itemName == "info")
                    {
                        int infoPositionStart = (int)torrentFile.BaseStream.Position;
                        if (torrentFile.ReadChar().ToString() == "d")
                        {
                            processDictionary(torrentFile, true, false);
                        }
                        else
                        {
                            throw new Exception("character invalid. expected 'd'");
                        }
                        int infoPositionEnd = (int)torrentFile.BaseStream.Position;
                        p_InfoHash = getHashInfo(torrentFile, infoPositionStart, infoPositionEnd - infoPositionStart - 1);
                        if (p_IsSingleFile)
                        {
                            InsertNewFile();
                        }
                    }
                    else
                    {
                        if (Convert.ToChar(torrentFile.PeekChar()).ToString() == "i")
                        {
                            itemValueInteger = getIntegerNumber(torrentFile);
                        }
                        else if (Convert.ToChar(torrentFile.PeekChar()).ToString() == "l")
                        {
                            ProcessList(torrentFile, itemName, itemName == "path");
                            torrentFile.ReadChar();
                        }
                        else if (Convert.ToChar(torrentFile.PeekChar()).ToString() == "d")
                        {
                            processDictionary(torrentFile, false, false);
                            torrentFile.ReadChar();
                        }
                        else
                        {
                            stringLength = getStringLength(torrentFile);
                            if ((itemName == "pieces") | (itemName == "ed2k") | (itemName == "ed2k"))
                            {
                                itemValueByte = getItemValueByte(torrentFile, stringLength);
                            }
                            else
                            {
                                itemValueString = getItemValue(torrentFile, stringLength);
                            }
                        }

                        if (isInfo || isFiles)
                        {
                            if (itemName == "length")
                            {
                                infoFile.Length = itemValueInteger;
                            }
                            else if (itemName == "name")
                            {
                                infoFile.Name = itemValueString;
                            }
                            else if (itemName == "piece length")
                            {
                                infoFile.PieceLength = itemValueInteger;
                            }
                            else if (itemName == "pieces")
                            {
                                infoFile.PieceLength = itemValueInteger;
                            }
                            else if (itemName == "md5sum")
                            {
                                infoFile.md5sum = itemValueString;
                            }
                            else if (itemName == "ed2k")
                            {
                                infoFile.ed2k = itemValueByte;
                            }
                            else if (itemName == "sha1")
                            {
                                infoFile.sha1 = itemValueByte;
                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            if (itemName == "announce")
                            {
                                p_Anounce = itemValueString;
                            }
                            else if (itemName == "comment")
                            {
                                p_Comment = itemValueString;
                            }
                            else if (itemName == "creation date")
                            {
                                p_CreationDate = new DateTime(1970, 1, 1).AddSeconds(itemValueInteger);
                            }
                            else if (itemName == "encoding")
                            {
                                p_Encoding = itemValueString;
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else if(Convert.ToChar(torrentFile.PeekChar()).ToString()=="d")
                {
                    torrentFile.ReadChar();
                    processDictionary(torrentFile, isInfo, isFiles);
                }
                else if (Convert.ToChar(torrentFile.PeekChar()).ToString() == "e")
                {
                    break;
                }
                else
                {
                    throw new Exception("expected number, 'd' or 'l'");
                }
            }
        }

        private void InsertNewFile()
        {
            if (p_Files == null)
            {
                p_Files = new stFile[0];
            }
            else
            {
                stFile[] oldArray = new stFile[p_Files.Length - 1];
                p_Files.CopyTo(oldArray, 0);
                p_Files = new stFile[p_Files.Length];
                oldArray.CopyTo(p_Files, 0);
            }
            if (!p_IsSingleFile)
            {
                infoFile.Path = infoFile.Path.Substring(1);
            }
            p_Files[p_Files.Length - 1] = infoFile;
            //infoFile = null;
        }

        private void ProcessList(BinaryReader torrentFile, string itemName, bool IsPath)
        {
            bool IsFiles = false;
            if (itemName == "files")
            {
                IsFiles = true;
                p_IsSingleFile = false;
            }
            bool IsFirstTime = true;
            while (Convert.ToChar(torrentFile.PeekChar()).ToString() != "e")
            {
                if (IsFirstTime && (Convert.ToChar(torrentFile.PeekChar()).ToString() == "l"))
                {
                    torrentFile.ReadChar();
                }
                if (IsPath)
                {
                    while (Convert.ToChar(torrentFile.PeekChar()).ToString() != "e")
                    {
                        int stringLength = getStringLength(torrentFile);
                        string itemValue = getItemName(torrentFile, stringLength);
                        infoFile.Path += "\\" + itemValue;
                    }
                    InsertNewFile();
                    break;
                }
                else if (Convert.ToChar(torrentFile.PeekChar()).ToString() == "d")
                {
                    torrentFile.ReadChar();
                    processDictionary(torrentFile, true, true);
                    torrentFile.ReadChar();
                }
                else if (Convert.ToChar(torrentFile.PeekChar()).ToString() == "l")
                {
                    ProcessList(torrentFile, itemName, IsPath);
                }
                else
                {
                    int stringLength;
                    string itemValue="";
                    while((Convert.ToChar(torrentFile.PeekChar()).ToString() != "e"))
                    {
                        stringLength=getStringLength(torrentFile);
                        itemValue=getItemValue(torrentFile,stringLength);
                    }
                    if(itemName=="announce-list")
                    {
                        InsertNewAnnounce(itemValue);
                    }
                    break;
                }
                IsFirstTime=false;
            }
        }

        private void InsertNewAnnounce(string newAnnounce)
        {
            if (p_AnnounceList == null)
            {
                p_AnnounceList = new string[0];
            }
            else
            {
                string[] oldArray = new string[p_AnnounceList.Length-1];
                p_AnnounceList.CopyTo(oldArray, 0);
                p_AnnounceList = new string[p_AnnounceList.Length];
                oldArray.CopyTo(p_AnnounceList, 0);
            }
            p_AnnounceList[p_AnnounceList.Length - 1] = newAnnounce;
        }
    }
}
