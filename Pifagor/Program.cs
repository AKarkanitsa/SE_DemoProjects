using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pifagor
{
	
	public class Program
	{
		//Является ли число простым  (входе - число, выходе - да или нет)
        public static bool IsPrime(int x)
		{
			if (x <= 1) return false;
			for (int i = 2; i <= x / 2; i++)
				if (x % i == 0) return false;
			return true;
		}

		static int isPossible(int N)                 
		{
			for (int i = 2; i <= N-i; i++)
			{
				if (IsPrime(i) && IsPrime(N - i))
				{
					Console.WriteLine("{0} {1}", i, N - i);
					return N - i;
				}
			}
			return 0;

		}

        static void Main()
        {
			int c = 11;
			int a = isPossible(c);
			if (a != 0)
			{
				Console.WriteLine("{0} = {1} + {2}", c, a, c - a);
			}
			else Console.WriteLine("Число {0} нельзя представить суммой двух простых чисел",c);
        }
    }

}
