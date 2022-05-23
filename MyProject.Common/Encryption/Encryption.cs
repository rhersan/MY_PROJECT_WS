using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Encryption
{
    public class Encryption
    {
        public static async Task<string> Encrypt(string data, string key)
        {
            try
            {
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.Mode = CipherMode.CBC;
                rijndaelCipher.Padding = PaddingMode.PKCS7;
                rijndaelCipher.KeySize = 0x80;
                rijndaelCipher.BlockSize = 0x80;

                byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
                byte[] keyBytes = new byte[16];
                int len = pwdBytes.Length;

                if (len > keyBytes.Length)
                {
                    len = keyBytes.Length;
                }

                Array.Copy(pwdBytes, keyBytes, len);
                rijndaelCipher.Key = keyBytes;
                rijndaelCipher.IV = keyBytes;

                ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(data);
                return await Task.FromResult<string>(
                    Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> Decrypt(string data, string key)
        {
            try
            {
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.Mode = CipherMode.CBC;
                rijndaelCipher.Padding = PaddingMode.PKCS7;
                rijndaelCipher.KeySize = 0x80;
                rijndaelCipher.BlockSize = 0x80;

                byte[] encryptedData = Convert.FromBase64String(data);
                byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
                byte[] keyBytes = new byte[16];
                int len = pwdBytes.Length;

                if (len > keyBytes.Length)
                {
                    len = keyBytes.Length;
                }

                Array.Copy(pwdBytes, keyBytes, len);
                rijndaelCipher.Key = keyBytes;
                rijndaelCipher.IV = keyBytes;

                byte[] plainText = rijndaelCipher.CreateDecryptor()
                    .TransformFinalBlock(encryptedData, 0, encryptedData.Length);

                return await Task.FromResult<string>(Encoding.UTF8.GetString(plainText));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
