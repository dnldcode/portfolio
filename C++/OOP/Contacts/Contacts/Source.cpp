#pragma once
#include "contact.h"
#include "friend.h"
#include "person.h"

void main()
{
	int menu;
	char db[255] = "db.txt";
	char list[255] = "list.txt";
	char log[255] = "log.dat";
	cout << "\n 1. Add new contact" << endl;
	cout << " 2. Find contact" << endl;
	cout << " 3. Edit contact" << endl;
	cout << " 4. Remove contact" << endl;
	cout << " 5. List contacts" << endl;
	cout << " 0. Exit" << endl;
	cout << "\n Select option : ";
	cin >> menu;
	/*if (menu != 1 || menu != 2 || menu != 3 || menu != 4 || menu != 5)
	{
		if (menu != 0)
		Error();
		exit(0);
	}*/
	switch (menu)
	{
	case 1:
	{
		char fname[32] = "";
		char lname[32] = "";
		char sex[7] = "";
		char phone[32] = "";
		char email[64] = "";
		char bday[32] = "";
		char address[64] = "";
		cout << " First name : ";
		cin.ignore();
		cin.getline(fname, sizeof(fname));
		cout << " Last name : ";
		cin.getline(lname, sizeof(fname));
		cout << " Sex : ";
		cin.getline(sex, sizeof(sex));
		cout << " Phone : ";
		cin.getline(phone, sizeof(phone));
		cout << " Email : ";
		cin.getline(email, sizeof(email));
		int ask;
		cout << "Is it a friend ? (0/1)";
		cin >> ask;
		if (ask == 1)
		{
			cin.ignore();
			cout << " Birthday : ";
			cin.getline(bday, sizeof(bday));
			cout << " Address : ";
			cin.getline(address, sizeof(address));
		}
		printf(" FName : %s Lname : %s Sex : %s Phone %s Email : %s Bday : %s Address : %s\n",fname,lname,sex,phone,email,bday,address);
		break;
	}
	case 2:
	{

		break;
	}
	case 3:
	{

		break;
	}
	case 4:
	{

		break;
	}
	case 5:
	{

		break;
	}
	case 0:
		exit(0);
	default:
	{
		Error();
		break;
	}
	}
}