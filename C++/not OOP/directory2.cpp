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
struct home
{
	char street[35]; // �����
	char hh[10]; // ���
	char number[35]; // �����
};
struct firm
{
	char name[35]; // �����
	char spec[35]; // ���������.
	home h;
};
struct person
{
	char surname[35]; // �������
	char name[35]; // ���
	home h;
};


void Show(firm *st, int &n, person *st1, int &m , short z)
{
	system("cls");
	if (z == 1)
	{
		cout << "\n\n=========================================================================================================================" << endl;
		cout << "|\t\t      �����  |\t\t\tC������������  |\t\t     ����� |    ���  |       ���.�����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < n; i++)
			cout << "|" << setw(26) << (st + i)->name << "  |" << setw(31) << (st + i)->spec << "  |" << setw(26) << (st + i)->h.street << " | " << fixed << setprecision(1) << setw(7) << (st + i)->h.hh << " | " << fixed << setprecision(1) << setw(16) << (st + i)->h.number << " |" << endl;
		cout << "=========================================================================================================================" << endl;
	}
	else if (z == 2)
	{
		cout << "\n\n=========================================================================================================================" << endl;
		cout << "|\t\t    �������  |\t\t\t          ���  |\t\t     ����� |    ���  |       ���.�����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < m; i++)
			cout << "|" << setw(26) << (st1 + i)->surname << "  |" << setw(31) << (st1 + i)->name << "  |" << setw(26) << (st1 + i)->h.street << " | " << fixed << setprecision(1) << setw(7) << (st1 + i)->h.hh << " | " << fixed << setprecision(1) << setw(16) << (st1 + i)->h.number << " |" << endl;
		cout << "=========================================================================================================================" << endl;


	}
}
void ShowN(firm *st, int &fs,int *find, person *st1 , short z)
{
	if (z == 1)
	{
		cout << "=========================================================================================================================" << endl;
		cout << "|\t\t      �����  |\t\t\tC������������  |\t\t     ����� |    ���  |       ���.�����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < fs; i++)
			cout << "|" << setw(26) << st[find[i]].name << "  |" << setw(31) << st[find[i]].spec << "  |" << setw(26) << st[find[i]].h.street<< " | " << fixed << setprecision(1) << setw(7) << st[find[i]].h.hh << " | " << fixed << setprecision(1) << setw(16) << st[find[i]].h.number << " |" << endl;
		cout << "=========================================================================================================================" << endl;
	}
	else if (z == 2)
	{
		cout << "\n\n=========================================================================================================================" << endl;
		cout << "|\t\t    �������  |\t\t\t          ���  |\t\t     ����� |    ���  |       ���.�����  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < fs; i++)
			cout << "|" << setw(26) << st1[find[i]].surname << "  |" << setw(31) << st1[find[i]].name << "  |" << setw(26) << st1[find[i]].h.street << " | " << fixed << setprecision(1) << setw(7) << st1[find[i]].h.hh<< " | " << fixed << setprecision(1) << setw(16) << st1[find[i]].h.number<< " |" << endl;
		cout << "=========================================================================================================================" << endl;

	}
}
void ShowF(FILE *res,firm *st,person *st1, short z, int *find,int fs)
{
	if (z == 1)
	{
		fprintf(res, "=========================================================================================================================\n");
		fprintf(res, "|\t\t      �����  |\t\t\tC������������  |\t\t     ����� |    ���  |       ���.�����  |\n");
		fprintf(res, "=========================================================================================================================\n");
		for (int i = 0; i < fs; i++)
		fprintf(res, "| %26s |%31s  |%26s | %7s | %16s |\n", st[find[i]].name, st[find[i]].spec, st[find[i]].h.street, st[find[i]].h.hh, st[find[i]].h.number);
		fprintf(res, "=========================================================================================================================\n");
	}
	else
	{
		fprintf(res, "=========================================================================================================================\n");
		fprintf(res, "|\t\t    �������  |\t\t\t          ���  |\t\t     ����� |    ���  |       ���.�����  |\n");
		fprintf(res, "=========================================================================================================================\n");
		for (int i = 0; i < fs; i++)
			fprintf(res, "| %26s |%31s  |%26s | %7s | %16s |\n", st1[find[i]].surname, st1[find[i]].name, st1[find[i]].h.street, st1[find[i]].h.hh, st1[find[i]].h.number);
		fprintf(res, "=========================================================================================================================\n");
	}
}
void C(char *ar, int n)
{
	do {
		cin.getline(ar, 100);
		if (!(strlen(ar) > 0 && strlen(ar) <= n))
			cout << "\n ������. �� ������� ����� ��� ���������� ���� �� ������ �� �����.\n" << endl;
	} while (!(strlen(ar) > 0 && strlen(ar) <= n));
}
void C1(char *name)
{
	do {
		cout << "\n\n ������� ����� ��� ������ : ";
		cin.getline(name, 30);
		if (!strlen(name) > 0)
			cout << "\n ������. �� �� ����� �����." << endl;
	} while (!strlen(name) > 0);
	system("cls");
}
firm *Create(firm *st, int n)
{
	firm *add = new firm[n];
	for (int i = 0; i < n; i++)
		*(add + i) = *(st + i);
	delete[] st;
	st = nullptr;
	st = new firm[n + 1];
	for (int i = 0; i < n; i++)
		*(st + i) = *(add + i);
	cout << " ������� �������� ����� : ";
	cin.ignore();
	C((st + n)->name, 26);
	cout << " ������� ������������� : ";
	C((st + n)->spec, 31);
	cout << " ������� ����� : ";
	C((st + n)->h.street, 26);
	cout << " ������� ��� : ";
	C((st + n)->h.hh, 7);
	cout << " ������� ���.����� : ";
	C((st + n)->h.number, 16);
	return st;
}
person *Create1(person *st1, int m)
{
	person *add = new person[m];
	for (int i = 0; i < m; i++)
		*(add + i) = *(st1 + i);
	delete[] st1;
	st1 = nullptr;
	st1 = new person[m + 1];
	for (int i = 0; i < m; i++)
		*(st1 + i) = *(add + i);
	cin.ignore();
	cout << " ������� ������� : ";
	C((st1 + m)->surname, 26);
	cout << " ������� ��� : ";
	C((st1 + m)->name, 31);
	cout << " ������� ����� : ";
	C((st1 + m)->h.street, 26);
	cout << " ������� ��� : ";
	C((st1 + m)->h.hh, 7);
	cout << " ������� ���.����� : ";
	C((st1 + m)->h.number, 16);
	return st1;
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
void Find(firm *st, int n, int *find, int &fs, char name[35], person *st1, int &m, short z, short x)
{
	char n1[35], *n2, n3[35], n4[35];
	int l;
	(z == 1) ? l = n : l = m;
	for (int i = 0; i < l; i++)
	{
		if (x == '1')
		{
			if (z == 1)
				Down(st[i].name, n3);
			else
				Down(st1[i].surname, n3);
		}
		if (x == '2')
		{
			if (z == 1)
				Down(st[i].spec, n3);
			else
				Down(st1[i].name, n3);
		}
		if (x == '3')
		{
			if (z == 1)
				Down(st[i].h.street, n3);
			else
				Down(st1[i].h.street, n3);
		}
		if (x == '4')
		{
			if (z == 1)
				Down(st[i].h.hh, n3);
			else
				Down(st1[i].h.hh, n3);
		}
		if (x == '5')
		{
			if (z == 1)
				Down(st[i].h.number, n3);
			else
				Down(st1[i].h.number, n3);
		}
		Down(name, n4);
		strcpy(n1, n3);
		n2 = strtok(n1, " ,;-\"+");
		do
		{
			if (strnicmp(n2, n4, strlen(n4)) == 0)
			{
				find[fs++] = i;
				break;
			}
			n2 = strtok('\0', " ,;-\"+");
		} while (n2 != '\0');
	}
	FILE *res = fopen("results.txt", "a");
	fprintf(res, "\n����� �� ����� %s : \n", name);
	if (fs != 0)
	{
		ShowN(st, fs, find, st1, z);
		ShowF(res, st, st1, z, find, fs);
	}
	else
	{
		cout << " ������, ������ �� �������." << endl;
		fprintf(res, " ������, ������ �� �������.");
	}
	fclose(res);
	fs = 0;
}
void Check(short &z)
{
	system("cls");
	printf("\n\n �������� ���������� : \n");
	printf("\n 1. �����(�����������)\n");
	printf(" 2. ���������� ����\n");
	do {
		printf("\n ����� : ");
		cin >> z;
	} while (!(z == 1 || z == 2));
}
void Read(short z)
{
	if (z == 1)
	{
		FILE *tab = fopen("Firm.txt", "r");
		if (!tab)
			printf("\n ������ �������� �����.\n");

		char *t;
		char buff[128];
		do
		{
			t = fgets(buff, sizeof(buff), tab);
			if (t) cout << buff;
		} while (t);
		fclose(tab);
	}
	else
	{
		FILE *tab = fopen("Person.txt", "r");
		if (!tab)
			printf("\n ������ �������� �����.\n");

		char *t;
		char buff[128];
		do
		{
			t = fgets(buff, sizeof(buff), tab);
			if (t) cout << buff;
		} while (t);
		fclose(tab);
	}
}
void CreateFile(firm *st, int n, person *st1, int m, short z)
{
	if (z == 1)
	{
		FILE *tab = fopen("Firm.txt", "w");
		fprintf(tab, "=========================================================================================================================\n");
		fprintf(tab, "|\t\t      �����  |\t\t\tC������������  |\t\t     ����� |    ���  |       ���.�����  |\n");
		fprintf(tab, "=========================================================================================================================\n");
		for (int i = 0; i < n; i++)
			fprintf(tab, "| %26s |%31s  |%26s | %7s | %16s |\n", (st + i)->name, (st + i)->spec, (st + i)->h.street, (st + i)->h.hh, (st + i)->h.number);
		fprintf(tab, "=========================================================================================================================\n");
		fclose(tab);
	}
	else
	{
		FILE *tab = fopen("Person.txt", "w");
		fprintf(tab, "=========================================================================================================================\n");
		fprintf(tab, "|\t\t    �������  |\t\t\t          ���  |\t\t     ����� |    ���  |       ���.�����  |\n");
		fprintf(tab, "=========================================================================================================================\n");
		for (int i = 0; i < m; i++)
			fprintf(tab, "| %26s |%31s  |%26s | %7s | %16s |\n", (st1 + i)->surname, (st1 + i)->name, (st1 + i)->h.street, (st1 + i)->h.hh, (st1 + i)->h.number);
		fprintf(tab, "=========================================================================================================================\n");
		fclose(tab);
	}
}
firm firm1 = { "��� \"����� �������\"", "������������ �������� �������","����� ��������", "23", "+380934910004" };
firm firm2 = { "\"��������\"", "����������������� �������","����� ���������", "14", "+380617644261" };
firm firm3 = { "����� ���", "������������ �������","����� ���������", "49", "7077505" };
firm firm4 = { "Sun City", "��������������� ��������","����� ����������������", "2","+380633510706" };
firm firm5 = { "Brain", "��������� ���� ���������","�������� ��������", "192","+380612285425" };

person pers1 = { "�������", "����","����� 12 ������", "78", "+380674655556" };
person pers2 = { "�����", "���������","����� �������� �������", "14","+380503988877" };
person pers3 = { "�������", "�����","����� ���������", "1", "+380684045566" };
person pers4 = { "�������", "������","����� �������� �����", "8","+380612892973" };
person pers5 = { "��������", "������","����� �����������", "4","+380662402222" };

char x;

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	int n = 5;
	int m = 5;
	firm *st = new firm[n];
	person *st1 = new person[m];
	*(st + 0) = { firm1 };
	*(st + 1) = { firm2 };
	*(st + 2) = { firm3 };
	*(st + 3) = { firm4 };
	*(st + 4) = { firm5 };
	*(st1 + 0) = { pers1 };
	*(st1 + 1) = { pers2 };
	*(st1 + 2) = { pers3 };
	*(st1 + 3) = { pers4 };
	*(st1 + 4) = { pers5 };


	short z;
	int find[35], fs = 0;
	char name[35];
	int q;
	for (z = 1 ; z < 3; z ++)
	CreateFile(st, n, st1, m, z);
S:
	system("cls");
	cout << "\n \t���� : \n" << endl;
	cout << " 1. ����� �� �������� �����/�������." << endl;
	cout << " 2. ����� �� �������������/�����." << endl;
	cout << " 3. ����� �� �����." << endl;
	cout << " 4. ����� �� ������ ����." << endl;
	cout << " 5. ����� �� ������ ��������." << endl;
	cout << " 6. ������ ���� �������   //(�� �����)." << endl;
	cout << " 7. �������� ������." << endl;
	cout << "\n 8. �����." << endl;
	do {
		cout << "\n ����� : ";
		cin >> x;
	} while (!(x == '1' || x == '2' || x == '3' || x == '4' || x == '5' || x == '6' || x == '7' || x == '8'));
	cin.ignore();
	switch (x)
	{
	case '1':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n ����� �� ����� � ������/�������� : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z,x);
		break;
	}
	case '2':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n ����� �� ����� � ��������������/������ : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '3':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n ����� �� ����� � ������ : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '4':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n ����� �� ������ ���� : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '5':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n ����� �� ������ �������� : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '6':
	{
		Check(z);
		Read(z);
		break;
	}
	case '7':
	{
		system("cls");
		Check(z);
		if (z == 1)
		{
			st = Create(st, n);
			n++;
		}
		else
		{
			st1 = Create1(st1, m);
			m++;
		}
		CreateFile(st, n, st1, m, z);
		break;
	}
	case '8':
		exit(0);
	}
	cout << "\n ������� ����� ������� ��� �������� � ������� ����" << endl;
	_getch();
	goto S;
}