#pragma once
#include "Sponsor.h"

class Coah
{
public:
	virtual int getBank() = 0;
};

class Coach : public Coah
{
private:
	int bank;
	Sponsor* sponsor;
public:
	Coach()
	{
	}
	Coach(Sponsor *s)
	{
		this->sponsor = s;
		this->bank = s->InvestMoney();
	}
	virtual int getBank()
	{
		return this->bank;
	}
	void setBank(int bank)
	{
		this->bank -= bank;
	}
};