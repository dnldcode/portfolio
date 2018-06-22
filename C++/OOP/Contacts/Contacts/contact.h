#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>
#include "person.h"

using namespace std;

inline void Error()
{
	cout << "\n Error! \n" << endl;
}
class Contact :public Person
{
public:
	char phone[36];
	char email[64];

	Contact(char* firstname = "No Firstname", char* surname = "No Surname", char* sex = "None", char* phone = "None", char* email = "None") :Person(firstname, surname, sex)
	{
		strcpy(this->phone, phone);
		strcpy(this->email, email);
	}
	virtual void Show()
	{
		printf("Firstname: %30s | Surname: %30s | Sex: %7s\nPhone number: %27s | Email: %30s\n", this->firstname, this->surname, this->sex, this->phone, this->email);
	}
};