using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegates
{
	public delegate  bool TryGet<T1, T2>(T1 x, Action<string> y, out int z);
	
	public class ActionDelegate
    {
		static void MainX()
		{
			Run(AskUser, Console.WriteLine);
		}

		static void Run(TryGet<string, int> askUser, Action<string> tellUser)
		{
			int age;
			if (askUser("What is your age?", tellUser, out age))
				tellUser("Age: " + age);
		}

		static bool AskUser(string questionText, Action<string> tellUser, out int age)
		{
			tellUser(questionText);
			var answer = Console.ReadLine();
			return int.TryParse(answer, out age);
		}
	}
}
