////#include<iostream>
////#include <ctime>
////#include <windows.h>
////#include <iomanip>
////using namespace std;
////
////inline void Error()
////{
////	cout << "Введено неверное значение. Попробуйте еще раз." << endl;
////}
////void CreateAr(int *p, int size)
////{
////	for (int i = 0; i < size; i++)
////	{
////		*(p + i) = rand() % 41 - 20;
////		cout << setw(4) << *(p + i) << " ";
////	}
////	cout << endl;
////}
////void ShowElemnts(int *p, int size)
////{
////	for (int i = size-1; i >= 0; i--)
////	{
////		cout <<setw(4)<< *(p + i) << " ";
////	}
////	cout << endl;
////}
////void main()
////{
////	setlocale(LC_ALL, "Russian");
////	srand(time(NULL));
////	char x;
////	const int N = 10;
////	int arr[N];
////	CreateAr(arr, N);
////	ShowElemnts(arr, N);
////}
#include<iostream>
#include <ctime>
#include <windows.h>
#include <iomanip>
using namespace std;

inline void Error()
{
	cout << "Введено неверное значение. Попробуйте еще раз." << endl;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	char x;
	short CASE;
	int x1, x2, q = 0, z = 0, t = 0, y = 1, q1 = 0, z1 = 0, tr = 1,tr1=0,o=0,now;
	int arr[11];

	cout << " Введите кол-во роботов, прилетевших на планету (не менее 3) : ";
	cin >> x1;
	cout << " Введите кол-во лет (до 10-ти) : ";
	cin >> x2;
	cout << "    Год:  С нач.года:  Группа-3:  Группа-5:    Новые:  Списанные:  Осталось:" << endl;
	now = x1;
	for (int i = 0; i < 2; i++)
	{
	cout << setw(8) << y;
	q = 0;
	if (now % 3 == !0)
	{
		q1 = x1 / 3;
		z1 = 0;
		if (y == 1)
		cout << setw(13) << 3 * q1 << setw(11) << q1 << setw(11) << z1;
		else 
			cout << setw(13) << now << setw(11) << q1 << setw(11) << z1;
		t++;
	}
	for (; q < 10; q++) // 3
	{
		z = 0;
		for (; z < 100; z++) // 5
		{
			if ((3 * q) + (5 * z) == now)
			{
				q1 = q;
				z1 = z;
				if (y == 1)
				cout << setw(13) << (3 * q) + (5 * z) << setw(11) << q << setw(11) << z;
				else
					cout << setw(13) << now << setw(11) << q << setw(11) << z;
				break;
			}
		}
	}
	arr[tr] = (5 * q1) + (9 * z1);
	cout << setw(10) << arr[tr];
	tr++;
	if (y % 3 == 0)
	{
		o = arr[tr1];
		cout << setw(12) << arr[tr1];
		tr1++;
	}
	else 
		cout << setw(12) << "0";

		cout << setw(11) << now + arr[tr - 1] - o << endl << endl << endl;
		now = now + arr[tr - 1] - o;

	y++;
	}


}