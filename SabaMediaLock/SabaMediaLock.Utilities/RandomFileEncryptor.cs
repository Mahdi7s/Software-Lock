using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TS7S.Base.Encryption;

namespace SabaMediaLock.Utilities
{
    public static class RandomFileEncryptor
    {
        private static readonly string Key = "hellobabyyoucallthatgirlhereyousay";//"肵噄ꔪᅍ欞믎볝尩Ⓢ㜍嵏鸡끟瓽ᘟ࠴쉿光鋯〨㘱Ṟ";

        public static void Encrypt(string srcPath, string desPath = null, int randCount = 5)
        {
            var fileBytes = File.ReadAllBytes(srcPath);
            if (string.IsNullOrEmpty(desPath))
            {
                File.Delete(srcPath);
                desPath = srcPath;
            }
            Encrypt(fileBytes, desPath, randCount);
        }

        public static void Encrypt(byte[] srcBytes, string desPath, int randCount = 5)
        {
            var fEn = new FileEncryptor(Key);
            var bytes = GetRandBytes(randCount).Concat(srcBytes).ToArray();
            using (var memStrm = new MemoryStream(bytes))
            {
                using (var desStrm = new FileStream(desPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fEn.EncryptOrDecryptFile(fEn.GetCryptoTransform(CryptoAlgorithm.RijndaelManaged), memStrm, desStrm);
                }
            }
        }

        public static Stream Decrypt(string srcPath, int randCount = 5)
        {
            var fEn = new FileEncryptor(Key);
            using (var srcStrm = File.OpenRead(srcPath))
            {
                using (var desStrm = new MemoryStream())
                {
                    fEn.EncryptOrDecryptFile(fEn.GetCryptoTransform(CryptoAlgorithm.RijndaelManaged, false), srcStrm, desStrm);
                    var retval = new MemoryStream(desStrm.ToArray().Skip(randCount).ToArray());

                    return retval;
                }
            }
        }

        private static IEnumerable<byte> GetRandBytes(int count)
        {
            var rand = new Random();
            return Enumerable.Range(0, count).Select(x => (byte)rand.Next(0, 255));
        }
    }
}
