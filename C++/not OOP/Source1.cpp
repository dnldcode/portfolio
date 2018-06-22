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
	cout <<	"Здравствуйте!" << endl;
	cout << "Какую задачу хотите посмотреть?" << endl;
	cout << "1 - Задание 1 " << endl;
	cout << "2 - Задание 2" << endl;
	cout << "3 - Задание 3" << endl;
	cout << "4 - Задание 4" << endl;
	cout << "5 - Задание 5" << endl;
	M0:
	cin >> x1;
	switch (x1)
	{	case '1':
		cout << "Напишите программу, которая вычисляет сумму целых чисел от а до 500 (значение a вводится с клавиатуры)." << endl;
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
		cout << "Сумма чисел от a до 500 - " << s << endl;
		break;	
	case '2':
		a = 1;
		a1 = 1;
		
		cout << "Напишите программу, которая запрашивает два целых числа x и y, после чего \nвычисляет и выводит значение x в степени y." << endl;
		M2:
	cin >> x >> y;
		if (x > 0 && y > 0)
		{
			x2 = x;
			for (; a < y; a++)
			{
				x = x* x2;

				cout << "Число в "<<++a1<<"ой степени : "<<  x << endl;
			}
		}
		else if (x > 0 && y == 0)
		{
			cout << "Квадрат : " << x << endl;
		}		
		else 
		{
			cout << "Неверные значения. Введите еще раз." << endl;
			goto M2;
		}

		break;	
	case '3':
		cout << "Найти среднее арифметическое всех целых чисел от 1 до 1000." << endl;
		s1 = 0;
		a0 = 0;
		for (; a0 <= 1000; a0++)
		{
			s1 = s1 + a0;
			z1 = s1;
		}
		cout << "Среднее арифметическое всех целых от 1 до 1000 : "<<s1 / 1000 << endl;
		break;	
	case '4':
		cout << "Найти произведение всех целых чисел от a до 20 (значение a вводится с клавиатуры: 1 <=a <= 20).";
		cout << "\n Введите a ";
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
		cout << "Всего доброго" << endl;
		goto M3;
	}

		break;	
	case '5':
	

		break;

	default:
		cout << "Введено неверное значение. Попробуйте еще раз." << endl;
		goto M0;
		break;
	}
	cout << "Что хотите сделать?(1 - перейти в меню, 2 -выйти)" << endl;
	M1:
	cin >> x1;
	switch (x1)
	{
	case '1':
		goto M;
	case '2':
		cout << "Всего доброго" << endl;
		break;
	default:
		cout << "Введено неверное значение. Попробуйте еще раз." << endl;
		goto M1;
		break;
	}
}
