using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_14_CS_PT2_5_SideWinder
{
	internal class Board
	{
		const char CIRCLE = '\u25cf';
		public TileType[,] Tile;
		public int Size;

		public enum TileType
		{
			Empty,
			Wall,
		}

		public void Initialize(int size)
		{
			if (size%2==0)
				return;
			Tile = new TileType[size, size];
			Size = size;

			GenerateBySideWinder();
		}

		void GenerateBySideWinder()
		{
			//일단 길을 다 막는 작업
			for (int y = 0; y<Size; y++)
			{
				for (int x = 0; x< Size; x++)
				{
					if (x % 2 == 0 || y % 2 == 0)
						Tile[y, x] = TileType.Wall;
					else
						Tile[y, x] = TileType.Empty;
				}
			}

			// 랜덤으로 우측, 혹은 아래로 길을 뚫는 작업
			Random rand = new Random();
			for (int y = 0; y<Size; y++)
			{
				int count = 1;
				for (int x = 0; x< Size; x++)
				{
					if (x % 2 == 0 || y % 2 == 0)
						continue;

					if (y == Size -2 && x == Size -2)
						continue;

					if (y == Size - 2)
					{
						Tile[y, x+1] = TileType.Empty;
						continue;
					}
					if (x == Size - 2)
					{
						Tile[y+1, x] = TileType.Empty;
						continue;
					}

					if (rand.Next(0, 2)==0)
					{
						Tile[y, x+1] = TileType.Empty;
						count++;
					}

					else
					{
						int randomIndex = rand.Next(0, count);
						Tile[y+1, x - randomIndex * 2] = TileType.Empty;
						count = 1;
					}
						
				}
			}
		}
		public void Render()
		{
			ConsoleColor prevColor = Console.ForegroundColor;
			for (int y = 0; y<Size; y++)
			{
				for (int x = 0; x< Size; x++)
				{
					Console.ForegroundColor = GetTileColor(Tile[y, x]);
					Console.Write(CIRCLE);
				}
				Console.WriteLine();
			}
			Console.ForegroundColor = prevColor;
		}
		ConsoleColor GetTileColor(TileType type)
		{
			switch (type)
			{
				case TileType.Empty:
					return ConsoleColor.Green;
				case TileType.Wall:
					return ConsoleColor.Red;
				default:
					return ConsoleColor.Green;
			}
		}

	}
}
