#pragma once
#include <iostream>
#include <Windows.h>
using namespace std;

class CPU
{
public:
	char name[64];
	double f;
	CPU(char *n = "Noname", double f = 0)
	{
		if (f >= 0)
		{
			strcpy(name, n);
			this->f = f;
		}
		else
			this->f = 0;
	}
	friend ostream &operator<<(ostream &os ,const CPU a)
	{
		os << "CPU Name: " << a.name << "\t CPU Frequency : " << a.f << endl;
		return os;
	}
};
class RAM
{
public:
	int ram;
	RAM(int ram = 0)
	{
		if (ram >= 0)
			this->ram = ram;
		else
			this->ram = 0;
	}
	friend ostream &operator<<(ostream &os, const RAM a)
	{
		os << "RAM Size : " << a.ram << endl;
		return os;
	}
};
class HDD
{
public:
	int hdd;
	HDD(int hdd = 0)
	{
		if (hdd >= 0)
			this->hdd = hdd;
		else
			this->hdd = 0;
	}
	friend ostream &operator<<(ostream &os, const HDD a)
	{
		os << "HDD Size : " << a.hdd << endl;
		return os;
	}
};
class MB
{
public:
	char name[128];
	MB(char *n = "Noname")
	{
			strcpy(name, n);
	}
	friend ostream &operator<<(ostream &os, const MB a)
	{
		os << "MB Name : " << a.name << endl;
		return os;
	}
};
class PC1
{
public:
	CPU *cp;
	RAM *ram;
	HDD *hdd;
	MB *mb;
	PC1()
	{
	}
	PC1(CPU *c, RAM *r, HDD *h, MB m)
	{
		cp = new CPU;
		strcpy(cp->name, c->name);
		ram = new RAM;
		hdd = new HDD;
		mb = new MB;
		strcpy(mb->name, m->name);
		if (c->f >= 0 && r->ram >= 0 && h->hdd >= 0)
		{
			cp->f = c->f;
			ram->ram = r->ram;
			hdd->hdd = h->hdd;
		}
		else
		{
			cp->f = 0;
			ram->ram = 0;
			hdd->hdd = 0;
		}
	}
	friend ostream& operator<<(ostream &os, const PC1 a)
	{
		os << *a.cp << endl;
		os << *a.ram << endl;
		os << *a.hdd << endl;
		os << *a.mb << endl;
		return os;
	}
};