#include "Header.h"
#include "Fishes1.h"

void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	FQueue q(5);
	q.add(Fish("fish 1", 5, 100));
	q.add(Fish("fish 2", 2, 120));
	q.add(Fish("fish 3", 3, 90));
	q.add(Fish("fish 4", 10, 150));
	q.add(Fish("fish 5", 13, 110));
	q.fishSort();
	while (q.getLast())
		cout << q.extract() << endl;
}