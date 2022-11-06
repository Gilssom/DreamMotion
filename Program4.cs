using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Test4
{
	/*
	 * [클래스 설계 역량 평가]
	 * 
	 * 테트리스 줄 없애기
	 *  - 테트리스에서처럼 완성된 줄을 없애는 기능을 구현하면 됩니다.
	 *  - 없어진 줄 윗 부분의 블록들은 한줄씩 내려와야 합니다.
	 *  - 완성된 줄이 여러 개라면 모두 처리되어야 합니다.
	 *  - TetrisState 클래스를 구현하세요.
	 */
	class Program
	{
		static void Main(string[] args)
		{
			TetrisState tetris = CreateTestTetris();

			PrintTetris(tetris);

			tetris.CheckCompleteLine();

			PrintTetris(tetris);
		}

		#region Stub
		static void PrintTetris(TetrisState tetris)
		{
			for (int y = TetrisState.TETRIS_SIZE_Y - 1; y >= 0; y--)
			{
				Console.Write("|");

				for (int x = 0; x < TetrisState.TETRIS_SIZE_X; x++)
				{
					if (tetris.Get(x, y))
					{
						Console.Write("M");
					}
					else
					{
						Console.Write(" ");
					}
				}

				Console.WriteLine("|");
			}

			Console.WriteLine(new String('-', TetrisState.TETRIS_SIZE_X + 2));
			Console.WriteLine();
			Console.WriteLine();
		}

		static TetrisState CreateTestTetris()
		{
			TetrisState tetris = new TetrisState();
			Random r = new Random();
			for (int i = 0; i < 100; i++)
			{
				int x = r.Next(0, TetrisState.TETRIS_SIZE_X);
				int y = r.Next(0, TetrisState.TETRIS_SIZE_Y);

				Console.WriteLine("first x = " + x);
				Console.WriteLine("first y = " + y);

				tetris.Set(x, y);
			}

			for (int i = 0; i < 5; i++)
			{
				int y = r.Next(0, TetrisState.TETRIS_SIZE_Y);

				for (int x = 0; x < TetrisState.TETRIS_SIZE_X; x++)
				{
					Console.WriteLine("second x = " + x);
					Console.WriteLine("second y = " + y);
					tetris.Set(x, y);
				}
			}

			return tetris;
		}
		#endregion
	}

	class TetrisState
	{
		public const int TETRIS_SIZE_X = 10;        // 테트리스 폭
		public const int TETRIS_SIZE_Y = 20;        // 테트리스 높이. Y값이 작을수록 낮은 곳. 가장 높은 위치는 Y=19입니다.

		// 2차원 배열로 테트리스 가상 공간 만들기
		int[,] Array = new int[TETRIS_SIZE_Y, TETRIS_SIZE_X];

		public bool Get(int x, int y)
		{
			// X, Y 위치에 블록이 있으면 true 리턴
			if (Array[y, x] == 1)
				return true;
			else
				return false;
		}

		public void Set(int x, int y)
		{
			// X, Y 위치에 블록을 배치;
			Array[y, x] = 1;
		}

		public void CheckCompleteLine()
		{
			// 완성된 줄을 없애고 윗 부분의 블록들을 한줄씩 내리는 기능을 구현
			for (int i = 0; i < TETRIS_SIZE_Y; i++)
			{
				if (isFullRow(i))
				{
					//Console.WriteLine("제거해야 하는 줄 위치 = " + i);
					DestroyRow(i);

					AllDownRow(i + 1);

					// 다시 한 줄 내려와서 다시 체크
					i--;
				}

			}
		}

		// 해당 Y 열이 꽉 차여져 있는지 확인
		public bool isFullRow(int y)
		{
			for (int x = 0; x < TETRIS_SIZE_X; x++)
			{
				if (Array[y, x] == 0)
					return false;
			}
			return true;
		}

		// 해당 Y 열 삭제
		public void DestroyRow(int y)
		{
			for (int x = 0; x < TETRIS_SIZE_X; x++)
			{
				Array[y, x] = 0;
			}
		}

		// 꽉 채워져 있는 Y 열의 +1 열 부터 최대 높이까지 모두 한칸씩 내림
		public void AllDownRow(int y)
		{
			for (int i = y; i < TETRIS_SIZE_Y; i++)
			{
				DownRow(i);
			}
		}

		// Y 열 한칸 내리기
		public void DownRow(int y)
		{
			for (int x = 0; x < TETRIS_SIZE_X; x++)
			{
				if (Array[y, x] != 0)
				{
					Array[y - 1, x] = Array[y, x];
					Array[y, x] = 0;
				}
			}
		}
	}
}