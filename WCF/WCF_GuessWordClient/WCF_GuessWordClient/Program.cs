using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Threading;

namespace WCF_GuessWordServer
{

    [DataContract]
    public class GameState
    {
        [DataMember]
        public int state;
        // - 0 ожидание полключения 2-го игрока
        // - 1 ход 1-го игрока
        // - 2 ход 2-го игрока
        // - 3 конец игры. Объява победителя
        // - 4 оба игрока покинули игру

        [DataMember]
        public string curWord; // Слово с отгаданными буквами
        [DataMember]
        public string word; // загаданное слово
        [DataMember]
        public List<string> users = new List<string>(); // Список игроков участвующих в игре users[0] - 1-й игрок и т.д.
    }

    [ServiceContract]
    public interface Game
    {
        [OperationContract]
        GameState login(string userName); // подключение игрока в игру

        [OperationContract]
        GameState getGameState(string userName); // получение состояние игры

        [OperationContract]
        void makeAction(string userName, char symbol);
    }

}

namespace WCF_GuessWordClient
{
    class Program
    {
        static string login;
        static WCF_GuessWordServer.Game wcfClient;

        static void  getGameStateRunMethod()
        {;
            while (true)
            {
                WCF_GuessWordServer.GameState gs = wcfClient.getGameState(login);
                Console.Clear();
                Console.WriteLine("Слово : {0}", gs.curWord);

                switch(gs.state)
                {
                    case 0:
                        {
                            Console.WriteLine("Ожидание подключения второго игрока");
                            break;
                        }
                    case 1:
                        {
                            if (gs.users[0] == login)
                                Console.WriteLine("Ваш ход");
                            else Console.WriteLine("Ходит {0}", gs.users[1]);
                            break;
                        }
                    case 2:
                        {
                            if (gs.users[1] == login)
                                Console.WriteLine("Ваш ход");
                            else Console.WriteLine("Ходит {0}", gs.users[0]);
                            break;
                        }
                    case 3:
                        {
                            if(gs.users[0] == login)
                                Console.WriteLine("Вы выиграли");
                            else Console.WriteLine("Выиграл {0}", gs.users[1]);
                            Console.WriteLine("Конец игры");
                            return;
                        }
                    case 4:
                        {
                            if (gs.users[1] == login)
                                Console.WriteLine("Вы выиграли");
                            else Console.WriteLine("Выиграл {0}", gs.users[0]);
                            Console.WriteLine("Конец игры");
                            return;
                        }

                }
                Thread.Sleep(2000);

            }
        }
        static void Main(string[] args)
        {
            ChannelFactory<WCF_GuessWordServer.Game> myChannelFactory =
                 new ChannelFactory<WCF_GuessWordServer.Game>(new NetTcpBinding(),
                    new EndpointAddress("net.tcp://10.3.60.204:5000/WCF_GuessWordServer"));
            wcfClient = myChannelFactory.CreateChannel();

            Console.WriteLine("Введите логин : ");
            login = Console.ReadLine();
            WCF_GuessWordServer.GameState gs = wcfClient.login(login);
            if(gs == null)
            {
                Console.WriteLine("Подключиться не удалось");
                return;
            }

            Thread T = new Thread(getGameStateRunMethod);
            T.IsBackground = true;
            T.Start();

            while(true)
            {
                String symbol = Console.ReadLine();
                if (symbol == "") break; //выход из игры по пустйо строке

                wcfClient.makeAction(login, symbol[0]);
            }

            

        }
    }
}
