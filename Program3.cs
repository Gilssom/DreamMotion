using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
	/*
	 * 비트 다루기
	 *    - MakeBitRange 함수를 구현하시면 됩니다.
	 *    - 출력값은 from 번째 비트부터 to 번째 비트까지 1로 세팅된 값이어야 합니다.
	 *    - 예) MakeBitRange(1,4) = 00011110 (0x0000001E)
	 *    - from, to는 0~31까지 값이며, to >= from 입니다.
	 */
	class Program
	{
		static void Main(string[] args)
		{
			int bits = MakeBitRange(5, 10);

			Print(bits);
		}

		#region Stub
		static void Print(int bits)
		{
			for( int i = 31; i >= 0; i-- )
				Console.Write(i % 10);

			Console.WriteLine();

			for( int i = 31; i >= 0; i-- )
				Console.Write((bits & (1 << i)) == 0 ? '.' : 'O');

			Console.WriteLine();
			Console.WriteLine();
		}
		#endregion

		static int MakeBitRange(int from, int to)
		{
			int answer = 0;
			string s = "";

			for (int i = to; i >= 0; i--)
			{
				if (i >= from)
					s += "1";
				else
					s += "0";
			}

			answer = Convert.ToInt32(s, 2);

			return answer;
		}
	}
}
