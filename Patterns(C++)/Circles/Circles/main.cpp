#pragma once
#include "Circleh.h"
#include "Point.h"

#define pi 3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679821480865129317675238467481846766940513200056812714526356082

int n = 0;
list<Circle> l;
list<Circle>::iterator mi;
double area;

void Show(Circle c)
{
	cout << c;
}
void CheckInside(Circle &c)
{
	double ownrange = (c.getCentreX() + c.getRadius()) - c.getCentreX();
	double checkrange;
	mi = l.begin();
	do {
		checkrange = sqrt(pow(mi->getCentreX() - c.getCentreX(), 2) + pow(mi->getCentreY() - c.getCentreY(), 2));
		if (checkrange <= ownrange && checkrange != 0)
			c.addInside(1);
		mi++;
	} while (mi != l.end());
}
void SaveCircles()
{
	FILE *f = fopen("Circles.txt", "a");
	if (!f)
	{
		printf(" Ошибка открытия файла Circles.txt");
		exit(EXIT_FAILURE);
	}
	fprintf(f, "\n ----------- \n\n");
	mi = l.begin();
	do {
		fprintf(f, " N : %5d  |  X : %7.1f  |  Y : %7.1f  |  Radius : %5d  |  Inside : %5d \n", mi->getN(), mi->getCentreX(), mi->getCentreY(), mi->getRadius(), mi->getInside());
		mi++;
	} while (mi != l.end());
	fclose(f);
}
void MakeCircles()
{
	int r;
	do {
		r = rand() % 5;
		l.push_back(Circle(++n, (rand() % ((50 - r * 2) + r)) + (rand() % 10 / 10.0), (rand() % ((50 - r * 2) + r)) + (rand() % 10 / 10.0), r));
	} while (l.size() % 200 != 0);
	for_each(l.begin(), l.end(), CheckInside); // Проверяю на вложеные
	SaveCircles(); // записываю в отдельный файл
}
void showInfo(set<Circle> &s, set<Circle>::iterator &si, list<Circle> &InsideList)
{
	si = s.begin();
	printf("\n Окружность в которую вложено больше всего окружностей : \n");
	cout << *si;
	printf("\n Информация про вложеные окружности : \n");
	for_each(InsideList.begin(), InsideList.end(), Show);
	printf("\n Суммарная площадь всех вложеных окружностей : %.3f единиц.\n", area);
}
void getInfo(set<Circle> &s, set<Circle>::iterator &si, list<Circle> &InsideList)
{
	InsideList.clear();
	s.clear();
	s.insert(l.begin(), l.end());
	si = s.begin();
	double ownrange = (si->getCentreX() + si->getRadius()) - si->getCentreX(), checkrange = 0;
	mi = l.begin();
	area = 0;
	do
	{
		checkrange = sqrt(pow(mi->getCentreX() - si->getCentreX(), 2) + pow(mi->getCentreY() - si->getCentreY(), 2));
		if (checkrange <= ownrange && checkrange != 0)
		{
			InsideList.push_back(*mi);
			area += pi * pow((si->getCentreX() + si->getRadius()) - si->getCentreX(), 2);
		}
		mi++;
	} while (mi != l.end());
	showInfo(s, si, InsideList);

	FILE *f = fopen("Circles.txt", "a");
	if (!f)
	{
		printf(" Ошибка открытия файла Circles.txt");
		exit(EXIT_FAILURE);
	}
	fprintf(f, "\n Окружность в которую вложено больше всего окружностей : \n");
	fprintf(f, " N : %5d  |  X : %7.1f  |  Y : %7.1f  |  Radius : %5d  |  Inside : %5d \n", si->getN(), si->getCentreX(), si->getCentreY(), si->getRadius(), si->getInside());
	fprintf(f, "\n Информация про вложеные окружности : \n");
	list<Circle>::iterator ins = InsideList.begin();
	do {
		fprintf(f, " N : %5d  |  X : %7.1f  |  Y : %7.1f  |  Radius : %5d  |  Inside : %5d \n", ins->getN(), ins->getCentreX(), ins->getCentreY(), ins->getRadius(), ins->getInside());
		ins++;
	} while (ins != InsideList.end());
	fprintf(f, "\n Суммарная площадь всех вложеных окружностей : %.3f единиц.\n", area);
	fclose(f);
}

int main()
{
	// Использовал лист.
	// Информация выводиться не выполняю исчисления.
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	
	set<Circle> s;
	set<Circle>::iterator si;
	list<Circle> InsideList;
	char answ;

	MakeCircles();
	getInfo(s, si, InsideList);

	printf("\n Посмотреть созданные окружности ?(yes - 1, no - 0)\n\n Ответ : ");
	cin >> answ;
	if (answ == '1')
		for_each(l.begin(), l.end(), Show);
	else if (answ == '0')
		exit(EXIT_SUCCESS);
	else
		exit(EXIT_FAILURE);

	return 0;
}