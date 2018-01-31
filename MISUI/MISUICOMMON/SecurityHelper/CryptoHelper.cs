// ***********************************************************************
// Assembly         : Core.Framework.Common
// Author           : Ujjwal Mishra
// Created          : 10-08-2012
//
// Last Modified By : Ujjwal Mishra
// Last Modified On : 10-08-2012
// ***********************************************************************
// <copyright file="CryptoHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace MISUICOMMON.SecurityHelper
{
    public static class CryptoHelper
    {
        /// <summary>
        /// Converts clear string to MD5 encrypted string
        /// </summary>
        /// <param name="clearText">Clear text</param>
        /// <returns>Returns MD5 encrypted text</returns>
        public static String ToMd5(this String clearText)
        {
            String result = String.Empty;

            String salt = ConfigurationManager.AppSettings["SALT"];
            string saltedString = String.Concat(clearText, salt);
            // Encrypt this user's password information.
            using (MD5 md5EncryptionObject = new MD5CryptoServiceProvider())
            {
                Byte[] originalStringBytes = Encoding.Default.GetBytes(saltedString);
                Byte[] encodedStringBytes = md5EncryptionObject.ComputeHash(originalStringBytes);

                var sb = new StringBuilder();
                foreach (byte b in encodedStringBytes)
                {
                    sb.Append(b.ToString("x2").ToLower());
                }
                //result = BitConverter.ToString(encodedStringBytes);
                result = sb.ToString();
            }
            return result;
        }

        /// <summary>
        /// Encrypt clear string to TripleDESC encrypted text
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public static String Encrypt(this String clearText)
        {
            string key = ConfigurationManager.AppSettings["ENC_KEY"];
            byte[] IV = new byte[8] {240, 3, 45, 29, 0, 76, 173, 59};
            byte[] buffer = Encoding.ASCII.GetBytes(clearText);
            var des = new TripleDESCryptoServiceProvider();
            var MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(key));
            des.IV = IV;

            return (Convert.ToBase64String(Encoding.ASCII.GetBytes(clearText)));
        }

        /// <summary>
        /// Decrypt TripleDESC encrypted text clear text
        /// </summary>
        /// <param name="encText"></param>
        /// <returns></returns>
        public static String Decrypt(this String encText)
        {
            try
            {
                string key = ConfigurationManager.AppSettings["ENC_KEY"];
                byte[] IV = new byte[8] {240, 3, 45, 29, 0, 76, 173, 59};
                byte[] buffer = Convert.FromBase64String(encText);
                var des = new TripleDESCryptoServiceProvider();
                var MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(key));
                des.IV = IV;

                return Encoding.ASCII.GetString(Convert.FromBase64String(encText));
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}


