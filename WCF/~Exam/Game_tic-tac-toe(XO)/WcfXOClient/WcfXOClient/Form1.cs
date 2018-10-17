using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WcfXOClient
{
	public partial class Form1 : Form
	{
		WcfXOServer.GameState gs;
		String name;
		public Thread thread;
		public Thread threadActivity;
		public Form1()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.BackColor = Color.White;
			this.StartPosition = FormStartPosition.CenterScreen;

			tableLayoutPanel2.BackColor = Color.Gainsboro;
			this.FormClosing += Form1_FormClosing;

			gs = null;
			name = "Unknown";
			Connection.login.textBoxInput.Text = "";

			if (Connection.MakeConnection())
			{
				Environment.Exit(0);
                return;
			}

			labelNickName.Text = this.name = Connection.login.textBoxInput.Text;
			labelStatus.Text = "В главном меню";
			threadActivity = new Thread(sendActivity);
			threadActivity.IsBackground = true;
			threadActivity.Start();
		}

		public void sendActivity()
		{
			while (true)
			{
				try
				{
					Connection.wcfClient.client.isConnected();
				}
				catch
				{
					threadActivity.Abort();
					threadActivity.Join(500);
					return;
				}
				if (gs == null || gs.state == 3 || gs.state == 4 || gs.state == 0)
					Connection.wcfClient.SendActivityMessage(this.name);
				Thread.Sleep(7500);
			}
		}

		public void resetAll()
		{
			this.Invoke(new Action(() => { this.labelStatus.Text = "В главном меню"; button1.Text = "Найти игру"; labelNickName.Text = this.name = Connection.login.textBoxInput.Text;label2.Visible = false;labelChar.Visible = false;MainTableLayout.Enabled = true; this.labelChar.Text = ""; }));
			foreach (Control c in MainTableLayout.Controls.OfType<Panel>())
				c.BackgroundImage = null;
			gs = null;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.name != "Unknown")
				Connection.wcfClient.UserDisconnect(this.name);
		}

		private void panels_Click(object sender, EventArgs e)
		{
			Panel panel = (Panel)sender;
			String[] str = (panel.Tag.ToString()).Split(';');
			if (Connection.wcfClient.SetInfoIntoField(name, Convert.ToInt32(str[0]), Convert.ToInt32(str[1])) == "SUCCESS")
			{
				MainTableLayout.Enabled = false;
				panel.BackgroundImage = (gs.players[gs.idOfPlayer(this.name)].Symbol == 'X') ? Resource1.X : Resource1.O; 
			}
			else if (gs == null)
			{
				MessageBox.Show("Начините поиск соперника чтобы играть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Invoke(new Action(() => { labelStatus.Text = "Поиск игры"; }));
			if (gs == null)
			{
				if (Connection.wcfClient.AddPlayer(this.name) == "SUCCESS")
				{
					gs = Connection.wcfClient.GetGameState(this.name);
					thread = new Thread(runCheck);
					thread.IsBackground = true;
					thread.Start();
					this.Invoke(new Action(() => { button1.Text = "Покинуть игру"; }));
				}
			}
			else
			{
				if (gs != null && gs.state == 1 || gs.state == 2)
					MessageBox.Show("Вы покинули игру, засчитан проигрыш", "Выход", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Connection.wcfClient.leaveFromGame(name);
				resetAll();
				thread.Abort();
				thread.Join(500);
			}
			foreach (Control c in MainTableLayout.Controls.OfType<Panel>())
				MainTableLayout.Invoke(new Action(() => { c.BackgroundImage = null; }));
		}

		public void runCheck()
		{
			while (true)
			{
				try
				{
					Connection.wcfClient.client.isConnected();
				}
				catch
				{
					Connection.MakeConnection(true);
					break;
				}
				gs = Connection.wcfClient.GetGameState(this.name);
				if (gs == null)
				{
					MessageBox.Show("Вы были кикнуты за бездействие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
					resetAll();
					break;
				}
				if (gs.state == 0)
					labelStatus.Invoke(new Action(() => { labelStatus.Text = "Ожидание игрока"; }));
				else if (gs.state == 1 || gs.state == 2)
				{
					String str = gs.players[gs.idOfPlayer(this.name)].Symbol.ToString();
					if (this.labelChar.Text != str)
						labelChar.Invoke(new Action(() => { labelChar.Text = str; labelChar.Visible = true; label2.Visible = true; }));
					if (gs.players[gs.state - 1].name == name)
					{
						if (gs.lastAction != null)
						{
							foreach (Control c in MainTableLayout.Controls.OfType<Panel>())
							{
								if (c.Tag.ToString().Contains(gs.lastAction))
								{
									Panel panel = c as Panel;
									if (panel.BackgroundImage == null)
										panel.Invoke(new Action(() => { panel.BackgroundImage = (gs.players[gs.idOfPlayer(this.name)].Symbol != 'X') ? Resource1.X : Resource1.O; }));
									break;
								}
							}
						}
						labelStatus.Invoke(new Action(() => { labelStatus.Text = "Ваш ход"; }));
						MainTableLayout.Invoke(new Action(() => { MainTableLayout.Enabled = true; }));
					}
					else
					{
						labelStatus.Invoke(new Action(() => { labelStatus.Text = "Ходит - " + gs.players[gs.state - 1].name; }));
						MainTableLayout.Invoke(new Action(() => { MainTableLayout.Enabled = false; }));
					}
				}
				else if (gs.state == 3 || gs.state == 4)
				{
					if (gs.players[gs.state - 3].name == name)
					{
						if (gs.players[(gs.state == 3) ? 1 : 0].name == "")
							labelStatus.Invoke(new Action(() => { labelStatus.Text = "Соперник покинул игру"; }));
						else
							labelStatus.Invoke(new Action(() => { labelStatus.Text = "Вы победили"; }));
						MessageBox.Show("Поздравляем с победой!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						if (gs.lastAction != null)
						{
							foreach (Control c in MainTableLayout.Controls.OfType<Panel>())
							{
								if (c.Tag.ToString().Contains(gs.lastAction))
								{
									Panel panel = c as Panel;
									if (panel.BackgroundImage == null)
										panel.Invoke(new Action(() => { panel.BackgroundImage = (gs.players[gs.idOfPlayer(this.name)].Symbol != 'X') ? Resource1.X : Resource1.O; }));
									break;
								}
							}
						}
						labelStatus.Invoke(new Action(() => { labelStatus.Text = "Победил - " + gs.players[gs.state - 3].name; }));
						MessageBox.Show("Вы проиграли. Повезет в следующий раз!", "Поражение", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					this.button1_Click(null, null);
					gs = null;
					break;
				}
				else if (gs.state == 5)
				{
					labelStatus.Invoke(new Action(() => { labelStatus.Text = "Ничья"; }));
					MessageBox.Show("Нет победивших. Конец игры", "Ничья", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.button1_Click(null, null);
					gs = null;
					break;
				}
				Thread.Sleep(1000);
			}
		}

		private void labelStatus_TextChanged(object sender, EventArgs e)
		{
			this.Text = $"Крестики-нолики [{labelStatus.Text}]";
		}
	}

	static public class Connection
	{
		static public wcfClient wcfClient = new wcfClient();
		static public LogIn login = new LogIn();
		static public bool MakeConnection(bool isError = false)
		{
			if(isError)
				MessageBox.Show("Невозможно подключиться, попробуйте позже.", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Form1 f1 = Program.getForm();
			if (f1 != null)
				f1.Hide();
			while (true)
			{
				ChannelFactory<WcfXOServer.XOPlatform> wcf = new ChannelFactory<WcfXOServer.XOPlatform>("MyConfig");
				wcfClient.client = wcf.CreateChannel();
				if (login.ShowDialog() == DialogResult.OK)
				{
					try
					{
						String[] strs = wcfClient.Login(login.textBoxInput.Text).Split('|');
						if (strs[0] == "ERROR")
						{
							MessageBox.Show(strs[1], "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
							continue;
						}
						else
						{
							if (f1 != null)
							{
								f1.resetAll();
								f1.Show();
								if (!f1.threadActivity.IsAlive)
								{
									f1.threadActivity = new Thread(f1.sendActivity);
									f1.threadActivity.IsBackground = true;
									f1.threadActivity.Start();
								}
							}
							return false;
						}
					}
					catch
					{
						MessageBox.Show("Невозможно подключиться, попробуйте позже.", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
						continue;
					}
				}
				else
				{
					Environment.Exit(0);
					return true;
				}
			}
		}
	}
	public class wcfClient
	{
		public WcfXOServer.XOPlatform client;

		public String Login(String name)
		{
			return client.Login(name);
		}
		public String MakeGame(String player)
		{
			try
			{
				return client.MakeGame(player);
			}
			catch
			{
				Connection.MakeConnection(true);
			}
			return null;
		}
		public String AddPlayer(String player)
		{
			try
			{
				return client.AddPlayer(player);
			}
			catch
			{
				Connection.MakeConnection(true);
			}
			return null;
		}
		public WcfXOServer.GameState GetGameState(String player)
		{
			try
			{
				return client.GetGameState(player);
			}
			catch
			{
				Connection.MakeConnection(true);
			}
			return null;
		}
		public String SetInfoIntoField(String player, int i1, int j1)
		{
			try
			{
				return client.SetInfoIntoField(player, i1, j1);
			}
			catch
			{
				Connection.MakeConnection(true);
			}
			return null;
		}
		public void leaveFromGame(String player)
		{
			try
			{
				client.leaveFromGame(player);
			}
			catch
			{
				Connection.MakeConnection(true);
			}
		}
		public void UserDisconnect(String player)
		{
			try
			{
				client.UserDisconnect(player);
			}
			catch { }
		}
		public void SendActivityMessage(String player)
		{
			try
			{
				client.SendActivityMessage(player);
			}
			catch
			{
				Connection.MakeConnection(true);
			}
		}
	}
}

namespace WcfXOServer
{
	public class GameState
	{
		[DataMember]
		public int state; //0- ожидание подключения
						  //1- ход первого игрока
						  //2- ход второго игрока
						  //3- победил 1
						  //4- победил 2
						  //5- ничья
		[DataMember]
		public String lastAction;
		[DataMember]
		public User[] players;
		public int idOfPlayer(String name)
		{
			return (players[1].name == name) ? 1 : 0;
		}
	}
	public class User
	{
		[DataMember]
		public String name;
		[DataMember]
		public char Symbol;
	}
	[ServiceContract]
	public interface XOPlatform
	{
		[OperationContract]
		String Login(String name);
		[OperationContract]
		String MakeGame(String player);
		[OperationContract]
		String AddPlayer(String player);
		[OperationContract]
		GameState GetGameState(String player);
		[OperationContract]
		String SetInfoIntoField(String player, int i1, int j1);
		[OperationContract]
		void leaveFromGame(String player);
		[OperationContract]
		void UserDisconnect(String player);
		[OperationContract]
		void SendActivityMessage(String player);
		[OperationContract]
		bool isConnected();
	}
}