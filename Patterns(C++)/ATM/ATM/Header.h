#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <map>
#include <algorithm>
#include <functional>

using namespace std;

class Request
{
private:
	int requested, rest;// rest - сколько осталось выдать
	map<int, int> notes;
public:
	Request(int requested = 0)
	{
		this->requested = requested;
		this->rest = requested;
	}
	void Show()
	{
		cout << " Was requested amount of : " << this->requested << endl;
		cout << " Transactions have been done :" << endl;
		map<int, int>::iterator it = notes.begin();
		for (it; it != notes.end(); it++)
		{
			cout << " was given : " << it->first << " in amount of : " << it->second << endl;
		}
		if (this->rest > 0)
		{
			cout << "Can't be given : " << this->rest << endl;
		}
	}
	int getRest()
	{
		return this->rest;
	}
	map<int, int> getNotes()
	{
		return this->notes;
	}
	void setNotes(map<int, int> n)
	{
		this->notes = n;
	}
	void setRest(int rest)
	{
		this->rest -= rest;
	}
};
class Handler
{
protected:
	Handler* next;
public:
	Handler()
	{
	}
	virtual void setHandler(Handler *next)
	{
		this->next = next;
	}
	virtual void HandleRequest(Request *request) = 0;
};
class Handler500 : public Handler
{
private:
	int count;
	int value;
public:
	Handler500(int count = 0)
	{
		this->count = count;
		this->value = 500;
	}
	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->getRest() >= this->value && this->count > 0 && next != NULL)
		{
			notes = request->getNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->setRest(this->value);
			request->setNotes(notes);
		}
		if (request->getRest() > 0 && next != NULL)
		{
			next->HandleRequest(request);
		}
	}
};
class Handler200 : public Handler
{
private:
	int count;
	int value;
public:
	Handler200(int count = 0)
	{
		this->count = count;
		this->value = 200;
	}
	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->getRest() >= this->value && this->count > 0 && next != NULL)
		{
			notes = request->getNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->setRest(this->value);
			request->setNotes(notes);
		}
		if (request->getRest() > 0)
		{
			next->HandleRequest(request);
		}
	}
};
class Handler100 : public Handler
{
private:
	int count;
	int value;
public:
	Handler100(int count = 0)
	{
		this->count = count;
		this->value = 100;
	}
	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->getRest() >= this->value && this->count > 0 && next != NULL)
		{
			notes = request->getNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->setRest(this->value);
			request->setNotes(notes);
		}
		if (request->getRest() > 0)
		{
			next->HandleRequest(request);
		}
	}
};
class Handler50 : public Handler
{
private:
	int count;
	int value;
public:
	Handler50(int count = 0)
	{
		this->count = count;
		this->value = 50;
	}
	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->getRest() >= this->value && this->count > 0 && next != NULL)
		{
			notes = request->getNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->setRest(this->value);
			request->setNotes(notes);
		}
		if (request->getRest() > 0)
		{
			next->HandleRequest(request);
		}
	}
};
class Handler20 : public Handler
{
private:
	int count;
	int value;
public:
	Handler20(int count = 0)
	{
		this->count = count;
		this->value = 20;
	}
	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->getRest() >= this->value && this->count > 0 && next != NULL)
		{
			notes = request->getNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->setRest(this->value);
			request->setNotes(notes);
		}
		if (request->getRest() > 0)
		{
			next->HandleRequest(request);
		}
	}
};
class Handler10 : public Handler
{
private:
	int count;
	int value;
public:
	Handler10(int count = 0)
	{
		this->count = count;
		this->value = 10;
	}
	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->getRest() >= this->value && this->count > 0 && next != NULL)
		{
			notes = request->getNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->setRest(this->value);
			request->setNotes(notes);
		}
		if (request->getRest() > 0)
		{
			next->HandleRequest(request);
		}
	}
};