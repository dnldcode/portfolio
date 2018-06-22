using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
	class Program
	{
		static void Main(string[] args)
		{
			Game game = new Game();
			game.run();
			Console.ReadKey(true);
		}
	}
	class GameField
	{
		private Gamer G = new Gamer();
		private static readonly int fieldWidth = 15;
		private int[,] field = new int[fieldWidth, fieldWidth];
		private int x;
		private int y;
		private List<Box> boxes = new List<Box>();
		private void init()
		{
			for (int i = 0; i < fieldWidth; i++)
				for (int j = 0; j < fieldWidth; j++)
					this.field[i, j] = 0;
			Random R = new Random();
			int cnt = R.Next((fieldWidth / 2) * 3, (fieldWidth / 2) * 5);//Кол-во барьеров
			for (int i = 0; i < cnt; i++)
			{
				do
				{
					int row = R.Next(0, fieldWidth);
					int col = R.Next(0, fieldWidth);
					if (this.field[row, col] == 0)
					{
						this.field[row, col] = 1;
						break;
					}
				} while (true);
			}
		}
		public void showField()
		{
			Console.CursorLeft = this.x;
			Console.CursorTop = this.y;
			Console.Write("┌");
			for (int i = 0; i < fieldWidth; i++)
				Console.Write("──");
			Console.Write("┐");
			//###
			for (int i = 0; i < fieldWidth; i++)
			{
				Console.CursorLeft = this.x;
				Console.CursorTop = this.y + i + 1;
				Console.Write("│");
				for (int j = 0; j < fieldWidth; j++)
				{
					if (this.field[i, j] == 1)
						Console.Write("▓▓");
					else if (this.field[i, j] == 0)
						Console.Write("  ");
					else if (this.field[i, j] == 2)
						Console.Write("[]");
					else if (this.field[i, j] == 3)
						Console.Write("██");
				}
				Console.Write("│");
			}
			//
			Console.CursorLeft = this.x;
			Console.CursorTop = this.y + fieldWidth;
			Console.Write("└");
			for (int i = 0; i < fieldWidth; i++)
				Console.Write("──");
			Console.Write("┘");
		}
		public GameField(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public void start()
		{
			this.init();
			int row, col;
			Random R = new Random();
			do
			{
				row = R.Next(0, fieldWidth);
				col = R.Next(0, fieldWidth);
			} while (this.field[row, col] != 0);
			this.field[row, col] = 3;
			this.G.row = row;
			this.G.col = col;
		}
		public void addBox(int time)
		{
			int row, col;
			Random R = new Random();
			do
			{
				row = R.Next(0, fieldWidth);
				col = R.Next(0, fieldWidth);
			} while (this.field[row, col] != 0);
			this.field[row, col] = 2;
			this.boxes.Add(new Box(row, col, time));
		}
		public Box[] getBoxes()
		{
			return this.boxes.ToArray();
		}
		public void removeBox(Box b)
		{
			this.boxes.Remove(b);
			this.field[b.row, b.col] = 0;
		}
		public void moveGamer(int dX, int dY)
		{
			int newRow = this.G.row + dY;
			int newCol = this.G.col + dX;
			if (newRow < 0 || newCol < 0 || newRow >= fieldWidth || newCol >= fieldWidth ||
									this.field[newRow, newCol] == 1)
				return;
			this.field[this.G.row, this.G.col] = 0;
			this.G.row = newRow;
			this.G.col = newCol;
			this.field[this.G.row, this.G.col] = 3;
		}
	}
	class Box
	{
		public int row;
		public int Row
		{
			get
			{
				return this.row;
			}
		}
		public int col;
		public int Col
		{
			get
			{
				return this.col;
			}
		}
		public int time;
		public Box(int row, int col, int time)
		{
			this.row = row;
			this.col = col;
			this.time = time;
		}
	}
	class Game
	{
		private GameField GF;
		public Game()
		{
			this.GF = new GameField(25, 3);
		}
		public void run()
		{
			bool isRun = true;
			while(isRun)
			{
				Console.WriteLine(" 1. Новая игра");
				Console.WriteLine(" 2. Выход");
				if (Console.ReadLine() != "1")
					break;
				Console.Clear();
				Random R = new Random();
				// New game
				this.GF.start();
				this.GF.addBox(R.Next(5, 15) * 100);
				this.GF.addBox(R.Next(5, 15) * 100);
				this.GF.addBox(R.Next(5, 15) * 100);
				while (true)
				{
					this.GF.showField();
					Thread.Sleep(100);
					Box[] boxes = this.GF.getBoxes();
					foreach(Box b in boxes)
					{
						b.time -= 100;
						if(b.time <= 10)
						{
							this.GF.removeBox(b);
							this.GF.addBox(R.Next(5, 15) * 1000);
						}
						if (Console.KeyAvailable)
						{
							ConsoleKeyInfo CKI = Console.ReadKey(true);
							if (CKI.Key == ConsoleKey.Escape)
							{
								Console.Clear();
								break;
							}
							switch(CKI.Key)
							{
								case ConsoleKey.UpArrow:
									this.GF.moveGamer(0, -1);
									break;
								case ConsoleKey.DownArrow:
									this.GF.moveGamer(0, 1);
									break;
								case ConsoleKey.LeftArrow:
									this.GF.moveGamer(-1, 0);
									break;
								case ConsoleKey.RightArrow:
									this.GF.moveGamer(1,0);
									break;
							}
						}

					}

				}
			}
		}
	}
	class Gamer
	{
		public int row { get; set; }
		public int col { get; set; }
	}
}