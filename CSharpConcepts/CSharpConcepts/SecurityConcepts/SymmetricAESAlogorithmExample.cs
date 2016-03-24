using System;
using CSharpConcepts.Interfaces;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace CSharpConcepts.SecurityConcepts
{
    internal class SymmetricAESAlogorithmExample : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Cryptography Examples");
        }

        public void MainMethod()
        {
            EncryptUsingAES();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            RSAPublicAndPrivateKeys();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            EncryptUsingRSA();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
        }

        private void EncryptUsingAES()
        {
            Console.WriteLine("Advanced Encryption Standard is a symmetric algorithm");
            Console.WriteLine("By using CryptoClass we can encrypt r decrypt a byte sequence");
            string original = "My secret data";

            using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string roundtrip = Decrypt(symmetricAlgorithm, encrypted);
                Console.WriteLine("Original :{0}, Round Trip :{1}", original, roundtrip);
            }

            
        }

        private void RSAPublicAndPrivateKeys()
        {
            Console.WriteLine("RSACryptoServiceProvider and DSACryptoServiceProvider are asymmetric algorithms");
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                Console.WriteLine("Public Key :\n {0}", publicKey);
                Console.WriteLine("Private Key :\n {0}", privateKey);
            }
        }

        private void EncryptUsingRSA()
        {
            Console.WriteLine("RSA implementation example");
            using (RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider())
            {
                string publicKey = rsa1.ToXmlString(false);
                string privateKey = rsa1.ToXmlString(true);

                string data = "My Secret Data";
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = ByteConverter.GetBytes(data);

                byte[] encryptedData;
                using (RSACryptoServiceProvider encrypter = new RSACryptoServiceProvider())
                {
                    encrypter.FromXmlString(publicKey);
                    encryptedData = encrypter.Encrypt(dataToEncrypt,false);
                }

                if(encryptedData!=null)
                {
                    byte[] decryptedData = null;
                    using (RSACryptoServiceProvider decryptor = new RSACryptoServiceProvider())
                    {
                        decryptor.FromXmlString(privateKey);
                        decryptedData = decryptor.Decrypt(encryptedData,false);
                    }

                    if(decryptedData!=null)
                    {
                        string decryptedText = ByteConverter.GetString(decryptedData);
                        Console.WriteLine("Original : {0}, RoundTrip :{1}", data, decryptedText);
                    }
                    else
                    {
                        Console.WriteLine("Failed to Decrypt Data");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to encrypt data");
                }
            }
        }

        #region "Symmetric Algorithms"
        private byte[] Encrypt(SymmetricAlgorithm symmetricAlgorithm, string original)
        {
            ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(original);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        private string Decrypt(SymmetricAlgorithm symmetricAlgorithm, byte[] encrypted)
        {
            ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
            using (MemoryStream msDecrypt = new MemoryStream(encrypted))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                    {
                        return swDecrypt.ReadToEnd();
                    }
                }
            }
        }
        #endregion
    }
}