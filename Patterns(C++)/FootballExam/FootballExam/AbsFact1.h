#pragma once
#include <iostream>
#include <Windows.h>
#include <set>
#include <vector>
#include <iomanip>
#include <ctime>
#include <string>
#include <algorithm>
#include <functional>
#include "Coach.h"
#include "Players.h"
#include "Sponsor.h"

using namespace std;

string n1[10] = { "Барселона", "Реал Мадрид", "Манчестер Юнайтед", "Ювентус", "Бавария", "Галатасарай", "Милан", "Ливерпуль", "Интер", "Марсель" };
string n2[30] = { "Lionel Messi", "Cristiano Ronaldo", "Franck Ribéry", "Sergio Ramos", "Gerard Piqué ", "Mario Gomez", "Carlos Tévez", "Vincent Kompany", "Giorgio Chiellini", "Yaya Touré", "Andrea Pirlo", "Iker Casillas", "Gianluigi Buffon", "Edinson Cavani", "Juan Mata", "Mesut Özil", "Gareth Bale", "Thiago Silva", "Nemanja Vidić", "Philipp Lahm", "Wayne Rooney", "David Silva", "Sergio Agüero", "Schweinsteiger", "Arjen Robben"," Zlatan Ibrahimović", "Xavi", "Robin van Persie", "Andres Iniesta", "Falcao" };

vector<string> ClubNames;
vector<string> PlayerNames;

class AbstractFactory
{
public:
	virtual Spns* CreateSpns() = 0;
	virtual Coah* CreateCoah(/*Sponsor *s*/) = 0;
	virtual void CreatePlr() = 0;
};
////////////////////////////////////////
class Player : public Plr
{
private:
	string name;
	double skill;
	int price;
public:
	virtual Player* clone() = 0;
	Player()
	{
		if (PlayerNames.size() != 0)
		{
			int q = rand() % PlayerNames.size();
			this->name = PlayerNames[q];
			PlayerNames.erase(PlayerNames.begin() + q);
		}
		else
			this->name = "Unknown";
		this->skill = rand() % 16 + 5 + rand() % 10 / 10.0;
		this->price = this->skill * 5000;
	}
	void Randomize()
	{
		if (PlayerNames.size() != 0)
		{
			int q = rand() % PlayerNames.size();
		this->name = PlayerNames[q];
				PlayerNames.erase(PlayerNames.begin() + q);
		}
		else
			this->name = "Unknown";
		this->skill = rand() % 16 + 5 + rand() % 10 / 10.0;
		this->price = this->skill * 51000;
	}
	string getName()
	{
		return name;
	}
	int getSkill()
	{
		return skill;
	}
	int getPrice()
	{
		return price;
	}
	void setPrice(int price = 0)
	{
		this->price = price;
	}
	friend ostream& operator<<(ostream &os, Player* pl)
	{
		os << " Name : " << setw(20) << pl->name << "  | Skill : " << setw(5) << pl->skill << "  | Price : " << setw(10) << pl->price << endl;
		return os;
	}
};

class Goalkeeper : public Player
{
public:
	virtual Player* clone()
	{
		return new Goalkeeper(*this);
	}
};
class Defender : public Player
{
public:
	virtual Player* clone()
	{
		return new Defender(*this);
	}
};
class Midfielder : public Player
{
public:
	virtual Player* clone()
	{
		return new Midfielder(*this);
	}
};
class Striker : public Player
{
public:
	virtual Player* clone()
	{
		return new Striker(*this);
	}
};
///////////////////////
class Sponsor : public Spns
{
private:
	int balance;
public:
	Sponsor()
	{
		do {
			int p = rand() * rand() * rand();
			this->balance = p % 5000000 + 5000000;
		} while (this->balance < 5000000);
	}
	int InvestMoney()
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
///////////////////////
class Coach : public Coah
{
private:
	int bank;
	Sponsor *sponsor;
public:
	Coach()
	{

	}
	Coach(Sponsor *s)
	{
		this->sponsor = s;
		this->bank = s->InvestMoney();
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
///////////////////////
class Club: public AbstractFactory
{
	string name;
	Sponsor* sponsor;
	Coach* coach;
	vector<Player*> players;
public:
	virtual Spns* CreateSpns()
	{
		return new Sponsor;
	}
	virtual Coah* CreateCoah()
	{
		return new Coach(this->sponsor);
	}
	virtual void CreatePlr()
	{
		int q;
		Goalkeeper gk;
		Defender df;
		Midfielder mf;
		Striker sk;
		for (int i = 0;i < 5;i++)
		{
			q = rand() % 4;
			switch (q)
			{
			case 0:
			{
				players.push_back(gk.clone());
				break;
			}
			case 1:
			{
				players.push_back(gk.clone());
				break;
			}
			case 2:
			{
				players.push_back(gk.clone());
				break;
			}
			case 3:
			{
				players.push_back(gk.clone());
				break;
			}
			}
			players[players.size() - 1]->Randomize();
			if (players[players.size() - 1]->getPrice() < coach->getBank())
			{
				coach->setBank(players[players.size() - 1]->getPrice());
			}
			else
			{
				players.erase(players.begin() + players.size() - 1);
				break;
			}
		}
	}
	void ShowPlayers()
	{
		vector<Player*>::iterator it = players.begin();
		while (it != players.end())
		{
			cout << *it << endl;
			it++;
		}
	}
	Club()
	{
		if (ClubNames.size() != 0)
		{
			int q = rand() % ClubNames.size();
			this->name = ClubNames[q];
			ClubNames.erase(ClubNames.begin() + q);
		}
		else
			this->name = "Unknown";
		this->sponsor = (Sponsor*)CreateSpns();
		this->coach = (Coach*)CreateCoah();
		CreatePlr();
	}
	friend ostream& operator<<(ostream &os, Club club)
	{
		os << " Club : " << setw(20) << club.name << "  | Bank : " << setw(5) << club.coach->getBank() << "  | Players playing : " << setw(5) << club.players.size() << endl;
		return os;
	}
};