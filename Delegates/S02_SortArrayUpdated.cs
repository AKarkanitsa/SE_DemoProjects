using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayUpdated
{
    internal class SortArrayUpdated
    {
		public static void SortStrings(string[] array, IComparer<string> comparer)
		{
			Array.Sort(array, comparer);
		}

		class StringLengthComparer : IComparer<string>
		{
			public int Compare(string x, string y)
			{
				return x.Length.CompareTo(y.Length);
			}
		}

		class StringComparer : IComparer<string>
		{
			public bool Descending { get; set; }
			public int Compare(string x, string y)
			{
				return x.CompareTo(y) * (Descending ? -1 : 1);
			}
		}

		static void MainX()
		{
			var strings = new[] { "A", "B", "AA" };
			SortStrings(strings, new StringComparer() { Descending = false });
			SortStrings(strings, new StringLengthComparer());
		}
	}
}
