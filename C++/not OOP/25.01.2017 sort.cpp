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


void GotoXY(int X, int Y)
{
	HANDLE hConsole;
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD coord = { X, Y };
	SetConsoleCursorPosition(hStdOut, coord);
}

inline void error()
{
	cout << "������! �������� ��������, ���������� ������ ��� ���!" << endl;
}

//template<typename T>
void printArray(int arr[], int count)
{
	
	for (int i = 0; i < count; i++)
	{
		if (i % 10 == 0)
			cout << endl;
		cout << setw(4) << arr[i] << "  ";
	}

	cout << endl;
}
template<typename T>
void printArray(T arr[30][30], int count1,int count2)
{
	for (int i = 0; i < count1; i++)
	{ 
		for (int j = 0;j<count2;j++)
		cout <<setw(4)<< arr[i][j] << "  ";

		cout << endl;
		}
}
//template<typename T>
void CreateAr(int arr[], int count)
{ 
	for (int i = 0; i < count; i++)
	{
		arr[i] = rand () %101 - 50;
	}
}
//template<typename T>
void CreateAr(int arr[30][30], int count1, int count2)
{
	for (int i = 0; i < count1; i++)
	{
		for (int j = 0; j < count2; j++)
			arr[i][j] = rand() % 101 - 50;


		//arr[i][j] = (T)(rand() % 25 + 65) + rand() % 100 / 100.0;
		cout << endl;
	}
}
//template<typename T>
//void Check(T arr[], int count)
//{
//	T max;
//	max = arr[0];
//	for (int i = 0; i < count; i++)
//	{
//		if (arr[i] > max)
//			max = arr[i];
//	}
//	cout << "������������ ������� ����������� ������� : " << (T)max << endl;
//}
//
//template<typename T>
//void Check(T arr[][30], int count1,int count2)
//{
//	T max;
//	max = arr[0][0];
//	for (int i = 0; i < count1; i++)
//	{
//		for (int j = 0; j < count2; j++)
//		{
//			if (arr[i][j] > max)
//				max = arr[i][j];
//		}
//	}
//	cout << "������������ ������� ���������� ������� : " << (T)max << endl;
//}
void selectSort(int arr[100], int size) 
{
	long i, j, k;
	int x;
	for (i = 0; i<size; i++) 
	{
		k = i;
		x = arr[i];
		for (j = i + 1; j<size; j++)
			if (arr[j]<x) {
				k = j;
				x = arr[j];
			}
		x = arr[j];
			
		arr[k] = arr[i];
		arr[i] = x;
	}
}
void selectSort11(int a[][30], int size)
{

	for (int k = 0; k < size; k++)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = size; j > i; j--)
				if (a[k][j] < a[k][j - 1])
				{
					int tmp = a[k][j];
					a[k][j] = a[k][j - 1];
					a[k][j - 1] = tmp;
				}
		}
	}
}
void selectSort1(int a[][30], int size)
{

	for (int k = 0; k < size; k++)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = size; j > i; j--)
				if (a[k][j] > a[k][j - 1])
				{
					int tmp = a[k][j];
					a[k][j] = a[k][j - 1];
					a[k][j - 1] = tmp;
				}
		}
	}
}

int BinSearch(int M[100], int n, int k)
{
	int L = 0;
	int R = n;

	int m;
	while (L<R)
	{
		m = (L + R) / 2;
		if (k > M[m]) L = m;
		if (k < M[m]) R = m;
		if (k == M[m])	return 1;

	}

	return 0;
}
void Sort_ex2(int arr[30][30], int size1, int size2)
{
	for (int l = 0; l < size1; l++)
	{
		if (l % 2)
		{
			selectSort11(arr, l);
		}
		else
		{
			selectSort1(arr,l);
		}

	}

}

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	char x;
	int m, n, key;
	//int sizea,m;

	int iArray[100];
	int iArray1[30][30];

	//double dArray[100];
	//double dArray1[30][30];

	//char cArray[100];
	//char cArray1[30][30];

	cout << "����� ������ ������ ����������?" << endl;
	cout << "1 - �������� �����" << endl;
	cout << "2 - ����������" << endl;
	S1:
	cin >> x;
	switch (x)
	{
	case '1':
	{
		cout << "������� ������ ������� : ";
		cin >> n;
		CreateAr(iArray, n);
		cout << "�������� ��������������� ������ : " << endl;
		printArray(iArray, n);
		cout << "������� �����, ������� ������ ����� � ������� : ";
		cin >> key;
		selectSort(iArray, n);
		printArray(iArray, n);
		cout << endl << endl;
		if ((BinSearch(iArray, n, key)) == 1)
			cout << "������ ����� ���� � �������" << endl;
		else if ((BinSearch(iArray, n, key)) == 0)
			cout << "������� ����� ���� � �������" << endl;

		break;
	}
	case '2':
	{
		cout << "������� ���-�� ����� : ";
		cin >> n;
		cout << "������� ���-�� �������� : ";
		cin >> m;
		CreateAr(iArray1, n, m);
		cout << "�������� ��������������� ������ : " << endl;
		printArray(iArray1, n, m);
		Sort_ex2(iArray1, n, m);
		cout << endl << endl;
		printArray(iArray1, n, m);
		break;
	}
	default:
		error();
		goto S1;
	}
}