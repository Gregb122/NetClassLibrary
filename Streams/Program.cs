using System;
using System.IO.Compression;
using System.IO;
using System.Security.Cryptography;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {

            string original = "Here is some data to encrypt!";

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization 
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {

                // Encrypt the string to an array of bytes.
                Stream encrypted = EncryptStringToGZip_Aes("file.txt", myAes.Key, myAes.IV);

                // Decrypt the bytes to a string.
                Stream roundtrip = DecryptStringFromGZip_Aes(encrypted, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);

                roundtrip.Close();
            }
        }

        private static Stream EncryptStringToGZip_Aes(string fileName, byte[] key, byte[] iV)
        {
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                FileStream fs = new FileStream(fileName, FileMode.Open);
                CryptoStream csEncrypt = new CryptoStream(fs, encryptor, CryptoStreamMode.Write);
                GZipStream swEncrypt = new GZipStream(csEncrypt, CompressionMode.Compress);

                return swEncrypt;
            }
        }

        private static Stream DecryptStringFromGZip_Aes(Stream fs, byte[] key, byte[] iV)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                GZipStream swEncrypt = new GZipStream(fs, CompressionMode.Decompress);
                CryptoStream csEncrypt = new CryptoStream(swEncrypt, decryptor, CryptoStreamMode.Write);

                return csEncrypt;
            }
        }
    }
}
