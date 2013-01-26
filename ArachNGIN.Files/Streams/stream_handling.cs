using System;
using System.IO;

namespace ArachNGIN.Files.Streams
{
	/// <summary>
	/// T��da pro pr�ci s proudy pln� statick�ch procedur
	/// </summary>
	public class StreamHandling
	{
		/// <summary>
		/// Konstruktor t��dy. Nic ned�l�
		/// </summary>
		/// <returns>nic</returns>
		public StreamHandling()
		{
		}

		/// <summary>
		/// Zkop�ruje jeden proud do druh�ho
		/// </summary>
		/// <remarks>
		/// (Aneb Pav��ci r�di Delphi a to co jim z nich chyb� si prost� p�elo�ej ;-)
		/// </remarks>
		/// <param name="s_source">zdrojov� proud</param>
		/// <param name="s_dest">c�lov� proud</param>
		/// <param name="i_count">po�et bajt� ke zkop�rov�n�. kdy� je 0 tak se zkop�ruje cel� proud</param>
		/// <returns>po�et zkop�rovan�ch bajt�</returns>
		public static long StreamCopy(Stream s_source, Stream s_dest, long i_count)
		{
			long result = 0;
			int MaxBufSize = 0xF000;
			int BufSize;
			byte[] Buffer;
			int N;
			BinaryReader r_input = new BinaryReader(s_source);
			BinaryWriter w_output = new BinaryWriter(s_dest);

			if (i_count == 0)
			{
				s_source.Position = 0;
				i_count = s_source.Length;
			}
			result = i_count;
			if (i_count > MaxBufSize) BufSize = MaxBufSize;
			else BufSize = (int)i_count;

			try
			{
				// serizneme vystup
				s_dest.SetLength(0);
				while(i_count != 0)
				{
					if(i_count > BufSize) N = BufSize;
					else N = (int)i_count;
					Buffer = r_input.ReadBytes(N);
					w_output.Write(Buffer);
					i_count = i_count - N;
				}
			}
			finally
			{
                // si po sobe hezky splachneme :-)
                w_output.Flush();
			}
			return result;
		}
        public static long StreamCopy(Stream s_source, Stream s_dest, long i_count,long i_startposition)
        {
            long result = 0;
            int MaxBufSize = 0xF000;
            int BufSize;
            byte[] Buffer;
            int N;
            BinaryReader r_input = new BinaryReader(s_source);
            BinaryWriter w_output = new BinaryWriter(s_dest);

            if (i_count == 0)
            {
                s_source.Position = 0;
                i_count = s_source.Length;
            }
            result = i_count;
            if (i_count > MaxBufSize) BufSize = MaxBufSize;
            else BufSize = (int)i_count;

            try
            {
                // naseekujeme zapisovaci pozici
                w_output.Seek((int)i_startposition, SeekOrigin.Begin);
                while (i_count != 0)
                {
                    if (i_count > BufSize) N = BufSize;
                    else N = (int)i_count;
                    Buffer = r_input.ReadBytes(N);
                    w_output.Write(Buffer);
                    i_count = i_count - N;
                }
            }
            finally
            {
                // si po sobe hezky splachneme :-)
                w_output.Flush();
            }
            return result;
        }
		
		/// <summary>
		/// Funkce pro p�evod pole znak� na string
		/// </summary>
		/// <param name="c_input">vsupn� pole znak�</param>
		/// <returns>v�sledn� �et�zec</returns>
		public static string PCharToString(char[] c_input)
		{
			// TODO: ODDELIT DO ArachNGIN.Strings! (az bude)
			string result = "";
			foreach(char c in c_input)
			{
				if (c == 0x0) break; // pcharovej konec retezce;
				result = result+c;
			}
			return result;
		}
	}

}
