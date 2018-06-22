#include <iostream>
#include <Windows.h>
#include <string>
#include <time.h>
#include <iomanip>
#include <conio.h>
#include <io.h> 
#include <fcntl.h>
#include <stdio.h>
#include <locale.h>
#include <stddef.h>
#include <wchar.h>
#include <locale.h>
#include <stdarg.h>
using namespace std;

enum ConsoleColor {
	Black, Blue, Green, Cyan, Red, Magenta, Brown, LightGray, DarkGray,
	LightBlue, LightGreen, LightCyan, LightRed, LightMagenta, Yellow, White
};


void SetColor(int text, int background)
{
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}
void GotoXY(int X, int Y)
{
	HANDLE hConsole;
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD coord = { X, Y };
	SetConsoleCursorPosition(hStdOut, coord);
}

void Bomb(int **miner, int n, int bombs, int m)
{
	int b = bombs, x, y;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			*(*(miner + i) + j) = 0;
		}
	}
	do {
		x = rand() % n;
		y = rand() % m;
		if (*(*(miner + x) + y) != -1)
		{
			*(*(miner + x) + y) = -1;
			b--;
		}
	} while (b != 0);
}
void Around(int **miner, int &n, int m)
{
	int around;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (*(*(miner + i) + j) != -1)
			{
				around = 0;
				if (i == 0 && j == 0)
				{
					if (*(*(miner + i) + j + 1) == -1) around++;
					if (*(*(miner + i + 1) + j + 1) == -1) around++;
					if (*(*(miner + i + 1) + j) == -1) around++;
				}
				else if (i == n - 1 && j == 0)
				{
					if (*(*(miner + i - 1) + j) == -1) around++;
					if (*(*(miner + i - 1) + j + 1) == -1) around++;
					if (*(*(miner + i) + j + 1) == -1) around++;
				}
				else if (i == 0 && j == m - 1)
				{
					if (*(*(miner + i + 1) + j) == -1) around++;
					if (*(*(miner + i + 1) + j - 1) == -1) around++;
					if (*(*(miner + i) + j - 1) == -1) around++;
				}
				else if (i == n - 1 && j == m - 1)
				{
					if (*(*(miner + i - 1) + j) == -1) around++;
					if (*(*(miner + i - 1) + j - 1) == -1) around++;
					if (*(*(miner + i) + j - 1) == -1) around++;
				}
				else if (i == 0)
				{
					if (*(*(miner + i) + j - 1) == -1) around++;
					if (*(*(miner + i) + j + 1) == -1) around++;
					if (*(*(miner + i + 1) + j) == -1) around++;
					if (*(*(miner + i + 1) + j + 1) == -1) around++;
					if (*(*(miner + i + 1) + j - 1) == -1) around++;
				}
				else if (i == n - 1)
				{
					if (*(*(miner + i - 1) + j) == -1) around++;
					if (*(*(miner + i - 1) + j + 1) == -1) around++;
					if (*(*(miner + i - 1) + j - 1) == -1) around++;
					if (*(*(miner + i) + j + 1) == -1) around++;
					if (*(*(miner + i) + j - 1) == -1) around++;
				}
				else if (j == 0)
				{
					if (*(*(miner + i) + j + 1) == -1) around++;
					if (*(*(miner + i - 1) + j + 1) == -1) around++;
					if (*(*(miner + i + 1) + j + 1) == -1) around++;
					if (*(*(miner + i - 1) + j) == -1) around++;
					if (*(*(miner + i + 1) + j) == -1) around++;
				}
				else if (j == m - 1)
				{
					if (*(*(miner + i + 1) + j) == -1) around++;
					if (*(*(miner + i - 1) + j) == -1) around++;
					if (*(*(miner + i + 1) + j - 1) == -1) around++;
					if (*(*(miner + i - 1) + j - 1) == -1) around++;
					if (*(*(miner + i) + j - 1) == -1) around++;
				}
				else
				{
					if (*(*(miner + i + 1) + j) == -1) around++;
					if (*(*(miner + i - 1) + j) == -1) around++;
					if (*(*(miner + i) + j + 1) == -1) around++;
					if (*(*(miner + i) + j - 1) == -1) around++;
					if (*(*(miner + i + 1) + j + 1) == -1) around++;
					if (*(*(miner + i + 1) + j - 1) == -1) around++;
					if (*(*(miner + i - 1) + j + 1) == -1) around++;
					if (*(*(miner + i - 1) + j - 1) == -1) around++;
				}
				*(*(miner + i) + j) = around;
			}
		}
	}
}
void Check(int **miner, int **minerc, int x, int y, short &bomb, int bombs, int &f, int n, int m, int &step)
{
	if (f == 0)
	{
		if (*(*(miner + x) + y) == -1)
		{
			if (*(*(miner + x) + y) == -1)
			{
				if (*(*(miner + 0) + 0) == 0)
					*(*(miner + 0) + 0) = -1;
				else if (*(*(miner + n - 1) + 0) == 0)
					*(*(miner + n - 1) + 0) = -1;
				else if (*(*(miner + 0) + n - 1) == 0)
					*(*(miner + 0) + n - 1) = -1;
				else if (*(*(miner + n - 1) + n - 1) == 0)
					*(*(miner + n - 1) + n - 1) = -1;
				else
				{
					int x1;
					int x2;
					do {
						x1 = rand() % n;
						x2 = rand() % m;
						if (*(*(miner + x1) + x2) >= 0)
							*(*(miner + x1) + x2) = -1;
					} while (*(*(miner + x1) + x2) != -1);
				}
			}
			*(*(miner + x) + y) = 0;
		}
	}
	if (*(*(miner + x) + y) >= 0 && *(*(minerc + x) + y) != -2)
	{
		*(*(minerc + x) + y) = -2;
		step++;
	}
	else if (*(*(miner + x) + y) == -1)
	{
		*(*(minerc + x) + y) == -1;
		bomb = 1;
		step++;
	}
	f++;
}
void OpenNear(int **miner, int **minerc, int x, int y, int n, int m)
{
	if (*(*(miner + x) + y) == 0)
	{
		if (x == n - 1 && y == m - 1 || x == n - 1 && y > 0 && y < m - 1 || y == m - 1 && x > 0 && x < n - 1 || x > 0 && x < n - 1 && y > 0 && y < m - 1) 
		{
			if (*(*(minerc + x - 1) + y - 1) == 0)
			{
				*(*(minerc + x - 1) + y - 1) = -2;
				OpenNear(miner, minerc, x - 1, y - 1, n, m);
			}
		}
	
	if (x == 0 && y == 0 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || x == 0 && y == 0 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || x == 0 && y > 0 && y < m - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || y == 0 && x > 0 && x < n - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || x > 0 && x < n - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1)
	{
		if (*(*(minerc + x + 1) + y + 1) == 0)
		{
			*(*(minerc + x + 1) + y + 1) = -2;
			OpenNear(miner, minerc, x + 1, y + 1, n, m);
		}
	}
	if (x == n - 1 && y == 0 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || x == n - 1 && y > 0 && y < m - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || y == 0 && x > 0 && x < n - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || x > 0 && x < n - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1)
	{
		if (*(*(minerc + x - 1) + y + 1) == 0)
		{
			*(*(minerc + x - 1) + y + 1) = -2;
			OpenNear(miner, minerc, x - 1, y + 1, n, m);
		}
	}
	if (x == 0 && y == m - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || x == 0 && y > 0 && y < m - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || y == m - 1 && x > 0 && x < n - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1 || x > 0 && x < n - 1 || y == 0 && x > 0 && x < n - 1 && y > 0 && y < m - 1)
	{
		if (*(*(minerc + x + 1) + y - 1) == 0)
		{
			*(*(minerc + x + 1) + y - 1) = -2;
			OpenNear(miner, minerc, x + 1, y - 1, n, m);
		}
	}
	if (y == 0 && x == 0 || y == m - 1 && x == 0 || y == 0 && x < n - 1 || y == m - 1 && x < n - 1 || x == 0 || y > 0 && y < m - 1 && x > 0 && x < n - 1) {
		if (*(*(minerc + x + 1) + y) == 0)
		{
			*(*(minerc + x + 1) + y) = -2;
			OpenNear(miner, minerc, x + 1, y, n, m);
		}
	}
	if (y == m - 1 && x == n - 1 || y == 0 && x == n - 1 || y == 0 && x > 0 || y == m - 1 && x > 0 || x == n - 1 || y > 0 && y < m - 1 && x > 0 && x < n - 1) {
		if (*(*(minerc + x - 1) + y) == 0)
		{
			*(*(minerc + x - 1) + y) = -2;
			OpenNear(miner, minerc, x - 1, y, n, m);
		}
	}
	if (y == m - 1 && x == n - 1 || y == m - 1 && x == 0 || y == m - 1 || x == 0 && y > 0 || x == n - 1 && y > 0 || y > 0 && y < m - 1 && x > 0 && x < n - 1) {
		if (*(*(minerc + x) + y - 1) == 0)
		{
			*(*(minerc + x) + y - 1) = -2;
			OpenNear(miner, minerc, x, y - 1, n, m);
		}
	}
	if (y == 0 && x == 0 || y == 0 && x == n - 1 || y == 0 || x == 0 && y < m - 1 || x == n - 1 && y < m - 1 || y > 0 && y < m - 1 && x > 0 && x < n - 1) {
		if (*(*(minerc + x) + y + 1) == 0)
		{
			*(*(minerc + x) + y + 1) = -2;
			OpenNear(miner, minerc, x, y + 1, n, m);
		}
	}
}
}
void End(int **miner, int **minerc, int n)
{
	for (int i = 0; i < n; i++)
		delete[]minerc[i];
	delete[]minerc;

	for (int i = 0; i < n; i++)
		delete[]miner[i];
	delete[]miner;
}
int CheckBombs(int **minerc, int n, int m)
{
	int b = 0;
	for (int i = 0; i < n; i++)
		for (int j = 0; j < m; j++)
			if (*(*(minerc + i) + j) == -2)
				b++;
	return b;
}
void Show(int **miner, int **minerc, int n, int m, int x, int y, int step, short bomb)
{
	system("cls");
	const int z = 6;
	int k = 6;
	SetColor(0, 8);
	GotoXY(z, k);
	wprintf(L"\u250f\u2501\u2503\u2533");
	for (int i = 1; i < m * 2 + 1; i++)
	{
		wprintf(L"%c", 205);
	}
	wprintf(L"%c\n", 187);
	for (int i = 0; i < n; i++)
	{
		k++;
		GotoXY(z, k);
		SetColor(0, 8);
		wprintf(L"%c", 186);
		for (int j = 0; j < m; j++)
		{
			if (i == x && j == y) SetColor(12, 15);
			if (*(*(minerc + i) + j) == -3 && (bomb != 1 || *(*(miner + i) + j) != -1))
			{
				if (i == x && j == y) SetColor(12, 15);
				else
					SetColor(12, 8);
				wprintf(L"%2c", 213);
				SetColor(0, 8);
			}
			if (*(*(miner + i) + j) == -1 && bomb == 1)
			{
				if (i == x && j == y) SetColor(15, 12);
				else
					SetColor(12, 7);
				wprintf(L"%2c", 254);
				SetColor(0, 8);
			}
			if (*(*(miner + i) + j) == -1 && bomb == 2)
			{
				if (i == x && j == y) SetColor(15, 12);
				else
					SetColor(12, 8);
				wprintf(L"%2c", 213);
				SetColor(0, 8);
			}

			if (*(*(minerc + i) + j) == -2)
			{
				SetColor(0, 7);
				if (i == x && j == y) SetColor(12, 15);
				if (*(*(miner + i) + j) == 0)
					wprintf(L"  ");
				else
				{
					int c;
					if (i == x && j == y) SetColor(12, 15);
					else {
						if (*(*(miner + i) + j) == 1)
							c = 9;
						if (*(*(miner + i) + j) == 2)
							c = 10;
						if (*(*(miner + i) + j) == 3)
							c = 12;
						if (*(*(miner + i) + j) == 4)
							c = 1;
						if (*(*(miner + i) + j) == 5)
							c = 4;
						if (*(*(miner + i) + j) == 6)
							c = 13;
						if (*(*(miner + i) + j) == 7)
							c = 5;
						if (*(*(miner + i) + j) == 8)
							c = 14;
						SetColor(c, 7);
					}
					wprintf(L"%2d", *(*(miner + i) + j));
				}
			}
			else if (*(*(miner + i) + j) > -2 && *(*(minerc + i) + j) != -1 && *(*(minerc + i) + j) != -3 && (*(*(miner + i) + j) != -1 || bomb != 1) && (*(*(miner + i) + j) != -1 || bomb != 2))
				wprintf(L"  ");
			SetColor(0, 8);
			if (j == m - 1)
				wprintf(L"%c", 186);
		}
		wprintf(L"\n");
	}
	GotoXY(z, k + 1);
	wprintf(L"%c", 200);
	for (int i = 1; i < m * 2 + 1; i++)
	{
		wprintf(L"%c", 205);
	}
	wprintf(L"%c", 188);
	SetColor(15, 0);
	GotoXY(z, 2);
	wprintf(L"Name : none");
	GotoXY(z, 3);
	wprintf(L"Steps : %d", step);
}

