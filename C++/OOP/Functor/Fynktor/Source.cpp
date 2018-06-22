#include "Fishes.h"

void show(Fish f)
{
	cout << f << endl;
}

char Names[10][15] = { "Щука", "Карась", "Елец", "Карп", "Лещ", "Лосось", "Окунь", "Форель", "Угорь", "Сом" };

class Functor1
{
public:
	double w;
	Functor1(double d = 0)
	{
		if (d < 0)
			this->w = 0;
		else
			this->w = d;
	}
	void operator()(Fish &f)
	{
		if(f.getWeight() > this->w)
		cout << f;
	}
};
void main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	vector<Fish> v;
	for (int i = 0;i < 10;i++)
	{
		v.push_back(*(new Fish(Names[rand() % 10],(double)(rand() % 5 + 1),(double)(rand() % 100 + 50))));
	}
	for_each(v.begin(), v.end(),show);
	Functor1 f1(4);
	for_each(v.begin(), v.end(), f1);
}