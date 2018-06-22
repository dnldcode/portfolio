#include <iostream>
#include <ctime>
#include <iomanip>
#include <windows.h>
#include <algorithm>
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

inline void error()
{
	SetColor(12, 0);
	cout << "������! �������� ��������, ���������� ������ ��� ���!" << endl;
	SetColor(8, 0);
}
double ex1(double *x1, double *x2)
{
	return *x1 + *x2;
}

double func1(double *x1, double *x2)
{
	return *x1 + *x2;
}
double func2(double *x1, double *x2)
{
	return *x1 -*x2;
}
double func3(double *x1, double *x2)
{
	return *x1 * *x2;
}
double func4(double *x1, double *x2)
{
	return *x1 / *x2;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	//1
	//double a, b, c;
	//cin >> a >> b;
	//c = ex1(&a, &b);
	//cout << "����� ���� ����� : " << c << endl;

	//2
	double a, b, c;
	char x;
	cout << "������� 2 ����� : ";
	cin >> a >> b;
	cout << "�������� �������� : " << endl;
	cout << "1 - ��������" << endl;
	cout << "2 - ���������" << endl;
	cout << "3 - ���������" << endl;
	cout << "4 - �������" << endl;
	S0:
	cin >> x;
	switch (x)
	{
	case '1':
		cout << "����� : " << func1(&a, &b) << endl;
		break;
	case '2':
		cout << "����� : " << func2(&a, &b) << endl;
		break;
	case '3':
		cout << "����� : " << func3(&a, &b) << endl;
		break;
	case '4':
		cout << "����� : " << func4(&a, &b) << endl;
		break;
	default:
		error();
		goto S0;
	}


	/*cout << "����� " << func1(a, b) << endl;
	cout << "��������� " << func2(a, b) << endl;
	cout << "��������� " << func3(a, b) << endl;
	cout << "������� " << func4(a, b) << endl;*/

}