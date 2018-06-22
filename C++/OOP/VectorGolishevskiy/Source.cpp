#include "Header.h"

void main()
{
	setlocale(LC_ALL, "Russian");
	int ar1[5] = { 1,2,3,4,5 };
	int ar2[3] = { 1,3,4 };
	Vector a(ar1, 5);
	Vector b(ar2, 3);
	cout << "\n Массив 1 : " << endl;
	cout << a << endl;
	cout << "\n Массив 2 : " << endl;
	cout << b << endl;
	cout << "\n Массив 1 + массив 2 : " << endl;
	cout << a + b << endl;
	cout << "\n Массив 1 - массив 2 : " << endl;
	cout << a - b << endl;
	cout << "\n Массив 1 + 5 : " << endl;
	cout << a + 5 << endl;
	cout << "\n Массив 1 - 5 : " << endl;
	cout << a - 5 << endl;
}