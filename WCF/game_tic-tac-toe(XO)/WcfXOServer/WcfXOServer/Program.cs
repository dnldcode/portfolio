using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfXOServer
{
	[DataContract]
	public class GameState
	{
		[DataMember]
		public int state = 0; // 0 - ожидание игроков, 1 - ходит 1, 2 - ходит 2, 3 - победил 1, 4 - победил 2, 5 - ничья
		[DataMember]
		public String lastAction = null;
		[DataMember]
		public User[] players = new User[2];
		public GameState()
		{
			players[0] = players[1] = new User("");
		}
	}
	[DataContract]
	public class User
	{
		[DataMember]
		public String name = "";
		[DataMember]
		public char Symbol = ' ';
		public DateTime lastActivity;
		public User(String name)
		{
			this.name = name;
			this.lastActivity = DateTime.Now;
		}
	}
	[ServiceContract(SessionMode = SessionMode.Required)]
	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
	public class XOPlatform
	{
		static public List<Game> games = new List<Game>();
		static public List<User> usersOnline = new List<User>();
		static public EventWaitHandle gamesEwh = new EventWaitHandle(true, EventResetMode.ManualReset);
		static public EventWaitHandle usersOnlineEwh = new EventWaitHandle(true, EventResetMode.ManualReset);
		static public Semaphore S = new Semaphore(0, 501);
		public Random R = new Random();
		public bool isUserOnline(String name)
		{
			usersOnlineEwh.WaitOne();
			S.WaitOne();
			foreach (User user in usersOnline)
			{
				if (user.name == name)
				{
					S.Release();
					return true;
				}
			}
			S.Release();
			return false;
		}
		[OperationContract]
		public String Login(String name)
		{
			if (usersOnline.Count == 500)
				return "ERROR|Все места на сервере заняты, попробуйте позже";
			if (this.getUserByName(name) == null)
			{
				if (name.Trim() == "")
					return "ERROR|Пустая строка";
				if (name.Length > 20)
					return "ERROR|Недопустимая длина имени";
				usersOnlineEwh.Reset();
				for (int i = 0; i < usersOnline.Count; i++)
					S.WaitOne();
				usersOnlineEwh.Set();

				usersOnline.Add(new User(name));

				for (int i = 0; i < usersOnline.Count; i++)
					S.Release();

				Console.WriteLine("Авторизирован пользователь с ником : " + name);
				S.Release();
				return "SUCCESS";
			}
			else
				return "ERROR|Игрок с данным ником уже существует";
		}
		[OperationContract]
		public String MakeGame(String player)
		{
			if (isUserOnline(player))
			{
				Game game = new Game(this.getUserByName(player));

				gamesEwh.Reset();
				for (int i = 0; i < games.Count; i++)
					S.WaitOne();
				gamesEwh.Set();

				games.Add(game);

				for (int i = 0; i < games.Count; i++)
					S.Release();

				Console.WriteLine("Создана игра #" + (games.Count - 1));
				Console.WriteLine($"Игрок {player} присоединился к игре #" + games.IndexOf(games[GetIdOfGameByPlayer(player)]));
				return "SUCCESS";
			}
			else
				return "ERROR|Не найден игрок";
		}
		[OperationContract]
		public String AddPlayer(String player)
		{
			if (games.Count == 0)
				return this.MakeGame(player);
			else
			{
				gamesEwh.WaitOne();
				S.WaitOne();
				foreach (Game game in games)
				{
					int count = game.getCountOfPlayers();
					if (count == 1 && game.gs.state == 0)
					{
						if (game.addPlayer(this.getUserByName(player)).Contains("ERROR"))
							continue;
						game.gs.state = R.Next(1, 3);
						if (game.gs.state == 1)
						{
							game.gs.players[0].Symbol = 'X';
							game.gs.players[1].Symbol = 'O';
						}
						else
						{
							game.gs.players[1].Symbol = 'X';
							game.gs.players[0].Symbol = 'O';
						}
						Console.WriteLine($"Игрок {player} присоединился к игре #{games.IndexOf(games[GetIdOfGameByPlayer(player)])}, GameState : {game.gs.state}");
						S.Release();
						return "SUCCESS";
					}
				}
				foreach (Game game in games)
				{
					int count = game.getCountOfPlayers();
					if (count == 0)
					{
						if (game.addPlayer(this.getUserByName(player)).Contains("ERROR"))
							continue;
						Console.WriteLine($"Игрок {player} присоединился к игре #{games.IndexOf(games[GetIdOfGameByPlayer(player)])}, GameState : {game.gs.state}");
						game.gs.state = 0;
						S.Release();
						S.Release();
						return "SUCCESS";
					}
				}
				S.Release();
				return this.MakeGame(player);
			}
		}
		public int GetIdOfGameByPlayer(String player)
		{
			gamesEwh.WaitOne();
			S.WaitOne();
			foreach (Game game in games)
			{
				if (game.ContainsPlayer(player))
				{
					S.Release();
					return games.IndexOf(game);
				}
			}
			S.Release();
			return -1;
		}
		[OperationContract]
		public GameState GetGameState(String player)
		{
			int temp = GetIdOfGameByPlayer(player);
			if (temp == -1)
				return null;
			return games[temp].gs;
		}
		[OperationContract]
		public String SetInfoIntoField(String player, int i1, int j1)
		{
			if (isUserOnline(player))
			{
				if (GetIdOfGameByPlayer(player) == -1)
					return "ERROR";
				String str = games[GetIdOfGameByPlayer(player)].setIntoField(player, i1, j1);
				if (str == "SUCCESS")
				{
					Console.WriteLine($"Игра #{GetIdOfGameByPlayer(player)}. Пользователь {player} походил по координатам : {i1}-{j1}.");
					User user = getUserByName(player);
					games[GetIdOfGameByPlayer(player)].gs.players[0].lastActivity = DateTime.Now;
					games[GetIdOfGameByPlayer(player)].gs.players[1].lastActivity = DateTime.Now;

                }
				return str;
			}
			return "ERROR";
		}
		public User getUserByName(String player)
		{
			usersOnlineEwh.WaitOne();
			if (usersOnline.Count != 0)
				S.WaitOne();
			foreach (User user in usersOnline)
			{
				if (user.name == player)
				{
					S.Release();
					return user;
				}
			}
			if (usersOnline.Count != 0)
				S.Release();
			return null;
		}
		[OperationContract]
		public void leaveFromGame(String player)
		{
			if (GetIdOfGameByPlayer(player) == -1)
				return;
			Game game = games[GetIdOfGameByPlayer(player)];

			game.removeFromGame(player);
		}
		[OperationContract]
		public void UserDisconnect(String player)
		{
			if (getUserByName(player) != null)
			{
				usersOnline.Remove(getUserByName(player));
				leaveFromGame(player);
				S.WaitOne();
				Console.WriteLine($"Пользователь {player} вышел из сети");
			}
		}
		[OperationContract]
		public void SendActivityMessage(String player)
		{
			User user = getUserByName(player);
			if (user == null)
				return;
			if (GetIdOfGameByPlayer(player) == -1)
				user.lastActivity = DateTime.Now;
			Console.WriteLine("Activity from : " + player);
		}
		[OperationContract]
		public bool isConnected()
		{
			return true;
		}
	}
	public class Game
	{
		public GameState gs;
		public char[,] field = new char[3, 3];
		public Game(User player = null)
		{
			gs = new GameState();
			if (player != null)
				this.addPlayer(player);
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					field[i, j] = '-';
		}
		public void removeFromGame(String player)
		{
			Console.WriteLine($"Пользователь {player} вышел из игры #{XOPlatform.games.IndexOf(this)}, GameState : {this.gs.state}");
			this.gs.state = 0;
			this.gs.lastAction = null;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					this.field[i, j] = '-';
			this.gs.players[this.getIndexOfPlayer(player)] = new User("");
			if (this.getCountOfPlayers() == 1)
			{
				int winnerIndex = (this.getIndexOfPlayer(this.gs.players[this.getIndexOfPlayer("")].name) == 0) ? 1 : 0;
				this.gs.state = (winnerIndex == 0) ? 3 : 4;
				Console.WriteLine($"Игра #{XOPlatform.games.IndexOf(this)} завершена. Победил : {this.gs.players[winnerIndex].name}");
			}
		}
		public bool ContainsPlayer(String player)
		{
			return (gs.players[0].name == player || gs.players[1].name == player);
		}
		public int getCountOfPlayers()
		{
			int n = 0;
			if (gs.players[0].name != "")
				n++;
			if (gs.players[1].name != "")
				n++;
			return n;
		}
		public int getIndexOfPlayer(String player)
		{
			if (this.ContainsPlayer(player))
			{
				if (gs.players[0].name == player)
					return 0;
				else if (gs.players[1].name == player)
					return 1;
				return -1;
			}
			else
				return -1;
		}
		public String setIntoField(String player, int i1, int j1)
		{
			if (player.Trim() == "" || player.Length > 25)
				return "ERROR";
			else if (i1 < 0 || i1 > 2 || j1 < 0 || j1 > 2)
				return "ERROR";
			if (field[j1, i1] == '-')
			{
				if (gs.players[0].name == player && gs.state == 1)
					field[j1, i1] = 'X';
				else if (gs.players[1].name == player && gs.state == 2)
					field[j1, i1] = 'O';
				else
					return "ERROR";
			}
			else
				return "ERROR";
			this.gs.lastAction = String.Format($"{i1};{j1}");
			if ((field[0, 0] == field[0, 1] && field[0, 1] == field[0, 2]) && field[0, 2] != '-' ||
			(field[1, 0] == field[1, 1] && field[1, 1] == field[1, 2]) && field[1, 2] != '-' ||
			(field[2, 0] == field[2, 1] && field[2, 1] == field[2, 2]) && field[2, 2] != '-' ||
			(field[0, 0] == field[1, 0] && field[1, 0] == field[2, 0]) && field[2, 0] != '-' ||
			(field[0, 1] == field[1, 1] && field[1, 1] == field[2, 1]) && field[2, 1] != '-' ||
			(field[0, 2] == field[1, 2] && field[1, 2] == field[2, 2]) && field[2, 2] != '-' ||
			(field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2]) && field[2, 2] != '-' ||
			(field[2, 0] == field[1, 1] && field[1, 1] == field[0, 2]) && field[0, 2] != '-')
				this.gs.state = (this.gs.state == 1) ? 3 : 4;
			else
			{
				int n = 0;
				for (int i = 0; i < 3; i++)
					for (int j = 0; j < 3; j++)
						if (field[i, j] != '-')
							n++;
				if (n == 9)
					this.gs.state = 5;
				else
					this.gs.state = (this.gs.state == 1) ? 2 : 1;
			}
			return "SUCCESS";
		}
		public String addPlayer(User player)
		{
			if (this.getCountOfPlayers() == 2)
				return "ERROR|Места заняты";
			this.gs.players[this.getCountOfPlayers()] = player;
			return "SUCCESS";
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(XOPlatform));
			try
			{
				serviceHost.Open();
			}
			catch
			{
				Console.WriteLine("Невозможно включить сервер. Проверьте найстроки и убедитесь что сервер уже не включен");
				return;
			}
			Thread thread = new Thread(checkActivities);
			thread.IsBackground = true;
			thread.Start();
			//Исусственный подъем онлайна до 499 человек
			//for (int i = 0; i < 499; i++)
			//{
			//	XOPlatform.usersOnline.Add(new User(""));
			//	XOPlatform.S.Release();
			//}
			Console.WriteLine("Нажмите ENTER для остановки сервера");
			Console.ReadLine();
			serviceHost.Close();
			thread.Abort();
			thread.Join(500);
		}

		static private void checkActivities()
		{
			while (true)
			{
				List<User> usersDisconnected = new List<User>();
				foreach (User user in XOPlatform.usersOnline)
				{
					TimeSpan ts = DateTime.Now - user.lastActivity;
					if (ts.Seconds > 30)
					{
						bool ingame = false;
						foreach (Game game in XOPlatform.games)
						{
							if (game.ContainsPlayer(user.name))
							{
								ingame = true;
								if (game.gs.state == (game.getIndexOfPlayer(user.name) + 1))
								{
									game.gs.state = (game.gs.state == 1) ? 4 : 3;
									game.removeFromGame(user.name);
									break;
								}
							}
						}
						if (!ingame)
							usersDisconnected.Add(user);
					}
				}
				foreach (User user1 in usersDisconnected)
				{
					XOPlatform.usersOnline.Remove(user1);
					XOPlatform.S.WaitOne();
					Console.WriteLine($"Пользователь {user1.name} вышел из сети");
				}
				usersDisconnected.Clear();
				Thread.Sleep(7500);
			}
		}
	}
}