using System;
using CSharpConcepts.Interfaces;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Security.Cryptography;

namespace CSharpConcepts.SecurityConcepts
{
    internal class DigitalCertificateExample : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Securing data using digital certificates");
        }

        public void MainMethod()
        {
            SignAndVerify();
        }

        private void SignAndVerify()
        {
            Console.Write("It included signing the text data.");
            Console.Write("\n 1. Fetch certificate from cert store.");
            Console.Write("\n 2. Fetch private key of the cert.");
            Console.Write("\n 3. Compute Hash value of text");
            Console.WriteLine("\n 4. Sign the computed hash value using the certificate to generate signature");

            Console.WriteLine("It than included verifying the signature with actual data");
            string textToSign = "Test paragraph";
            byte[] signature = Sign(textToSign, "CN=MayankTestCert");
            Console.WriteLine("Is certification valid :{0}", Verify(textToSign, signature));
        }

        private byte[] Sign(string text,string certSubject)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        private bool Verify(string text,byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        private X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertStore", StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];
            return certificate;
        }

        private byte[] HashData(string text)
        {
            UnicodeEncoding encoder = new UnicodeEncoding();
            HashAlgorithm algo = new SHA1Managed();
            byte[] data = encoder.GetBytes(text);
            return algo.ComputeHash(data);
        }
    }
}