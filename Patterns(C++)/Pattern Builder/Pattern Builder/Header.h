#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <vector>
#include <string>

using namespace std;

class PC
{
private:
	vector<string> parts;
public:
	void addPart(string part)
	{
		this->parts.push_back(part);
	}
	void Show()
	{
		cout << "\n Current PC : \n" << endl;
		for (int i = 0;i < parts.size();i++)
		{
			cout << parts[i] << endl;
		}
		cout << endl;
	}
};

class ABuilder
{
protected:

public:
	virtual void BuildCPU() = 0;
	virtual void BuildMB() = 0;
	virtual void BuildRAM() = 0;
	virtual void BuildHDD() = 0;
	virtual PC getPC() = 0;
};

class Builder1 : public ABuilder
{
	PC pc1;
public:
	void BuildCPU()
	{
		pc1.addPart(" Intel Core Duo");
	}
	void BuildMB()
	{
		pc1.addPart(" Motherboard Asus");
	}
	void BuildRAM()
	{
		pc1.addPart(" DDR4 2GB");
		pc1.addPart(" DDR4 2GB");
	}
	void BuildHDD()
	{
		pc1.addPart(" Samsung HDD 1TB");
	}
	PC getPC()
	{
		return pc1;
	}
};
class Builder2 : public ABuilder
{
	PC pc1;
public:
	void BuildCPU()
	{
		pc1.addPart(" Intel Core 7");
	}
	void BuildMB()
	{
		pc1.addPart(" Motherboard MSI");
	}
	void BuildRAM()
	{
		pc1.addPart(" DDR4 4GB");
		pc1.addPart(" DDR4 4GB");
	}
	void BuildHDD()
	{
		pc1.addPart(" WesternDigital HDD 2TB");
	}
	PC getPC()
	{
		return pc1;
	}
};
class Builder3 : public ABuilder
{
	PC pc1;
public:
	void BuildCPU()
	{
		pc1.addPart(" Intel Core 7");
	}
	void BuildMB()
	{
		pc1.addPart(" Motherboard Gigabyte");
	}
	void BuildRAM()
	{
		pc1.addPart(" DDR4 16GB");
	}
	void BuildHDD()
	{
		pc1.addPart(" Kingston SSD 240 GB");
	}
	PC getPC()
	{
		return pc1;
	}
};

class Director
{
public:
	PC CreatePC(ABuilder* builder)
	{
		builder->BuildCPU();
		builder->BuildMB();
		builder->BuildRAM();
		builder->BuildHDD();
		return builder->getPC();
	}
};