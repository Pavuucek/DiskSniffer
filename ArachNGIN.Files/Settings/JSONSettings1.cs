using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.IO.IsolatedStorage;

namespace ArachNGIN.Files.Settings
{

    /* example:
     * 
     * class Program
     * {
     *      static void Main(string[] args)
     *      {
     *          MySettings settings = MySettings.Load();
     *          Console.WriteLine("Current value of 'myInteger': " + settings.myInteger);
     *          Console.WriteLine("Incrementing 'myInteger'...");
     *          settings.myInteger++;
     *          Console.WriteLine("Saving settings...");
     *          settings.Save();
     *          Console.WriteLine("Done.");
     *          Console.ReadKey();
     *      }
     *
     *      class MySettings : AppSettings<MySettings>
     *      {
     *          public string myString = "Hello World";
     *          public int myInteger = 1;
     *      }
     * }
     */

    public class JSONSettings1<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.jsn";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }
        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }
        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            return t;
        }
    }
}
