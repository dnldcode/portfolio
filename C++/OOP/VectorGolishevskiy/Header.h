#pragma once
#include <iostream>
#include <Windows.h>
using namespace std;
inline void Error()
{
	printf("\n Error\n");
}
class Vector
{
private:
	int *data;
	int size;
public:
	Vector(int ar[], int size)
	{
		if (size <= 0)
			data = NULL;
		else
		{
			data = new int[size];
			for (int i = 0; i < size; i++)
				data[i] = ar[i];
		}
		this->size = size;
	}
	friend ostream &operator<<(ostream &os, Vector v)
	{
		os << " ";
		for (int i = 0; i < v.size; i++)
			os << v.data[i] << "  ";
		os << endl;
		return os;
	}
	Vector(const Vector &v) 
	{
		this->size = v.size;
		this->data = new int[this->size];
		for (int i = 0; i < this->size; i++) 
			*(this->data + i) = *(v.data + i);
	}
	void insert(int in, const int value)
	{
		if (in < 0 || in > this->size)
		{
			Error();
			return;
		}
		else
		{
			int *tmp = new int[++this->size];
			for (int i = 0; i < this->size - 1; i++)
			{
				if (i < in)
					tmp[i] = data[i];
				else if (i >= in)
				{
					tmp[i + 1] = data[i];
				}
				tmp[in] = value;
			}
			delete[] this->data;
			this->data = new int[this->size];
			for (int i = 0; i < this->size; i++)
				*(data + i) = *(tmp + i);
			delete[] tmp;
		}
	}
	void remove(int in)
	{
		if (in < 0 || in > this->size - 1)
		{
			Error();
			return;
		}
		else
		{
			int *tmp = new int[--this->size];
			for (int i = 0; i <= this->size; i++)
			{
				if (i < in)
					tmp[i] = data[i];
				else if (i > in)
					tmp[i - 1] = data[i];
			}
			delete[] this->data;
			this->data = new int[this->size];
			for (int i = 0; i < this->size; i++)
				*(data + i) = *(tmp + i);
			delete[] tmp;
		}
	}
	int &operator[](int in)
	{
		return this->data[in];
	}
	Vector &operator=(const Vector &a)
	{
		if (this != &a)
		{
			if (this->data != NULL)
				delete[] this->data;
			this->size = a.size;
			this->data = new int[this->size];
			for (int i = 0; i < this->size; i++)
			{
				*(this->data + i) = *(a.data + i);
			}
			return *this;
		}
		else
			return *this;
	}
	friend Vector operator+(const int &c, const Vector &a)
	{
		int *tmp = new int[a.size];
		for (int i = 0; i < a.size; i++)
			*(tmp + i) = *(a.data + i) + c;
		return Vector(tmp, a.size);
	}
	friend Vector operator-(const int &c, const Vector &a)
	{
		int *tmp = new int[a.size];
		for (int i = 0; i < a.size; i++)
			*(tmp + i) = *(a.data + i) - c;
		return Vector(tmp, a.size);
	}
	Vector operator+(const Vector const a)
	{
		int *tmp = new int[this->size + a.size];
		for (int i = 0; i < this->size + a.size; i++)
		{
			if (i<this->size)
				tmp[i] = this->data[i];
			else
				tmp[i] = a.data[i - this->size];
		}
		Vector az(tmp, this->size + a.size);
		return az;
	}
	Vector operator-(const Vector const a)
	{
		int *tmp = new int[this->size];
		for (int i = 0; i < this->size; i++)
			tmp[i] = this->data[i];
		int q = this->size;

		for (int i = 0; i < q; i++)
		{
			for (int j = 0; j < a.size; j++)
			{
				if (tmp[i] == a.data[j])
				{
					for (int z = 0; z < q; z++)
					{
						if (z > i)
							tmp[z - 1] = tmp[z];
					}
					q--;
					if (i != q)
						i--;
					break;
				}
			}
		}

		Vector az(tmp, q);
		return az;
	}
	Vector operator+(int a)
	{
		for (int i = 0; i < this->size; i++)
			this->data[i] += a;
		return *this;
	}
	Vector operator-(int a)
	{
		for (int i = 0; i < this->size; i++)
			this->data[i] -= a;
		return *this;
	}
	~Vector()
	{
		delete[] this->data;
	}
};