using System;
using System.IO;
using System.Text;

namespace CSharpConcepts
{
	public class DataAccess
	{
		public void Run()
		{
			Console.Write("Inside Data Access Class");
			FileStreamCreateAndUse();
		}
		
		public void FileStreamCreateAndUse()
		{
			Console.WriteLine("FileStream create file example");
			string path = "tmp.txt";
			using(FileStream fileStream = File.Create(path))
			{
				string myValue = "Mayank is .......";
				byte[] data = Encoding.UTF8.GetBytes(myValue);
				fileStream.Write(data,0,data.Length);
			}
		}
	}
}