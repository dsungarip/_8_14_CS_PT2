﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_13_CS_PT2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;

			const int WAIT_TICK = 1000/ 30;
			const char CIRCLE = '\u25cf';

			int lastTick = 0;
			while (true)
			{
				#region 프레임 관리
				int currentTick = System.Environment.TickCount;


				if (currentTick - lastTick < WAIT_TICK) //만약에 경화한 시간이 1/30초 보다 작다면
					continue;
				lastTick = currentTick;
				#endregion


				//입력 : 사용자의 입력을 감지하는 단계

				//로직 : 입력에 따라 로직실행

				//렌더링 : 연산된 게임을 렌더링(DirectX 등등)
				Console.SetCursorPosition(0, 0);

				for (int i = 0; i<25; i++)
				{
					for (int j = 0; j<25; j++)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write(CIRCLE);
					}
					Console.WriteLine();
				}
			}
		}
	}
}