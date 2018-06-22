using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wcfTelegramServer
{
	[ServiceContract(SessionMode = SessionMode.Required)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class Telegram
	{
		public static List<User> usersOnline = new List<User>();
		public static List<String> messages = new List<String>();
		static public EventWaitHandle usersOnlineEwh = new EventWaitHandle(true, EventResetMode.ManualReset);
		static public EventWaitHandle messagesEwh = new EventWaitHandle(true, EventResetMode.ManualReset);
		static public Semaphore S = new Semaphore(0, 501);
		[OperationContract]
		public String Login(String name)
		{
			if (usersOnline.Count == 500)
				return "ERROR|Сервер переполнен";
			if (name.Trim() == "")
				return "ERROR|Строка пуста";
			if (name.Length > 25)
				return "ERROR|Недопустимая длина сообщения. Максимальная длина : 25";
			if (getUserByString(name) != null)
				return "ERROR|Данное имя уже занятно. Попробуйте новое.";

			usersOnlineEwh.Reset();
			messagesEwh.Reset();
			for (int i = 0; i < usersOnline.Count; i++)
				S.WaitOne();
			usersOnlineEwh.Set();
			messagesEwh.Set();

			usersOnline.Add(new User(name));
			messages.Add($"Пользователь {name} зашел в сеть");

			for (int i = 0; i < usersOnline.Count; i++)
				S.Release();

			Console.WriteLine($"Пользователь {name} зашел в сеть");
			S.Release();
			return "SUCCESS";
		}
		[OperationContract]
		public String sendMessage(String userName, String message)
		{
			if (message.ToLower().Contains("флюид"))
				return "ERROR|Недопустимое слово";
			if (message.Length > 40)
				return "ERROR|Недопустимая длина сообщения. Максимум : 40";
			if (message.Trim() == "")
				return "ERROR|Пустая строка";

			messagesEwh.Reset();
			for (int i = 0; i < usersOnline.Count; i++)
				S.WaitOne();
			messagesEwh.Set();

			Console.WriteLine($"Пользователь {userName} отправил сообщение : {message}");
			messages.Add(userName + " : " + message);

			for (int i = 0; i < usersOnline.Count; i++)
				S.Release();

			return "SUCCESS";
		}
		[OperationContract]
		public String getMessages(int n)
		{
			if (n < 0)
				return "ERROR|Номер последнего сообщения меньше нуля";
			if (n > messages.Count)
				return "ERROR|Номер последнего сообщения больше существующего";
			String str = "SUCCESS|";
			messagesEwh.WaitOne();
			S.WaitOne();
			for (int i = n; i < messages.Count; i++)
				str += messages[i] + "&";
			S.Release();
			return str;
		}
		[OperationContract]
		public String getOnlineUsers()
		{
			String str = "";
			usersOnlineEwh.WaitOne();
			S.WaitOne();
			foreach (User user in usersOnline)
				str += user.Name + "^";
			S.Release();
			return str;
		}
		[OperationContract]
		public void Disconnect(String name)
		{
			if (getUserByString(name) == null)
				return;

			usersOnlineEwh.Reset();
			messagesEwh.Reset();
			for (int i = 0; i < usersOnline.Count; i++)
				S.WaitOne();
			usersOnlineEwh.Set();
			messagesEwh.Set();

			usersOnline.Remove(getUserByString(name));
			messages.Add($"Пользователь {name} вышел из сети");

			for (int i = 0; i < usersOnline.Count; i++)
				S.Release();

			S.WaitOne();
			Console.WriteLine($"Пользователь {name} вышел из сети");
		}
		[OperationContract]
		public void sendActivity(String name)
		{
			if (getUserByString(name) == null)
				return;
			getUserByString(name).activity = DateTime.Now;
			Console.WriteLine($"Активность от : {name}");
		}
		public User getUserByString(String name)
		{
			usersOnlineEwh.WaitOne();
			if (usersOnline.Count != 0)
				S.WaitOne();
			foreach (User user in usersOnline)
			{
				if (user.Name == name)
				{
					S.Release();
					return user;
				}
			}
			if (usersOnline.Count != 0)
				S.Release();
			return null;
		}
	}
	public class User
	{
		public String Name;
		public DateTime activity = DateTime.Now;
		public User(String userName)
		{
			this.Name = userName;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(Telegram));
			try
			{
				serviceHost.Open();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return;
			}
			Thread threadActivity = new Thread(Program.checkActivities);
			threadActivity.IsBackground = true;
			threadActivity.Start();
			Console.WriteLine("Нажмите ENTER для остановки сервера");
			Console.ReadLine();
			serviceHost.Close();
		}
		static public void checkActivities()
		{
			while (true)
			{
				List<User> usersDisconnected = new List<User>();
				foreach (User user in Telegram.usersOnline)
				{
					TimeSpan ts = DateTime.Now - user.activity;
					if (ts.Seconds > 15)
						usersDisconnected.Add(user);
				}
				foreach(User user in usersDisconnected)
				{
					Telegram.usersOnline.Remove(user);
					Telegram.S.WaitOne();
					Telegram.messages.Add($"Пользователь {user.Name} вышел из сети");
					Console.WriteLine($"Пользователь {user.Name} вышел из сети");
				}
				Thread.Sleep(7500);
			}
		}
	}
}