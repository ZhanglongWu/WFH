namespace Wicresoft.WFH.Core
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text.RegularExpressions;

    public static class StringExtension
    {
        private static readonly Rijndael _aes = Rijndael.Create();
        private static readonly MD5 _md5Provider = new MD5CryptoServiceProvider();
        private static readonly byte[] _aesIv = { 75, 108, 109, 104, 90, 66, 67, 121, 74, 100, 52, 74, 82, 84, 68, 57 };
        private static readonly byte[] _aesKey = { 79, 83, 90, 120, 103, 115, 54, 81, 118, 82, 72, 102, 105, 101, 51, 71 };

        public static int GetDeterministicHashCode(this string str)
        {
            unchecked
            {
                var hash1 = (5381 << 16) + 5381;
                var hash2 = hash1;

                for (var i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        public static string ToValidSqlString(this object obj)
        {
            return obj.ToString().Trim().Replace("'", "''");
        }

        public static bool IsChineseCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        public static bool ContainsWord(this string str, string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            if (word.IsChineseCharacter())
                return str.Contains(word);

            return Regex.IsMatch(str, $@"\b{word}\b", RegexOptions.IgnoreCase);
        }

        public static string Encrypt(this string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
            {
                return null;
            }
            var buffer = Encoding.Unicode.GetBytes(plaintext);
            using (var stream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(stream, _aes.CreateEncryptor(_aesKey, _aesIv), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(buffer, 0, buffer.Length);
                    cryptoStream.FlushFinalBlock();
                    cryptoStream.Close();
                }
                buffer = stream.ToArray();
                stream.Close();
            }
            return Convert.ToBase64String(buffer);
        }

        public static string Decrypt(this string ciphertext)
        {
            if (string.IsNullOrEmpty(ciphertext))
            {
                return null;
            }
            var buffer = Convert.FromBase64String(ciphertext);
            using (var cryptoStream = new CryptoStream(new MemoryStream(buffer), _aes.CreateDecryptor(_aesKey, _aesIv), CryptoStreamMode.Read))
            {
                using (var stream = new MemoryStream())
                {
                    var swap = new byte[2048];
                    int length;
                    while ((length = cryptoStream.Read(swap, 0, swap.Length)) > 0)
                    {
                        stream.Write(swap, 0, length);
                    }
                    return Encoding.Unicode.GetString(stream.ToArray());
                }
            }
        }

        public static string Join(this IEnumerable<string> str, string separator = ";")
        {
            if (str == null || !str.Any() || (str.Count() == 1 && str.All(string.IsNullOrEmpty)))
                return string.Empty;

            return string.Join(separator, str);
        }

        public static string MD5(this string plaintext)
        {
            var buffer = Encoding.Unicode.GetBytes(plaintext);

            buffer = _md5Provider.ComputeHash(buffer);

            return BitConverter.ToString(buffer).Replace("-", "");
        }
    }
}
