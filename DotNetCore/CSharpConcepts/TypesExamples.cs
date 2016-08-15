using System;

namespace CSharpConcepts
{
	public class TypesExamples
	{
		public void Run()
		{
			Console.WriteLine("In Types Examples");
			//InitializingValueTypes();
			//ValueTypesValues();
			//UsingStruct();
			//UsingExtensionMethods();
			//NamedArgumentExample();
			UsingIndexers();
		}

		public void InitializingValueTypes()
		{
			int num1 = 1;
			Int32 num2 = 2;
			int num3 = new int();
			Int32 num4 = new Int32();
			Console.WriteLine("Num1 is {0}, Num2 is {1}, Num3 is {2}, Num4 is {3}",num1,num2,num3,num4);
		}

		public void ValueTypesValues()
		{
			Console.WriteLine("Value Types properties");
			int myInt;
			double myDouble;
			byte myByte;
			char myChar;
			decimal myDecimal;
			float myFloat;
			long myLong;
			short myShort;
			bool myBool;
				
			myInt = 2147483647;
			Console.WriteLine("Integer");
			Console.WriteLine(myInt);
			Console.WriteLine(myInt.GetType());
			Console.WriteLine(sizeof(int));
			Console.WriteLine();

			myDouble = 5000.0;
			Console.WriteLine("Double");
			Console.WriteLine(myDouble);
			Console.WriteLine(myDouble.GetType());
			Console.WriteLine(sizeof(double));
			Console.WriteLine();

			myByte = 254;
			Console.WriteLine("Byte");
			Console.WriteLine(myByte);
			Console.WriteLine(myByte.GetType());
			Console.WriteLine(sizeof(byte));
			Console.WriteLine();

			myChar = 'r';
			Console.WriteLine("Char");
			Console.WriteLine(myChar);
			Console.WriteLine(myChar.GetType());
			Console.WriteLine(sizeof(byte));
			Console.WriteLine();
			
			myDecimal = 20987.89756M;
			Console.WriteLine("Decimal");
			Console.WriteLine(myDecimal);
			Console.WriteLine(myDecimal.GetType());
			Console.WriteLine(sizeof(byte));
			Console.WriteLine();

			myFloat = 254.09F;
			Console.WriteLine("Float");
			Console.WriteLine(myFloat);
			Console.WriteLine(myFloat.GetType());
			Console.WriteLine(sizeof(byte));
			Console.WriteLine();

			myLong = 2544567538754;
			Console.WriteLine("Long");
			Console.WriteLine(myLong);
			Console.WriteLine(myLong.GetType());
			Console.WriteLine(sizeof(byte));
			Console.WriteLine();

			myShort = 3276;
			Console.WriteLine("Short");
			Console.WriteLine(myShort);
			Console.WriteLine(myShort.GetType());
			Console.WriteLine(sizeof(byte));
			Console.WriteLine();

			myBool = true;
			Console.WriteLine("Boolean");
			Console.WriteLine(myBool);
			Console.WriteLine(myBool.GetType());
			Console.WriteLine(sizeof(byte));
			Console.WriteLine();
		}
		public void UsingStruct()
		{
			Console.WriteLine("Inside Using Struct example");
			Book book = new Book("Word power made easy","English Reading","Norman Lewis",686,1400,818307100,"Soft Cover");
			Console.WriteLine(book.Title + "\n" + book.Category + "\n" + book.Author + "\n" + book.NumberOfPages + "\n"
				+ book.CurrentPage + "\n" + book.ISBN + "\n" + book.CoverStyle); 
		}

		public void UsingExtensionMethods()
		{
			Console.WriteLine("Using extension methods");
			int num = 5;
			Console.WriteLine("Square of number {0} is :{1}",num,num.square());
		}

		public void NamedArgumentExample()
		{
			Console.WriteLine("Named argument example");
			Console.WriteLine("Area of rectangle with length {0} and width {1} is {2}",22,23.6,rectArea(width:23.6,length:22));
		}

		public double rectArea(int length,double width)
		{
			return length * width;
		}

		public void UsingIndexers()
		{
			Console.WriteLine("In indexers example");
			IPAddress address = new IPAddress();
			for(int i=0;i<32;i++)
			{
				address[i] = 0;
			}
		}
	}

	public struct Book
	{
		public String Title;
		public String Category;
		public String Author;
		public Int32 NumberOfPages;
		public Int32 CurrentPage;
		public Double ISBN;
		public String CoverStyle;

		public Book(string title,string category,string author,int numberOfPages,int currentPage,double ISBN,string coverStyle)
		{
			this.Title = title;
			this.Category = category;
			this.Author = author;
			this.NumberOfPages = numberOfPages;
			if(currentPage > 0 && currentPage <= this.NumberOfPages)
				this.CurrentPage = currentPage;
			else
				this.CurrentPage = 1;
			this.ISBN = ISBN;
			this.CoverStyle = coverStyle;
		}		

		public void NextPage()
		{
			if(CurrentPage != NumberOfPages)
			{
				CurrentPage++;
				Console.WriteLine("Current Page is now:{0}",CurrentPage);
			}
			else{
				Console.WriteLine("End of Book.");
			}
		}

		public void PreviousPage()
		{
			if(CurrentPage > 1)
			{
				CurrentPage--;
				Console.WriteLine("Current page is now:{0}",CurrentPage);
			}
			else
			{
				Console.WriteLine("Beginning of Book.");
			}
		}
	}

	public static class MyExtensionMethod
	{
		public static int square(this int num)
		{
			return num*num;
		}
	}

	public class IPAddress
	{
		private int[] ip;
		public int this[int index]
		{
			get{
				if(ip != null && index < ip.Length && index >=0)
					return ip[index];
				else
					throw new Exception("Invalid index"); 
			}
			set
			{
				if(value == 0 || value == 1)
					ip[index] = value;
				else
					throw new Exception("Invalid value");
			}
		}
		public IPAddress()
		{
			ip = new int[100];
		}
	}
}
