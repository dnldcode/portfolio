#include "Header.h"

Mage* Mage::psm = NULL;
Shaman* Shaman::pss = NULL;

template<typename T>
vector<T*> GenerateUnits(T* u, int num)
{
	vector<T*> units;
	for (int i = 0;i < num;i++)
	{
		T* tmp = u->clone();
		tmp->randomize();
		units.push_back(tmp);
	}
	return units;
}
void ShowBers(Berserk *b)
{
	cout << *b;
}
int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));

	OrkFactory* ofactory = new OrkFactory;
	Client* co = new Client(ofactory);
	HumanFactory* hfactory = new HumanFactory;
	Client* ch = new Client(hfactory);
	Palladin *p = (Palladin*)co->getUnitB();
	vector<Palladin*> pals = GenerateUnits(p, 100);
	delete p;
	Berserk *b = (Berserk*)ch->getUnitB();
	vector<Berserk*> bers = GenerateUnits(b, 100);
	delete b;
	Peasant *ps = (Peasant*)co->getUnitC();
	vector<Peasant*> peas = GenerateUnits(ps, 50);
	delete ps;
	Slave *sv = (Slave*)ch->getUnitC();
	vector<Slave*> slav = GenerateUnits(sv, 50);
	delete sv;
	Mage *mage = (Mage*)ch->getUnitA();
	Shaman *sham = (Shaman*)co->getUnitA();
	delete ofactory;
	delete co;
	delete ch;
	delete hfactory;

	int step = 0;
	int move = 0;
	int strike_h = 0;
	int strike_o = 0;
	for_each(bers.begin(), bers.end(), ShowBers);
	while (step < 100)
	{
		move = rand() % 2;
		if (move == 0)
		{
			move = rand() % 2;
			if (move == 0)
			{
				vector<Palladin*>::iterator it = pals.begin();
				for (it;it != pals.end();it++)
				{
					strike_h += (*it)->attack;
				}
			}
			else
			{
				strike_h += mage->attack;
			}
			strike_h /= 3;
			move = 1;
			switch (move)
			{
				case 0:
				{
					//vector<
					break;
				}
				case 1:
				{
					vector<Berserk*>::iterator itb = bers.begin();
					while (strike_h > 0)
					{
						if (itb == bers.end())
							break;
						int def_b = (*itb)->defend;
						int hlt_b = (*itb)->health;
						strike_h -= hlt_b;
						hlt_b = (hlt_b - hlt_b * def_b / 100);
						if (hlt_b < 0)
						{
							hlt_b = 0;
							(*itb)->attack = 0;//нужно обнулять аттаку, не работает
						}
						(*itb)->defend = 0;
						(*itb)->health = hlt_b;
						if (itb != bers.end())
						itb++;
					}
					break;
				}
				case 2:
					break;
			}
		}
		else
		{
			move = rand() % 2;
		}
		step++;
	}
	cout << "--------------" << endl;
	for_each(bers.begin(), bers.end(), ShowBers);
	cout << strike_h << endl;
	return 0;
}