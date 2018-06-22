#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <string>
#include <vector>

using namespace std;

class AbMediator;
class AbChatter
{
protected:
	string name;
public:
	AbChatter(string name)
	{
		this->name = name;
	}
	string getName()
	{
		return this->name;
	}
	virtual void Send_Message(AbMediator* abm, string msg) = 0;
	virtual void Recieve_Message(AbChatter *abc, string msg) = 0;
};
class AbMediator
{
protected:
	vector<AbChatter*> chatters;
public:
	virtual void AddChatter(AbChatter* abc)
	{
		chatters.push_back(abc);
	}
	virtual void TransferMessage(AbChatter* abc, string msg) = 0;
};
class Chatter : public AbChatter
{
public:
	Chatter(string name) : AbChatter(name)
	{

	}
	virtual void Send_Message(AbMediator* abm, string msg)
	{
		abm->TransferMessage(this, msg);
	}
	virtual void Recieve_Message(AbChatter *abc, string msg)
	{
		cout << getName() << " recieved \"" << msg << "\" from  " << abc->getName() << endl;
	}
};
class Mediator1 : public AbMediator
{
public:
	virtual void TransferMessage(AbChatter* abc, string msg)
	{
		vector<AbChatter*>::iterator it = chatters.begin();
		for (it;it != chatters.end();it++)
			if ((*it) != abc)
				(*it)->Recieve_Message(abc, msg);
	}
};
class Mediator2 : public AbMediator
{
public:
	virtual void TransferMessage(AbChatter* abc, string msg)
	{
		vector<AbChatter*>::iterator it = chatters.begin();
		for (it;it != chatters.end();it++)
			if ((*it) != abc)
				(*it)->Recieve_Message(abc, msg);
	}
	virtual void Send_Message(AbMediator* abm, string msg)
	{
		msg = to_string(msg.length());
		abm->TransferMessage(this, msg);
	}
};