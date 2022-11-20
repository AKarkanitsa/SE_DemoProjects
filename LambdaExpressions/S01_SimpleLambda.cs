namespace SimpleLambdas
{
    public class SimpleLambda
    {
		public static void Sort<T>(T[] array, Func<T, T, int> comparer)
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

		static void Main()
		{
			var strings = new[] { "A", "B", "AA" };
			//Лямбда-выражение - краткая форма записи метода.
			//(x, y) => x.Length.CompareTo(y.Length) - это лямбда
			//Компилятор автоматически определит тип возвращаемого значения и тип аргументов. 
			//Эти типы определяются из строки, в которой объявлен массив!
			Sort(strings, (x, y) => x.Length.CompareTo(y.Length));
		}
	}
}