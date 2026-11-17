using System.Text;

namespace EtlaToolPicker.EtlaToolbelt.Postgres;

/// <summary>An implementation of an Rc4 algorithm</summary>
internal class Rc4
{
    /// <summary>Converts a hex string to an equivalent processed string</summary>
    /// <param name="hexString">The string to process</param>
    /// <returns>The processed string</returns>
    internal static string ToString(string hexString)
    {
        var buffer = ToRc4(HexStringToByteArray(hexString));
        return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
    }

    /// <summary>Converts a string to an equivalent hex string</summary>
    /// <param name="plain">The string to process</param>
    /// <returns>The processed hex string</returns>
    internal static string ToHex(string plain)
    {
        var buffer = ToRc4(Encoding.ASCII.GetBytes(plain));
        return ByteArrayToHexString(buffer);
    }

    /// <summary>Converts bytes to hex</summary>
    /// <param name="ba">The byte array</param>
    /// <returns>The equivalent hex string</returns>
    private static string ByteArrayToHexString(byte[] ba)
    {
        return BitConverter.ToString(ba).Replace("-", "");
    }

    /// <summary>Converts a hex string to a processed array of bytes</summary>
    /// <param name="hex">The hex string to process</param>
    /// <returns>The processed array of bytes</returns>
    private static byte[] HexStringToByteArray(string hex)
    {
        int NumberChars = hex.Length;
        byte[] bytes = new byte[NumberChars / 2];
        for (int i = 0; i < NumberChars; i += 2) { bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16); }
        return bytes;
    }

    /// <summary>An implementation of the Rc4 algorithm</summary>
    /// <param name="inBytes">The bytes to process</param>
    /// <returns>The processed bytes</returns>
    private static byte[] ToRc4(byte[] inBytes)
    {
        byte[] keyBytes = Encoding.ASCII.GetBytes(Initialiser.GetKey());

        byte[] answer = new byte[inBytes.Length];

        byte i = 0;
        byte j = 0;
        ushort[] k = new ushort[256];
        ushort[] s = new ushort[256];

        for (ushort ix = 0; ix < 256; ++ix)
        {
            s[ix] = ix;
            k[ix] = keyBytes[ix % keyBytes.Length];
        }

        for (ushort ix = 0; ix < 256; ++ix)
        {
            j = (byte)((j + s[ix] + k[ix]) % 256);
            (s[ix], s[j]) = (s[j], s[ix]);  //swap using tuple
        }

        j = 0;
        for (int ix = 0; ix < inBytes.Length; ++ix)
        {
            i = (byte)((i + 1) % 256);
            j = (byte)((j + s[i]) % 256);
            (s[i], s[j]) = (s[j], s[i]); // swap using tuple
            var t = (byte)((s[i] + s[j]) % 256);
            if (s[t] == inBytes[ix])
            {
                answer[ix] = inBytes[ix];
            }
            else
            {
                answer[ix] = (byte)(s[t] ^ inBytes[ix]);
            }
        }

        return answer;
    }

}
