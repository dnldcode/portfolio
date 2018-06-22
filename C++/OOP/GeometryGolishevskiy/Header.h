#pragma once
#include<iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h> 

using namespace std;

class Point
{
protected:
	int x, y;
public:

	Point()
	{
		x = y = 0;
	}
	Point(int x, int y)
	{
		this->x = x;
		this->y = y;
	}
	void Show()
	{
		cout << "| X = " << x << ";| Y = " << y << " |" << endl;
	}

	double Area()
	{
		return 0.0; 
	}
};


class Circle : public Point
{
protected:
	int radius;
public:

	Circle()
	{
		radius = 0;
	}
	Circle(int x, int y, int r) : Point(x, y)
	{
		if (r >= 0)
		{
			this->radius = r;
		}
		else
			this->radius = 0;
	}

	void Show()
	{
		cout << " Radius = " << radius << endl;
	}
	double Area()
	{
		return 3.14*radius*radius;
	}
};



class ColorCircle : public Circle
{
protected:
	char Color[15];
public:

	ColorCircle()
	{
		strcpy(this->Color, "ÁÅÑÖÂÅÒÍÛÉ");
	}

	ColorCircle(int x, int y, int r, char *Color = "ÁÅÑÖÂÅÒÍÛÉ") : Circle(x, y, r)
	{
		strcpy(this->Color, Color);
	}

	void Show()
	{
		cout << " X = " << x << " Y = " << y << " Radius = " << radius << " Öâåò: " << Color << endl;
	}
};


class Sphere : public ColorCircle
{
public:

	Sphere(int x, int y, int r, char *Color = "ÁÅÑÖÂÅÒÍÛÉ") : ColorCircle(x, y, r)
	{
		strcpy(this->Color, Color);
	}
	double V_Sphere()
	{
		return (4 * 3.1415926*radius*radius*radius) / 3;
	}
	double S_sphere()
	{
		return 4 * 3.1415926*radius*radius;
	}
	void Show()
	{
		cout << " X = " << x << " Y = " << y << " Radius = " << radius << " Öâåò: " << Color << endl;
		cout << " V = " << V_Sphere() << endl;
		cout << " S = " << S_sphere() << endl;
	}
};