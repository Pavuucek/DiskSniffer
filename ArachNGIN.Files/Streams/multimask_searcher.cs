using System;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

namespace ArachNGIN.Files.Streams
{
    public class MultimaskFileSearcher
    {
        ArrayList _extensions;
        bool _recursive;
        public ArrayList SearchExtensions
        {
            get
            {
                return _extensions;
            }
        }
        public bool Recursive
        {
            get
            {
                return _recursive;
            }
            set
            {
                _recursive = value;
            }
        }
        public MultimaskFileSearcher()
        {
            _extensions = ArrayList.Synchronized(new ArrayList());
            _recursive = true;
        }
        public FileInfo[] Search(string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            ArrayList subFiles = new ArrayList();
            foreach (FileInfo file in root.GetFiles())
            {
                // kdyz chceme vsechno (*.*) tak pridavame vsechno :-)
                if ((_extensions.Contains(file.Extension)) || (_extensions.Contains("*.*")))
                {
                    subFiles.Add(file);
                }
            }
            if (_recursive)
            {
                foreach (DirectoryInfo directory in root.GetDirectories())
                {
                    subFiles.AddRange(Search(directory.FullName));
                }
            }
            return (FileInfo[])subFiles.ToArray(typeof(FileInfo));
        }
    }
}