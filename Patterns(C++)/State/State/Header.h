#pragma once
#include <fstream>
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h> 
#include <algorithm>
#include <string>
#include <map>

using namespace std;

class Car;
////////Базовый класс
class CarState
{
public:
	virtual void UseCar(Car car) = 0;
	
};
class Car
{
protected:
	CarState* state;
	int fuel;
public:

	/////constr
	Car()
	{
		//this->state = new NormalState();
		this->fuel = 50;
	}
	/////Getters
	int GetFuel()
	{
		return this->fuel;
	}
	/////Setters
	void SetState(CarState* state)
	{
		this->state = state;
	}
	void SetFuel(int fuel)
	{
		this->fuel -= fuel;
	}
	/////////смена состояния 
	void ChangeState()
	{

	}
};

/////////Классы состояний
class OutOfFuelState : public CarState
{
	virtual void UseCar(Car car)
	{
		cout << "car is refueling..." << endl;
	}
};
class NormalState: public CarState
{
public:
	virtual void UseCar(Car car)
	{
		cout << "car is driving..." << endl;
		/////////-fuel
		while (car.GetFuel() > 0)
		{
			Sleep(20);
			car.SetFuel(rand() % 5);
		}
		car.SetState(new OutOfFuelState());
	}
};
///////////////////

