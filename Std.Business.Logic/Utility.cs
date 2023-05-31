using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Std.Business.Logic
{
    public class Utility
    {
        public static bool IsDBRunning(string ConnectionSTR)
        {
            SqlConnection Con = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();

            Con.ConnectionString = ConnectionSTR;

            try
            {

                Con.Open();
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                    return true;
                }
                else
                {
                    Con.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                Con.Close();
            }
        }
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        static bool ByteArraysEqual(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
        {
            return a1.SequenceEqual(a2);
        }
        public static string ConvertToPascalCase(string Name)
        {
            Name.ToLower();
            if ((Name == null) || (Name.Length == 0)) return Name;

            string[] words = Name.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    string word = words[i];
                    char firstLetter = char.ToUpper(word[0]);
                    words[i] = firstLetter + word.Substring(1);
                    words[i] = words[i] + ' ';
                }
            }

            return string.Join(string.Empty, words).Trim();
        }
    }
}