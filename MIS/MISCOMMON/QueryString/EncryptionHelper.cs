using System;
using System.Text;
using System.Security.Cryptography;

namespace MISCOMMON.QueryString
{
   
    public class EncryptionHelper
    {
        #region Declarations
        private SymmetricAlgorithm mobjCryptoService;
        /// <summary>
        ///  Supported .Net intrinsic SymmetricAlgorithm classes.
        /// </summary>
        public enum EncryptionProviderEnum : int
        {
            DES, RC2, Rijndael
        }
        #endregion


        /// <remarks>
        /// Constructor for using an intrinsic .Net SymmetricAlgorithm class.
        /// </remarks>
        public EncryptionHelper(EncryptionProviderEnum NetSelected)
        {
            switch (NetSelected)
            {
                case EncryptionProviderEnum.DES:
                    mobjCryptoService = new DESCryptoServiceProvider();
                    break;
                case EncryptionProviderEnum.RC2:
                    mobjCryptoService = new RC2CryptoServiceProvider();
                    break;
                case EncryptionProviderEnum.Rijndael:
                    mobjCryptoService = new RijndaelManaged();
                    break;
            }
        }

        /// <summary>
        /// Encrypts an input string and returns a normal hashed string
        /// </summary>
        /// <param name="sInputstring">the string to be MD5 hashed</param>
        /// <returns></returns>
      public static string MD5StringEncrypt(string sInputstring)
        {
            //call encryption
            byte[] bHashedString = MD5Encryption(sInputstring);
            //convert hashed bytes to string
            string sHashedString = BitConverter.ToString(bHashedString);
            //return noraml string
            return sHashedString.Replace("-", "").ToLower();
        }
      public static byte[] MD5Encryption(string ToEncrypt)
        {
            // Create instance of the crypto provider.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            // Create a Byte array to store the encryption to return.
            byte[] hashedbytes;
            // Required UTF8 Encoding used to encode the input value to a usable state.
            UTF8Encoding textencoder = new UTF8Encoding();

            // let the show begin.
            hashedbytes = md5.ComputeHash(textencoder.GetBytes(ToEncrypt));
            // Destroy objects that aren't needed.
            md5.Clear();
            md5 = null;

            // return the hased bytes to the calling method.
            return hashedbytes;
        }

        /// <summary>
        /// Encode a string to 64 bit 
        /// </summary>
        /// <param name="sInputString">Input string</param>
        /// <returns>encoded string</returns>
        public static string Encode64BitString(string sInputString)
        {
           string sEncodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(sInputString)));
           return sEncodedString;
        }
        /// <summary>
        /// Decodes a 64 bit string to string
        /// </summary>
        /// <param name="sInputString">encoded string</param>
        /// <returns>decoded string</returns>
        public static string Decode64BitString(string sInputString)
        {
            string sDecodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(sInputString));
            return sDecodedString;
        }


        /// <remarks>
        /// Depending on the legal key size limitations of a specific CryptoService provider
        /// and length of the private key provided, padding the secret key with space character
        /// to meet the legal size of the algorithm.
        /// </remarks>
        private byte[] GetLegalKey(string Key)
        {
            string sTemp;
            if (mobjCryptoService.LegalKeySizes.Length > 0)
            {
                int lessSize = 0, moreSize = mobjCryptoService.LegalKeySizes[0].MinSize;
                // key sizes are in bits
                while (Key.Length * 8 > moreSize)
                {
                    lessSize = moreSize;
                    moreSize += mobjCryptoService.LegalKeySizes[0].SkipSize;
                }
                sTemp = Key.PadRight(moreSize / 8, ' ');
            }
            else
                sTemp = Key;

            // convert the secret key to byte array
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string Encrypting(string Source, string Key)
        {
            byte[] bytIn = System.Text.ASCIIEncoding.ASCII.GetBytes(Source);
            // create a MemoryStream so that the process can be done without I/O files
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            byte[] bytKey = GetLegalKey(Key);

            // set the private key
            mobjCryptoService.Key = bytKey;
            mobjCryptoService.IV = bytKey;

            // create an Encryptor from the Provider Service instance
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();

            // create Crypto Stream that transforms a stream using the encryption
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);

            // write out encrypted content into MemoryStream
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();

            // get the output and trim the '\0' bytes
            byte[] bytOut = ms.GetBuffer();
            int i = 0;
            for (i = 0; i < bytOut.Length; i++)
                if (bytOut[i] == 0)
                    break;

            // convert into Base64 so that the result can be used in xml
            return System.Convert.ToBase64String(bytOut, 0, i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string Decrypting(string Source, string Key)
        {
            // convert from Base64 to binary
            byte[] bytIn = System.Convert.FromBase64String(Source);
            // create a MemoryStream with the input
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);

            byte[] bytKey = GetLegalKey(Key);

            // set the private key
            mobjCryptoService.Key = bytKey;
            mobjCryptoService.IV = bytKey;

            // create a Decryptor from the Provider Service instance
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();

            // create Crypto Stream that transforms a stream using the decryption
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

            // read out the result from the Crypto Stream
            System.IO.StreamReader sr = new System.IO.StreamReader(cs);
            return sr.ReadToEnd();
        }

    }

}

