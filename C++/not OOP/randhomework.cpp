

#include <iostream> 
using namespace std;
////*
////�������� ����������������� ���� ������ (���������) ��� �������� ����.
////��� ������ ���������� ������ ������� ������� ������.
////*/
//struct date
//{
//	int day; //���� 
//	int month; //����� 
//	int year;//���
//	int weekday; //���� ������
//	char mon_name[15];// �������� ������
//};
//
//void main() {
//
//	//�������� ������� � ����� date � ������������� ��� ��� �������� 
//	date my_birthday = { 20,7,1981,1,"July" };
//
//	
//	// ����� ����������� ������� �� �����
//	// ��������� � ���������� ����� ��������� ������������ �����
//	// �������� ����� (.)
//	cout << "____________MY BIRTHDAY________________\n\n";
//	cout << "DAY " << my_birthday.day << "\n\n";
//	cout << "MONTH " << my_birthday.month << "\n\n";
//	cout << "YEAR " << my_birthday.year << "\n\n";
//	cout << "WEEK DAY " << my_birthday.weekday << "\n\n";
//	cout << "MONTH NAME " << my_birthday.mon_name << "\n\n";
//
//
//
//	//// �������� ������� ������� � ���������� ��� � ���������� 
//
//	date your_birthday;
//	
//	cout<<"DAY ? "; 
//	cin>>your_birthday.day; 
//	cout<<"MONTH ?";
//	cin>>your_birthday.month; 
//	cout<<"YEAR ?";
//	cin>>your_birthday.year; 
//	cout<<"WEEK DAY ?";
//	cin>>your_birthday.weekday; 
//	cout<<"MONTH NAME ?";
//	cin>>your_birthday.mon_name;
//	
//	cout<<"_____________YOUR BIRTHDAY_______________\n\n";      
//	cout<<"DAY "<<your_birthday.day<<"\n\n";
//	cout<<"MONTH "<<your_birthday.month<<"\n\n"; 
//	cout<<"YEAR "<<your_birthday.year<<"\n\n"; 
//	cout<<"WEEK DAY "<<your_birthday.weekday<<"\n\n"; 
//	cout<<"MONTH NAME "<<your_birthday.mon_name<<"\n\n";
//	}

///////////////////////////////////////////////////////////
//struct date
//{
//	int day; // ����.
//	char month[10]; // �����. 
//	int year; // ���.
//
//};
//
//struct person
//{
//	char name[50]; // ���, �������, ��������. 
//	char address[100]; // �������� �����.
//	int zipcode; // �������� ������.
//	int s_number; // ��� ���.�����������. 
//	int salary; // ��������.
//	date birthdate; // ���� ��������.
//	date hiredate; // ���� ����������� �� ������.
//
//};
//
//person hom1 = { "Chornogor", "nfdggkgfg",69000, 1236, 20000,{ 01,"November",1917 },{ 07, "March", 2017 } };
//person hom2 = { "Ivanov", "vikip;;",69000, 4589, 1258963, 01,"November",1917, 07, "March", 2017 };
//person hom3 = { "Kirov", "fhhhk",69000, 87963, 200, 01,"November",1917, 07, "March", 2017 };
////
//void main()
//{
//
//	person hom[4] = { hom1, hom2, hom3 };
//
//	for (int i = 0; i<4; i++)
//		cout << hom[i].name << ' ' << hom[i].address << ' ' << hom[i].zipcode << ' ' <<
//		hom[i].s_number << ' ' << hom[i].salary << ' ' << hom[i].birthdate.day << ' ' <<
//		hom[i].birthdate.month << ' ' << hom[i].birthdate.year << ' ' <<
//		hom[i].hiredate.day << ' ' << hom[i].hiredate.month << ' ' << hom[i].hiredate.year << ' ' << endl;
//}



//4.	������������ ��������� ��� ������� ������.



