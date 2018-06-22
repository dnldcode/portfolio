#pragma once
#include "Fishes1.h"

class FQueue
{
public:
	Fish *data;
	int size, last;
public:
	bool full()
	{
		return this->last == this->size;
	}
	bool empty()
	{
		return this->last == 0;
	}
	FQueue(int size = 10)
	{
		if (size > 0)
		{
			this->size = size;
			data = new Fish[this->size];
			this->last = 0;
		}
	}
	void add(Fish f)
	{
		if (!full())
		{
			data[last++] = f;
		}
	}
	Fish extract()
	{
		Fish tmp;
		if (!empty())
		{
			tmp = data[0];
			for (int i = 1; i < this->last; i++)
				data[i - 1] = data[i];
			last--;
			return tmp;
		}
		else
		{
			return tmp;
		}

	}
	FQueue(const FQueue &f)
	{
		data = new Fish[f.size];
		for (int i = 0; i < f.size; i++)
			data[i] = f.data[i];
		this->last = f.last;
		this->size = f.size;
	}
	FQueue &operator =(FQueue &f)
	{
		if (this == &f)
			return *this;
		Fish *tmp = new Fish[f.size];
		if (!tmp)
			return *this;
		for (int i = 0; i < f.size; i++) 
			tmp[i] = f.data[i];

		if (data)
			delete[] data;
		data = tmp;
	}

	void fishSort() 
	{
		Fish tmp;
		int j;
		for (int i = 0; i < size; i++) 
		{
			tmp = data[i];
			for (j = i - 1; j >= 0 && data[j].getPrice() < tmp.getPrice(); j--) 
			{
				data[j + 1] = data[j];
			}
			data[j + 1] = tmp;
		}
	}
	int getLast() 
	{
		return this->last;
	}
	~FQueue()
	{
		delete[] data;
	}
};