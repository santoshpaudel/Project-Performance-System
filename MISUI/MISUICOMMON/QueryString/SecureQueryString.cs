using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MISUICOMMON.QueryString
{
  /// <summary>
  /// Provides a secure means for transfering data within a query string.
  /// 
  /// </summary>
  public class SecureQueryString : NameValueCollection
  {
    public SecureQueryString() : base() { }

    public SecureQueryString(string encryptedString)
    {
      deserialize(decrypt(encryptedString));  
    }

    /// <summary>
    /// Returns the encrypted query string.
    /// </summary>
    public string EncryptedString
    {
      get
      {
          return "?enc=" + HttpUtility.UrlEncode(encrypt(serialize()));
      }
    }
     

    /// <summary>
    /// Returns the EncryptedString property.
    /// </summary>
    public override string ToString()
    {
      return EncryptedString;
    }

    /// <summary>
    /// Encrypts a serialized query string 
    /// </summary>
    private string encrypt(string serializedQueryString)
    {
      byte[] buffer = Encoding.ASCII.GetBytes(serializedQueryString);
      TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
      MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
      des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
      des.IV = IV;
      //modified for mozilla url issue
      return EncryptionHelper.Encode64BitString(serializedQueryString);
            
    }

    /// <summary>
    /// Decrypts a serialized query string
    /// </summary>
    private string decrypt(string encryptedQueryString)

    {
      try
      {
        byte[] buffer = Convert.FromBase64String(encryptedQueryString);
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
        des.IV = IV;
        //modified for mozilla url issue
        return EncryptionHelper.Decode64BitString(encryptedQueryString);
       

      }
      catch (CryptographicException)
      {
        return "";
        //throw new InvalidFormatException();
      }
      catch (FormatException)
      {
        return "";
        //throw new InvalidFormatException();
      }
    }

    /// <summary>
    /// Deserializes a decrypted query string and stores it
    /// as name/value pairs.
    /// </summary>
    private void deserialize(string decryptedQueryString)
    {
      string[] nameValuePairs = decryptedQueryString.Split('&');
      for (int i = 0; i < nameValuePairs.Length; i++)
      {
        string[] nameValue = nameValuePairs[i].Split('=');
        if (nameValue.Length == 2)
        {
          base.Add(nameValue[0], nameValue[1]);
        }
      }
    }

    /// <summary>
    /// Serializes the underlying NameValueCollection as a QueryString
    /// </summary>
    private string serialize()
    {
      StringBuilder sb = new StringBuilder();
      foreach (string key in base.AllKeys)
      {
        sb.Append(key);
        sb.Append('=');
        sb.Append(base[key]);
        sb.Append('&');
      }

      return sb.ToString();
    }

    // The key used for generating the encrypted string
    private const string cryptoKey = "TradeFlow";

    // The Initialization Vector for the DES encryption routine
    private readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };


   
  }
            

}
