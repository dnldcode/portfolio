#include <iostream>
#include <Windows.h>
#include <string>
#include <time.h>
#include <iomanip>
#include <conio.h>
using namespace std;

inline void Error()
{
	cout << "������� �������� ��������. ���������� ��� ���." << endl;
}
struct filmt
{
	char Film[35]; // �����
	char Rej[35]; // ��������
	char Janr[35]; // ����
	float rate; // �������
	double price; // ����
};

void Show(filmt *st, int &n);
filmt *Create(filmt *st, int n);
void Down(char *name, char *n);
void FindN(filmt *st, int n, int *find, int &fs, char name[35]);
void FindR(filmt *st, int n, int *find, int &fs, char name[35]);
void FindJ(filmt *st, int n, int *find, int &fs, char name[35]);
void Sort(filmt *st, int n, int &fs, int *find, char name[35]);
void CreateFile(filmt *st, int n)
{
	FILE *tab = fopen("Tab.txt", "w");
	fprintf(tab,"\n\n=========================================================================================================================\n");
	fprintf(tab, "|\t\t �������� ������  |\t\t\t  ��������  |\t\t\t        ���� | ������� |  ����  |\n");
	fprintf(tab, "=========================================================================================================================\n");
	for (int i = 0; i < n; i++)
		fprintf(tab, "|%31s |%31s  |%31s | %7.1f | %6.1f |\n", (st + i)->Film, (st + i)->Rej, (st + i)->Janr, (st + i)->rate, (st + i)->price);
	fprintf(tab, "=========================================================================================================================\n");
	fclose(tab);
}

filmt film1 = { "�����", "������ �������","����������, ������, �������", 0, 0 }; // ����� �� ����������
filmt film2 = { "���������", "������ �������","����������, �����", 7.0,65 };
filmt film3 = { "�����", "�. ���� ��������","�����, �������", 7.5,30 };
filmt film4 = { "��������", "���� ������","����������, �������", 8.0,100 };
filmt film5 = { "����: ������ ������", "������� ���-�������","����������, �������, ������", 7.1,90 };
filmt film6 = { "����������", "Ը��� ���������","����������", 5,60 };
filmt film7 = { "��������", " ���� ���������","����������, �����, �������", 7.2,90 };
filmt film8 = { "�����", "������� ��������","�����, ����������, �������", 7.1,90 };
filmt film9 = { "������� ���������", "��� ���������","����������, ������, �����������", 6.3,90 };
filmt film10 = { "����� ������", "������� �������","����������, �������, ������", 7.1,90 };
char x;

void C(char *ar, int n) 
{
	do {
		cin.getline(ar, 100);
		if (!(strlen(ar) > 0 && strlen(ar) <= n))
			cout << "\n ������. �� ������� ����� ��� ���������� ���� �� ������ �� �����.\n" << endl;
	} while (!(strlen(ar) > 0 && strlen(ar) <= n));
}

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	int n = 10;
	filmt *st = new filmt[n];
	*(st + 0) = { film1 };
	*(st + 1) = { film2 };
	*(st + 2) = { film3 };
	*(st + 3) = { film4 };
	*(st + 4) = { film5 };
	*(st + 5) = { film6 };
	*(st + 6) = { film7 };
	*(st + 7) = { film8 };
	*(st + 8) = { film9 };
	*(st + 9) = { film10 };
	int find[35], fs = 0;
	char name[35];
	int q;
S:
	CreateFile(st, n);
	system("cls");
	cout << "\n \t���� : \n" << endl;
	cout << " 1. ����� �� ��������." << endl;
	cout << " 2. ����� �� �����." << endl;
	cout << " 3. ����� �� ���������." << endl;
	cout << " 4. ����� ���������� ����� � �����." << endl;
	cout << " 5. �������� ��� ������." << endl;
	cout << " 6. �������� ������." << endl;
	cout << "\n 7. �����." << endl;
	do {
		cout << "\n ����� : ";
		cin >> x;
	} while (!(x == '1' || x == '2' || x == '3' || x == '4' || x == '5' || x == '6' || x == '7'));
	cin.ignore();
	switch (x)
	{
	case '1':
	{
		Show(st, n);
		do {
			cout << "\n\n ������� ����� ��� ������ : ";
			cin.getline(name, 30);
			if (!strlen(name) > 0)
				cout << "\n ������. �� �� ����� �����." << endl;
		} while (!strlen(name) > 0);
		system("cls");
		cout << "\n ����� �� ����� �� �������� : ";
		puts(name);
		cout << endl << endl;
		FindN(st, n, find, fs, name);
		break;
	}
	case '2':
	{
		Show(st, n);
		do {
			cout << "\n\n ������� ����� ��� ������ : ";
			cin.getline(name, 30);
			if (!strlen(name) > 0)
				cout << "\n ������. �� �� ����� �����." << endl;
		} while (!strlen(name) > 0);
		system("cls");
		cout << "\n ����� �� ����� �� ����� : ";
		puts(name);
		cout << endl << endl;
		FindJ(st, n, find, fs, name);
		break;
	}
	case '3':
	{
		Show(st, n);
		do {
			cout << "\n\n ������� ����� ��� ������ : ";
			cin.getline(name, 30);
			if (!strlen(name) > 0)
				cout << "\n ������. �� �� ����� �����." << endl;
		} while (!strlen(name) > 0);
		system("cls");
		cout << "\n ����� �� ����� � ���������� : ";
		puts(name);
		cout << endl << endl;
		FindR(st, n, find, fs, name);
		break;
	}
	case '4':
	{
		Show(st, n);
		do {
			cout << "\n\n ������� ����� ��� ������ : ";
			cin.getline(name, 30);
			if (!strlen(name) > 0)
				cout << "\n ������. �� �� ����� �����." << endl;
		} while (!strlen(name) > 0);
		system("cls");
		cout << "\n ����� ������� �� ����� � ������ : ";
		puts(name);
		cout << endl << endl;
		Sort(st, n, fs, find, name);
		break;
	}
	case '5':
	{
		Show(st, n);
		break;
	}
	case '6':
	{
		system("cls");
		st = Create(st, n);
		n++;
		break;
	}
	case '7':
		exit(0);
	}
	cout << "\n ������� ����� ������� ��� �������� � ������� ����" << endl;
	_getch();
	goto S;
}

