#pragma once
#include "Header.h"

class PC2
{
public:
	CPU cp;
	RAM ram;
	HDD hdd;
	MB mb;
	PC2()
	{
	}
	PC2(char *cpuname, double cpuf, int ramv, int hddv, char *mbname)
	{
		CPU cpu(cpuname, cpuf);
		RAM ram(ramv);
		HDD hdd(hddv);
		MB mb(mbname);
		this->cp = cpu;
		this->ram = ram;
		this->hdd = hdd;
		this->mb = mbname;
	}
	friend ostream &operator<<(ostream &os, const PC2 a)
	{
		os << *a.cp << endl;
		os << *a.ram << endl;
		os << *a.hdd << endl;
		os << *a.mb << endl;
		return os;
	}
};