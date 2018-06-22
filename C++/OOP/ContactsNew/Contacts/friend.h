#pragma once
#include "contact.h"

using namespace std;

class Friend :public Contact
{
public:
	char birthday[12];
	char address[64];

	Friend(char* firstname = "No Firstname", char* surname = "No Surname", char* sex = "None", char* phone = "None", char* email = "None", char* birthday = "None", char* address = "None") :Contact(firstname, surname, sex, phone, email)
	{
		strcpy(this->birthday, birthday);
		strcpy(this->address, address);
	}
	virtual void Show()
	{
		printf("Firstname: %s | Surname: %s | Sex: %s | Phone number: %s | Email: %s | Birthday: %s | Address: %s\n", this->firstname, this->surname, this->sex, this->phone, this->email, this->birthday, this->address);
	}
};