using System;

namespace CSharpConcepts
{
	public class ProgramFlow
	{
		public void Run()
		{
			Console.WriteLine("Inside Program Flow");
			lottery_program();
		}

		public void lottery_program()
		{
			int[] picked = new int[6];
			Random rnd = new Random(DateTime.Now.Year);
			for(int i=0;i<6;i++)
			{
				picked[i] = rnd.Next(49);
			}

			Console.WriteLine("Your Lotto numbers is:");
			for(int j=0;j<6;j++)
			{
				Console.WriteLine(" " + picked[j] + " ");
			}
		}
	}
}
