using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw8
{
	class Program
	{
		static void Main(string[] args)
		{
			CreditCard card = new CreditCard(500);
			ATM atm = new ATM();
			atm.cashOut(card, 409.12);
			atm.cashOut(card, 100); 
		}
	}
	class CreditCard
	{
		private double account;

		public double Account
		{
			get
			{
				return this.account;
			}
			set
			{
				if (value < 0)
					value *= -1;
				this.account = value;
			}
		}
		public CreditCard(double num = 0)
		{
			Account = num;
		}
		
	}
	interface CashOut
	{
		double getAmount(CreditCard cc); // Получить состояние счета
		String greeting(); //Приветствие
		String goodBye(); // Прощание
		void cashOut(CreditCard cc, double sum); // Снятие денег
	};
	class ATM : CashOut
	{
		public void cashOut(CreditCard cc, double sum)
		{
			if (cc.Account >= sum)
			{
				cc.Account -= sum;
				Console.WriteLine("С карточки снято {0} грн. Остаток на балансе : {1} грн.", sum, cc.Account);
			}
			else
				Console.WriteLine("Недостаточно средств для снятия {0} грн. Баланс : {1} грн.", sum, cc.Account);
		}

		public double getAmount(CreditCard cc)
		{
			return cc.Account;
		}

		public string greeting()
		{
			return String.Format(" Вас приветствует наш банк. Удачных транзакций!");
		}

		public string goodBye()
		{
			return String.Format(" Благодарим за использование нашего банка! Всего хорошего!");
		}
	}
	class Cashier : CashOut
	{
		public void cashOut(CreditCard cc, double sum)
		{
			if (cc.Account >= sum)
			{
				cc.Account -= sum;
				Console.WriteLine(" Держите ваши {0} грн. У вас на балансе осталось : {1} грн.", sum, cc.Account);
			}
			else
				Console.WriteLine(" У вас недостаточно средств для снятия {0} грн. У вас на балансе : {1} грн.", sum, cc.Account);
		}

		public double getAmount(CreditCard cc)
		{
			return cc.Account;
		}

		public string greeting()
		{
			return String.Format(" Здраствуйте, что хотите сделать с вашим счетом?");
		}

		public string goodBye()
		{
			return String.Format(" Досвидания! Благодарим за транзакцию.");
		}
	}
}