#include<iostream>
#include <ctime>
#include <windows.h>
#include <iomanip>
#include <conio.h>
#include <stdio.h>
#include <string.h>
using namespace std;

enum ConsoleColor {
	Black, Blue, Green, Cyan, Red, Magenta, Brown, LightGray, DarkGray,
	LightBlue, LightGreen, LightCyan, LightRed, LightMagenta, Yellow, White
};

void SetColor(int text, int background)
{
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}

inline void Error()
{
	SetColor(12, 0);
	cout << "Введено неверное значение. Попробуйте еще раз." << endl;
	SetColor(11, 0);
}
struct date
{
	float day;
	float month;
	float year;

};
struct person
{
	char name[50];
	char adress[100];
	int zipcode;
	int s_number;
	int salary;
	date birthdate;
	date hiredate;
};
person hom1, hom2, hom3;

void main()
{
	setlocale(NULL, "Russian");
	person hom1 = { "Pupsik1 Pupsik2 Pupsik3", "Dom1", 6900, 001, 40, 1, 1, 0001, 27, 4, 2016 };
	person hom2 = { "Pupsik4 Pupsik5 Pupsik6", "Dom2", 6900, 002, 45, 1, 1, 0001, 11, 9, 2016 };
	person hom3 = { "Pupsik7 Pupsik8 Pupsik9", "Dom3", 6900, 003, 35, 1, 1, 0001, 5, 12, 2016 };
	float q[3];
	//if (hom1.hiredate.month == "January")
	//	q[0] = 1;
	//if (hom1.hiredate.month == "February")
	//	q[0] = 2;
	// if (hom1.hiredate.month == "March")
	//	q[0] = 3;
	// if (hom1.hiredate.month == "April")
	//	q[0] = 4;
	//if (hom1.hiredate.month == "May")
	//	q[0] = 5;
	// if (hom1.hiredate.month == "June")
	//	q[0] = 6;
	//if (hom1.hiredate.month == "July")
	//	q[0] = 7;
	//if (hom1.hiredate.month == "August")
	//	q[0 ] = 8;
	//if (hom1.hiredate.month == "September")
	//	q[0] = 9;
	//if (hom1.hiredate.month == "October")
	//	q[0] = 10;
	// if (hom1.hiredate.month == "November")
	//	q[0] = 11;
	//if (hom1.hiredate.month == "December")
	//	q[0] = 12;

	//if (hom2.hiredate.month == "January")
	//	q[1] = 1;
	//if (hom2.hiredate.month == "February")
	//	q[1] = 2;
	// if (hom2.hiredate.month == "March")
	//	q[1] = 3;
	// if (hom2.hiredate.month == "April")
	//	q[1] = 4;
	//if (hom2.hiredate.month == "May")
	//	q[1] = 5;
	//if (hom2.hiredate.month == "June")
	//	q[1] = 6;
	// if (hom2.hiredate.month == "July")
	//	q[1] = 7;
	// if (hom2.hiredate.month == "August")
	//	q[1] = 8;
	//if (hom2.hiredate.month == "September")
	//	q[1] = 9;
	//if (hom2.hiredate.month == "October")
	//	q[1] = 10;
	//if (hom2.hiredate.month == "November")
	//	q[1] = 11;
	// if (hom2.hiredate.month == "December")
	//	q[1] = 12;

	//if (hom3.hiredate.month == "January")
	//	q[2] = 1;
	// if (hom3.hiredate.month == "February")
	//	q[2] = 2;
	// if (hom3.hiredate.month == "March")
	//	q[2] = 3;
	// if (hom3.hiredate.month == "April")
	//	q[2] = 4;
	// if (hom3.hiredate.month == "May")
	//	q[2] = 5;
	// if (hom3.hiredate.month == "June")
	//	q[2] = 6;
	// if (hom3.hiredate.month == "July")
	//	q[2] = 7;
	// if (hom3.hiredate.month == "August")
	//	q[2] = 8;
	// if (hom3.hiredate.month == "September")
	//	q[2] = 9;
	// if (hom3.hiredate.month == "October")
	//	q[2] = 10;
	//if (hom3.hiredate.month == "November")
	//	q[2] = 11;
	// if (hom3.hiredate.month == "December")
	//	q[2] = 12;
	if (hom1.hiredate.year == hom2.hiredate.year && hom1.hiredate.year == hom3.hiredate.year)
	{
		if ((hom1.hiredate.month / hom1.hiredate.day) < (hom2.hiredate.month / hom2.hiredate.day) && (hom1.hiredate.month / hom1.hiredate.day) < (hom3.hiredate.month / hom3.hiredate.day))
			cout << "1" << endl;
		else if ((hom2.hiredate.month / hom2.hiredate.day) < (hom3.hiredate.month / hom3.hiredate.day) && (hom2.hiredate.month / hom2.hiredate.day) < (hom1.hiredate.month / hom1.hiredate.day))
			cout << "2" << endl;
		else if ((hom3.hiredate.month / hom3.hiredate.day) < (hom2.hiredate.month / hom2.hiredate.day) && (hom3.hiredate.month / hom3.hiredate.day) < (hom1.hiredate.month / hom1.hiredate.day))
			cout << "3" << endl;
	}
	else
		if (hom1.hiredate.year < hom2.hiredate.year && hom1.hiredate.year < hom3.hiredate.year)
			cout << "1" << endl;
		else if (hom2.hiredate.year < hom3.hiredate.year && hom2.hiredate.year < hom1.hiredate.year)
			cout << "2" << endl;
		else if (hom3.hiredate.year < hom2.hiredate.year && hom3.hiredate.year < hom1.hiredate.year)
			cout << "3" << endl;

}