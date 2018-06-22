#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <set>
#include <utility>
#include <list>
#include <map>
#include <algorithm>
#include <functional>
#include <string>

using namespace std;

class Student
{
private:
	string firstname, lastname, group, email;
	int debt;
	map<string, int> exams;
public:
	Student(string firstname = "Unknown", string lastname = "Unknown", string group = "Unknown", string email = "Unknown")
	{
		this->firstname = firstname;
		this->lastname = lastname;
		this->group = group;
		this->email = email;
		debt = 0;
	}
	string getFirstName()
	{
		return this->firstname;
	}
	string getLastName()
	{
		return this->lastname;
	}
	string getGroup()
	{
		return this->group;
	}
	string getEmail()
	{
		return this->email;
	}
	int getDebt()
	{
		return this->debt;
	}
	void addDebt(int debt = 0)
	{
		this->debt += debt;
	}
	void setFirstName(string firstname = "Unknown")
	{
		this->firstname = firstname;
	}
	void setLastName(string lastname = "Unknown")
	{
		this->lastname = lastname;
	}
	void setGroup(string group = "Unknown")
	{
		this->group = group;
	}
	void setEmail(string email = "Unknown")
	{
		this->email = email;
	}
	void setExam(pair<string, int> e)
	{
		exams.insert(e);
	}
	void showExams()const
	{
		cout << "Exam list " << this->lastname << " : " <<  endl;
		map<string, int>::const_iterator it = exams.begin();
		while (it != exams.end())
		{
			cout << it->first << " : " << it->second << endl;
			it++;
		}
	}
	friend ostream& operator<<(ostream &os, const Student s)
	{
		os << endl << "FName : " << setw(15) << s.firstname << "  | LName : " << setw(15) << s.lastname << "  | Group : " << setw(10) << s.group << "  | Email : " << setw(18) << s.email << "  | Debt : " << setw(6) << s.debt;
		map<string, int>::const_iterator it = s.exams.begin();
		int i = 0;
		double rate = 0;
		while (it != s.exams.end())
		{
			rate += it->second;
			it++;
			i++;
		}
		if (i == 0)
		cout << "  | Rate : " << 0 << endl;
		else 
		cout << "  | Rate : " << (double)rate / i << endl;

		return os;
	}
	bool operator<(Student const &s)const
	{
		return this->lastname < s.lastname;
	}
	bool operator==(Student const &s)const
	{
		return this->firstname == s.firstname && this->lastname == s.lastname && this->group == s.group && this->email == s.email;
	}
};