#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <string>
#include <map>
#include <algorithm>
#include <functional>
#include <fstream>

using namespace std;

class BaseSymbol
{
protected:
	char symbol;
	int position;
	int size;
	string color;
public:
	char getChar()
	{
		return this->symbol;
	}
	virtual string DisplaySymbol(int size, string color) = 0;
	friend ostream &operator<<(ostream &os, BaseSymbol &bs)
	{
		os << " Symbol : " << setw(15) << bs.symbol << "  | Position : " << setw(5) << bs.position << "  | Size : " << setw(5) << bs.size << "  | Color : " << bs.color << endl;
		return os;
	}
};

class Symbol : public BaseSymbol
{
public:
	Symbol(char c)
	{
		this->symbol = c;
		this->position = 0;
		this->size = 20;
		this->color = "blue";
	}
	virtual string DisplaySymbol(int size, string color)
	{
		char s[20];
		string str = "<span style='color:";
		str += color;
		str += ";fron-size:";
		itoa(size, s, 10);
		str += s;
		str += "'>";
		str += this->symbol;
		str == "</span>";
		return str;

		cout << "<span style = 'color:" << color << ";font-size:" << size << ";'>" << this->symbol << "</span>" << endl;
		
	}
};
class CharFactory
{
protected:
	map<char, BaseSymbol*> pool;
public:
	BaseSymbol* getSymbol(char key)
	{
		map <char, BaseSymbol*>::iterator it = pool.find(key);
		if (it == pool.end())
		{
			BaseSymbol* bs = new Symbol(key);
			pool[key] = bs;
			return bs;
		}
		else
		{
			return it->second;
		}
	}
	int getPoolSize()
	{
		return this->pool.size();
	}
	void showPool()
	{
		for (map<char, BaseSymbol*>::iterator it = pool.begin(); it != pool.end();it++)
		{
			cout << setw(3) << it->first << "   " << *it->second << endl;
		}
	}
};