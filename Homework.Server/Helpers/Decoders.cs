using System.Text;

namespace Homework.Server.Helpers
{
    public static class Decoders
    {
        public static string? DecodeFromUtf16ToUtf8(string? utf16String)
        {
            if (utf16String == null)
                return null;

            // copy the string as UTF-8 bytes
            byte[] utf8Bytes = new byte[utf16String.Length];
            for (int i = 0; i < utf16String.Length; ++i)
                utf8Bytes[i] = (byte)utf16String[i];

            return Encoding.UTF8.GetString(utf8Bytes, 0, utf8Bytes.Length);
        }
    }
}
