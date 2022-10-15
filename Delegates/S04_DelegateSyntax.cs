using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
	public delegate void TellUser(string message); 
    public class DelegateSyntax
    {
		static void Run(TellUser tellUser)
		{

			tellUser("hi!");
			tellUser("how r u?");
		}

		static void SaySomething(string message)
		{
			Console.WriteLine("===============");
			Console.WriteLine(message);
			Console.WriteLine("===============");
		}
		public static void Main()
		{
			//делегает указывет на метод Console.WriteLine
			Run(Console.WriteLine);
			//делегает указывет на метод SaySomething
			Run(SaySomething);
		}
	
		
	}
}
