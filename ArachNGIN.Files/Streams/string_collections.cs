using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace ArachNGIN.Files.Strings
{
	/// <summary>
	/// Tøída pro práci se StringCollection (aka TStrings)
	/// </summary>
	public class StringCollections
	{
        /// <summary>
        /// Tøídy se samejma statickejma fcema konstruktory nepotøebujou :-)
        /// </summary>
		public StringCollections()
		{
			// hey there, nothin' here :-)
		}

        /// <summary>
        /// Pøevede StringCollection na jeden string
        /// </summary>
        /// <param name="stringCollection">Vstupní StringCollection</param>
        /// <returns>Výstupní string</returns>
        public static string StringCollectionToString(StringCollection stringCollection)
        {
            string outputString = "";
            if (stringCollection != null && stringCollection.Count > 0)
            {
                foreach (string inputString in stringCollection)
                    outputString += inputString + "\r\n";
                outputString = outputString.Substring(0, outputString.Length - 1);

            }
            return outputString;
        }

		
		/// <summary>
		/// Uloží obsah StringCollection do souboru
		/// </summary>
		/// <param name="s_file">název souboru</param>
		/// <param name="s_collection">StringCollection</param>
		public static void SaveToFile(string s_file, StringCollection s_collection)
		{
			FileInfo fi = new FileInfo(s_file);
			TextWriter writer;
			writer = fi.CreateText();
			StringEnumerator enu = s_collection.GetEnumerator();
			while(enu.MoveNext())
			{
				writer.WriteLine(enu.Current);
			}
			writer.Close();
		}

        /// <summary>
        /// Uloží obsah StringCollection do proudu
        /// </summary>
        /// <param name="s_output">proud</param>
        /// <param name="s_collection">obsah</param>
        public static void SaveToStream(Stream s_output, StringCollection s_collection)
        {
            StreamWriter writer = new StreamWriter(s_output);
            writer.AutoFlush = true;
            StringEnumerator enu = s_collection.GetEnumerator();
            while (enu.MoveNext())
            {
                writer.WriteLine(enu.Current);
            }
            writer.Flush();
            //writer.Close(); // nezavirat!
        }

        public static void SaveToFile(string s_file, ListView.ListViewItemCollection s_collection)
        {
            FileInfo fi = new FileInfo(s_file);
            TextWriter writer;
            writer = fi.CreateText();
            foreach (ListViewItem item in s_collection)
            {
                string s = "";
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    s = s + item.SubItems[i].ToString();
                    if (i < item.SubItems.Count - 1) s = s + " -> ";
                    s = s.Replace("ListViewSubItem:", "");
                    s = s.Replace("}", "");
                    s = s.Replace("{", "");
                }
                //ListViewItemConverter k = new ListViewItemConverter();
                //string s = k.ConvertToString(item);
                writer.WriteLine(s);
            }
            writer.Close();
        }

		/// <summary>
		/// Naète soubor (textový) do StringCollection
		/// </summary>
		/// <param name="s_file">název souboru</param>
		/// <param name="s_collection">StringCollection do které se bude naèítat</param>
		/// <param name="b_append">pøipojit k existujícím prvkùm v kolekci</param>
		public static void LoadFromFile(string s_file, StringCollection s_collection, bool b_append)
		{
			FileInfo soubor_info = new FileInfo(s_file);
			TextReader reader;
			string s = "0";
			if(!soubor_info.Exists) return;
			// naèíty naèíty :-)
			reader = soubor_info.OpenText();
			if(!b_append) s_collection.Clear();
			while((s = reader.ReadLine()) != null)
			{
				s_collection.Add(s);
			}
			// naèteno	
			reader.Close();
		}

        /// <summary>
        /// Naète proud do StringCollection
        /// </summary>
        /// <param name="s_input">proud</param>
        /// <param name="s_collection">výstup</param>
        /// <param name="b_append">pøipojit k existujícím prvkùm v kolekci</param>
        public static void LoadFromStream(Stream s_input, StringCollection s_collection, bool b_append)
        {
            StreamReader reader = new StreamReader(s_input);
            string s = "0";
            if (!b_append) s_collection.Clear();
            while ((s = reader.ReadLine()) != null)
            {
                s_collection.Add(s);
            }
            // reader.Close(); // nezavirat!
        }

        /// <summary>
        /// Naète proud do StringCollection
        /// </summary>
        /// <param name="s_input">proud</param>
        /// <param name="s_collection">výstup</param>
        public static void LoadFromStream(Stream s_input, StringCollection s_collection)
        {
            LoadFromStream(s_input, s_collection, false);
        }

		/// <summary>
		/// Naète soubor (textový) do StringCollection
		/// </summary>
		/// <param name="s_file">název souboru</param>
		/// <param name="s_collection">StringCollection do které se bude naèítat</param>
		public static void LoadFromFile(string s_file, StringCollection s_collection)
		{
			LoadFromFile(s_file,s_collection,false);
		}

        public static void SaveToFile(string s_file, ListView list)
        {
            StringBuilder listViewContent = new StringBuilder();

            foreach (ListViewItem item in list.Items)
            {
                listViewContent.Append(item.Text);
                listViewContent.Append(Environment.NewLine);
            }

            TextWriter tw = new StreamWriter(s_file);

            tw.WriteLine(listViewContent.ToString());

            tw.Close();

        }
	}
}
