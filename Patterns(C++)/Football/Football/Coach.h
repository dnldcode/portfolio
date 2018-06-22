#pragma once

class Coach
{
protected:
	int bank;
	Sponsor *sponsor;
public:
	Coach()
	{

	}
	Coach(Sponsor *s)
	{
		this->sponsor = s;
		this->bank = this->sponsor->InvestMoney();
	}
	int getBank()
	{
		return this->bank;
	}
	void setBank(int bank)
	{
		this->bank -= bank;
	}
};

