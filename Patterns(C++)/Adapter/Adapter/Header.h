#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <string>

using namespace std;

class Rectangle
{
public:
	virtual void show() = 0;//Создание метода для вывода фигуры
};
class ColorRectangle
{
private:
	int x, y, w, h;
	string color;
public:
	ColorRectangle(int x = 0, int y = 0, int w = 0, int h = 0, string color = "Unknown")
	{
		if (w > 0 && h > 0)
		{
			this->x = x;
			this->y = y;
			this->w = w;
			this->h = h;
			this->color = color;
		}
		else
		{
			this->x = 0;
			this->y = 0;
			this->w = 0;
			this->h = 0;
			this->color = "Unknown";
		}
	}
	void showRect()
	{
		cout << " X : " << setw(5) << this->x << "  | Y : " << setw(5) << this->x << "  | Width : " << setw(5) << this->w << "  | Height : " << setw(5) << this->h << "  | Color : " << setw(15) << this->color << endl;
	}
};
class MyRectangle : public Rectangle, public ColorRectangle
{
private:
public:
	MyRectangle(int x = 0, int y = 0, int w = 0, int h = 0, 
		string color = "Unknown") : ColorRectangle(x, y, w, h, color){}
	virtual void show()
	{
		cout << "From show method" << endl;
		showRect();
	}
};