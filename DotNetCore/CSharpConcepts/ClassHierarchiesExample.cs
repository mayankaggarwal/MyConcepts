using System;

namespace CSharpConcepts
{
	public class ClassHierarchiesExamples
	{
		public void Run()
		{
			Console.WriteLine("Class Hierarchies Examples");
		}
	}

	public class Person1
	{
		private String firstName;
		private String lastName;

		public String FirstName
		{
			get
			{
				return firstName;
			}
		}

		public String LastName
		{
			get
			{
				return lastName;
			}
		}

		public Person1(string firstName,string lastName)
		{
			if(String.IsNullOrEmpty(firstName))
				throw new ArgumentException("First Name must not be null or empty",firstName);

			if(String.IsNullOrEmpty(lastName))
				throw new ArgumentException("Last Name must not be null or empty",lastName);

			this.firstName = firstName;
			this.lastName = lastName;
		}
	}

	public class Employee1:Person1
	{
		public String DepartmentName{get;private set;}
		public Employee1(string firstName,string lastName,string departmentName):base(firstName,lastName)
		{
			if(String.IsNullOrEmpty(departmentName))
				throw new ArgumentException("Department Name must not be null or empty",departmentName);

			this.DepartmentName = departmentName;
		}
	}
	
}
