#pragma once
#include <iostream>
#include <Windows.h>
#include "Header1.h"
using namespace std;
inline void Error()
{
	printf("\n Error\n");
}
class Stack
{
private:
	Fish *data;
	int capacity, top;
public:
	Stack(int c = 10)
	{
		if (c > 0)
		{
			data = new Fish[c];
			for (int i = 0; i < c; i++)
				data[i] = Fish("",0,0);
			this->capacity = c;
			this->top = 0;
		}
	}
	int Push(Fish e)
	{
		if (!IsFull())
			data[++this->top] = e;
		return this->top;
	}
	bool IsFull()
	{
		return this->top == this->capacity;
	}
	bool IsEmpty()
	{
		return this->top == 0;
	}
	Fish Pop()
	{
		if (!IsEmpty())
			return this->data[this->top--];
		return 0;
	}
	void Clear()
	{
		this->top = 0;
	}
	Fish Peep()
	{
		if (!IsEmpty())
			return this->data[this->top];
		return 0;
	}
};