#include<iostream>
using namespace std;
void main()
{
	setlocale(LC_ALL, "Russian");
	char x1;
	int a,a1,x,y,x2;
	int s = 0,z= 0;
	float a0, z1, s1;
	_LONGLONG s0;
	M:
	cout <<	"������������!" << endl;
	cout << "����� ������ ������ ����������?" << endl;
	cout << "1 - ������� 1 " << endl;
	cout << "2 - ������� 2" << endl;
	cout << "3 - ������� 3" << endl;
	cout << "4 - ������� 4" << endl;
	cout << "5 - ������� 5" << endl;
	M0:
	cin >> x1;
	switch (x1)
	{	case '1':
		cout << "�������� ���������, ������� ��������� ����� ����� ����� �� � �� 500 (�������� a �������� � ����������)." << endl;
		cin >> a;
		if (a < 500)
		{
			z = 0;
				s = 0;
			for (;a <= 500;a++)
			{
				s = s + a;
				cout << a << " + " << z << " = " << s << endl;
				z = s;
			}
		}
		else if (a == 500)
		{
			a = s;
		}
		else {
			for (; a >= 500; a--)
			{
	
				s = s + a;
			cout << a << " + " <<z<<" = "<< s << endl;
			z = s;
			}
		}
		cout << "����� ����� �� a �� 500 - " << s << endl;
		break;	
	case '2':
		a = 1;
		a1 = 1;
		
		cout << "�������� ���������, ������� ����������� ��� ����� ����� x � y, ����� ���� \n��������� � ������� �������� x � ������� y." << endl;
		M2:
	cin >> x >> y;
		if (x > 0 && y > 0)
		{
			x2 = x;
			for (; a < y; a++)
			{
				x = x* x2;

				cout << "����� � "<<++a1<<"�� ������� : "<<  x << endl;
			}
		}
		else if (x > 0 && y == 0)
		{
			cout << "������� : " << x << endl;
		}		
		else 
		{
			cout << "�������� ��������. ������� ��� ���." << endl;
			goto M2;
		}

		break;	
	case '3':
		cout << "����� ������� �������������� ���� ����� ����� �� 1 �� 1000." << endl;
		s1 = 0;
		a0 = 0;
		for (; a0 <= 1000; a0++)
		{
			s1 = s1 + a0;
			z1 = s1;
		}
		cout << "������� �������������� ���� ����� �� 1 �� 1000 : "<<s1 / 1000 << endl;
		break;	
	case '4':
		cout << "����� ������������ ���� ����� ����� �� a �� 20 (�������� a �������� � ����������: 1 <=a <= 20).";
		cout << "\n ������� a ";
	M3:
		cin >> a;
	if (1 <= a <= 20)
	{
		s0 = a;
		for (; a < 20; )
		{
			a++;
			s0 = s0 * a;
			cout << a << " * " << z << " = " << s << endl;
			//cout << s0 << endl;
			z = s0;
		}
	}
	else {
		cout << "����� �������" << endl;
		goto M3;
	}

		break;	
	case '5':
	

		break;

	default:
		cout << "������� �������� ��������. ���������� ��� ���." << endl;
		goto M0;
		break;
	}
	cout << "��� ������ �������?(1 - ������� � ����, 2 -�����)" << endl;
	M1:
	cin >> x1;
	switch (x1)
	{
	case '1':
		goto M;
	case '2':
		cout << "����� �������" << endl;
		break;
	default:
		cout << "������� �������� ��������. ���������� ��� ���." << endl;
		goto M1;
		break;
	}
}
