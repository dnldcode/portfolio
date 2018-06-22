#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <functional>
#include <list>
#include <vector>
#include <set>
#include <math.h>
#include <stdio.h>
#include <conio.h>
#include <fstream>
#include <cstdlib>
#include "Point.h"

enum ConsoleColor 
{
	Black, Blue, Green, Cyan, Red, Magenta, Brown, LightGray, DarkGray,
	LightBlue, LightGreen, LightCyan, LightRed, LightMagenta, Yellow, White
};

void SetColor(int text, int background)
{
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}

void GotoXY(int X, int Y)
{
	HANDLE hConsole;
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD coord = { X, Y };
	SetConsoleCursorPosition(hStdOut, coord);
}

using namespace std;

class Circle : public Point
{
private:
	int radius, inside;
public:
	Circle(int num = 0, double centreX = 0., double centreY = 0., int radius = 0) : Point(num, centreX, centreY)
	{
		if (radius >= 0 && radius <= 50)
			this->radius = radius;
		else
			this->radius = 0;
		this->inside = 0;
	}
	void setRadius(int radius)
	{
		this->radius = radius;
	}
	void addInside(int inside)
	{
		this->inside += inside;
	}
	int getRadius() const
	{
		return this->radius;
	}
	int getInside() const
	{
		return this->inside;
	}
	friend ostream& operator<<(ostream& os, Circle c)
	{
		os << " Num : " << setw(4) << c.num << "  | X : " << fixed << setprecision(1) << setw(6) << c.centreX << "  | Y : " << fixed << setprecision(1) << setw(6) << c.centreY << "  | Radius : " << setw(3) << c.radius << "  | Inside : " << c.inside << endl;
		return os;
	}
	Circle& operator=(const Circle& c) 
	{
		this->centreX = c.centreX;
		this->centreY = c.centreY;
		this->radius = c.radius;
		this->num = c.num;
		this->inside = c.inside;
		return *this;
	}
	// Перегрузил просто так.
	bool operator>(Circle c)
	{
		return this->getInside() > c.getInside();
	}
	bool operator>=(Circle c)
	{
		return this->getInside() >= c.getInside();
	}
	bool operator<=(Circle c)
	{
		return this->getInside() <= c.getInside();
	}
	bool operator<(Circle const c)const
	{
		return this->getInside() > c.getInside();
	}
	bool operator==(Circle const c)const
	{
		return this->centreX == c.centreX && this->centreY == c.centreY;
	}
};