//
//#include <iostream> 
//		using namespace std;
//
//	struct date
//	{
//		int day;
//		int month;
//		int year;
//		char mon_name[12];
//	};
//	date a = { 14,7,1954,"July" };
//	date b;
//
//	void main()
//	{
//		// ����� ����������� ������� a 
//		cout << a.day << " ";
//		cout << a.year << " ";
//		cout << a.month << " ";
//		cout << a.mon_name << "\n\n";
//
//		// ������������� ������� b �������� a 
//		b = a;
//		b.year = a.year;
//	
//		// ����� ����������� ������� b 
//		cout << b.day << " ";
//		cout << b.year << " ";
//		cout << b.month << " ";
//		cout << b.mon_name << "\n\n";
//		
//}
//
//#include <iostream> 
//using namespace std;
//
////�������� ��������� � ������ date. 
//struct date
//{
//int day;
//int month; 
//int year;
//char mon_name[12];
//};
//
////�������� � ������������� ������� ���������.
//date d = { 2,5,1776,"July" }; //d - ���������� ���� date.
//
//void main ()
//{
//// ��������� p ��������� �� ��������� ���� date. 
// date *p;
//
//// ����� ����������� ��������� �� �����
////(��������� ����� ������) 
//
//
//cout<< d.day << " "; 
//cout<< d.year << " "; 
//cout<< d.month << " ";
//cout<< d.mon_name << "\n\n";
//
//// ������ ������ ������� ��������� � ��������� 
//p = &d;
//
//// ����� ����������� ��������� �� �����
////(��������� ����� ���������) 
//cout << p->day << " ";
//cout << p->month << " "; 
//cout << p->year << " ";
//cout << p->mon_name << "\n\n";
////
//5.	��������  ���������  �  ��������  ���������  �������  �  ����������� ��������� � ���������� ������ �������.

//#include <iostream> 
//using namespace std;
//
//struct date
//{
//	int day;
//	int month;
//	int year;
//	char mon_name[12];
//};
//
//void Show(date a)
//{
//	// ����� ����������� ������� a 
//	cout << a.day << " ";
//	cout << a.year << " ";
//	cout << a.month << " ";
//	cout << a.mon_name << "\n\n";
//}
//
//date Put()
//{
//// ������������ ������� 
//date temp;
//cout<<"DAY ? "; 
//cin>>temp.day; 
//cout<<"MONTH ? ";
//cin>>temp.month; 
//cout<<"YEAR ? ";
//cin>>temp.year; 
//cout<<"MONTH NAME ? ";
//cin>>temp.mon_name; 
//return temp;
//}
//
//date ver = { 14,7,1954,"July" };
//date b;
//
//void main()
//{
//	// �������� ������� � ������� 
//	Show(ver);
//
//	//��������� ������� � �������� ������������� �������� 
//	b = Put();
//	
//	// ����� ����������� ������� b 
//	Show(b);
//}

////6.	��������	���������	�����������	���������	�	��������	���������� �������.��������, ��� ������� day_of_year1 :
//
//
//#include <iostream> 
//using namespace std;
//
//// ��������������� ������, ���������� �� ������ � ���� 
//int day_tab[2][13] = { 0,31,28,31,30,31,30,31,31,30,31,30,31,0,31,29,31,30,31,30,31,31,30,31,30,31 };
//
//struct date
//{
//	int day;
//	int month;
//	int year;
//	int dayyear;
//	char mon_name[12];
//};
//
//void Show(date a) {
//	// ����� ����������� ������� a 
//	cout << a.day << " ";
//	cout << a.year << " ";
//	cout << a.month << " ";
//	cout << a.dayyear << " ";
//	cout << a.mon_name << "\n\n";
//}
//
//int day_of_year1(int day, int month, int year)
//{
//	//���������� ��� � ���� � ������� ������ � ����. 
//	int i, leap;
//	leap = year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
//	for (i = 1; i <month; i++)
//		day += day_tab[leap][i]; return (day);
//}
//
//date a = {10,12,2000,0,"March" };
//
//void main()
//{
//	// �������� ��������� ������	������� 
//	a.dayyear = day_of_year1(a.day, a.month, a.year);
//
//	// ����� ����������� ������� a 
//	Show(a);
//}


/////////////////////////////////

