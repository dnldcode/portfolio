#pragma once
#include <iostream>
#include <Windows.h>
using namespace std;
class Fish
{
private:
	char name[20];
	double weight;
	double price;
public:
	Fish(char *name = "Noname", double weight = 0, double price = 0)
	{
		if (weight >= 0 && price >= 0)
		{
			strcpy(this->name, name);
			this->weight = weight;
			this->price = price;
		}
	}
	friend ostream &operator<<(ostream &os, Fish &a)
	{
		os << "  Name : " << a.name << "  Weight : " << a.weight << "  Price : " << a.price << endl;
		return os;
	}
	void setWeight(double weight)
	{
		this->weight = weight;
	}
	void setPrice(double price)
	{
		this->price = price;
	}
	int getWeight()
	{
		return this->weight;
	}
	int getPrice()
	{
		return this->price;
	}
};