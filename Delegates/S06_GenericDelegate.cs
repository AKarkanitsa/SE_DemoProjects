using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
	public delegate int ObjectComparer<T> (T x, T y);
	class Comparer
	{
		public bool Descending { get; set; }
		public int Compare<T>(T x, T y) where T : IComparable
		{
			return x.CompareTo(y) * (Descending ? -1 : 1);
		}
	}
	public class GenericDelegate
    {
		public static void Sort<T>(T[] array, ObjectComparer<T> comparer)
		{
			for (int i = array.Length - 1; i > 0; i--)
				for (int j = 1; j <= i; j++)
				{
					var element1 = array[j - 1];
					var element2 = array[j];
					if (comparer(element1, element2) > 0)
					{
						var temporary = array[j];
						array[j] = array[j - 1];
						array[j - 1] = temporary;
					}
				}
		}

		static void MainX()
		{
			var strings = new[] { "A", "B", "AA", "C", "AAA" };
			var obj1 = new Comparer { Descending = false };
			//Сортируем строковый массив
			Sort(strings, obj1.Compare);

			var ints = new[] { 2, 4, 8, 12, 7, 10, 1 };
			var obj2 = new Comparer { Descending = false };
			//Сортируем массив чисел
			Sort(ints, obj2.Compare);
			Console.WriteLine();
		}
	}
}
