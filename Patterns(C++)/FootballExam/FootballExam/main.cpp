#include "AbsFact1.h"

void InsertNames()
{
	for (int i = 0;i < 10;i++)
		ClubNames.push_back(n1[i]);
	for (int i = 0;i < 30;i++)
		PlayerNames.push_back(n2[i]);
}

int main()
{
	setlocale(LC_ALL, "Russian");
 	srand(time(NULL));

	InsertNames();
	Club club1;
	Club club2;

	cout << club1 << endl;
	club1.ShowPlayers();
	cout << "-------------------" << endl;;
	cout << club2 << endl;
	club2.ShowPlayers();
	return 0;
}