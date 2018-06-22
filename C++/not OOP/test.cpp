//Пример 1.1

// #include <iostream>
//using namespace std;
//
//char line[] = {'P','u','p','s','i','k'}; // Инициализация строкового массива.
//
//void main()
//{
//	/*for (int i = 0; i < sizeof(line)/sizeof(line[0]); i++)
//		cout << line[i] << ' ';
//	cout << endl;*/
//	cout << "Lesson: "; // Показ на экран строкового массива. 
//	cout << line << endl;
//}

//Пример 1.2

//#include <iostream>
//using namespace std;
//
//char line[] = "Pupsik"; // Инициализация строкового массива.
//
//void main()
//{
//	cout << "Lesson: "; // Показ на экран строкового массива. 
//	cout << line << endl;
//	cout<< strlen(line)<<endl;
//	cout << sizeof(line) << endl;
//}

////////////////////////////////

// Пример 2

//#include <iostream>
//using namespace std;
//void main()
//{
//	char *message;
//char line[] = "Pupsik";
//char *pr = line;
//
//	//message = "Hello";
//	//cout << " " << message << " " << pr << "\n";
//
//
//	int i = 0;
//	while	(*(pr+i)!='\0')
//	{
//	cout<< *(pr+i++) << " ";
//	}
//}

///////////////////////////////

////Пример 3
//
//#include<iostream>
//using namespace std;
//
//void show_string(char *string)
//{
//	while (*string != '\0')
//	{
//		cout << *string<<' ' ;
//		string++;
//	}
//}
//void main(void)
//{
//	setlocale(LC_ALL, "Russian");
//	show_string("Учимся программировать на языке C++!");
//	cout << endl;
//	char *message = "Hello";
//	show_string(message);
//	cout << endl;
//}

//////////////////////

//Пример 4

//#include<iostream>
//#include<iomanip>
//using namespace std;
//
//int string_length(char *string)
//{
//	int length = 0;
//	while (*string != '\0')
//	{
//		length++;
//		string++;
//	}
//	return(length);
//}
//void main(void)
//{
//	setlocale(LC_ALL, "Russian");
//	char title[] = "Учимся программировать на языке C++";
//	cout << title << endl << " содержит " << string_length(title) << " символов"<<endl;
//	cout <<sizeof(title)<< endl;
//}

/////////////////

// Пример 5

//#include <iostream>
////#include <string.h>
//using namespace std;
//void main()
//
//{
//	char line[20];//Массив, предназначенный для запоминания строки 
//	//gets_s(line);	//Ввести строку с клавиатуры
//	//puts(line);	//Вывести строку на экран
//	cin >> line;
//	cout << line << endl;
//	cout << sizeof(line) << endl;
//	cout << strlen(line) << endl;
//
//}

//////////////////

// Пример 6

//# include <iostream>
//#include <windows.h>
//using namespace std;
//void main()
//{
//	//setlocale(LC_ALL, "Russian");
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	char *S1 = new char[10];
//	cin.getline(S1, 9);
//	cout << endl;
//	cout << S1 << endl;
//	cout << sizeof(S1) << endl;
//	puts(S1);
//	cout << endl;
//
//}

//////////////////

//// Пример 6

//#include <iostream>
//#include <windows.h>
//using namespace std;
//
//void main()
//{
//	//setlocale(LC_ALL, "Russian");
//	int len;
//	char str[255];
//	char tmp;
//	cout << "Введите строку: ";
//	cin.getline(str, 254);
//	len = strlen(str);
//	cout << len << endl;
//	for (int i = 0; i<len - 1; i++)
//	{
//		if (i % 2 == 0)
//		{
//			tmp = str[i];
//			str[i] = str[i + 1];
//			str[i + 1] = tmp;
//		}
//	}
//	cout << str << endl;
//}

////////////////////////
// ИСПОЛЬЗОВАНИЕ СТРОКОВЫХ ФУНКЦИЙ

// Пример 7
//void main()
//{
//
//	//setlocale(LC_ALL, "Russian");// не работает 
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);// работает
//
//	cout << "Введите слово : ";
//	char line[80];//Массив, предназначенный для запоминания строки
//	gets_s(line);	//Ввести строку с клавиатуры
//	puts(line);	//Вывести строку на экран
//}

