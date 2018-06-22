#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <vector>
#include <algorithm>
#include <ctime>
#include <string>

using namespace std;

int categoryn, productn;

class Category
{
private:
	int id;
	string name;
public:
	Category(int id = 0, string name = "Unknown")
	{
		if (id >= categoryn)
		{
			this->id = id;
			this->name = name;
		}
		else
		{
			this->id = 0;
			this->name = "Unknown";
		}
	}
	int getCategoryId()
	{
		return this->id;
	}
	string getCategoryName()
	{
		return this->name;
	}
	void setCategoryId(int id = 0)
	{
		this->id = id;
	}
	void setCategoryName(string name = "Unknown")
	{
		this->name = name;
	}
	friend ostream &operator<<(ostream &os, Category &c)
	{
		os << " Id категории : " << setw(5) << c.id << "  | Имя категории : " << setw(15) << c.name << endl;
		return os;
	}
};
class Product
{
private:
	int id;
	string name;
	int price;
	int count;
	int categoryid;
public:
	Product(int id = 0, string name = "Unknown", int price = 0, int count = 0, int categoryid = 0)
	{
		if (id >= productn && price > 0 && count > 0 && categoryn > 0)
		{
			this->id = id;
			this->name = name;
			this->price = price;
			this->count = count;
			this->categoryid = categoryid;
		}
		else
		{
			this->id = 0;
			this->name = "Unknown";
			this->price = 0;
			this->count = 0;
			this->categoryid = 0;
		}
	}
	int getProductId()
	{
		return this->id;
	}
	string getProductName()
	{
		return this->name;
	}
	int getProductPrice()
	{
		return this->price;
	}
	int getProductCount()
	{
		return this->count;
	}
	int getProductCategoryId()
	{
		return this->categoryid;
	}
	void setProductId(int id = 0)
	{
		this->id = id;
	}
	void setProductName(string name = "Unknown")
	{
		this->name = name;
	}
	void setProductPrice(int price = 0)
	{
		this->price = price;
	}
	void setProductCount(int count = 0)
	{
		this->count = count;
	}
	void setProductCategoryId(int categoryid = 0)
	{
		this->categoryid = categoryid;
	}
	friend ostream &operator<<(ostream &os, Product &p)
	{
		os << "  Id : " << setw(5) << p.id << "  | Имя : " << setw(20) << p.name << "  | Цена : " << setw(5) << p.price << "  | Кол-во : " << setw(5) << p.count << "  | Id категории : " << setw(5) << p.categoryid << endl;
		return os;
	}
};
class Order
{
private:
	vector<Product>::iterator ito;
	int count;
public:
	Order(vector<Product>::iterator ito, int count = 0)
	{
		if (count > 0)
		{
			this->ito = ito;
			this->count = 0;
		}
	}
	int getIterator()
	{
		cout << *ito;
	}
	int getCount()
	{
		return this->count;
	}
	void setIterator(vector<Product>::iterator ito)
	{
		this->ito = ito;
	}
	void setCount(int count = 0)
	{
		this->count = count;
	}
	void MakeOrder(int &balance, vector<Product> &products)
	{
		balance -= ito->getProductPrice() * count;
		ito->setProductCount(ito->getProductCount() - count);
		if (ito->getProductCount() == 0)
			products.erase(ito);
		cout << "\n Заказ успешно оформлен! Спасибо за покупку. Остаток на балансе : " << balance << " грн.\n" << endl;

	}
};