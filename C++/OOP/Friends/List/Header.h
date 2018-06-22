#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <algorithm>
#include <list>
#include <string>

using namespace std;

string boys[10] = { "Абзал",  "Бакир",  "Ахмет",  "Касымхан",  "Нурлыбек",  "Сырым",  "Умбет",  "Кобжан",  "Жаназар",  "Акылбай" };
string girls[10] = { "Айбала",  "Арифа",  "Арувджан",  "Багдагуль",  "Беневша",  "Валида",  "Джума",  "Мугубат",  "Замира",  "Генже" };

class Child
{
private:
	string name;
	int age;
	string sex;
	bool hasFriend;
public:
	Child(string name = "No name",int age = 0,string sex = "No sex")
	{
		this->name = name;
		this->sex = sex;
		if (age > 0)
			this->age = age;
		else
			this->age = 0;
		this->hasFriend = 0;
	}
	string getName()
	{
		return this->name;
	}
	int getAge()
	{
		return this->age;
	}
	string getSex()
	{
		return this->sex;
	}
	bool getHasFriend()
	{
		return this->hasFriend;
	}
	void setName(string name)
	{
		this->name = name;
	}
	void setAge(int age)
	{
		this->age = age;
	}
	void setSex(string sex)
	{
		this->sex = sex;
	}
	void setHasFriend(bool hasFriend)
	{
		this->hasFriend = hasFriend;
	}
	friend ostream &operator<<(ostream &os, const Child &c)
	{
		os << " Name : " << setw(10) << c.name << " | Age : " << setw(3) << c.age << " | Sex : " << setw(3) << c.sex << " | Has friends : " << c.hasFriend << endl;
		return os;
	}
};