

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
#include <conio.h>
using namespace std;

inline void Error()
{
	cout << "������� �������� ��������. ���������� ��� ���." << endl;
}
struct person
{
	char Film[25]; // �����
	char Rej[25]; // ��������
	char Janr[25]; // ����
	float rate; // �������
	float price; // ����
};
void Show(person *st, int &n)
{
	system("cls");
	cout << "================================================================================================================" << endl;
	cout << "|\t �������� ������  |\t\t ��������  |\t\t\t ����  |\t �������  |\t ����  |" << endl;
	cout << "================================================================================================================" << endl;
	for (int i = 0;i<n;i++)
	cout <<"|"<< setw(23) << (st + i)->Film<<"  |" << setw(22) << (st + i)->Rej << "  |"<< setw(25) << (st + i)->Janr <<"  |"<< setw(16) << (st + i)->rate <<"  |"<< setw(10) << (st + i)->price<< "  |" << endl;
	cout << "================================================================================================================" << endl;
}
void Create(char *film, char *rej, char *janr, float &rate1, float &price,person *st,int &n)
{
	//person *tempObj = new person[n+1];

	//for (int i = 0; i < n; i++)
	//{
	//	tempObj[i] = st[i];
	//}
	//delete[] st;
	//st = tempObj;
	//n++;

	strcpy(st[n].Film,film);
	strcpy(st[n].Rej, rej);
	strcpy(st[n].Janr, janr);
	st[n].rate = rate1;
	st[n].price = price;
	n++;
}
person film1 = { "Film1", "Rej1","Janr1,safasfasffffasfasf", 8.9,100 };
person film2 = { "Film2", "Rej2","Janr2", 8.8,90 };
person film3 = { "Film3", "Rej3","Janr3", 8.7,80 };
person film4 = { "Film4", "Rej4","Janr4", 8.6,70 };
person film5 = { "Film5", "Rej5","Janr5", 8.5,60 };
char x;

void main()
{
		SetConsoleCP(1251);
		SetConsoleOutputCP(1251);
		srand(time(NULL));
	//person *st = new person[5];
	person st[20] = { film1 ,film2 , film3 , film4, film5 };
	//person *st = new person[6];
	//st[0] = { film1 };
	//st[1] = { film2 };
	//st[2] = { film3 };
	//st[3] = { film4 };
	//st[4] = { film5 };

	char film[25], rej[25], janr[25];
	float rate1, price;
	int n = 5;
S:
	system("cls");
	cout << " 1. ����� �� ��������." << endl;
	cout << " 2. ����� �� �����." << endl;
	cout << " 3. ����� �� ���������." << endl;
	cout << " 4. ����� ���������� ����� � �����." << endl;
	cout << " 5. �������� ��� ������." << endl;
	cout << " 6. �������� ������." << endl;
	cout << "\n 7. �����." << endl;
	S1:
	cin >> x;
	switch (x)
	{
	case '5':
	{
		Show(st, n);
		cout << " ������� ����� ������� ��� �������� � ������� ����" << endl;
		_getch();
		goto S;
		break;
	}
	case '6':
	{
		system("cls");
		cout << " ������� �����: ";
		cin >> film;
		cout << " ������� ���������: ";
		cin >> rej;
		cout << " ������� ����: ";
		cin >> janr;
		cout << " ������� �������: ";
		cin >> rate1;
		cout << " ������� ����: ";
		cin >> price;
		//	person qq = { *film, *rej,*janr, 8.9,100 };
		//person qq = { "1", "1","1", 8.9,100 };
		//st[6] = qq;
		//n++;
		//Show(st, n);
		Create(film, rej, janr, rate1, price,st,n);

		cout << " ������� ����� ������� ��� �������� � ������� ����" << endl;
		_getch();
		goto S;
		break;
	}
	default:
	{
		Error();
		goto S1;
	}
	}

}