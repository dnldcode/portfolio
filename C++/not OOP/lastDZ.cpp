////#include<iostream>
////#include <ctime>
////#include <windows.h>
////#include <iomanip>
////using namespace std;
////
////inline void Error()
////{
////	cout << "������� �������� ��������. ���������� ��� ���." << endl;
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
	cout << "������� �������� ��������. ���������� ��� ���." << endl;
}
void CreateAr(int *pa, int *size)
{
	for (int i = 0; i < *size; i++)
	{
		*(pa+i) = (rand() % 41-20);
	}
}
void PrintArray(int *pa, int *size)
{
	for (int i = 0; i < *size; i++)
	{
		cout <<setw(4)<< *(pa+i);
	}
	cout << endl;
}
void Swap(int *pa, int *size)
{
	for (int i = 2; i < *size; i += 2)
	{
		if (i % 2 == 0)
		{
			int t = *(pa + i - 1);
			*(pa + i - 1) = *(pa + i);
			*(pa + i) = t;
		}
	}
}
void Sort(int *pa, int *n)
{
	int temp;
	for (int i = 0; i < *n - 1; i++)
	{
		for (int j = i + 1; j < *n; j++)
		{
			if (*(pa+i) > *(pa+j))
			{
				temp = *(pa + i);
				*(pa + i) = *(pa + j);
				*(pa + j) = temp;
			}
		}
	}
}
void CreateArEx2(int *pA,int *x1,int *pB,int *x2,int *arr)
{
	int z = *x2;
	for (int i = 0; i < *x1; i++)
	{
		arr[i] = *(pA + i);
	}
	for (int i = 0; i < *x2; i++)
	{
		arr[z] = *(pB + i);
		z++;
	}
}
void Check(int *pA, int *x1, int *pB, int *x2, int *arr,int &qq)
{
	for (int i = 0; i < *x1; i++)
	{
		for (int j = 0; j < *x2; j++)
		{
			if (*(pA + i) == *(pB + j))
			{
				arr[qq] = *(pA + i);
				qq++;
					}
		}
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	char x;
	short CASE;
	int N;
	int ar[200];
	int n, m, q;
	int A[100];
	int B[100];
	int C[1000];
M:
	system("cls");
	cout << "������� ����� ������, ������� ������ �����������." << endl;
	cout << " 1 - �������� ������� �������� � ������� ���������" << endl;
	cout << " 2 - �������� ������� � � ��� ������������" << endl;
	cout << " 3 - ������� � �������� � ����������" << endl;
M0:
	cin >> x;
	switch (x)
	{
	case '1':
	{	CASE = 1;
M01:
	cout << "������� ������ �������" << endl;
X0:
	cin >> N;
	if (N > 0)
	{
	cout << "\n�������� ���������� ������ : " << endl;
	CreateAr(ar, &N);
	PrintArray(ar, &N);
	cout << "\n��������������� ������ : " << endl;
	Swap(ar, &N);
	PrintArray(ar, &N);
	}
	else
	{
		Error();
		goto X0;
	}

	break;
	}
	case '2':
	{	CASE = 2;
M02:
	X1:
	cout << "������� ������ ������� A" << endl;
	cin >> n;
	cout << "������� ������ ������� B" << endl;
	cin >> m;
	if (n > 0 && m > 0)
	{
		CreateAr(A, &n);
		CreateAr(B, &m);
		Sort(A, &n);
		Sort(B, &n);
		cout << "������ � �� ����������� : " << endl;
		PrintArray(A, &n);
		cout << endl << "������ B �� ����������� : " << endl;
		PrintArray(B, &m);
		cout << "\n\n����� ������ : " << endl;
		CreateArEx2(A,&n,B, &m,C);
		q = n+m;
		PrintArray(C, &q);
		cout << "\n\n������ � �� ����������� : " << endl;
		Sort(C, &q);
		PrintArray(C, &q);
	}
	else
	{
		Error();
		cout << endl;
		goto X1;
	}
	break;
	}
	case '3':
	{	CASE = 3;
M03:
X2:
	int t = 0;
	cout << "������� ������ ������� A" << endl;
	cin >> n;
	cout << "������� ������ ������� B" << endl;
	cin >> m;
	if (n > 0 && m > 0)
	{
		CreateAr(A, &n);
		CreateAr(B, &m);
		cout << "������ � : " << endl;
		PrintArray(A, &n);
		cout << endl << "������ B : " << endl;
		PrintArray(B, &m);
		cout << endl << endl;
		cout << "�������� ����� �������� � ������� � : " << endl;
		CreateArEx2(A, &n, B, &m, C);
		q = n + m;
		PrintArray(C, &q);
		cout << "����� �������� ���� �������� : " << endl;
		Check(A, &n, B, &m, C,t);
		PrintArray(C, &t);
	}
	else
	{
		Error();
		goto X2;
	}
	break;
	}
	default:
	{	Error();
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