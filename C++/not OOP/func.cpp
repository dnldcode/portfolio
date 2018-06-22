#include <iostream>
#include <ctime>
#include <windows.h>
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

//void mas(int ar[], int n1, int n2, int col)
//{
//	for (int i = 0; i < col; i++)
//	{
//		ar[i] = rand() % (n2 - n1 + 1) + n1;
//		
//	}
//
//}
//void masPrint(int ar[], int col)
//{
//	float  sum = 0;
//	for (int i = 0; i < col; i++)
//	{
//		cout << ar[i] << " ";
//		sum += ar[i];
//		
//	}
//	cout << endl <<endl<< "—умма элементов массива : " << sum << endl;
//}
//
//void avr(int ar[], int col, double avr = 0)
//{
//	for (int i = 0; i < col; i++)
//	{
//		avr += ar[i];
//
//	}
//	cout << endl << "—реднее арифм. : " << avr / col << endl;
//}

void mas(int ar[][100], int n1, int n2, int size1, int size2);
void masPrint(int ar[][100], int n1, int n2, int size1, int size2);
void masAR(int ar[][100], int n1, int n2, int size1, int size2);


void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	//const int size1 = 100;
	//int g[size1];
	//int l, x, y;
	//cout << "¬ведите от и до" << endl;
	//cin >> x >> y >> l;
	//cout << endl << endl;
	//mas(g, x, y, l);
	//cout << endl << endl;
	//masPrint (g,l);
	//avr(g, l);
	//cout << endl << g[4] << endl;
	//cout << endl;
	const int s1 = 100,s2 = 100;
	int g[s1][s2];
	int l, x, y,z;
	cin >> x >> y >> l >> z;
	mas(g,x,y,l,z);
	
	/*masPrint(g, x, y, l, z);*/
	masAR(g, x, y, l, z);
}
void mas(int ar[][100], int n1, int n2, int size1, int size2)
{
	for (int i = 0; i < size1; i++)
		for (int j = 0; j < size2; j++)
			ar[i][j] = rand() % (n2 - n1 + 1) + n1;

}



void masPrint(int ar[][100], int n1, int n2, int size1, int size2)
{
	for (int i = 0; i < size1; i++)
	{
		for (int j = 0; j < size2; j++)
			cout << ar[i][j] << " ";
		cout << endl;
	}
}
void masAR(int ar[][100], int n1, int n2, int size1, int size2)
{
	double arr;

	for (int i = 0; i < size1; i++)
	{
		arr = 0;
		for (int j = 0; j < size2; j++)
		{
			cout << ar[i][j] << " ";
			arr += ar[i][j];
		}
		cout << "\t" << arr / size2 << endl << endl;
	}
}