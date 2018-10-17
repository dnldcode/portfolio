#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>

using namespace std;

int in = 0;
int Days[12] = { 21,22,24,22,24,23,22,23,22,22,22,24 };
char Names[20][20] = { "Archibald","Donald","Dominic","Matthew","Robert" ,"Paul" ,"Dwain" ,"Phillip" ,"Oliver" ,"Edward" ,"Jeffrey" ,"Willis" ,"Baldwin" ,"William" ,"Moris" ,"Henry" ,"Jeffrey" ,"John" ,"Mark" ,"Garry" };
int is;
class Employee
{
protected:
	char *name;
	int tn;
public:
	Employee(char *name = "Noname", int tn = 0)
	{
		if (tn > 0)
		{
			this->name = new char[strlen(name) + 1];
			strcpy(this->name, name);
			this->tn = tn;
		}
		else
		{
			this->tn = 0;
		}
	}
	int getTn()
	{
		return this->tn;
	}
	// Чисто виртуальные методы.
	virtual double Salary() = 0;
	virtual double Bonus() = 0;
	virtual double Tax(double sum) = 0;
	friend ostream &operator<<(ostream &os, const Employee& a)
	{
		os << setw(25) << a.name << setw(10) << a.tn;
		return os;
	}
	virtual void Show()
	{
		cout << setw(15) << "Employee name : " << setw(15) << name << "    tn : " << tn << endl;
	}
};
class Programmer : public Employee
{
protected:
	double time;// Часы отработанные в месяц
	double hourrate;// Почасовой оклад, тарифная ставка
public:
	Programmer(char *name = "Noname", int tn = 0, double time = 0, double hourrate = 0) : Employee(name, tn)
	{
		if (time >= 0 && hourrate >= 0)
		{
			this->time = time;
			this->hourrate = hourrate;
		}
		else
		{
			this->time = 0;
			this->hourrate = 0;
		}
	}
	virtual double Salary()
	{
		double sum = this->time * this->hourrate;
		return sum;
	}
	virtual double Bonus()
	{
		if (this->time > 180)
			return this->time * this->hourrate;
		else if (this->time > 100)
			return this->time * this->hourrate / 2;
		else
			return 0;
	}
	virtual double Tax(double sum)
	{
		return sum * 0.1;
	}
	friend ostream &operator<<(ostream &os, const Programmer& a)
	{
		os << setw(25) << a.name << setw(10) << a.tn << fixed << setprecision(1) << setw(10) << a.time << setw(10) << a.hourrate << endl;
		return os;
	}
	virtual void Show()
	{
		cout << setw(15) << "Program name : " << setw(20) << this->name << setw(10) << "    tn : " << this->tn << setw(10) << "    time : " << setw(10) << this->time << setw(15) << "hourRate : " << setw(10) << this->hourrate << endl;
	}
};
class Manager : public Employee
{
protected:
	int days;//отработ дни.
	int monthRate;//ставка
public:
	Manager(char *name = "Noname", int tn = 0, int days = 0, int monthRate = 0) : Employee(name, tn)
	{
		if (days >= 0 && monthRate >= 0)
		{
			this->days = days;
			this->monthRate = monthRate;
		}
		else
		{
			this->days = 0;
			this->monthRate = 0;
		}
	}
	virtual double Salary()
	{
		double sum = this->days * this->monthRate / Days[in - 1];
		return sum;
	}
	virtual double Bonus()
	{
		if (this->days > Days[in - 1])
			return this->days * this->monthRate;
		else if (this->days > 0)
			return this->days * this->monthRate / 4;
		else
			return 0;
	}
	virtual double Tax(double sum)
	{
		return sum * 0.25;
	}
	friend ostream &operator<<(ostream &os, const Manager& a)
	{
		os << setw(25) << a.name << setw(10) << a.tn << fixed << setprecision(1) << setw(10) << a.days << setw(10) << a.monthRate << endl;
		return os;
	}
	virtual void Show()
	{
		cout << setw(15) << "Manager name : " << setw(20) << this->name << setw(10) << "    tn : " << this->tn << setw(10) << "    days : " << setw(10) << this->days << setw(15) << "monthRate : " << setw(10) << this->monthRate << endl;
	}

};
class Boss : public Employee
{
protected:
	int days;//отработ дни.
	int monthRate;//ставка
public:
	Boss(char *name = "Noname", int tn = 0, int days = 0, int monthRate = 0) : Employee(name, tn)
	{
		if (days >= 0 && monthRate >= 0)
		{
			this->days = days;
			this->monthRate = monthRate;
		}
		else
		{
			this->days = 0;
			this->monthRate = 0;
		}
	}
	virtual double Salary()
	{
		double sum = this->days * this->monthRate;
		return sum;
	}
	virtual double Bonus()
	{
		if (this->days >= 12)
			return this->days * this->monthRate;
		else if (this->days > 5)
			return this->days * this->monthRate / 4;
		else
			return 0;
	}
	virtual double Tax(double sum)
	{
		return sum * 0.01;
	}
	friend ostream &operator<<(ostream &os, const Boss& a)
	{
		os << setw(25) << a.name << setw(10) << a.tn << fixed << setprecision(1) << setw(10) << a.days << setw(10) << a.monthRate << endl;
		return os;
	}
	virtual void Show()
	{
		cout << setw(15) << "Boss name : " << setw(20) << this->name << setw(10) << "    tn : " << this->tn << setw(10) << "    days : " << setw(10) << this->days << setw(15) << "monthRate : " << setw(10) << this->monthRate << endl;
	}

};