#pragma once
#include <Windows.h>
#include <iostream>
#include <iomanip>
#include <ctime>
#include <string>
#include <vector>
#include <typeinfo>

using namespace std;

class UnitC
{
public:
	virtual void Work() = 0;
	virtual UnitC* clone() = 0;
	virtual void randomize() = 0;
};
class UnitB
{
public:
	virtual void Protect(UnitC* c) = 0;
	virtual UnitB* clone() = 0;
	virtual void randomize() = 0;
};
class UnitA
{
public:
	virtual void Rule(UnitB* b) = 0;
	virtual void randomize() = 0;
};

class AbstractFactory
{
public:
	virtual UnitA* CreateUnitA() = 0;
	virtual UnitB* CreateUnitB() = 0;
	virtual UnitC* CreateUnitC() = 0;
};
class Peasant : public UnitC
{
public:
	int health;
	Peasant()
	{
		this->health = rand() % 50 + 50;
	}
	virtual void Work()
	{
		cout << typeid(Peasant).name() << " works..." << endl;
	}
	virtual Peasant* clone()
	{
		return new Peasant(*this);
	}
	void randomize()
	{
		this->health = rand() % 50 + 50;
	}
};
class Palladin : public UnitB
{
public:
	int health, attack, defend;
	Palladin()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
	void Protect(UnitC* p)
	{
		cout << typeid(Palladin).name() << " protects " << typeid(Peasant).name() << " from berserks" << endl;
	}
	virtual Palladin* clone()
	{
		return new Palladin(*this);
	}
	void randomize()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
};
class Mage : public UnitA
{
private:
	int health, attack, defend;
	Mage()
	{
		this->health = rand() % 10 + 50;
		this->attack = rand() % 500 + 500;
		this->defend = rand() % 40 + 40;
	}
	Mage(const Mage &s);
	Mage& operator=(Mage &s);
	static Mage *psm;
public:
	void Rule(UnitB* p)
	{
		cout << typeid(Mage).name() << " rules over " << typeid(Palladin).name() << " against orcs " << endl;
	}
	void randomize()
	{
		this->health = rand() % 10 + 50;
		this->attack = rand() % 500 + 500;
		this->defend = rand() % 40 + 40;
	}
	static Mage* getInstance()
	{
		if (!psm)
			psm = new Mage();
		return psm;
	}
};
class Slave : public UnitC
{
public:
	int health;
	Slave()
	{
		this->health = rand() % 50 + 50;
	}
	void Work()
	{
		cout << typeid(Slave).name() << " works..." << endl;
	}
	virtual Slave* clone()
	{
		return new Slave(*this);
	}
	virtual void randomize()
	{
		this->health = rand() % 50 + 50;
	}
};
class Berserk : public UnitB
{
public:
	int health, attack, defend;
	Berserk()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
	void Protect(UnitC* s)
	{
		cout << typeid(Berserk).name() << " protects " << typeid(Slave).name() << " from palladins" << endl;
	}
	virtual Berserk* clone()
	{
		return new Berserk(*this);
	}
	void randomize()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
};
class Shaman : public UnitA
{
private:
	Shaman()
	{
		this->health = rand() % 10 + 50;
		this->attack = rand() % 500 + 500;
		this->defend = rand() % 40 + 40;
	}
	Shaman(const Shaman &s);
	Shaman& operator=(Shaman &s);
	static Shaman *pss;
public:
	int health, attack, defend;
	void Rule(UnitB* p)
	{
		cout << typeid(Shaman).name() << " rules over " << typeid(Berserk).name() << " against humans " << endl;
	}
	void randomize()
	{
		this->health = rand() % 10 + 50;
		this->attack = rand() % 500 + 500;
		this->defend = rand() % 40 + 40;
	}
	static Shaman* getInstance()
	{
		if (!pss)
			pss = new Shaman();
		return pss;
	}
};
class HumanFactory : public AbstractFactory
{
public:
	//Create peasant(крестьяне)
	UnitC* CreateUnitC()
	{
		return new Peasant();
	}
	//Create Palladin
	UnitB* CreateUnitB()
	{
		return new Palladin();
	}
	//Create Mage
	UnitA* CreateUnitA()
	{
		return Mage::getInstance();
	}

};
class OrkFactory : public AbstractFactory
{
public:
	//Create Slave
	UnitC* CreateUnitC()
	{
		return new Slave();
	}
	//Create Berserk
	UnitB* CreateUnitB()
	{
		return new Berserk();
	}
	//Create Shaman
	UnitA* CreateUnitA()
	{
		return Shaman::getInstance();
	}

};
class Client
{
protected:
	UnitA* oa;
	UnitB* ob;
	UnitC* oc;
public:
	Client(AbstractFactory* factory)
	{
		oa = factory->CreateUnitA();
		ob = factory->CreateUnitB();
		oc = factory->CreateUnitC();
	}
	UnitC* getUnitC()
	{
		return oc;
	}
	UnitB* getUnitB()
	{
		return ob;
	}
	UnitA* getUnitA()
	{
		return oa;
	}
};