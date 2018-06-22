#pragma once
#include <iomanip>
#include <iostream>
#include <Windows.h>
#include <ctime>

using namespace std;

class Prototype
{
protected:
	int x, y;
public:
	virtual Prototype* clone() = 0;
	int getX()
	{
		return this->x;
	}
	int getY()
	{
		return this->y;
	}
	void setX(int x)
	{
		this->x = x;
	}
	void setY(int y)
	{
		this->y = y;
	}
	friend ostream& operator<<(ostream &os, Prototype &p)
	{
		os << "  X : " << setw(5) << p.x << "  |  Y : " << setw(5) << p.y << endl;
		return os;
	}
};

class Rect : public Prototype
{
protected:
	int width, height;
public:
	/*Rect(int width, int height)
	{
		if (width >= 0 && height >= 0)
		{
			this->width = width;
			this->height = height;
		}
		else
		{
			this->width = 0;
			this->height = 0;
		}
	}*/
	Prototype* clone()
	{
		return new Rect(*this);
	}
	int getWidth()
	{
		return this->width;
	}
	int getHeight()
	{
		return this->height;
	}
	void setWidth(int width)
	{
		if (width <= 0)
			width = 0;
		this->width = width;
	}
	void setHeight(int height)
	{
		if (height <= 0)
			height = 0;
		this->height = height;
	}
	friend ostream& operator<<(ostream &os, Rect &p)
	{
		os << "  X : " << setw(5) << p.x << "  |  Y : " << setw(5) << p.y << "  |  Width : " << setw(5) << p.width << "  |  Height : " << setw(5) << p.height << endl;
		return os;
	}
};

class Circle : public Prototype
{
protected:
	int radius;
public:
	/*Circle(int radius)
	{
		if (radius < 0)
			radius = 0;
		this->radius = radius;
	}*/
	Prototype* clone()
	{
		return new Circle(*this);
	}
	int getRadius()
	{
		return this->radius;
	}
	void setRadius(int radius)
	{
		if (radius <= 0)
			radius = 0;
		this->radius = radius;
	}

	friend ostream& operator<<(ostream &os, Circle &p)
	{
		os << "  X : " << setw(5) << p.x << "  |  Y : " << setw(5) << p.y << "  |  Radius : " << setw(5) << p.radius << endl;
		return os;
	}
};

class Client
{
private:
	static Prototype* figure1;
	static Prototype* figure2;
public:
	static void Init()
	{
		figure1 = new Rect;
		figure2 = new Circle;
	}
	static Prototype* getRect()
	{
		return figure1->clone();
	}
	static Prototype* getCircle()
	{
		return figure2->clone();
	}
};
Prototype* Client::figure1 = NULL;
Prototype* Client::figure2 = NULL;