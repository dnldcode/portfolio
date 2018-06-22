#pragma once
#include "Coach.h"
#include "Sponsor.h"

class AbstractFactory
{
public:
	virtual Spns* CreateSpns() = 0;
	virtual Coah* CreateCoah() = 0;
	virtual void CreatePlr() = 0;
};

class Club : public AbstractFactory
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
	double getTotalAttackSkill()
	{
		double sum = 0;
		for (int i = 0;i < players.size();i++)
			sum += players[i]->getSkill();
		return sum;
	}
	string getName()
	{
		return this->name;
	}
	Club()
	{
		int q;
		if (ClubNames.size() != 0)
		{
			q = rand() % ClubNames.size();
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