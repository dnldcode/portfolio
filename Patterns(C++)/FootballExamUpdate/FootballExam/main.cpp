#pragma once
#include "AbsFact1.h"

void InsertNames()
{
	for (int i = 0;i < 10;i++)
		ClubNames.push_back(n1[i]);
	for (int i = 0;i < 30;i++)
		PlayerNames.push_back(n2[i]);
}
Club Game(Club &c1, Club &c2)
{
	int c1goal = 0, c2goal = 0;
	double c1skill = c1.getTotalAttackSkill(), c2skill = c2.getTotalAttackSkill();
	int priority1 = 0, priority2 = 0;
	(c1skill > c2skill) ? priority1 = 15 : priority2 = 15;// у того, у кого суммарный скилл больше получает +15% к победе
	int randnum;
	for (int i = 0;i < rand() % 8;i++)
	{
		randnum = rand() % 101;
		if (randnum <= 30 + priority1)
			c1goal++;
		else if (randnum >= 70 - priority2)
			c2goal++;
	}
	if (c1goal == c2goal)
		(rand() % 2 == 0) ? c1goal++ : c2goal++;
	FILE *winners = fopen("games.txt", "a");
	if (c1goal > c2goal)
	{
		printf(" %s won %s with score  %d : %d\n", c1.getName().c_str(), c2.getName().c_str(), c1goal, c2goal);
		fprintf(winners, " %s won %s with score  %d : %d\n", c1.getName().c_str(), c2.getName().c_str(), c1goal, c2goal);
		fclose(winners);
		return c1;
	}
	else
	{
		printf(" %s won %s with score  %d : %d\n", c2.getName().c_str(), c1.getName().c_str(), c2goal, c1goal);
		fprintf(winners, " %s won %s with score  %d : %d\n", c2.getName().c_str(), c1.getName().c_str(), c2goal, c1goal);
		fclose(winners);
		return c2;
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");
 	srand(time(NULL));

	InsertNames();
	Club club1, club2, club3, club4;
	cout << " Team 1\n" << club1 << endl;
	cout << " Team 2\n" << club2 << endl;
	cout << " Team 3\n" << club3 << endl;
	cout << " Team 4\n" << club4 << endl;


	cout << "\n Winner : \n" << Game(Game(club3, club4), Game(club1, club2)) << endl;

	return 0;
}