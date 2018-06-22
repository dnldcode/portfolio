#pragma once
#include "Club.h"

void Game(Club c1, Club c2)
{
	int att1 = c1.getTotalAttackSkill(), def1 = c1.getTotalDefendSkill();
	int att2 = c2.getTotalAttackSkill(), def2 = c2.getTotalDefendSkill();
	int goal1 = 0, goal2 = 0;
	for (int i = 0;i < 5;i++)
	{
		int a1 = rand() % att1;
		int a2 = rand() % att2;
		int d1 = rand() % def1;
		int d2 = rand() % def2;
		if (a1 - d2 - c2.getGSkill() > 0)
			goal1++;
		if (a2 - d1 - c1.getGSkill() > 0)
			goal2++;
	}
	cout << setw(20) << c1.getName() << " : " << c2.getName() << endl;
	cout << setw(20) << goal1 << " : " << goal2 << endl;
	FILE *out = fopen("score.txt", "a+");
	fprintf(out, "Score :  %20s-%s \t %3d : %d\n\n", c1.getName(), c2.getName(), goal1, goal2);
	fclose(out);
}

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	Sponsor s1;
	Coach coach1(&s1);
	Club club1(&coach1);
	club1.TeamFactory();

	Sponsor s2;
	Coach coach2(&s2);
	Club club2(&coach2);
	club2.TeamFactory();
	club1.OptimizeTeam();
	club1.ShowTeam();

	club2.OptimizeTeam();
	club2.ShowTeam();

	Game(club1, club2);
}