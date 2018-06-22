#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h> 
#include <string>
#include <vector>
#include <functional>
#include <algorithm>
#include <numeric>
#include "header.h"

using namespace std;

template<class T>
void SelectSort(vector<T>& v)
{
	SortStrategy<T>* strategy;
	if (v.size() % 2 == 0)
		strategy = new InsertSort<T>;
	else
		strategy = new QuickSort<T>;
	strategy->Sort(v);
}

void Show(int& c)
{
	cout << c << endl;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	vector<int>v;
	for (int i = 0; i < 9; i++)
	{
		v.push_back(rand() % 100);
	}
	SelectSort(v);
	for_each(v.begin(), v.end(), Show);
}