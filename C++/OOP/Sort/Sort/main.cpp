#include "Fishes.h"

using namespace std;

class sortFunctor
{
public:
	bool operator()(Fish& f1, Fish& f2)
	{
		return f1.getWeight() > f2.getWeight();
	}
};

char Names[7][15] = { "Карась", "Щука", "Окунь", "Карп", "Тарань", "Красноперка", "Верховодка" };

void show(Fish f)
{
	cout << f;
}

bool sortFish(Fish& f1, Fish& f2)
{
	if (f1.getPrice() < f2.getPrice())
		return false;
	else
		return true;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));

	vector<Fish> v;
	for (int i = 0; i < 10; i++)
		v.push_back(*(new Fish(Names[rand() % 7], (double)(rand() % 5 + 1), (double)(rand() % 100 + 1))));
	for_each(v.begin(), v.end(), show);
	cout << "\n Сортировка по весу : " << endl;
	sortFunctor q;
	sort(v.begin(), v.end(), q);
	for_each(v.begin(), v.end(), show);
	cout << "\n Сортировка по цене :" << endl;
	sort(v.begin(), v.end(), sortFish);
	for_each(v.begin(), v.end(), show);

	return 0;
}