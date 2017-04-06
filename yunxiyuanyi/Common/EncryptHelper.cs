using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class EncryptHelper
    {
        /// <summary>
        /// 加密成16位MD5
        /// </summary>
        public static string ToMD5_16(this string source)
        {
            return source.ToMD5_16(Encoding.UTF8);
        }
        /// <summary>
        /// 加密成16位MD5
        /// </summary>
        public static string ToMD5_16(this string source, Encoding encoding)
        {
            if (String.IsNullOrEmpty(source) || source.Trim() == "")
                return "";
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string result = BitConverter.ToString(md5.ComputeHash(encoding.GetBytes(source)), 4, 8);
            result = result.Replace("-", "");
            return result;
        }
        /// <summary>
        /// 加密成32位MD5
        /// </summary>
        public static string ToMD5_32(this string source)
        {
            return source.ToMD5_32(Encoding.UTF8);
        }
        /// <summary>
        /// 加密成32位MD5
        /// </summary>
        public static string ToMD5_32(this string source, Encoding encoding)
        {
            if (String.IsNullOrEmpty(source) || source.Trim() == "")
                return "";
            byte[] result = encoding.GetBytes(source);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        /// <summary>
        /// 加密成3DES KEY长度为24位
        /// </summary>
        public static string To3DES(this string source)
        {
            string key = ConfigurationManager.AppSettings["3des_key"];
            return source.To3DES(Encoding.UTF8, key);
        }

        /// <summary>
        /// 加密成3DES KEY长度为24位
        /// </summary>
        public static string To3DES(this string source, Encoding encoding, string key)
        {
            if (String.IsNullOrEmpty(source) || source.Trim() == "")
                return "";
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = encoding.GetBytes(key);
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = encoding.GetBytes(source);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        /// <summary>
        /// 3DES解密  KEY长度为24位
        /// </summary>
        public static string Dencrypt3DES(this string source)
        {
            string key = ConfigurationManager.AppSettings["3des_key"];
            return source.Dencrypt3DES(Encoding.UTF8, key);
        }
        /// <summary>
        /// 3DES解密  KEY长度为24位
        /// </summary>
        public static string Dencrypt3DES(this string source, Encoding encoding, string key)
        {
            if (String.IsNullOrEmpty(source) || source.Trim() == "")
                return "";
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = encoding.GetBytes(key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(source);
            return encoding.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

    }
}
