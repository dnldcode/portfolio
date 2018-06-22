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
		printf("Firstname: %30s | Surname: %30s | Sex: %7s\nPhone number: %27s | Email: %30s\nBirthday: %12s | Address: %36s\n", this->firstname, this->surname, this->sex, this->phone, this->email, this->birthday, this->address);
	}
};