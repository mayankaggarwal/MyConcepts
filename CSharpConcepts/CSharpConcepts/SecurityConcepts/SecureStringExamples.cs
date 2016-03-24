using System;
using CSharpConcepts.Interfaces;
using System.Security;
using System.Runtime.InteropServices;

namespace CSharpConcepts.SecurityConcepts
{
    internal class SecureStringExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Secure String Examples:");
        }

        public void MainMethod()
        {
            InitilizingSecureStringExample();
            ConvertToUnsecureString();
        
        }

        private SecureString ReadSecureString(SecureString ss)
        {
            Console.Write("Enter any string to be secured :");
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter) break;

                ss.AppendChar(cki.KeyChar);
                Console.Write("*");
            }
            ss.MakeReadOnly();
            return ss;
        }
        private void InitilizingSecureStringExample()
        {
            Console.WriteLine("Intializing Secure string example:");
            using (SecureString ss = new SecureString())
            {
                ReadSecureString(ss);
            }
            Console.WriteLine("\nEntered key was read securely");
        }

        private void ConvertToUnsecureString()
        {
            Console.WriteLine("Converting secure string to unsecure string using pointers");
            using (SecureString secureString = new SecureString())
            {
                ReadSecureString(secureString);
                IntPtr unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = Marshal.SecureStringToCoTaskMemUnicode(secureString);
                    Console.WriteLine("\n" + Marshal.PtrToStringUni(unmanagedString));
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
        }
    }
}