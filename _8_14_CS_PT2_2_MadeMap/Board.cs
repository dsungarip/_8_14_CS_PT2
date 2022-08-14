using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_14_CS_PT2_3_MadeMap
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
			Tile = new TileType[size, size];
			Size = size;

			for(int y =0;y<Size;y++)
			{
				for(int x =0; x< Size; x++)
				{
					if (x == 0 || x == Size - 1 || y==0 || y==size-1)
						Tile[y, x] = TileType.Wall;
					else
						Tile[y, x] = TileType.Empty;
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
			switch(type)
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
