using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/**
* @author: Chalaka Hasantha
* @clr_current_version: 4.0.30319.42000
* @file_created_time - 4/21/2020 9:26:06 PM 
* @year: 2020
*/

namespace Election_voting.Controller
{
	//Encrypt Method UTF8 
    public class Encrypt_Decrypt_MD5
    {
        string hash = "rsZx5tJUiI%$";
        public string EncryptString(string text)
        {
            byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }

        }
	
	//Decrypt Method
        public string DecryptString(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }

        }
    }
}