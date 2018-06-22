#pragma once

class Point
{
protected:
	int num;
	double centreX, centreY;
public:
	Point(int num = 0, double centreX = 0., double centreY = 0.)
	{
		if (centreX < 500 && centreX > -500 && centreY < 500 && centreY > -500)
		{
			this->centreX = centreX;
			this->centreY = centreY;
			this->num = num;
		}
		else
		{
			this->centreX = 0.;
			this->centreY = 0.;
			this->num = 0;
		}
	}
	void setCentreX(double centreX)
	{
		this->centreX = centreX;
	}
	void setCentreY(double centreY)
	{
		this->centreY = centreY;
	}
	double getCentreX() const
	{
		return this->centreX;
	}
	double getCentreY() const
	{
		return this->centreY;
	}
	int getN() const
	{
		return this->num;
	}
};