#pragma once
#include "Header5.h"

struct Config
{
	int teamIndex;
};
Employee* Factory(Config cf)
{
	Employee *tmp = NULL;
	do
	{
		Sleep(300);
		int r = rand() % 101;
		if (r % 3 == 0)
			tmp = new Programmer(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 101 + 10, 0);   //рандомно выбираем имя из списка имён для програмиста, рандомим табельный номер,
		else if (r % 2 == 1 && r < 70)
			tmp = new Manager(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 401 + 800, 0);
		else if (r % 5 == 0 && r > 70)
			tmp = new Boss(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 401 + 200, 0);
		else
			tmp = new Programmer(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 101 + 10, 0);   //рандомно выбираем имя из списка имён для програмиста, рандомим табельный номер,
	} while (!tmp);
	return tmp;
}
Employee *Staff[100];
Config ReadConfig()
{
	Config cf;
	FILE *in = fopen("config.txt", "r");
	if (!in)
	{
		cf.teamIndex = 1;
		in = fopen("config.txt", "w+");
		fwrite(&cf, sizeof(cf), 1, in);
		fclose(in);
	}
	else
	{
		fread(&cf, sizeof(cf), 1, in);
		fclose(in);
	}
	return cf;
}
void SetConfig(Config cf)
{
	FILE *in = fopen("config.txt", "w");
	fwrite(&cf, sizeof(cf), 1, in);
	fclose(in);
}
void SaveTeam(int team)
{
	char FileName[255];
	itoa(team, FileName, 10);
	strcat(FileName, ".txt");
	FILE *out = fopen(FileName, "w");
	for (int i = 0; i < is; i++)
	{
		fwrite(Staff[i], sizeof(Staff[i]), 1, out);
	}
	fclose(out);
}
void ReadTeam(int team)
{
	char FileName[255];
	itoa(team, FileName, 10);
	strcat(FileName, ".txt");
	FILE *in = fopen(FileName, "r");
	is = 0;
	while (!feof(in))
	{
		Programmer p;
		Manager m;
		Boss b;
		try {
			fread(&p, sizeof(p), 1, in);
			Staff[is++] = &p;
		}
		catch (exception e)
		{
			try {
				fread(&m, sizeof(m), 1, in);
				Staff[is++] = &m;
			}
			catch (exception e)
			{
				fread(&b, sizeof(b), 1, in);
				Staff[is++] = &b;
			}
		}
	}
}
void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	int menu, num;
	do {
		printf("\n 1. Hire staff.\n");
		printf(" 2. Select project.\n");
		printf(" 3. Accrue salary.\n");
		printf(" 4. Show reports.\n");
		printf("\n 0. Exit.\n");
		printf("\n Select action : ");
		scanf("%d", &menu);
		switch (menu)
		{
		case 1:
		{
			Config cf = ReadConfig();
			int team = cf.teamIndex + 1;
			int num = rand() % 10 + 5;
			for (int i = 0; i < num; i++)
			{
				Staff[is++] = Factory(cf);
			}
			for (int i = 0; i < is; i++)
				Staff[i]->Show();
			SaveTeam(team);
			cf.teamIndex = team;
			SetConfig(cf);
			break;
		}
		case 2:
		{
		/*	Config cf = ReadConfig();
			int team = cf.teamIndex;
			cout << "Select team from 1 to " << team << ":";
			cin >> team;
			ReadTeam(team);
			for (int i = 0; i < is; i++)
			{
				Staff[i]->Show();
			}*/
			break;
		}
		case 3:
		{

			break;
		}
		case 4:
		{

			break;
		}
		case 0:
			exit(0);
		default:
		{
			printf("\n Error\n");
			break;
		}
		}

	} while (menu != 0);
}