///////////////////////////////////

// Пример 8
//
//#include<iostream>
//#include <windows.h>
//
//using namespace std;
//
//void main()
//{
//	//setlocale(LC_ALL, "Russian");
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//
//
//	cout << "\nWhat is your name?" << endl;
//	char *str = new char[10];
//
//	cin.getline(str, 10);
//	strupr(str);
//	strrev(str);
//	cout << "\nHello! " << str << endl;
//	cout << strlen(str) << endl;//dlina stroki
//
//	delete[]str;
//}

///////////////////////////////////
// Пример 9

//#include <iostream>
//#include <stdio.h>
//#include<Windows.h>
//using namespace std;
//
//
//void main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);// работает
//	char ch, flag = -1;
//	unsigned c = 0, n = 1, w = 0;
//
//	while ((ch = getchar()) != '@')
//	{
//		if (ch == '\n') n++; // строки
//		else c++; // символы
//
//		if (ch == ' ' || ch == '\n') flag = -1; // слова
//		else
//			if (flag == -1) {
//				flag = 1;
//				w++;
//			}
//	}
//
//	cout << c << endl;
//	cout << n << endl;
//	cout << w << endl;
//	cout << ch << endl;
//
//
//}

////////////////

// Пример 9.1

//#include <iostream>
//#include <stdio.h>
//#include<Windows.h>
//using namespace std;
//
//
//void main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	char ch, flag = -1;
//	unsigned c = 0, n = 1, w = 0, s = 0;
//	int i = 0;
//	char *str = new char [20];
//	cout << "Введите текст \n";
//	while ((ch = getchar()) != '@')
//	{
//		str[i] = ch;
//		i++;
//		if (ch == '.!?')
//			s++;
//		if (ch == '\n') n++; // строки
//		else c++; // символы
//
//		if (ch == ' ' || ch == '\n') flag = -1; // слова
//		else
//			if (flag == -1) {
//				flag = 1;
//				w++;
//			}
//	}
//	cout << str << endl;
//	//char *token;
//	//token = strtok(str, ".!?");
//	//cout << "Tokens:\n-------------\n";
//	//while (token != NULL)
//	//{
//	//	// пока находим подстроки в исходной строке
//	//	cout << token << endl;	// выводим слово с новой строки
//	//							// переходим к новой лексеме
//	//	token = strtok(NULL, ".!?");
//	//}
//	//cout << "\n-------------\nBye!!!\n";
//
//	cout << "Количество символов" << c << '\n';
//	cout << "Количество строк" << n << '\n';
//	cout << "Количество слов" << w << '\n';
//	cout << "Количество предложений" << s << '\n';
//	system("pause");
//
//}
/////////////////////////////////////

// Пример 10

//#include <iostream>
//#include <conio.h>
//#include <stdio.h>
//#include <string.h>
//#include<Windows.h>
//using namespace std;
//
//void main()
//{
//	setlocale(LC_ALL, "Russian");
//	int len;
//	char str[255], strnew[255] = "\0";
//	char *pointer;
//	cout << "Введите строку: ";
//	cin.getline(str, 254);
//	pointer = strtok(str, " ");
//
//	while (1)
//	{
//		pointer = strtok(NULL, " ");//cимвол NULL указывает программе последний символ в строке.
//		if (pointer == NULL)
//		{
//			break;
//		}
//		if (pointer[0] == 'a' || pointer[0] == 'd' || pointer[0] == 'k' || pointer[0] == 'p')
//		{
//			strcat(strnew, pointer); strcat(strnew, " ");
//		}
//	}
//	cout << "Выводим новую строку " << strnew << endl;
//}

//////////////////

// Пример 11.1

# include <iostream>
#include <conio.h>
#include <stdio.h>
#include <string.h>

using namespace std;
void main()
{
	 //Полное имя
	char S1[] = "Chornogor";
	char S2[] = "Eleonora";
	char S3[] = "Yurevna";
	int N = strlen(S1) + strlen(S2) + strlen(S3) + 3;
	char *mas = new char[15];
	strcpy(mas, S1);
	strcat(mas, " ");
	strcat(strcat(mas, S2), " ");
	strcat(mas, S3);
	cout << mas << endl;
}
//
////============================================


