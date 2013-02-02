using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArachNGIN.Files;
using ArachNGIN.Files.Streams;
using ArachNGIN.Files.Strings;

namespace DiskSniffer.Database
{
    public class sqlite
    {
        public const int i_RequiredDbVersion = 1;
        public const string f_NewDbScript = @"sql\create_db_01.sql";
        public const string f_DataFile="data.ds";
        public SQLiteConnection connection;

        public sqlite(string FileName)
        {
            string datafile=Program.ATemp.AppDir + f_DataFile;
            if (!File.Exists(datafile)) CreateDatabase(datafile);
            if ((connection != null) && (connection.State != ConnectionState.Closed))
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            connection = new SQLiteConnection("data source=" + datafile);
        }


        private void CreateDatabase(string FileName)
        {
            SQLiteConnection.CreateFile(FileName);
            if ((connection != null) && (connection.State != ConnectionState.Closed))
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            connection = new SQLiteConnection();
            connection.ConnectionString = "FailIfMissing=False;Data Source=" + @FileName;
            connection.Open();
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = GetSQLFromFile(f_NewDbScript);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }

        private string GetSQLFromFile(string strFile)
        {
            string s = "";
            if (Program.PakFS.AskFile(strFile))
            {
                StringCollection sc = new StringCollection();
                StringCollections.LoadFromFile(Program.ATemp.AppTempDir + strFile, sc);
                s = StringCollections.StringCollectionToString(sc);
            }
            return s;
        }
    }
}
