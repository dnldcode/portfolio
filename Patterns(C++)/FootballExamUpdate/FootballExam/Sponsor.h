#pragma once
#include "AbsFact1.h"

class Spns
{
public:
	virtual int InvestMoney() = 0;
};

class Sponsor : public Spns
{
private:
	int balance;
public:
	Sponsor()
	{
		this->balance = rand() % 150000 + 150000;
	}
	virtual int InvestMoney()
	{
		int part = rand() % 3 + 2;
		int money = this->balance / part;
		this->balance -= money;
		return money;
	}
	int getBalance()
	{
		return this->balance;
	}
};