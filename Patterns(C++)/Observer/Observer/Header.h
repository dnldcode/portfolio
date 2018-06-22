#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <functional>
#include <algorithm>
#include <string>
#include <vector>

using namespace std;

//abstract Observer
class Shop
{
protected:
	string name;
public:
	virtual void Notify(int price) = 0;
};
//publisher
class Product
{
private:
	string product;
	int price;
	vector<Shop*> shops;
public:
	Product(string product, int price)
	{
		this->product = product;
		this->price = price;
	}
	void Subscribe(Shop* shop)
	{
		this->shops.push_back(shop);
	}
	void Unsubscribe(Shop* shop)
	{
		shops.erase(remove(shops.begin(), shops.end(), shop));
	}
	void ChangePrice(int price)
	{
		this->price = price;
	}
	virtual void NotifyAll()
	{
		vector<Shop*>::iterator it = shops.begin();
		for (it; it != shops.end();it++)
		{
			(*it)->Notify(this->price);
		}
	}
};
class RealShop : public Shop
{
protected:
	string name;
	int price;
public:
	RealShop(string name)
	{
		this->name = name;
		this->price = 0;
	}
	virtual void Notify(int price)
	{
		this->price = price;
		cout << name << " received new price : " << price << endl;
	}
};