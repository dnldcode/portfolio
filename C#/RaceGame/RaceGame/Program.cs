using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;
using System.Xml;
using System.IO;

namespace RaceGame
{
	class Program
	{
		static public bool isRun;
		static public readonly int len = 45;
		static public readonly int wid = 76;
		static public readonly int gwid = 26;
		static public readonly int step = 2;
		static public readonly int stime = 50;
		static public String nickname = "";
		static void Main(string[] args)
		{
			nickname = ConfigurationManager.AppSettings["Nickname"];
			Game game = new Game();
			int move = 0;
			while (true)
			{
				Console.Clear();
				Console.WindowWidth = 80;
				Console.WindowHeight = 36;
				Console.CursorTop = 3;
				Console.CursorLeft = Console.WindowWidth / 2 - 10;
				Console.ForegroundColor = ConsoleColor.White;
				if (move == 0) Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("1. Начать игру\n");
				Console.ForegroundColor = ConsoleColor.White;
				Console.CursorLeft = Console.WindowWidth / 2 - 10;
				if (move == 1) Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("2. Настройки\n");
				Console.ForegroundColor = ConsoleColor.White;
				Console.CursorLeft = Console.WindowWidth / 2 - 10;
				if (move == 2) Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("3. История игр\n");
				Console.ForegroundColor = ConsoleColor.White;
				Console.CursorLeft = Console.WindowWidth / 2 - 10;
				if (move == 3) Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("4. Выход\n");
				Console.ForegroundColor = ConsoleColor.White;
				ConsoleKeyInfo CKI = Console.ReadKey(true);
				switch (CKI.Key)
				{
					case ConsoleKey.Escape:
						Console.Clear();
						Environment.Exit(0);
						break;
					case ConsoleKey.Enter:
						{
							switch (move)
							{
								case 0:
									while (nickname.Length == 0 || nickname.Length > 20)
									{
										Console.Clear();
										Console.CursorTop = 10;
										Console.CursorLeft = Console.WindowWidth / 2 - 20;
										Console.Write(" Введите ник : ");
										Console.BackgroundColor = ConsoleColor.Gray;
										Console.CursorLeft = Console.WindowWidth / 2;
										Console.Write("                    ");
										Console.CursorLeft = Console.WindowWidth / 2;
										nickname = Console.ReadLine();
										changeConfig("Nickname", nickname);
										Console.BackgroundColor = ConsoleColor.Black;
									}
									game.run();
									break;
								case 1:
									int movenew = 0;
									bool isRunSettings = true;
									while (isRunSettings)
									{
										Console.Clear();
										Console.CursorTop = 3;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										Console.ForegroundColor = ConsoleColor.White;
										if (movenew == 0) Console.ForegroundColor = ConsoleColor.Green;
										Console.Write("Никнэйм : ");

										Console.CursorLeft = Console.WindowWidth / 2;
										if (nickname.Length == 0)
											Console.WriteLine("Unknown");
										else
											Console.WriteLine(nickname);
										Console.WriteLine();
										Console.ForegroundColor = ConsoleColor.White;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										if (movenew == 1) Console.ForegroundColor = ConsoleColor.Green;
										Console.Write("Ширина поля : ");
										Console.CursorLeft = Console.WindowWidth / 2;
										Console.WriteLine(ConfigurationManager.AppSettings["fWidth"] + "\n");
										Console.ForegroundColor = ConsoleColor.White;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										if (movenew == 2) Console.ForegroundColor = ConsoleColor.Green;
										Console.Write("Длина поля : ");
										Console.CursorLeft = Console.WindowWidth / 2;
										Console.WriteLine(ConfigurationManager.AppSettings["fLength"] + "\n");
										Console.ForegroundColor = ConsoleColor.White;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										if (movenew == 3) Console.ForegroundColor = ConsoleColor.Green;
										Console.Write("Ширина дороги : ");
										Console.CursorLeft = Console.WindowWidth / 2;
										Console.WriteLine(ConfigurationManager.AppSettings["gameWidth"] + "\n");
										Console.ForegroundColor = ConsoleColor.White;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										if (movenew == 4) Console.ForegroundColor = ConsoleColor.Green;
										Console.Write("Единица хода(1-5) : ");
										Console.CursorLeft = Console.WindowWidth / 2;
										Console.WriteLine(ConfigurationManager.AppSettings["gameStep"] + "\n");
										Console.ForegroundColor = ConsoleColor.White;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										if (movenew == 5) Console.ForegroundColor = ConsoleColor.Green;
										Console.Write("1/5очк для замедления  : ");
										Console.CursorLeft = Console.WindowWidth / 2;
										Console.WriteLine(ConfigurationManager.AppSettings["slowtime"] + "\n");
										Console.ForegroundColor = ConsoleColor.White;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										if (movenew == 6) Console.ForegroundColor = ConsoleColor.Green;
										Console.WriteLine("Вернуть исходные настройки\n");
										Console.CursorLeft = Console.WindowWidth / 2;
										Console.ForegroundColor = ConsoleColor.White;
										Console.CursorLeft = Console.WindowWidth / 2 - 25;
										if (movenew == 7) Console.ForegroundColor = ConsoleColor.Green;
										Console.WriteLine("Назад");
										ConsoleKeyInfo CKI1 = Console.ReadKey(true);
										switch (CKI1.Key)
										{
											case ConsoleKey.Enter:
												{
													int newvalue;
													switch (movenew)
													{
														case 0:
															Console.CursorTop = movenew + 3;
															Console.CursorLeft = Console.WindowWidth / 2;
															Console.BackgroundColor = ConsoleColor.Gray;
															Console.Write("                    ");
															Console.CursorLeft = Console.WindowWidth / 2;
															String nname;
															try
															{
																nname = Console.ReadLine();
																if (!(nname.Length == 0 || nname.Length > 20))
																{
																	nickname = nname;
																	changeConfig("Nickname", nickname);
																}
															}
															catch { }
															Console.BackgroundColor = ConsoleColor.Black;
															break;
														case 1:
															Console.CursorTop = movenew * 2 + 3;
															Console.CursorLeft = Console.WindowWidth / 2;
															Console.BackgroundColor = ConsoleColor.Gray;
															Console.Write("          ");
															Console.CursorLeft = Console.WindowWidth / 2;
															try
															{
																newvalue = Int32.Parse(Console.ReadLine());
																if (newvalue >= 30 && newvalue <= 100 && newvalue >= Int32.Parse(ConfigurationManager.AppSettings["gameWidth"]) + 10)
																	changeConfig("fWidth", newvalue.ToString());
															}
															catch { }
															Console.BackgroundColor = ConsoleColor.Black;
															break;
														case 2:
															Console.CursorTop = movenew * 2 + 3;
															Console.CursorLeft = Console.WindowWidth / 2;
															Console.BackgroundColor = ConsoleColor.Gray;
															Console.Write("          ");
															Console.CursorLeft = Console.WindowWidth / 2;
															try
															{
																newvalue = Int32.Parse(Console.ReadLine());
																if (newvalue >= 15 && newvalue <= 55)
																	changeConfig("fLength", newvalue.ToString());
															}
															catch { }
															Console.BackgroundColor = ConsoleColor.Black;
															break;
														case 3:
															Console.CursorTop = movenew * 2 + 3;
															Console.CursorLeft = Console.WindowWidth / 2;
															Console.BackgroundColor = ConsoleColor.Gray;
															Console.Write("          ");
															Console.CursorLeft = Console.WindowWidth / 2;
															try
															{
																newvalue = Int32.Parse(Console.ReadLine());
																if (newvalue >= 10 && newvalue <= Int32.Parse(ConfigurationManager.AppSettings["fWidth"]) - 10)
																	changeConfig("gameWidth", newvalue.ToString());
															}
															catch { }
															Console.BackgroundColor = ConsoleColor.Black;
															break;
														case 4:
															Console.CursorTop = movenew * 2 + 3;
															Console.CursorLeft = Console.WindowWidth / 2;
															Console.BackgroundColor = ConsoleColor.Gray;
															Console.Write("          ");
															Console.CursorLeft = Console.WindowWidth / 2;
															try
															{
																newvalue = Int32.Parse(Console.ReadLine());
																if (newvalue >= 1 && newvalue <= 5)
																	changeConfig("gameStep", newvalue.ToString());
															}
															catch { }
															Console.BackgroundColor = ConsoleColor.Black;
															break;
														case 5:
															Console.CursorTop = movenew * 2 + 3;
															Console.CursorLeft = Console.WindowWidth / 2;
															Console.BackgroundColor = ConsoleColor.Gray;
															Console.Write("          ");
															Console.CursorLeft = Console.WindowWidth / 2;
															try
															{
																newvalue = Int32.Parse(Console.ReadLine());
																if (newvalue >= 10)
																	changeConfig("slowtime", newvalue.ToString());
															}
															catch { }
															Console.BackgroundColor = ConsoleColor.Black;
															break;
														case 6:
															changeConfig("fWidth", wid.ToString());
															changeConfig("fLength", len.ToString());
															changeConfig("gameWidth", gwid.ToString());
															changeConfig("gameStep", step.ToString());
															changeConfig("slowtime", stime.ToString());
															break;
														case 7:
															isRunSettings = false;
															break;
													}
													break;
												}
											case ConsoleKey.UpArrow:
												movenew--;
												if (movenew == -1)
													movenew = 7;
												break;
											case ConsoleKey.DownArrow:
												movenew++;
												if (movenew == 8)
													movenew = 0;
												break;
											case ConsoleKey.Escape:
												isRunSettings = false;
												break;
										}
									}
									break;
								case 2:
									Console.Clear();
									Console.WindowWidth = 100;
									Console.WriteLine("\n Последние 100 игр :\n");
									String[] lines;
									lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"/logs.dat");
									for (int i = lines.Length - 1; i >= 0; i--)
									{
										if (i == lines.Length - 101)
											break;
										Console.WriteLine(lines[i]);
									}
									Console.ReadKey();
									break;
								case 3:
									Console.Clear();
									Environment.Exit(0);
									break;
							}
							break;
						}
					case ConsoleKey.UpArrow:
						move--;
						if (move == -1)
							move = 3;
						break;
					case ConsoleKey.DownArrow:
						move++;
						if (move == 4)
							move = 0;
						break;
				}
			}
		}
		static void changeConfig(String setting, String value)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

