#pragma once
#include "contact.h"

using namespace std;

class Person
{
public:
	char firstname[36];
	char surname[36];
	char sex[7];

	virtual void Show() = 0;

	Person(char* firstname = "No Firstname", char* surname = "No Surname", char* sex = "None")
	{
		strcpy(this->firstname, firstname);
		strcpy(this->surname, surname);
		strcpy(this->sex, sex);
	}
};