#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <vector>
#include <algorithm>
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
		strcpy(this->name, name);
		if (weight >= 0 && price >= 0)
		{
			this->weight = weight;
			this->price = price;
		}
		else
		{
			this->weight = 0;
			this->price = 0;
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