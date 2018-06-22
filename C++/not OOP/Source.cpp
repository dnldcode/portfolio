#include <iostream>
#include <ctime>
#include <windows.h>
using namespace std;
void main()
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);

	srand(time(NULL));
	//1
	short a,a1;
	int x;
	int p = 0, you = 0;
	cout << "\t\tDice!" << endl;
	a1 = rand() % 2;
	cout << "The game is starting : ";
	if (a1 == 0)
		cout << "computer" << endl;
	if (a1 == 1)
		cout << "you " << endl;
	cout << "Are you ready?(1 - yes, 0 no)" << endl;
	S0:
	cin >> x;
	if (x == 1)
	{
		for (int i = 0; i < 2; i++)
		{
			a = rand() % 6 + 1;
			if (a == 1)
			{
				cout << char(201) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(187) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(200) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(188) << endl;
				p += 1;
			}
			if (a == 2)
			{
				cout << char(201) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(187) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "            " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "            " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "            " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "            " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "            " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "            " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(200) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(188) << endl;
				p += 2;
			}

			if (a == 3)
			{
				cout << char(201) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(187) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "            " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "            " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "            " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "            " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "            " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "            " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(200) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(188) << endl;
				p += 3;
			}

			if (a == 4)
			{
				cout << char(201) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(187) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(200) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(188) << endl;
		
				p += 4;
			}

			if (a == 5)
			{
				cout << char(201) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(187) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "       " << char(254) << char(254) << char(254) << char(254) << "       " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(200) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(188) << endl;
		
				p += 5;
			}

			if (a == 6)
			{
				cout << char(201) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(187) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "                  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(186) << "  " << char(254) << char(254) << char(254) << char(254) << "      " << char(254) << char(254) << char(254) << char(254) << "  " << char(186) << endl;
				cout << char(200) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(205) << char(188) << endl;
			
				p += 6;
			}
			
		}
		cout << "Total score : " << p << endl;
				}
	else if (x == 0)
		cout << "Bye!" << endl;
	else
	{
		cout << "Your answer isn't correct!" << endl;
		goto S0;
	}

}