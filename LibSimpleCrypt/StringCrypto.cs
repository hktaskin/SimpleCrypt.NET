using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LibSimpleCrypt
{
    public static class StringCrypto
    {
        public static string Encrypt(this string plaintext, string strkey)
        {
            // string key'i AES keyine donustur
            byte[] key;
            using (SHA256Managed hash = new SHA256Managed())
                key = hash.ComputeHash(Encoding.UTF8.GetBytes(strkey));

            // Random IV uret
            byte[] iv = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                rng.GetBytes(iv);

            byte[] ciphertext;

            // AES ile sifreleme
            using (AesManaged aes = new AesManaged())
            {
                aes.Mode = CipherMode.CBC;
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // plaintext'i sifrele
                            swEncrypt.Write(plaintext);
                        }
                        // ciphtertext'i byte array'e yaz
                        ciphertext = msEncrypt.ToArray();
                    }
                }
            }

            // Ciphertext ve IV yi birlestir
            byte[] result = new byte[ciphertext.Length + iv.Length];
            Array.Copy(ciphertext, 0, result, 0, ciphertext.Length);
            Array.Copy(iv, 0, result, ciphertext.Length, iv.Length);

            // Base64 ile encode et
            string final = Convert.ToBase64String(result);

            return final;
        }

        public static string Decrypt(this string strciphertext, string strkey)
        {
            // Base64'u decode et
            byte[] byteciphertext = Convert.FromBase64String(strciphertext);

            // string key'i AES keyine donustur
            byte[] key;
            using (SHA256Managed hash = new SHA256Managed())
                key = hash.ComputeHash(Encoding.UTF8.GetBytes(strkey));

            // IV ve ciphertext'i cikar
            byte[] ciphertext = new byte[byteciphertext.Length - 16];
            byte[] iv = new byte[16];
            Array.Copy(byteciphertext, 0, ciphertext, 0, ciphertext.Length);
            Array.Copy(byteciphertext, ciphertext.Length, iv, 0, iv.Length);

            string plaintext = null;

            // AES ile sifre cozme
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static bool Test()
        {
            string plaintext = Guid.NewGuid().ToString();

            string key = Guid.NewGuid().ToString();

            string ciphertext = StringCrypto.Encrypt(plaintext, key);

            string new_plaintext = StringCrypto.Decrypt(ciphertext, key);

            return plaintext.Equals(new_plaintext);
        }
    }
}
