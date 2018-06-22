#include <iostream>
#include <ctime>
#include <windows.h>
#include <iomanip>
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
void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	const int row = 50;
	const int col = 50;
	const int m = 3;
	const int size = 3;
	int ar[row][col];
	int n, m, l,sum,year = 2012;
	//cin >> n >> m >> l;
	for (int k = 0; k < 3; k++)
	{
		cout << "\t\tГод "<<year << endl;
		year++;
		sum = 0;
		int ar1[size] = { 0,0,0 };
		cout << "\n\t\t   Янв     Февр    Март" << endl;
		for (int i = 0; i < 4; i++)
		{
			cout << "\tЦех : " << i + 1 << " ";
			for (int j = 0; j < 3; j++)
			{
				ar[i][j] = rand() % 51 + 50;
				cout << setw(5) << ar[i][j] << "\t";
				ar1[j] += ar[i][j];
				sum += ar[i][j];
			}
			cout << endl;
		}
		cout << "Всего за месяц : ";
		for (int i = 0; i < 3; i++)
		{
			cout << "  " << ar1[i] << "   ";
		}

		cout << "\n\nИтого :            " << sum << endl;
		cout << endl;
	}

	}