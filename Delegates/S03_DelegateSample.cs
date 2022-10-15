using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
	//Объявляем делегата
	//Делегат - это указатель на метод. В данном случае на любой метод, который
	//возвращает int и принимает два строковых параметра
	//Делегат - это не член класса. Это сам по себе тип данных. Не объявляем его внутри класса.
	public delegate int StringComparer(string x, string y);
	public class DelegateSample
	{
		//В методе SortStrings второй параметр имеет тип делегата StringComparer,
		//то есть вместо этого параметра можно передать любой метод, соответствующий сигнатере делегата
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

		//Но для обеспечения делегирования приходится писать 
		//слишком много инфраструктурного кода: объявлять класс,
		//реализовывать интерфейс. Задача: сократить объем инфраструктурного кода
		public static int CompareLength (string x, string y) 
		{
			return x.Length.CompareTo(y.Length);
		}

		static void MainX()
		{
			var strings = new[] { "A", "BBBB", "AA","BB" };
			
			StringComparer comparer; //объявляем объект-делегат
			comparer = CompareLength; //назначаем делегату метод
			//Вызываем метод SortStrings и передаем ему вместо второго параметра объект-делегат,
			//указывающий на метод CompareLength
			SortStrings(strings, comparer);
			SortStrings(strings, comparer);

			//Тоже самое можно записать корооче
			SortStrings(strings, new StringComparer(CompareLength));
		}
	}
}
