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
	cout << "Ошибка! Неверное значение, попробуйте ввести еще раз!" << endl;
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
	//cout << "Сумма двух чисел : " << c << endl;

	//2
	double a, b, c;
	char x;
	cout << "Введите 2 числа : ";
	cin >> a >> b;
	cout << "Выберите действие : " << endl;
	cout << "1 - Сложение" << endl;
	cout << "2 - Вычитание" << endl;
	cout << "3 - Умножение" << endl;
	cout << "4 - Деление" << endl;
	S0:
	cin >> x;
	switch (x)
	{
	case '1':
		cout << "Ответ : " << func1(&a, &b) << endl;
		break;
	case '2':
		cout << "Ответ : " << func2(&a, &b) << endl;
		break;
	case '3':
		cout << "Ответ : " << func3(&a, &b) << endl;
		break;
	case '4':
		cout << "Ответ : " << func4(&a, &b) << endl;
		break;
	default:
		error();
		goto S0;
	}


	/*cout << "Сумма " << func1(a, b) << endl;
	cout << "Вычитание " << func2(a, b) << endl;
	cout << "Умножение " << func3(a, b) << endl;
	cout << "Деление " << func4(a, b) << endl;*/

}