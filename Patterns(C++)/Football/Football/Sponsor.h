#pragma once

class Sponsor
{
protected:
	LONGLONG balance;
public:
	Sponsor()
	{
		Sleep(100);
		do {
			int p = rand() * rand() * rand();
			this->balance = p % 5000000 + 5000000;
		} while (!(this->balance >= 5000000));
	}
	int InvestMoney()
	{
		int part = rand() % 3 + 2;
		LONGLONG money = this->balance / part;
		this->balance -= money;
		return money;
	}
	int getBalance()
	{
		return this->balance;
	}
};