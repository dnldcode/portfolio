#include<iostream>
#include <ctime>
#include <cmath>
#include <windows.h>
#include <iomanip>
using namespace std;

inline void Error()
{
	cout << "������� �������� ��������. ���������� ��� ���." << endl;
}
void Create2Arr(int ar[30][30])
{
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			ar[i][j] = rand() % 31;
		}
	}
}
void Print2Arr(int ar[30][30],int a[5])
{
	int x = 0;
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			cout <<setw(8)<< ar[i][j];
		}
		cout << "\t����� = " << a[x]<< endl;
		x++;
	}
}
void Sum2Arr(int ar[30][30], int a[5])
{
	int x = 0;
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			a[x] += ar[i][j];
		}
		x++;
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	char x;
	short CASE;
	int arr[30][30];
	int x1[5];
M:
	system("cls");
	cout << "������� ����� ������, ������� ������ �����������." << endl;
	cout << " 1 - ������������ ����� ��������� ���������� �������" << endl;
	cout << " 2 - " << endl;
	cout << " 3 - " << endl;
	cout << " 4 - " << endl;
	cout << "\n 5 - �����" << endl;
M0:
	cin >> x;
	switch (x)
	{
	case '1':
	{	CASE = 1;
M01:
	Create2Arr(arr);
	Sum2Arr(arr, x1);
	Print2Arr(arr,x1);
	break;
	}
	case '2':
	{	CASE = 2;
M02:
	
	break;
	}
	case '3':
	{	CASE = 3;
M03:

	break;
	}
	case '4':
	{	CASE = 4;
M04:
	
	break;
	}
	case '5':
		exit(0);

	default:
	{Error();
	goto M0;
	break; }
	}
	cout << "\n��� ������ �������?(1 - ������� � ����, 2 - ��������� ������ ��� ���, 3 - �����)" << endl;
M1:
	cin >> x;
	switch (x)
	{
	case '1':
		goto M;
	case '2':
		if (CASE == 1)
			goto M01;
		else if (CASE == 2)
			goto M02;
		else if (CASE == 3)
			goto M03;
		else 
			goto M04;
		break;
	case '3':
		cout << "�������..." << endl;
		break;
	default:
		Error();
		goto M1;
		break;
	}
}