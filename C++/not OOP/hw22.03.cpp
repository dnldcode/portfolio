// 24:30 nice
#include <iostream>
#include <Windows.h>
#include <string>
#include <time.h>
#include <iomanip>
#include <conio.h>
using namespace std;
struct timer
{
	unsigned hh : 5;
	unsigned mm : 6;
	unsigned ss : 6;
};
inline void Error()
{
	cout << "Error. Try again." << endl;
}
void reset(timer &t)
{
	t.hh = 0;
	t.mm = 0;
	t.ss = 0;
}
void set_time(timer &t, int h, int m, int s)
{
	t.hh = h;
	t.mm = m;
	t.ss = s;
}
void Show(timer &t)
{
	(t.hh > 9) ? cout << t.hh << ":" : cout << "0" << t.hh << ":";
	(t.mm > 9) ? cout << t.mm << ":" : cout << "0" << t.mm << ":";
	(t.ss > 9) ? cout << t.ss : cout << "0" << t.ss;
}
void Show(int h, int m, int s, int h1, int m1, int s1)
{
	cout << "\n ������ ������ ����������� : ";
	(h > 9) ? cout << h << ":" : cout << "0" << h << ":";
	(m > 9) ? cout << m << ":" : cout << "0" << m << ":";
	(s > 9) ? cout << s : cout << "0" << s;
	cout << "\n ����� ������ ����������� : ";
	(h1 > 9) ? cout << h1 << ":" : cout << "0" << h1 << ":";
	(m1 > 9) ? cout << m1 << ":" : cout << "0" << m1 << ":";
	(s1 > 9) ? cout << s1 : cout << "0" << s1;
	cout << endl;
}
void time(timer &t, int &q, int h, int m, int s)
{
	t.ss++;
		if (t.ss == 60)
		{
			t.ss = 0;
			t.mm++;
			if (t.mm == 60)
			{
				t.mm = 0;
				t.hh++;
				if (t.hh == 24)
					reset(t);
			}
		}
		if (t.ss == s && t.mm == m && t.hh == 0)
			q = 1;
}
void TimerDown(timer &t, int &q, int h, int m, int s)
{
		if (t.ss == 0 && t.mm > 0)
		{
			t.ss = 60;
			t.mm--;
			if (t.mm == 0 && t.hh > 0)
			{
				t.mm = 60;
				t.hh--;
				if (t.hh == 0)
					reset(t);
			}
		}
		t.ss--;
	if (t.ss == s && t.mm == m && t.hh == h)
		q = 1;
}
char x;
int q;
void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	timer t;
	int h, m, s, h1, m1, s1,p;
M:
	system("cls");
	cout << "\n \t����:" << endl;
	cout << " 1. ����������" << endl;
	cout << " 2. ������" << endl;
	cout << "\n 3. �����" << endl;
	do
	{
		cout << "\n �����(1-3) : ";
		cin >> x;
	} while (!(x == '1' || x == '2' || x == '3'));
	switch (x)
	{
	case '1':
	{
		Q1:
		q = 0;
		p = 1;
		system("cls");
		C:
		cout << " ������� ����� ������ ������ �����������" << endl;
		do
		{
			cout << "\n ������� ���(0 - 24) : ";
			cin >> h;
		} while (!(h > -1 && h < 25));
		do
		{
			cout << "\n ������� ������(0 - 60) : ";
			cin >> m;
		} while (!(m > -1 && m < 61));
		do
		{
			cout << "\n ������� �������(0 - 60) : ";
			cin >> s;
		} while (!(s > -1 && s < 61));
		cout << "\n ������� ����� ����� ������ �����������" << endl;
		do
		{
			cout << "\n ������� ���(0 - 24) : ";
			cin >> h1;
		} while (!(h1 > -1 && h1 < 25));
		do
		{
			cout << "\n ������� ������(0 - 60) : ";
			cin >> m1;
		} while (!(m1 > -1 && m1 < 61));
		do
		{
			cout << "\n ������� �������(0 - 60) : ";
			cin >> s1;
		} while (!(s1 > -1 && s1 < 61));
		if ((h >= h1) && (m >= m1) && (s >= s1))
		{
			system("cls");
			cout << "\n ������ ����� ������ ���� ����� �������, ���������� �������. \n\n" << endl;
			goto C;
		}

		set_time(t, h, m, s);
		do
		{
			system("cls");
			time(t, q, h1, m1, s1);
			Show(t);
			Sleep(700);
			if (kbhit())
				break;
		} while (q == 0);
		Show(h, m, s, h1, m1, s1);
		break;
	}
	case '2':
	{
		Q2:
		q = 0;
		p = 2;
		system("cls");
	Z:
		cout << " ������� ����� ������ ������ �������" << endl;
		do
		{
			cout << "\n ������� ���(0 - 24) : ";
			cin >> h;
		} while (!(h > -1 && h < 25));
		do
		{
			cout << "\n ������� ������(0 - 60) : ";
			cin >> m;
		} while (!(m > -1 && m < 61));
		do
		{
			cout << "\n ������� �������(0 - 60) : ";
			cin >> s;
		} while (!(s > -1 && s < 61));
		cout << "\n ������� ����� ����� ������ �������" << endl;
		do
		{
			cout << "\n ������� ���(0 - 24) : ";
			cin >> h1;
		} while (!(h1 > -1 && h1 < 25));
		do
		{
			cout << "\n ������� ������(0 - 60) : ";
			cin >> m1;
		} while (!(m1 > -1 && m1 < 61));
		do
		{
			cout << "\n ������� �������(0 - 60) : ";
			cin >> s1;
		} while (!(s1 > -1 && s1 < 61));
		if ((h <= h1) && (m <= m1) && (s <= s1))
		{
			system("cls");
			cout << "\n ������ ����� ������ ���� ����� �������, ���������� �������. \n\n" << endl;
			goto Z;
		}

		set_time(t, h, m, s);
		do
		{
			system("cls");
			TimerDown(t, q, h1, m1, s1);
			Show(t);
			Sleep(700);
			if (kbhit())
				break;
		} while (q == 0);
		Show(h, m, s, h1, m1, s1);
		break;
	}
	case '3':
		exit(0);
	/*default:
		cout << "Error. Try again." << endl;
		goto S;*/
	}
	cout << "\n\n ��� ������ �������?(1 - � ����, 2 - ��� ���, ����� ������ - �����)" << endl;
	cin >> x;
	switch (x)
	{
	case '1':
		goto M;
	case '2': 
		if (p == 1)
			goto Q1;
		if (p == 2)
			goto Q2;
		break;
	default:
		exit(0);
	}
}