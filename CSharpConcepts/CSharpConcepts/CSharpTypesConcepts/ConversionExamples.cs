using System;
using CSharpConcepts.Interfaces;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpConcepts.CSharpTypesConcepts
{
    internal class ConversionExamples : IMainMethod
    {
        public void MainMethod()
        {
            Console.WriteLine("Type Casting Examples");
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint GetShortPathName(
            [MarshalAs(UnmanagedType.LPTStr)] string lpszLongPath,
            char[] lpszShortPath, int cchBuffer);

        public void CallUnmanagedCode()
        {
            string longName = @"D:\ebooks\70_483\MCSD Certification Toolkit (Exam 70-483) Programming in C # -nelly-.pdf";
            char[] buffer = new char[1024];
            //StringBuilder buffer = new StringBuilder();
            long length = GetShortPathName(longName, buffer, buffer.Length);
            string shortName = new string(buffer);
            Console.WriteLine("Long Name :{0} \nShortName :{1}", longName, shortName);
        }

        public void SummaryMethod()
        {
            ParsingMethodExample();
            CallUnmanagedCode();
        }

        public void ParsingMethodExample()
        {
            var usCulture = CultureInfo.CreateSpecificCulture("en-US");
            string number = "$123,456.78";
            decimal amount = decimal.Parse(number,
                NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands |
                NumberStyles.AllowDecimalPoint, usCulture);
            Console.WriteLine("The amount {0} after conversion is :{1}", number, amount);
        }
    }
}