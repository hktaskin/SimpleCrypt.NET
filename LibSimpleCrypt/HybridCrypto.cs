using System;
using System.IO;
using System.Security.Cryptography;

namespace LibSimpleCrypt
{
    public static class HybridCrypto
    {
        /*
         * Heavily influenced from
         * https://msdn.microsoft.com/en-us/library/bb397867(v=vs.110).aspx
         */

        const int KEY_SIZE_BYTES = 32;
        const int IV_SIZE_BYTES = 16;

         /// <summary>
         /// 
         /// </summary>
         /// <param name="inputStream">Input stream for plaintext, any stream with read capability is allowed.</param>
         /// <param name="outputFile">File name for the encrypted content to be saved. Any existing file will be overridden.</param>
         /// <param name="strPublickey"></param>
        public static void Encrypt(Stream inputStream, string outputFile, string strPublickey)
        {
            if (!inputStream.CanRead)
                throw new Exception("Input stream should be readable!");

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportCspBlob(Convert.FromBase64String(strPublickey));

            if (!rsa.PublicOnly)
                throw new Exception("Don't use the private key blob for public key operations. Keep it in a safe place!");

            // Random Key ve IV üret
            byte[] key = new byte[KEY_SIZE_BYTES];
            byte[] iv = new byte[IV_SIZE_BYTES];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);
            }

            // Key'i rsa ile şifrele
            byte[] encryptedKey = rsa.Encrypt(key, false);
            rsa.Clear();

            // Create byte arrays to contain
            // the length values of the key and IV.
            byte[] lenEncKey = new byte[4];
            byte[] lenIV = new byte[4];

            lenEncKey = BitConverter.GetBytes(encryptedKey.Length);
            lenIV = BitConverter.GetBytes(iv.Length);

            // Dosyayı key ve iv ile şifrele
            // IV ve şifreli dosyayı kaydet
            using (FileStream outputStream = new FileStream(outputFile, FileMode.Create))
            {
                outputStream.Write(lenEncKey, 0, 4);
                outputStream.Write(lenIV, 0, 4);
                outputStream.Write(encryptedKey, 0, encryptedKey.Length);
                outputStream.Write(iv, 0, iv.Length);

                using (AesManaged aes = new AesManaged())
                {
                    aes.Mode = CipherMode.CBC;
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (CryptoStream outStreamEncrypted = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        int count = 0;
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        do
                        {
                            count = inputStream.Read(data, 0, blockSizeBytes);
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        }
                        while (count > 0);

                        outStreamEncrypted.FlushFinalBlock();
                        outStreamEncrypted.Close();
                    }
                    outputStream.Close();
                }
                Array.Clear(key, 0, key.Length);
            }
        }

        public static void Decrypt(Stream encryptedFile, string outputFile, string strPrivatekey)
        {
            if (!encryptedFile.CanRead)
                throw new Exception("Input stream should be readable!");

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportCspBlob(Convert.FromBase64String(strPrivatekey));

            if (rsa.PublicOnly)
                throw new Exception("The blob does not contain any private key!");

            // Dosyadan iv ve encrypted key çıkar.

            // headerdan 8 byte oku, enckey ve iv boylarını öğren
            byte[] lenEncKey = new byte[4];
            byte[] lenIV = new byte[4];

            encryptedFile.Read(lenEncKey, 0, 4);
            encryptedFile.Read(lenIV, 0, 4);

            int lEncKey = BitConverter.ToInt32(lenEncKey, 0);
            int lIV = BitConverter.ToInt32(lenIV, 0);

            byte[] encryptedKey = new byte[lEncKey];
            encryptedFile.Read(encryptedKey, 0, lEncKey);

            byte[] iv = new byte[lIV];
            encryptedFile.Read(iv, 0, lIV);

            // encrypted key'i çöz
            byte[] key = rsa.Decrypt(encryptedKey, false);
            rsa.Clear();

            // dosyayı çöz
            using (FileStream outputStream = new FileStream(outputFile, FileMode.Create))
            {
                using (AesManaged aes = new AesManaged())
                {
                    aes.Mode = CipherMode.CBC;
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (CryptoStream outStreamEncrypted = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        int count = 0;
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        do
                        {
                            count = encryptedFile.Read(data, 0, blockSizeBytes);
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        }
                        while (count > 0);

                        outStreamEncrypted.FlushFinalBlock();
                        outStreamEncrypted.Close();
                    }
                    outputStream.Close();
                }
                Array.Clear(key, 0, key.Length);
            }
        }

        public static string GenerateKeyPair()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                string _private = Convert.ToBase64String(rsa.ExportCspBlob(true));
                string _public = Convert.ToBase64String(rsa.ExportCspBlob(false));
                //Console.WriteLine("\r\nPrivate: " + _private);
                //Console.WriteLine("\r\nPublic: " + _public);
                return "PRIVATE\r\n" + _private + "\r\nPUBLIC\r\n" + _public;
            }
        }
    }
}
