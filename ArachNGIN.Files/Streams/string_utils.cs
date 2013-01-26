/*
 * Created by SharpDevelop.
 * User: Takeru
 * Date: 19.3.2006
 * Time: 15:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Text.RegularExpressions;

namespace ArachNGIN.Files.Strings
{
	/// <summary>
	/// Třída plná statických funkcí pro práci s řetězci
	/// </summary>
	public class StringUtils
	{
		/// <summary>
		/// Konstruktor třídy. Nic nedělá.
		/// </summary>
		/// <returns>nic</returns>
		public StringUtils()
		{
			// nic here :-) 
		}
		
		/// <summary>
		/// Funkce pro rozdělení řetězce na jednotlivá slova
		/// </summary>
		/// <param name="WholeString">celý řetězec</param>
		/// <param name="Delimiter">oddělovač (nejspíš mezera)</param>
		/// <returns></returns>
		 public static string[] StringSplit(string WholeString, string Delimiter)
          {
               Regex r = new Regex("(" + Delimiter + ")");
               string[] s = r.Split(WholeString);

               int iHalf = System.Convert.ToInt16((s.GetUpperBound(0) / 2) + 1);
               string[] res = new string[iHalf];

               int j = 0;
               for (int i=0; i <= s.GetUpperBound(0); i++)
               {
                    if (s[i] != Delimiter)
                    {
                         res[j] = s[i];
                         j++;
                    }
               }
               return res;
          }
        public static string strAddSlash(string strString)
        {
            // zapamatovat si: lomítko je 0x5C!
            string s = strString;
            if (s[s.Length - 1] != (char)0x5C) return s + (char)0x5C;
            else return s;
        }

        public static byte[] UInt32ToBigEndianBytes(UInt32 x)
        {
            return new byte[]
            {
                (byte)((x >> 24) & 0xff),
                (byte)((x >> 16) & 0xff),
                (byte)((x >> 8) & 0xff),
                (byte)(x & 0xff)
            };
        }
        public static string UInt32ToByteString(UInt32 x)
        {
            byte[] tmp = UInt32ToBigEndianBytes(x);
            string s = string.Empty;
            foreach (byte b in tmp) s += b.ToString("x2");
            return s;
        }

        public static string PadNumToLength(int number, int length)
        {
            string result = number.ToString();
            while (result.Length < length)
            {
                result = "0" + result;
            }
            return result;
        }
    }
}
