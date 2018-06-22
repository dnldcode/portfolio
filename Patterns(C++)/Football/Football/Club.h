#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include "Sponsor.h"
#include "Coach.h"
#include "Player.h"
using namespace std;

int it = 0;
char clubs[10][20] = { "Барселона", "Реал Мадрид", "Манчестер Юнайтед", "Ювентус", "Бавария", "Галатасарай", "Милан", "Ливерпуль", "Интер", "Марсель" };
class Club
{
protected:
	Player *team[15];
	char name[20];
	Coach *coach;
	int gskill;
	int it = 0;
public:
	Club(Coach *coach)
	{
		strcpy(this->name, clubs[rand() % 10]);
		this->coach = coach;
	}
	bool CheckNames(Player *p)
	{
		for (int i = 0;i < it;i++)
		{
			if (strcmp(team[i]->getName(), p->getName()) == 0 )
			{
				return 1;
			}
		}
		return 0;
	}
	void SortTeam()
	{
		Player *tmp;
		int i, j;
		for (i = 1;i < it;i++)
		{
			tmp = team[i];
			for (j = i - 1;j >= 0 && team[j]->getSkill() > tmp->getSkill();j--)
			{
				team[j + 1] = team[j];
			}
			team[j + 1] = tmp;
		}
	}
	double getAvg()
	{
		int total = 0;
		for (int i = 0;i < it;i++)
		{
			total += team[i]->getSkill();
		}
		return (double)total / it;
	}
	double getAttackSkill()
	{
		int total = 0, q = 0;
		for (int i = 0;i < it;i++)
		{
			if (typeid(*team[i]) != typeid(PStriker))
				continue;
			total += team[i]->getSkill();
			q++;
		}
		return (double)total / q;
	}
	double getDefendSkill()
	{
		int total = 0, q = 0;
		for (int i = 0;i < it;i++)
		{
			if (typeid(*team[i]) == typeid(PStriker))
				continue;
			total += team[i]->getSkill();
			q++;
		}
		return (double)total / q;
	}
	void TeamFactory()
	{
		bool done = 0;
		team[it] = new PGoalkeeper;
		gskill = team[it]->getSkill();
		coach->setBank(team[it++]->getPrice());
		int count = 0;
		while (!done)
		{
			if (rand() % 2)
			{
				PStriker *st = new PStriker;
				if (CheckNames(st)) 
						continue;
				if (coach->getBank() > st->getPrice())
				{
					coach->setBank(st->getPrice());
					team[it++] = st;
				}
			}
			else 
			{
				PMiddlefielder *pm = new PMiddlefielder;
				if (CheckNames(pm))
					continue;
				if (coach->getBank() > pm->getPrice())
				{
					coach->setBank(pm->getPrice());
					team[it++] = pm;
				}
			}
			count++;
			if (it == 15 || coach->getBank() <= 10000 || count >= 50)
				done = 1;
		}
		SortTeam();
	}
	void ShowTeam()
	{
		cout << "\n " << name << " : \n" << endl;
		cout << "                 Игрок :     Цена : " << endl;
		for (int i = 0;i < it;i++)
		{
			cout << setw(20) << team[i]->getName() << "(" << setw(2) <<  team[i]->getSkill() << ")" << setw(10) << setw(10) << team[i]->getPrice() << "$" << endl;
		}
		cout << "\n Средний скилл команды : " << getAvg() << endl;
		cout << " Средний скилл атаки : " << getAttackSkill() << endl;
		cout << " Средний скилл защиты : " << getDefendSkill() << endl;
		cout << " Остаток денег : " << coach->getBank() << endl << endl;
	}
	void OptimizeTeam()
	{
		double avg = getAvg();
		if (this->coach->getBank() < 10000)
			return;
		int q = 0;
		if (getAttackSkill() > getDefendSkill())
		{
			while (true)
			{
				q++;
				if (q >= 50)
					break;
				PMiddlefielder *mf = new PMiddlefielder;
				if (mf->getSkill() < avg || CheckNames(mf))
				{
					delete mf;
					continue;
				}
				if (this->coach->getBank() > mf->getPrice())
				{
					if (typeid(*team[0]) != typeid(PGoalkeeper))
					{
						delete team[0];
						team[0] = mf;
					}
					else
					{
						delete team[1];
						team[1] = mf;
					}
					this->coach->setBank(mf->getPrice());
					break;
				}
			}
		}
		else
		{
			while (true)
			{
				q++;
				if (q >= 50)
					break;
				PStriker *ps = new PStriker;
				if (ps->getSkill() < avg || CheckNames(ps))
				{	
					delete ps;
					continue;
				}
				if (this->coach->getBank() > ps->getPrice())
				{
					if (typeid(*team[0]) != typeid(PGoalkeeper))
					{
						delete team[0];
						team[0] = ps;
					}
					else
					{
						delete team[1];
						team[1] = ps;
					}
					this->coach->setBank(ps->getPrice());
					break;
				}
			}
		}
		SortTeam();
	}
	int getTotalAttackSkill()
	{
		int total = 0;
		for (int i = 0;i < this->it;i++)
		{
			if (typeid(*team[i]) != typeid(PStriker))
				continue;
			total += team[i]->getSkill();
		}
		return total;
	}
	int getTotalDefendSkill()
	{
		int total = 0;
		for (int i = 0;i < this->it;i++)
		{
			if (typeid(*team[i]) == typeid(PStriker))
				continue;
			total += team[i]->getSkill();
		}
		return total;
	}
	int getGSkill()
	{
		return this->gskill;
	}
	char *getName()
	{
		return this->name;
	}
};