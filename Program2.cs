using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
	/*
	 * 배열 중에서 가장 큰 값 찾기
	 *    - FindMaximum 함수를 구현하시면 됩니다.
	 */
	class Program
	{
		static void Main(string[] args)
		{
			int[] array = CreateTestArray(5);

			Print(array);

			int maximum = FindMaximum(array);

			Console.WriteLine("최대값 : " + maximum);
		}

		#region Stub
		static int[] CreateTestArray(int count)
		{
			var array = new int[count];

			var rnd = new Random();
			for( int i = 0; i < count; i++ )
			{
				array[i] = rnd.Next() % 1000;
			}

			return array;
		}

		static void Print(int[] array)
		{
			foreach(int i in array)
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();
		}
		#endregion

		static int FindMaximum(int[] array)
		{
			// array에서 가장 큰 값을 찾아 리턴

			return array.Max();
		}
	}
}