void Show(filmt *st, int &n)
{
	system("cls");
	cout << "\n\n=========================================================================================================================" << endl;
	cout << "|\t\t �������� ������  |\t\t\t  ��������  |\t\t\t        ���� | ������� |  ����  |" << endl;
	cout << "=========================================================================================================================" << endl;
	for (int i = 0; i < n; i++)
		printf("|%31s  |%31s  |%31s | %7.1f | %6.1f |\n", (st + i)->Film, (st + i)->Rej, (st + i)->Janr, (st + i)->rate, (st + i)->price);
	cout << "=========================================================================================================================" << endl;
}
filmt *Create(filmt *st, int n)
{
	filmt *add = new filmt[n];
	for (int i = 0; i < n; i++)
		*(add + i) = *(st + i);
	delete[] st;
	st = nullptr;
	st = new filmt[n + 1];
	for (int i = 0; i < n; i++)
		*(st + i) = *(add + i);
	cout << " ������� ����� : ";
	C((st + n)->Film, 31);
	cout << " ������� ��������� : ";
	C((st + n)->Rej,31);
	cout << " ������� ���� : ";
	C((st + n)->Janr, 31);
	cout << " ������� �������(0-10) : ";

	do {
		cout << " ������� �������(0-10) : ";
		cin >> (st + n)->rate;
		if (!(((st + n)->rate) >= 0 && ((st + n)->rate) <= 10))
			cout << "\n ������. ������� ������ ���� � ��������� [0,10].\n" << endl;
	} while (!(((st + n)->rate) >= 0 && ((st + n)->rate) <= 10));
	do {
		cout << " ������� ���� : ";
		cin >> (st + n)->price;
		if (!(((st + n)->price) >= 0 && ((st + n)->price) <= 9999))
			cout << "\n ������. ���� ������ ���� �������������.\n" << endl;
	} while (!(((st + n)->price) >= 0 && ((st + n)->price) <= 9999));
	return st;
}
void Down(char *name, char *n)
{
	strcpy(n, name);
	for (int i = 0; i < strlen(n); i++)
		for (int j = 192; j <= 223; j++)
			if (*(n + i) == char(j))
				*(n + i) = j + 32;

	for (int i = 0; i < strlen(n); i++)
		for (int j = 65; j <= 90; j++)
			if (*(n + i) == char(j))
				*(n + i) = j + 32;
}
void FindN(filmt *st, int n, int *find, int &fs, char name[35])
{
	char n1[35], *n2, n3[35], n4[35];
	for (int i = 0; i < n; i++)
	{
		Down(st[i].Film, n3);
		Down(name, n4);
		strcpy(n1, n3);
		n2 = strtok(n1, " ,;-");
		do
		{
			if (strnicmp(n2, n4, strlen(n4)) == 0)
			{
				find[fs++] = i;
				break;
			}
			n2 = strtok('\0', " ,;-");
		} while (n2 != '\0');
	}
	if (fs != 0)
	{
		cout << "=========================================================================================================================" << endl;
		cout << "|\t\t �������� ������  |\t\t\t  ��������  |\t\t\t        ���� | ������� |  ����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < fs; i++)
			cout << "|" << setw(31) << st[find[i]].Film << "  |" << setw(31) << st[find[i]].Rej << "  |" << setw(31) << st[find[i]].Janr << " | " << fixed << setprecision(1) << setw(7) << st[find[i]].rate << " | " << fixed << setprecision(1) << setw(6) << st[find[i]].price << " |" << endl;
		cout << "=========================================================================================================================" << endl;
	}
	else
		cout << " ������, ������ �� �������." << endl;
	fs = 0;
}
void FindR(filmt *st, int n, int *find, int &fs, char name[35])
{
	char n1[35], *n2, n3[35], n4[35];
	for (int i = 0; i < n; i++)
	{
		Down(st[i].Rej, n3);
		Down(name, n4);
		strcpy(n1, n3);
		n2 = strtok(n1, " ,;-");
		do
		{
			if (strnicmp(n2, n4, strlen(n4)) == 0)
			{
				find[fs++] = i;
				break;
			}
			n2 = strtok('\0', " ,;-");
		} while (n2 != '\0');
	}
	if (fs != 0)
	{
		cout << "=========================================================================================================================" << endl;
		cout << "|\t\t �������� ������  |\t\t\t  ��������  |\t\t\t        ���� | ������� |  ����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < fs; i++)
			cout << "|" << setw(31) << st[find[i]].Film << "  |" << setw(31) << st[find[i]].Rej << "  |" << setw(31) << st[find[i]].Janr << " | " << fixed << setprecision(1) << setw(7) << st[find[i]].rate << " | " << fixed << setprecision(1) << setw(6) << st[find[i]].price << " |" << endl;
		cout << "=========================================================================================================================" << endl;
	}
	else
		cout << " ������, ������ �� �������." << endl;
	fs = 0;
}
void FindJ(filmt *st, int n, int *find, int &fs, char name[35])
{
	char n1[35], *n2, n3[35], n4[35];
	for (int i = 0; i < n; i++)
	{
		Down(st[i].Janr, n3);
		Down(name, n4);
		strcpy(n1, n3);
		n2 = strtok(n1, " ,;-");
		do
		{
			if (strnicmp(n2, n4, strlen(n4)) == 0)
			{
				find[fs++] = i;
				break;
			}
			n2 = strtok('\0', " ,;-");
		} while (n2 != '\0');
	}
	if (fs != 0)
	{
		FILE *res = fopen("results.txt", "a");
		cout << "=========================================================================================================================" << endl;
		cout << "|\t\t �������� ������  |\t\t\t  ��������  |\t\t\t        ���� | ������� |  ����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < fs; i++)
			cout << "|" << setw(31) << st[find[i]].Film << "  |" << setw(31) << st[find[i]].Rej << "  |" << setw(31) << st[find[i]].Janr << " | " << fixed << setprecision(1) << setw(7) << st[find[i]].rate << " | " << fixed << setprecision(1) << setw(6) << st[find[i]].price << " |" << endl;
		cout << "=========================================================================================================================" << endl;

		fprintf(res, "=========================================================================================================================\n");
		fprintf(res, "|\t\t �������� ������  |\t\t\t  ��������  |\t\t\t        ���� | ������� |  ����  |\n");
		fprintf(res, "=========================================================================================================================\n");
		for (int i = 0; i < fs; i++)
			fprintf(res, "|%31s  |%31s  |%31s | %7.1f | %6.1f |\n", st[find[i]].Film, st[find[i]].Rej, st[find[i]].Janr, st[find[i]].rate, st[find[i]].price);
		fprintf(res, "=========================================================================================================================\n");
		fclose(res);
	}
	else
		cout << " ������, ������ �� �������." << endl;
	fs = 0;
}
void Sort(filmt *st, int n, int &fs, int *find, char name[35])
{
	int q = 0;
	char n1[35], *n2, n3[35], n4[35];
	for (int i = 0; i < n; i++)
	{
		Down(st[i].Janr, n3);
		Down(name, n4);
		strcpy(n1, n3);
		n2 = strtok(n1, " .,;-");
		do
		{
			if (strnicmp(n2, n4, strlen(n4)) == 0)
			{
				find[fs++] = i;
				break;
			}
			n2 = strtok('\0', " .,;-");
		} while (n2 != '\0');
	}
	if (fs != 0)
	{
		int min = st[find[0]].rate, in = find[0];
		for (int i = 1; i < fs; i++)
		{
			if (min < st[find[i]].rate)
			{
				min = st[find[i]].rate;
				in = find[i];
			}
		}
		cout << "=========================================================================================================================" << endl;
		cout << "|\t\t �������� ������  |\t\t\t  ��������  |\t\t\t        ���� | ������� |  ����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		cout << "|" << setw(31) << st[in].Film << "  |" << setw(31) << st[in].Rej << "  |" << setw(31) << st[in].Janr << " | " << fixed << setprecision(1) << setw(7) << st[in].rate << " | " << fixed << setprecision(1) << setw(6) << st[in].price << " |" << endl;
		cout << "=========================================================================================================================" << endl;
	}
	else
	{
		cout << " ������, ������ �� �������.\n" << endl;
	}
	fs = 0;
}