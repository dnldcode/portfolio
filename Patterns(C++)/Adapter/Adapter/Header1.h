#pragma once

class MyRectangle2
{
private:
	int x, y, w, h;
	string color;
	ColorRectangle cr;
public:
	MyRectangle2(int x, int y, int w, int h, string color)
	{
		if (w > 0 && h > 0)
		{
			this->cr = new MyRectangle(x, y, w, h, color);;
		}
		//Перегрузить еще'='
		else
		{
			this->x = 0;
			this->y = 0;
			this->w = 0;
			this->h = 0;
			this->color = "Unknown";
		}
	}
};