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

void Stepenb(double x1,int x2)
{
	double x0 = x1;
	if (x2 >= 0)
	{
		for (int i = 1; i < x2; i++)
			x0 *= x1;
			cout << x0 << endl;
	}
	else if (x2 < 0)
	{
		for (int i = 1; i < (x2*(-1)); i++)
			x0 *= x1;
		cout  << 1 / x0 << endl;
	}
}
void Diapason(double x1, int x2)
{
	int diap;
	if (x1 < x2)
	{
		diap = x1;
		for (; x1 < x2;)
		{
			x1++;
			diap += x1;	
		}
		cout << diap << endl;
	}
	else 
	{ 
		diap = x2;
		for (; x1 > x2;)
		{
			x1--;
			diap += x1;
		}
		cout << diap << endl;
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	//1

	//double a;
	//int b;
	//cout << "¬ведите число и степень, в которую хотите возвести число" << endl;
	//cin >> a >> b;
	//Stepenb(a, b);


	//2
	int M, N;
	cout << "¬ведите диапозон (2 числа)" << endl;
	cin >> M >> N;
	Diapason(M, N);

}