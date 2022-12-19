using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace AssemblyLicense.Utils
{
    public static class AESEncryption
    {
        public static string Encrypt(string strToEncrypt, string password)
        {
            return Encryption(strToEncrypt, password, true);
        }

        public static byte[] Encrypt(byte[] bytes, string password)
        {
            return Encryption(bytes, password, true);
        }

        public static string Decrypt(string encryptedStr, string password)
        {
            return Encryption(encryptedStr, password, false);
        }

        public static byte[] Decrypt(byte[] bytes, string password)
        {
            return Encryption(bytes, password, false);
        }

        private static string Encryption(string encryptionStr, string password, bool isEncrypting)
        {
            if (string.IsNullOrEmpty(encryptionStr))
                throw new ArgumentNullException("encryptionStr");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            var strBytes = Helpers.ConvertToByte(encryptionStr, isEncrypting);
            var retValBytes = Encryption(strBytes, password, isEncrypting);

            return Helpers.ConvertToString(retValBytes, !isEncrypting);
        }

        private static byte[] Encryption(byte[] bytes, string password, bool isEncrypting)
        {
            using (var stream = new MemoryStream())
            {
                using(var cryptoStrm = Encryption(stream, bytes, password, isEncrypting))
                {
                    stream.Position = 0;
                    var retValBytes = new byte[stream.Length];
                    stream.Read(retValBytes, 0, retValBytes.Length);

                    return retValBytes;
                }
            }
        }

        private static CryptoStream Encryption(Stream stream, byte[] bytes, string password, bool isEncrypting)
        {
            if (bytes == null || bytes.Length <= 0)
                throw new ArgumentNullException("bytes");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            using (var rijndael = new RijndaelManaged { KeySize = 24 * 8, BlockSize = 16 * 8 })
            {
                var md5Pass = StringUtils.HashWithMD5(password);

                byte[] key = md5Pass.Concat(md5Pass.Skip(8)).ToArray(), iv = md5Pass.ToArray();
                var encryptor = isEncrypting
                                    ? rijndael.CreateEncryptor(key, iv)
                                    : rijndael.CreateDecryptor(key, iv);

                var cryptoStrm = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);
                cryptoStrm.Write(bytes, 0, bytes.Length);
                cryptoStrm.FlushFinalBlock();

                return cryptoStrm;
            }
        }
    }
}
