using System;
using Nez;

namespace MonogameChess
{
	public class gameBoard : Component
	{

		public int[,] board;

		public gameBoard()
		{
			board = new int[,]
			{
				{1, 1, 1, 1, 1, 1, 1, 1},
				{1, 1, 1, 1, 1, 1, 1, 1},
				{0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0},
				{1, 1, 1, 1, 1, 1, 1, 1},
				{1, 1, 1, 1, 1, 1, 1, 1}
			};
		}

		public int At(int x, int y)
		{
			return board[x, y];
		}
	}
}
