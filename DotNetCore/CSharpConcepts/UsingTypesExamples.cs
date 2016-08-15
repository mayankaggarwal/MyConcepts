using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpConcepts
{
	public class UsingTypesExamples
	{
		public void Run()
		{
			Console.WriteLine("Inside Using Types examples");
			//ArrayTypeConversionExample();
			//ConversionByParsing();
			CallUnmanagedCode();
		}

		public void ArrayTypeConversionExample()
		{
			Console.WriteLine("Array type converion example:");
			Employee[] employees = new Employee[10];
			for(int i=0;i<10;i++)
				employees[i] = new Employee(i);

			Person[] persons;
			persons = employees;
			employees = (Employee[])persons;
			if(persons is Employee[])
				Console.WriteLine("Persons are Employees");

			employees = persons as Employee[];

			Manager[] managers;
			managers = persons as Manager[];
			
			if(persons is Manager[])
			{
				Console.WriteLine("Persons are managers");
			}
			else
			{
				Console.WriteLine("Persons are not managers");
			}
		}

		public void ConversionByParsing()
		{
			Console.WriteLine("Conversion by Parsing example");
			//var usCulture = CultureInfo.CreateSpecificCulture("en-US");
			CultureInfo usCulture = new CultureInfo("en-US");
			string number = "$123,456.78";
			decimal amount = decimal.Parse(number,NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint,usCulture);
			Console.WriteLine("The parsed amount for number {0} is:{1}",number,amount);
		}
		
		[DllImport("kernel32.dll",CharSet=CharSet.Unicode,SetLastError = true)]
		public static extern uint GetShortPathName(string lpszLongPath,char[] lpszShortPath,int cchBuffer);
		
		public void CallUnmanagedCode()
		{
			string longName = @"D:\ebooks\70_483\MCSD Certification Toolkit (Exam 70-483) Programming in C # -nelly-.pdf";
			char[] buffer = new char[1024];
			long length = GetShortPathName(longName,buffer,buffer.Length);
			string shortName = new string(buffer);
			Console.WriteLine("Long Name :{0} and ShortName :{1}",longName,shortName);
		}	
	}

	public class Person
	{
	}

	public class Employee:Person
	{
		private Int32 _ID;
		private String _FirstName;

		public Int32 ID
		{
			get;
		}

		public String FirstName
		{
			get
			{
				return _FirstName;
			}
		}
		public Employee(int ID)
		{
			this._ID = ID;
		}

		public Employee(int ID,string firstName)
		{
			this._ID = ID;
			this._FirstName = firstName;
		}
	}

	public class Manager:Employee
	{
		public Manager(int ID):base(ID)
		{
		}

		public Manager(int ID,string firstName):base(ID,firstName)
		{
		}
		
	}
}
