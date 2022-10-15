using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonStaticDelegate
{
	public delegate int StringComparer(string x, string y);

	class Comparer
	{
		public bool Descending { get; set; }
		public int CompareStrings(string x, string y)
		{
			return x.CompareTo(y) * (Descending ? -1 : 1);
		}
	}
	public class NonStaticMethod
    {
		static int CompareStringLength(string x, string y)
		{
			return x.Length.CompareTo(y.Length);
		}

		public static void SortStrings(string[] array, StringComparer comparer)
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
			var strings = new[] { "A", "B", "AA" };
			var lengthComparer = new StringComparer(CompareStringLength);
			//Вызываем через делегата статический метод CompareStringLength
			SortStrings(strings, lengthComparer);


			//Создаем объект типа Comparer. В классе Comparer реализован нестатический метод CompareStrings
			//для сравнения строк в алфавитном порядке (по возрастсанию или убыванию)
			var obj = new Comparer { Descending = true };
			//Создаем объект-делегат и свзываем его с нестатическим методом CompareStrings,
			//поэтому обращаемся к нему через имя объекта - obj.CompareStrings
			var simpleComparer = new StringComparer(obj.CompareStrings);
			//сортируем строки
			SortStrings(strings, simpleComparer);
		}
	}
}
