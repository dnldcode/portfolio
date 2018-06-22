#pragma once
#include "Header.h"

struct Db
{
	int month;
	int tn;
	double s;
	double b;
	double t;
};
Db Archiv[500];
int ia;
struct Config
{
	int teamIndex;
};
Employee *Factory(Config cf)
{
	Employee *tmp = NULL;
	do
	{		
		int r = rand() % 101;
		if (r % 3 == 0)
			tmp = new Programmer(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 101 + 10, rand() % 11 + 10);   //рандомно выбираем имя из списка имён для програмиста, рандомим табельный номер,
		else if (r % 2 == 1 && r < 70)
			tmp = new Manager(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 401 + 800, rand() % 1001 + 100);
		else if (r % 5 == 0 && r > 70)
			tmp = new Boss(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 401 + 200, rand() % 5001 + 1000);
		else
			tmp = new Programmer(Names[rand() % 20], cf.teamIndex * 100 + is, rand() % 101 + 10, rand() % 11 + 10);   //рандомно выбираем имя из списка имён для програмиста, рандомим табельный номер,
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
	int tid = 0;
	for (int i = 0;i < is;i++)
	{
		if (typeid(*Staff[i]) == typeid(Programmer))
		{
			tid = 1;
			fwrite(&tid, sizeof(tid), 1, out);
			fwrite(Staff[i], sizeof(Programmer), 1, out);
		}
		else if (typeid(*Staff[i]) == typeid(Manager))
		{
			tid = 2;
			fwrite(&tid, sizeof(tid), 1, out);
			fwrite(Staff[i], sizeof(Manager), 1, out);
		}
		else if (typeid(*Staff[i]) == typeid(Boss))
		{
			tid = 3;
			fwrite(&tid, sizeof(tid), 1, out);
			fwrite(Staff[i], sizeof(Boss), 1, out);
		}
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
	/*Programmer *pp = new Programmer;
	Manager *pm = new Manager;
	Boss *pb = new Boss;*/
	int tid = 0;
	while(!feof(in))
	{
		fread(&tid, sizeof(tid), 1, in);
		if (tid == 1)
		{
			Programmer *pp = new Programmer;
			fread(pp, sizeof(*pp), 1, in);
			Staff[is++] = pp;
		}
		else if (tid == 3)
		{
			Manager *pm = new Manager;
			fread(pm, sizeof(*pm), 1, in);
			Staff[is++] = pm;
		}
		else if (tid == 3)
		{
			Boss *pb = new Boss;
			fread(pb, sizeof(*pb), 1, in);
			Staff[is++] = pb;
		}
		Sleep(100);
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
			for (int i = 0;i < num;i++)
			{
				Staff[is++] = Factory(cf);
			}
			for(int i = 0; i < is; i++)
				Staff[i]->Show();
			SaveTeam(team);
			cf.teamIndex = team;
			SetConfig(cf);
			/*for (int i = 0; i < is; i++) 
				delete Staff[i];
			is = 0;*/
			break;
		}
		case 2:
		{
			Config cf = ReadConfig();
			int team = cf.teamIndex;
			cout << "Select team from 1 to " << team << ":";
			cin >> team;
			ReadTeam(team);
			for (int i = 0;i < is;i++)
			{
				Staff[i]->Show();
			}
			break;
		}
		case 3:
		{
			cout << "Enter month : ";
			cin >> in;
			for (int i = 0; i < is;i++)
			{
				double s = Staff[i]->Salary();
				double b = Staff[i]->Bonus();
				double t = Staff[i]->Tax(s + b);
				Db db;
				db.month = in;
				db.s = s;
				db.b = b;
				db.t = t;
				Archiv[ia++] = db;
				Staff[i]->Show();
				cout << "Salary : " << Archiv[i].s << " Bonus : " << Archiv[i].b << " Tax : " << Archiv[i].t << endl;
				cout << "---------------------------------" << endl;
			}
			break;
		}
		case 4:
		{
			cout << "Enter month : ";
			cin >> in;
			for (int i = 0;i < ia;i++)
			{
				if (in == Archiv[i].month)
				{
					Staff[i]->Show();
					cout << "Salary : " << Archiv[i].s << " Bonus : " << Archiv[i].b << " Tax : " << Archiv[i].t << endl;
					cout << "---------------------------------" << endl;
				}
			}
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