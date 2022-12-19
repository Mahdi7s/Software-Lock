using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AssemblyLicense.License;

namespace SoftwareClient.Utility
{
    public static class StringUtils
    {
        static StringUtils()
        {
            //LicManager.Validate(() => typeof (StringUtils).Assembly.FullName);
        }

        public static string GetDigitAndLetters(string str)
        {
            return str.Where(ch => char.IsLetterOrDigit(ch)).Aggregate(string.Empty, (current, ch) => current + ch.ToString());
        }

        public static byte[] SubByte(byte[] bytes, byte byteToSub)
        {
            var retVal = new byte[bytes.Length];

            for(int i =0;i<bytes.Length;i++)
            {
                int nByte = bytes[i] - byteToSub;
                //if(nByte<0)
                //{
                //    nByte = 256-nByte;
                //}
                retVal[i] = (byte) nByte;
            }

            return retVal;
        }

        public static byte[] AddByte(byte[] bytes, byte byteToAdd)
        {
            var retVal = new byte[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                var nByte = bytes[i] + byteToAdd;
                //if (nByte > byte.MaxValue)
                //{
                //    nByte -= 256;
                //}
                retVal[i] = (byte)nByte;
            }

            return retVal;
        }

        public static byte[] HashWithMD5(string strToHash)
        {
            var md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes(strToHash));
        }

        // the valid chars for the encoding
        private static string ValidChars = "QAZ2WSX3" + "EDC4RFV5" + "TGB6YHN7" + "UJM8K9LP";

        public static string ToBase32String(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(); // holds the base32 chars
            byte index;
            int hi = 5;
            int currentByte = 0;

            while (currentByte < bytes.Length)
            {
                // do we need to use the next byte?
                if (hi > 8)
                {
                    // get the last piece from the current byte, shift it to the right
                    // and increment the byte counter
                    index = (byte) (bytes[currentByte++] >> (hi - 5));
                    if (currentByte != bytes.Length)
                    {
                        // if we are not at the end, get the first piece from
                        // the next byte, clear it and shift it to the left
                        index = (byte) (((byte) (bytes[currentByte] << (16 - hi)) >> 3) | index);
                    }

                    hi -= 3;
                }
                else if (hi == 8)
                {
                    index = (byte) (bytes[currentByte++] >> 3);
                    hi -= 3;
                }
                else
                {

                    // simply get the stuff from the current byte
                    index = (byte) ((byte) (bytes[currentByte] << (8 - hi)) >> 3);
                    hi += 5;
                }

                sb.Append(ValidChars[index]);
            }

            return sb.ToString();
        }

        public static byte[] FromBase32String(string str)
        {
            int numBytes = str.Length*5/8;
            byte[] bytes = new Byte[numBytes];

            // all UPPERCASE chars
            str = str.ToUpper();

            int bit_buffer;
            int currentCharIndex;
            int bits_in_buffer;

            if (str.Length < 3)
            {
                bytes[0] = (byte) (ValidChars.IndexOf(str[0]) | ValidChars.IndexOf(str[1]) << 5);
                return bytes;
            }

            bit_buffer = (ValidChars.IndexOf(str[0]) | ValidChars.IndexOf(str[1]) << 5);
            bits_in_buffer = 10;
            currentCharIndex = 2;
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte) bit_buffer;
                bit_buffer >>= 8;
                bits_in_buffer -= 8;
                while (bits_in_buffer < 8 && currentCharIndex < str.Length)
                {
                    bit_buffer |= ValidChars.IndexOf(str[currentCharIndex++]) << bits_in_buffer;
                    bits_in_buffer += 5;
                }
            }

            return bytes;
        }
    }
}