			foreach (XmlElement element in xmlDoc.DocumentElement)
			{
				if (element.Name.Equals("appSettings"))
				{
					foreach (XmlNode node in element.ChildNodes)
					{
						if (node.Attributes[0].Value.Equals(setting))
						{
							node.Attributes[1].Value = value;
						}
					}
				}
			}

			xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
			ConfigurationManager.RefreshSection("appSettings");
		}
	}
	class Field
	{
		public List<int[]> road = new List<int[]>();
		public static int fieldWidth = Int32.Parse(ConfigurationManager.AppSettings["fWidth"]);
		public static int fieldLength = Int32.Parse(ConfigurationManager.AppSettings["fLength"]);
		public static int gameWidth = Int32.Parse(ConfigurationManager.AppSettings["gameWidth"]);
		public Player player = new Player(fieldWidth / 2, fieldLength - 4);
		int lastX = fieldWidth / 2 - (gameWidth / 2);
		public int way, wayLen;

		public void showField()
		{
			Console.CursorTop = 0;
			Console.CursorLeft = 0;
			String tmp = "";
			for (int i = 0; i < fieldLength; i++)
			{
				for (int j = 0; j < fieldWidth; j++)
				{
					if (road[i][j] == 1 || j == fieldWidth - 1 || j == 0)
						tmp += '│';
					else if (road[i][j] == 0)
						tmp += ' ';
					else if (road[i][j] == 2)
						tmp += '█';
				}
				tmp += '\n';
			}
			Console.WriteLine(tmp);
			Console.CursorTop = Field.getHeigth() + 3;
			Console.CursorLeft = Console.WindowWidth / 2 + 10;
			Console.Write(" Score : " + Game.score / 3);
			Console.CursorTop = 0;
			Console.CursorLeft = 0;
		}
		private void randField()
		{
			wayLen = 0;
			lastX = fieldWidth / 2 - (gameWidth / 2);
			player = new Player(fieldWidth / 2, fieldLength - 4);
			for (int i = 0; i < fieldLength; i++)
			{
				int[] temp = new int[fieldWidth];
				for (int j = 0; j < fieldWidth; j++)
				{
					if (j == lastX || j == lastX + gameWidth + 2 || j == fieldWidth - 1)
						temp[j] = 1;
					else
						temp[j] = 0;
				}
				road.Add(temp);
			}
			road[player.pY + 2][player.pX] = 2;
			road[player.pY + 2][player.pX + 1] = 2;
			road[player.pY + 2][player.pX - 1] = 2;
			road[player.pY + 1][player.pX] = 2;
			road[player.pY + 1][player.pX + 1] = 2;
			road[player.pY + 1][player.pX - 1] = 2;
			road[player.pY][player.pX] = 2;
			road[player.pY][player.pX + 1] = 2;
			road[player.pY][player.pX - 1] = 2;
		}
		public void runGame()
		{
			fieldWidth = Int32.Parse(ConfigurationManager.AppSettings["fWidth"]);
			fieldLength = Int32.Parse(ConfigurationManager.AppSettings["fLength"]);
			gameWidth = Int32.Parse(ConfigurationManager.AppSettings["gameWidth"]);
			Console.WindowWidth = fieldWidth;
			Console.WindowHeight = fieldLength + 5;
			randField();
			Program.isRun = true;
		}
		public void calcWay()
		{
			int x1 = lastX;
			int x2 = lastX + gameWidth;
			Random R = new Random();
			wayLen = 0;
			while (wayLen == 0)
			{
				way = R.Next(-1, 2);
				switch (way)
				{
					case -1:
						if (x1 - 2 < 2)
							break;
						wayLen = R.Next(0, x1 - 2) / 1;
						break;
					case 0:
						if (Game.score == 0)
							break;
						wayLen = R.Next(1, 5);
						break;
					case 1:
						if (fieldWidth - x2 - 3 < 3)
							break;
						wayLen = R.Next(0, fieldWidth - x2 - 3) / 1;
						break;
					default:
						break;
				}
			}
		}
		public void changeField()
		{
			if (wayLen-- <= 0)
				calcWay();
			switch (way)
			{
				case -1:
					lastX--;
					break;
				case 1:
					lastX++;
					break;
				default:
					break;
			}
			int[] tmp = new int[fieldWidth];
			for (int i = 0; i < fieldWidth; i++)
			{
				if (i == lastX || i == lastX + gameWidth + 2)
					tmp[i] = 1;
				else
					tmp[i] = 0;
			}
			tmp[0] = lastX * -1;
			this.road.RemoveAt(fieldLength - 1);
			this.road.Insert(0, tmp);
			move(0, 0);
		}
		public void move(int pX, int pY)
		{
			int newpY = this.player.pY + pY;
			int newpX = this.player.pX + pX;
			if (newpY > fieldLength - 4 || newpY < 2) return;
			hidePlayer();
			road[newpY + 2][newpX] = 2;
			road[newpY + 2][newpX + 1] = 2;
			road[newpY + 2][newpX - 1] = 2;
			road[newpY + 1][newpX] = 2;
			road[newpY + 1][newpX + 1] = 2;
			road[newpY + 1][newpX - 1] = 2;
			road[newpY][newpX] = 2;
			road[newpY][newpX + 1] = 2;
			road[newpY][newpX - 1] = 2;
			this.player.pX = newpX;
			this.player.pY = newpY;
			if ((newpX > Math.Abs(road[newpY][0]) + gameWidth || newpX < Math.Abs(road[newpY][0]) + 2) && Game.score > 0)
			{
				StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + @"/logs.dat");
				DateTime dt = DateTime.Now;
				sw.Write(" [{0}.{1}.{2} {3}:{4}:{5}]", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second);
				sw.Write(" Player \"{0}\" earned {1} points", Program.nickname, Game.score / 3);
				sw.WriteLine("(W - {0}, L - {1}, gW - {2}, S - {3})", ConfigurationManager.AppSettings["fWidth"], ConfigurationManager.AppSettings["fLength"]
																	, ConfigurationManager.AppSettings["gameWidth"], ConfigurationManager.AppSettings["gameStep"]);
				sw.Close();
				Program.isRun = false;
			}
		}
		public void hidePlayer()
		{
			for (int i = player.pY; i < player.pY + 4; i++)
				for (int j = 0; j < fieldWidth; j++)
				{
					if (road[i][j] == 2)
						road[i][j] = 0;
				}
		}
		static public int getHeigth()
		{
			return fieldLength;
		}
		static public int getWidth()
		{
			return fieldWidth;
		}
	}
	class Player
	{
		public int pX { get; set; }
		public int pY { get; set; }
		public Player(int pX, int pY)
		{
			this.pX = pX;
			this.pY = pY;
		}
	}
	class Game
	{
		private Field field = new Field();
		static public int score = 0;
		private double time = 75;
		private double count = 50;
		private int gameStep;
		static private bool slowReady = false;
		static double temptime;
		static int slowtime;
		static int energyscore = 0;
		public void run()
		{
			gameStep = Int32.Parse(ConfigurationManager.AppSettings["gameStep"]);
			time = 75;
			count = 50;
			score = 0;
			field = new Field();
			slowtime = Int32.Parse(ConfigurationManager.AppSettings["slowtime"]);
			field.runGame();
			int n = 0;
			energyscore = 0;
			while (Program.isRun)
			{
				if (field.road[this.field.player.pY][0] < 0)
				{
					score++;
					energyscore++;
				}
				this.field.changeField();
				this.field.showField();
				Thread.Sleep((int)time);
				if (score / 3 == (int)count && time > 15 && time != 250)
				{
					time -= 6;
					count *= 2.3;
				}
				if (score == 1)
					time = 35;
				if (score == 0)
				{
					while (Console.KeyAvailable) Console.ReadKey(true);
				}
				if (energyscore % (slowtime * 3) == 0)
					showEnergy();
				if (time == 150)
				{
					if (n == 35)
					{
						time = temptime;
						slowReady = false;
						energyscore = 0;
						n = 0;
						Console.CursorTop = Field.getHeigth() + 3;
						Console.CursorLeft = 1;
						for (int i = 0; i < 5; i++)
							Console.Write("  ");
					}
					n++;
				}

				if (Console.KeyAvailable && score != 0)
				{
					ConsoleKeyInfo CKI = Console.ReadKey(true);
					while (Console.KeyAvailable) Console.ReadKey(true);
					if (CKI.Key == ConsoleKey.Escape)
					{
						Console.Clear();
						break;
					}
					switch (CKI.Key)
					{
						case ConsoleKey.UpArrow:
							this.field.move(0, -gameStep);
							break;
						case ConsoleKey.DownArrow:
							this.field.move(0, gameStep);
							break;
						case ConsoleKey.LeftArrow:
							this.field.move(-gameStep, 0);
							break;
						case ConsoleKey.RightArrow:
							this.field.move(gameStep, 0);
							break;
						case ConsoleKey.Spacebar:
							if (slowReady)
							{
								slowReady = false;
								temptime = time;
								time = 150;
							}
							break;
					}
				}
			}
			Console.CursorTop = Field.getHeigth() / 2 - 3 + 2;
			Console.CursorLeft = Field.getWidth() / 2 - 5;
			Console.WriteLine("Вы врезались!");
			Console.CursorLeft = Field.getWidth() / 2 - 5;

			Console.WriteLine("Ваш счет : " + score / 3);
			while(true)
			{
				ConsoleKeyInfo CKI = Console.ReadKey(true);
				if (CKI.Key == ConsoleKey.Enter)
					break;
			}
		}
		static public void showEnergy()
		{
			Console.CursorTop = Field.getHeigth() + 2;
			Console.CursorLeft = Console.WindowWidth / 2 - Console.WindowWidth / 2;
			Console.WriteLine("┌───────────┐");
			Console.CursorLeft = Console.WindowWidth / 2 - Console.WindowWidth / 2;
			Console.Write("│");
			Console.CursorLeft = Console.WindowWidth / 2 - Console.WindowWidth / 2 + 11;
			Console.WriteLine(" ││");
			Console.CursorLeft = Console.WindowWidth / 2 - Console.WindowWidth / 2;
			Console.WriteLine("└───────────┘");
			if (energyscore / (slowtime * 3) <= 6)
			{
				Console.CursorTop = Field.getHeigth() + 3;
				Console.CursorLeft = 1;
				for (int i = 0; i < energyscore / (slowtime * 3); i++)
				{
					Console.Write(" │");
				}
				if (energyscore / (slowtime * 3) == 5)
				{
					slowReady = true;
				}
			}
		}
	}
}