//
//
//#include <iostream>
//#include <Windows.h>
//#include <string>
//using namespace std;
//struct student
//{
//	char NAME[128];
//	int GROUP;
//	int SES[5];
//	double avg;
//};
//void zapoln(student *st, int N)
//{
//	char NAME[128];
//	for (int i(0); i < N; ++i)
//	{
//
//		double s = 0.;
//		cout << "������� �:";
//
//		cin >> st[i].NAME;
//		cout << "������� ����� ������:";
//		cin >> st[i].GROUP;
//		cout << "������� ������ :" << endl;
//		for (int j(0); j < 5; ++j)
//		{
//			cout << j + 1 << ":";
//			cin >> st[i].SES[j];
//			s += st[i].SES[j];
//		}
//		st[i].avg = s / 5;
//	}
//}
////
//
//
//void Show(student *st, int N)
//{
//	cout << "�������\t����� ������\t������\t\n";
//	for (int i(0); i < N; i++)
//	{
//		cout << st[i].NAME << "\t" << st[i].GROUP << "\t\t";
//		for (int j(0); j < 5; j++)
//		{
//			cout << st[i].SES[j];
//			if (j != 4)
//				cout << ",";
//
//		}
//		cout << "\t" << st[i].avg << endl;
//	}
//
//}
//
//void sort(student *st, int N)
//{
//	for (int k = 0;k < N; k++)
//	{
//		for (int i = 0; i < N; i++)
//		{
//			for (int j = i + 1; j < N; j++)
//			{
//
//				if (st[j].avg < st[i].avg)
//					swap(st[i], st[j]);
//				i++;
//			}
//		}
//	}
//}
//
//
//
//void main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	int N;
//	cout << "����� ���������:";
//	cin >> N;
//	student *st = new student[N];
//	zapoln(st, N);
//	Show(st, N);
//	sort(st, N);
//	Show(st, N);
//}

/////////////////////////
#include <iostream>
#include <Windows.h>
#include <string>
#include <time.h>
#include <iomanip>
using namespace std;

struct date
{
	int day;
	char month[10];
	int year;

};
struct person
{
	char name[50]; // ���, �������, ��������. 
	char address[100]; // �������� �����.
	int zipcode; // �������� ������.
	int s_number; // ��� ���.�����������. 
	date birthdate; // ���� ��������.
	date hiredate; // ���� ����������� �� ������.
	int salary[3]; // ��������.
	double avr;
};
void Show(person *st)
{
	cout << "											������ :						" << endl;
	cout << "            ���   �����  ����.��� ���.�����      ���� ����.        ���� ������.      1      2     3       �����:\n" << endl;
	for (int i(0); i < 5; i++)
	{
		cout << setw(15) << st[i].name<< setw(8) << st[i].address << setw(10) << st[i].zipcode <<setw(10)<<st[i].s_number;
		cout << setw(5)<< st[i].birthdate.day << " " << st[i].birthdate.month  << " " << st[i].birthdate.year<< setw(5) << st[i].hiredate.day << " " << st[i].hiredate.month << " " << st[i].hiredate.year;
		cout <<setw(10)<< st[i].salary[0] << "   " << st[i].salary[1] << "  "  << st[i].salary[2] << "     " << st[i].avr<< endl;
	}
}

void RandSalary(person *st)
{
	char name[50];
	double s;
	for (int i = 0; i < 5; i++)
	{
		s = 0;
		for (int j = 0; j < 3; j++)
		{
			st[i].salary[j] = rand() % 5001 + 5000;
			s += st[i].salary[j];
		}
		st[i].avr = s / 3;
	}
}
void Sort(person *st)
{
		for (int k = 0;k < 5; k++)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = i + 1; j < 5; j++)
				{
	
					if (st[j].avr > st[i].avr)
						swap(st[i], st[j]);
					i++;
				}
			}
		}
}


person hom1 = { "Chad Oliver", "Kiev",69005, 11,{ 01,"November",1917 },{ 07, "March", 2017 } };
person hom2 = { "Job Byrd", "Kiev",69015, 12,{ 01,"November" ,1917 },{ 07, "March", 2017 } };
person hom3 = { "Thomas Benett", "Kiev",69030, 13,{ 01,"November",1917 },{ 07, "March", 2017 } };
person hom4 = { "Isabel Jenkins", "Kiev",69093, 14,{ 01,"November",1917 },{ 07, "March", 2017 } };
person hom5 = { "Gilbert Flynn", "Kiev",69048, 15,{ 01,"November",1917 },{ 07, "March", 2017 } };

void main()
{

	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	enum Months { January = 1, February, March, April, May, June, July, August, September, October, November, December };
	
	person st[5] = { hom1 , hom2 , hom3 , hom4, hom5 };
		RandSalary(st);
		Show(st);
		Sort(st);
		cout << endl << endl;
		Show(st);

}