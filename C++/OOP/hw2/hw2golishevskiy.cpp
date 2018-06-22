#include <iostream>
#include <Windows.h>
class Time
{
private:
	unsigned hh : 5;
	unsigned mm : 6;
	unsigned ss : 7;
public:
	Time(int h, int m, int s)
	{
		this->hh = h;
		this->mm = m;
		this->ss = s;
	}
	void setH(int h)
	{
		this->hh = h;
	}
	void setM(int mm)
	{
		this->mm = mm;
	}
	void setS(int ss)
	{
		this->ss = ss;
	}
	int getH()
	{
		return this->hh;
	}
	int getM()
	{
		return this->mm;
	}
	int getS()
	{
		return this->ss;
	}
	void show()
	{
		(this->hh > 9) ? printf("%d:", this->hh) : printf("0%d:", this->hh);
		(this->mm > 9) ? printf("%d:", this->mm) : printf("0%d:", this->mm);
		(this->ss > 9) ? printf("%d", this->ss) : printf("%d", this->ss);
		printf("\n");
	}
	void dif(Time f)
	{
		int t1 = (this->hh * 3600 + this->mm * 60 + this->ss) - (f.hh * 3600 + f.mm * 60 + f.ss);
		(t1 > 0) ? t1 : t1 *= (-1);
		printf("\n Разница :\n\n Часов : %d\t Минут : %d\t Секунд : %d\n\n", t1 / 3600, t1 % 3600 / 60, t1 % 60);
	}

};
void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	Time f1(11, 30, 32);
	Time f2(10, 42, 42);
	printf("\n Время 1 : ");
	f1.show();
	printf(" Время 2 : ");
	f2.show();
	f1.dif(f2);
}