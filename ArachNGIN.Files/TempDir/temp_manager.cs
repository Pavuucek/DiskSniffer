using System;
using System.IO;
using System.Windows.Forms;
using ArachNGIN.Files.Strings;

namespace ArachNGIN.Files
{
	/// <summary>
	/// Tøída pro obstarávání temp adresáøe a podobné vìci
	/// </summary>
	public class TempManager
	{

		private string s_AppDir;
		private string s_AppTempDir;
		private string s_TempDir;

		/// <summary>
		/// property vracející adresáø aplikace
		/// </summary>
		public string AppDir
		{
			get
			{
				return s_AppDir;
			}
		}
		
		/// <summary>
		/// property vracející adresáø aplikace v tempu
		/// (napø. c:\windows\temp\aplikace_035521152515)
		/// poslední èást je guid (aby se 2 instance aplikace/této tøídy
		/// nehádaly o 1 adresáø)
		/// </summary>
		public string AppTempDir
		{
			get
			{
				return s_AppTempDir;
			}
		}
		
		/// <summary>
		/// property vracející tempový adresáø
		/// (napø. c:\windows\temp)
		/// </summary>
		public string TempDir
		{
			get
			{
				return s_TempDir;
			}
		}
		
		/// <summary>
		/// Konstruktor tøídy
		/// vytvoøí adresáø v tempu
		/// </summary>
		/// <returns>instance tøídy</returns>
		public TempManager()
		{
			Guid g_guid = Guid.NewGuid();
			s_TempDir = StringUtils.strAddSlash(Environment.GetEnvironmentVariable("TEMP"));
			string str = Path.GetFileName(Application.ExecutablePath).ToLower();
			str = str.Replace(@".",@"_");
			str = str + @"_" + g_guid.ToString();
            s_AppTempDir = StringUtils.strAddSlash(s_TempDir + str.ToLower());
            s_AppDir = StringUtils.strAddSlash(Path.GetDirectoryName(Application.ExecutablePath));
			Directory.CreateDirectory(s_AppTempDir);
		}

		/// <summary>
		/// Smaže adresáø v tempu
		/// </summary>
		public void Close()
		{
			Directory.Delete(s_AppTempDir, true);
		}
		
		/// <summary>
		/// Destruktor tøídy vyvolá fci Close(); a potlaèuje výjimky
		/// </summary>
		~TempManager()
		{
			try
			{
				Close();
			}
			catch {}
		}
	}
}
