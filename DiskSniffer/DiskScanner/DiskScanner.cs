using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DiskSniffer;
using System.Data.SQLite;

namespace DiskSniffer.DiskScanner
{
    public static class DiskScanner
    {

        public static void Scan(string strPath)
        {
            string[] filenames = Directory.GetFiles(strPath, "*.*", SearchOption.AllDirectories);
            SQLiteTransaction transaction = Program.mainform.DB.connection.BeginTransaction();
            foreach (string filename in filenames)
            {
                FileInfo fi = new FileInfo(filename);
                SQLiteCommand cmd = Program.mainform.DB.connection.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO 'files' VALUES (NULL,'1', '@filename', '@fullpath','@datetime');";
                cmd.Parameters.Add("@filename",
            }
        }
    }
}