void main()
{
	_setmode(_fileno(stdout), _O_U16TEXT);
	_setmode(_fileno(stdin), _O_U16TEXT);
	_setmode(_fileno(stderr), _O_U16TEXT);
	srand(time(NULL));
	short k = 1, en = 0;
	int n, m, bombs;
	do {
		if (en == 80) {
			k++;
			if (k == 6) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 5;
		}
		if (en == 13) {
			switch (k) {
			case 1:
			{
				short g = 1, en = 0;
				do {
					if (en == 80) {
						g++;
						if (g == 6) g = 1;
					}
					if (en == 72) {
						g--;
						if (g == 0) g = 5;
					}
					if (en == 13) {
						switch (g) {
						case 1:
						{
							n = 9;
							m = 9;
							bombs = 10;
							break;
						}
						case 2:
						{
							n = 16;
							m = 16;
							bombs = 40;
							break;
						}
						case 3:
						{
							n = 16;
							m = 30;
							bombs = 3;
							break;
						}
						case 4:
						{
							wcin >> n >> m >> bombs;
							break;
						}
						}
					Start:

						/*wchar_t name[30];
						wprintf(L"Write your name :");
						wcin.getline(name, 30);*/

						time_t seconds;

						seconds = time(NULL);
						int step = 0;
						short bomb = 0;
						int flag = 0, f = 0;
						int **miner = new int*[n];
						for (int i = 0; i < n; i++)
							*(miner + i) = new int[m];

						int **minerc = new int*[n];
						for (int i = 0; i < n; i++)
							*(minerc + i) = new int[m];

						for (int i = 0; i < n; i++)
							for (int j = 0; j < m; j++)
								minerc[i][j] = 0;
						short en = 0, x = 0, y = 0;
						Bomb(miner, n, bombs, m);
						do {
							if (en == 80) {
								x++;
								if (x == n) x = n - 1;
							}
							if (en == 72) {
								x--;
								if (x == -1) x = 0;
							}
							if (en == 75) {
								y--;
								if (y == -1) y = 0;
							}
							if (en == 77) {
								y++;
								if (y == m) y = m - 1;
							}
							if (en == 13) {
								Check(miner, minerc, x, y, bomb, bombs, f, n, m, step);
								if (f == 1)
									Around(miner, n, m);
								if (*(*(miner + x) + y) == 0)
									OpenNear(miner, minerc, x, y, n, m);

								if (((n*m) - CheckBombs(minerc, n, m)) == bombs || bomb == 1)
								{
									if (((n*m) - CheckBombs(minerc, n, m)) == bombs)
									{
										bomb = 2;
										Show(miner, minerc, n, m, x, y, step, bomb);
										GotoXY(25, 2);
										wprintf(L"You won!");
										FILE *w = fopen("won.txt", "a");
										fwprintf(w, L"%5d      ", step);
										(seconds / 3600 > 9) ? fwprintf(w, L"%d:", seconds / 3600) : fwprintf(w, L"0%d:", seconds / 3600);
										(seconds % 3600 - seconds % 60 > 9) ? fwprintf(w, L"%d:", seconds % 3600 - seconds % 60) : fwprintf(w, L"0%d:", seconds % 3600 - seconds % 60);
										(seconds % 60 > 9) ? fwprintf(w, L"%d", seconds % 60) : fwprintf(w, L"0%d", seconds % 60);
										fwprintf(w, L"\n");
										fclose(w);
									}
									else if (bomb == 1)
									{
										Show(miner, minerc, n, m, x, y, step, bomb);
										GotoXY(25, 2);
										wprintf(L"You lost!");
									}
									seconds = time(NULL) - seconds;
									GotoXY(25, 3);
									(seconds / 3600 > 9) ? wprintf(L"%d:", seconds / 3600) : wprintf(L"0%d:", seconds / 3600);
									(seconds % 3600 - seconds % 60 > 9) ? wprintf(L"%d:", seconds % 3600 - seconds % 60) : wprintf(L"0%d:", seconds % 3600 - seconds % 60);
									(seconds % 60 > 9) ? wprintf(L"%d", seconds % 60) : wprintf(L"0%d", seconds % 60);
									Sleep(1500);
									End(miner, minerc, n);
									_getch();
									goto Start;

								}
							}
							if (en == 32)
							{
								if (*(*(minerc + x) + y) == -3)
								{
									*(*(minerc + x) + y) = 0;
									flag--;
								}
								else if (*(*(minerc + x) + y) != -2 && *(*(minerc + x) + y) != -1 && flag != bombs)
								{
									*(*(minerc + x) + y) = -3;
									flag++;
								}
							}
							if (en == 27)
							{
								system("cls");
								goto Start;
							}
							Show(miner, minerc, n, m, x, y, step, bomb);
						} while (en = getch());
					}

					system("cls");
					if (g == 1) SetColor(10, 0);
					GotoXY(27, 3);
					wprintf(L"1. Normal\n");
					SetColor(15, 0);
					if (g == 2) SetColor(10, 0);
					GotoXY(27, 4);
					wprintf(L"2. Hard\n");
					SetColor(15, 0);
					if (g == 3) SetColor(10, 0);
					GotoXY(27, 5);
					wprintf(L"3. Proffesional\n");
					SetColor(15, 0);
					if (g == 4) SetColor(10, 0);
					GotoXY(27, 6);
					wprintf(L"4. Other\n");
					SetColor(15, 0);
				} while (en = getch());
			}

			}

		}

		system("cls");
		if (k == 1) SetColor(10, 0);
		GotoXY(27, 3);
		wprintf(L"1. Start a game\n");
		SetColor(15, 0);
		if (k == 2) SetColor(10, 0);
		GotoXY(27, 4);
		wprintf(L"2. Change nickname\n");
		SetColor(15, 0);
		if (k == 3) SetColor(10, 0);
		GotoXY(27, 5);
		wprintf(L"3. Help\n");
		SetColor(15, 0);
		if (k == 4) SetColor(10, 0);
		GotoXY(27, 6);
		wprintf(L"4. Top Players\n");
		SetColor(15, 0);
		if (k == 5) SetColor(10, 0);
		GotoXY(27, 7);
		wprintf(L"5. Exit\n");
		SetColor(15, 0);
	} while (en = getch());
}