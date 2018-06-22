#include <iostream>
#include <Windows.h>
#include <string>
#include <time.h>
#include <iomanip>
#include <conio.h>
using namespace std;

inline void Error()
{
	cout << "Введено неверное значение. Попробуйте еще раз." << endl;
}
struct home
{
	char street[35]; // Улица
	char hh[10]; // Дом
	char number[35]; // Номер
};
struct firm
{
	char name[35]; // Фирма
	char spec[35]; // Специализ.
	home h;
};
struct person
{
	char surname[35]; // Фамилия
	char name[35]; // Имя
	home h;
};


void Show(firm *st, int &n, person *st1, int &m , short z)
{
	system("cls");
	if (z == 1)
	{
		cout << "\n\n=========================================================================================================================" << endl;
		cout << "|\t\t      Фирма  |\t\t\tCпециализация  |\t\t     Улица |    Дом  |       Моб.номер  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < n; i++)
			cout << "|" << setw(26) << (st + i)->name << "  |" << setw(31) << (st + i)->spec << "  |" << setw(26) << (st + i)->h.street << " | " << fixed << setprecision(1) << setw(7) << (st + i)->h.hh << " | " << fixed << setprecision(1) << setw(16) << (st + i)->h.number << " |" << endl;
		cout << "=========================================================================================================================" << endl;
	}
	else if (z == 2)
	{
		cout << "\n\n=========================================================================================================================" << endl;
		cout << "|\t\t    Фамилия  |\t\t\t          Имя  |\t\t     Улица |    Дом  |       Моб.номер  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < m; i++)
			cout << "|" << setw(26) << (st1 + i)->surname << "  |" << setw(31) << (st1 + i)->name << "  |" << setw(26) << (st1 + i)->h.street << " | " << fixed << setprecision(1) << setw(7) << (st1 + i)->h.hh << " | " << fixed << setprecision(1) << setw(16) << (st1 + i)->h.number << " |" << endl;
		cout << "=========================================================================================================================" << endl;


	}
}
void ShowN(firm *st, int &fs,int *find, person *st1 , short z)
{
	if (z == 1)
	{
		cout << "=========================================================================================================================" << endl;
		cout << "|\t\t      Фирма  |\t\t\tCпециализация  |\t\t     Улица |    Дом  |       Моб.номер  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < fs; i++)
			cout << "|" << setw(26) << st[find[i]].name << "  |" << setw(31) << st[find[i]].spec << "  |" << setw(26) << st[find[i]].h.street<< " | " << fixed << setprecision(1) << setw(7) << st[find[i]].h.hh << " | " << fixed << setprecision(1) << setw(16) << st[find[i]].h.number << " |" << endl;
		cout << "=========================================================================================================================" << endl;
	}
	else if (z == 2)
	{
		cout << "\n\n=========================================================================================================================" << endl;
		cout << "|\t\t    Фамилия  |\t\t\t          Имя  |\t\t     Улица |    Дом  |       Моб.номер  |" << endl;
		cout << "=========================================================================================================================" << endl;
		for (int i = 0; i < fs; i++)
			cout << "|" << setw(26) << st1[find[i]].surname << "  |" << setw(31) << st1[find[i]].name << "  |" << setw(26) << st1[find[i]].h.street << " | " << fixed << setprecision(1) << setw(7) << st1[find[i]].h.hh<< " | " << fixed << setprecision(1) << setw(16) << st1[find[i]].h.number<< " |" << endl;
		cout << "=========================================================================================================================" << endl;

	}
}
void ShowF(FILE *res,firm *st,person *st1, short z, int *find,int fs)
{
	if (z == 1)
	{
		fprintf(res, "=========================================================================================================================\n");
		fprintf(res, "|\t\t      Фирма  |\t\t\tCпециализация  |\t\t     Улица |    Дом  |       Моб.номер  |\n");
		fprintf(res, "=========================================================================================================================\n");
		for (int i = 0; i < fs; i++)
		fprintf(res, "| %26s |%31s  |%26s | %7s | %16s |\n", st[find[i]].name, st[find[i]].spec, st[find[i]].h.street, st[find[i]].h.hh, st[find[i]].h.number);
		fprintf(res, "=========================================================================================================================\n");
	}
	else
	{
		fprintf(res, "=========================================================================================================================\n");
		fprintf(res, "|\t\t    Фамилия  |\t\t\t          Имя  |\t\t     Улица |    Дом  |       Моб.номер  |\n");
		fprintf(res, "=========================================================================================================================\n");
		for (int i = 0; i < fs; i++)
			fprintf(res, "| %26s |%31s  |%26s | %7s | %16s |\n", st1[find[i]].surname, st1[find[i]].name, st1[find[i]].h.street, st1[find[i]].h.hh, st1[find[i]].h.number);
		fprintf(res, "=========================================================================================================================\n");
	}
}
void C(char *ar, int n)
{
	do {
		cin.getline(ar, 100);
		if (!(strlen(ar) > 0 && strlen(ar) <= n))
			cout << "\n Ошибка. Не хватает места для заполнения либо вы ничего не ввели.\n" << endl;
	} while (!(strlen(ar) > 0 && strlen(ar) <= n));
}
void C1(char *name)
{
	do {
		cout << "\n\n Введите слово для поиска : ";
		cin.getline(name, 30);
		if (!strlen(name) > 0)
			cout << "\n Ошибка. Вы не ввели слово." << endl;
	} while (!strlen(name) > 0);
	system("cls");
}
firm *Create(firm *st, int n)
{
	firm *add = new firm[n];
	for (int i = 0; i < n; i++)
		*(add + i) = *(st + i);
	delete[] st;
	st = nullptr;
	st = new firm[n + 1];
	for (int i = 0; i < n; i++)
		*(st + i) = *(add + i);
	cout << " Введите название фирмы : ";
	cin.ignore();
	C((st + n)->name, 26);
	cout << " Введите специализацию : ";
	C((st + n)->spec, 31);
	cout << " Введите улицу : ";
	C((st + n)->h.street, 26);
	cout << " Введите дом : ";
	C((st + n)->h.hh, 7);
	cout << " Введите моб.номер : ";
	C((st + n)->h.number, 16);
	return st;
}
person *Create1(person *st1, int m)
{
	person *add = new person[m];
	for (int i = 0; i < m; i++)
		*(add + i) = *(st1 + i);
	delete[] st1;
	st1 = nullptr;
	st1 = new person[m + 1];
	for (int i = 0; i < m; i++)
		*(st1 + i) = *(add + i);
	cin.ignore();
	cout << " Введите фамилию : ";
	C((st1 + m)->surname, 26);
	cout << " Введите имя : ";
	C((st1 + m)->name, 31);
	cout << " Введите улицу : ";
	C((st1 + m)->h.street, 26);
	cout << " Введите дом : ";
	C((st1 + m)->h.hh, 7);
	cout << " Введите моб.номер : ";
	C((st1 + m)->h.number, 16);
	return st1;
}
void Down(char *name, char *n)
{
	strcpy(n, name);
	for (int i = 0; i < strlen(n); i++)
		for (int j = 192; j <= 223; j++)
			if (*(n + i) == char(j))
				*(n + i) = j + 32;

	for (int i = 0; i < strlen(n); i++)
		for (int j = 65; j <= 90; j++)
			if (*(n + i) == char(j))
				*(n + i) = j + 32;
}
void Find(firm *st, int n, int *find, int &fs, char name[35], person *st1, int &m, short z, short x)
{
	char n1[35], *n2, n3[35], n4[35];
	int l;
	(z == 1) ? l = n : l = m;
	for (int i = 0; i < l; i++)
	{
		if (x == '1')
		{
			if (z == 1)
				Down(st[i].name, n3);
			else
				Down(st1[i].surname, n3);
		}
		if (x == '2')
		{
			if (z == 1)
				Down(st[i].spec, n3);
			else
				Down(st1[i].name, n3);
		}
		if (x == '3')
		{
			if (z == 1)
				Down(st[i].h.street, n3);
			else
				Down(st1[i].h.street, n3);
		}
		if (x == '4')
		{
			if (z == 1)
				Down(st[i].h.hh, n3);
			else
				Down(st1[i].h.hh, n3);
		}
		if (x == '5')
		{
			if (z == 1)
				Down(st[i].h.number, n3);
			else
				Down(st1[i].h.number, n3);
		}
		Down(name, n4);
		strcpy(n1, n3);
		n2 = strtok(n1, " ,;-\"+");
		do
		{
			if (strnicmp(n2, n4, strlen(n4)) == 0)
			{
				find[fs++] = i;
				break;
			}
			n2 = strtok('\0', " ,;-\"+");
		} while (n2 != '\0');
	}
	FILE *res = fopen("results.txt", "a");
	fprintf(res, "\nПоиск по слову %s : \n", name);
	if (fs != 0)
	{
		ShowN(st, fs, find, st1, z);
		ShowF(res, st, st1, z, find, fs);
	}
	else
	{
		cout << " Ошибка, ничего не найдено." << endl;
		fprintf(res, " Ошибка, ничего не найдено.");
	}
	fclose(res);
	fs = 0;
}
void Check(short &z)
{
	system("cls");
	printf("\n\n Выберите подкаталог : \n");
	printf("\n 1. Фирмы(предприятия)\n");
	printf(" 2. Физические лица\n");
	do {
		printf("\n Ответ : ");
		cin >> z;
	} while (!(z == 1 || z == 2));
}
void Read(short z)
{
	if (z == 1)
	{
		FILE *tab = fopen("Firm.txt", "r");
		if (!tab)
			printf("\n Ошибка открытия файла.\n");

		char *t;
		char buff[128];
		do
		{
			t = fgets(buff, sizeof(buff), tab);
			if (t) cout << buff;
		} while (t);
		fclose(tab);
	}
	else
	{
		FILE *tab = fopen("Person.txt", "r");
		if (!tab)
			printf("\n Ошибка открытия файла.\n");

		char *t;
		char buff[128];
		do
		{
			t = fgets(buff, sizeof(buff), tab);
			if (t) cout << buff;
		} while (t);
		fclose(tab);
	}
}
void CreateFile(firm *st, int n, person *st1, int m, short z)
{
	if (z == 1)
	{
		FILE *tab = fopen("Firm.txt", "w");
		fprintf(tab, "=========================================================================================================================\n");
		fprintf(tab, "|\t\t      Фирма  |\t\t\tCпециализация  |\t\t     Улица |    Дом  |       Моб.номер  |\n");
		fprintf(tab, "=========================================================================================================================\n");
		for (int i = 0; i < n; i++)
			fprintf(tab, "| %26s |%31s  |%26s | %7s | %16s |\n", (st + i)->name, (st + i)->spec, (st + i)->h.street, (st + i)->h.hh, (st + i)->h.number);
		fprintf(tab, "=========================================================================================================================\n");
		fclose(tab);
	}
	else
	{
		FILE *tab = fopen("Person.txt", "w");
		fprintf(tab, "=========================================================================================================================\n");
		fprintf(tab, "|\t\t    Фамилия  |\t\t\t          Имя  |\t\t     Улица |    Дом  |       Моб.номер  |\n");
		fprintf(tab, "=========================================================================================================================\n");
		for (int i = 0; i < m; i++)
			fprintf(tab, "| %26s |%31s  |%26s | %7s | %16s |\n", (st1 + i)->surname, (st1 + i)->name, (st1 + i)->h.street, (st1 + i)->h.hh, (st1 + i)->h.number);
		fprintf(tab, "=========================================================================================================================\n");
		fclose(tab);
	}
}
firm firm1 = { "ООО \"АЛЬФА ГРАФИКА\"", "Производство наружной рекламы","улица Чекистов", "23", "+380934910004" };
firm firm2 = { "\"Витадент\"", "Стоматологическая клиника","улица Анголенко", "14", "+380617644261" };
firm firm3 = { "Диана Вет", "Ветеринарная клиника","улица Димитрова", "49", "7077505" };
firm firm4 = { "Sun City", "Развлекательный комплекс","улица Нижнеднепровская", "2","+380633510706" };
firm firm5 = { "Brain", "Розничная сеть магазинов","проспект Соборный", "192","+380612285425" };

person pers1 = { "Зарубин", "Иван","улица 12 Апреля", "78", "+380674655556" };
person pers2 = { "Зимин", "Александр","улица Парковый бульвар", "14","+380503988877" };
person pers3 = { "Климова", "Елена","улица Хакасская", "1", "+380684045566" };
person pers4 = { "Кружков", "Никита","улица Северное шоссе", "8","+380612892973" };
person pers5 = { "Федосова", "Галина","улица Центральная", "4","+380662402222" };

char x;

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	int n = 5;
	int m = 5;
	firm *st = new firm[n];
	person *st1 = new person[m];
	*(st + 0) = { firm1 };
	*(st + 1) = { firm2 };
	*(st + 2) = { firm3 };
	*(st + 3) = { firm4 };
	*(st + 4) = { firm5 };
	*(st1 + 0) = { pers1 };
	*(st1 + 1) = { pers2 };
	*(st1 + 2) = { pers3 };
	*(st1 + 3) = { pers4 };
	*(st1 + 4) = { pers5 };


	short z;
	int find[35], fs = 0;
	char name[35];
	int q;
	for (z = 1 ; z < 3; z ++)
	CreateFile(st, n, st1, m, z);
S:
	system("cls");
	cout << "\n \tМеню : \n" << endl;
	cout << " 1. Поиск по названию фирмы/фамилии." << endl;
	cout << " 2. Поиск по специализации/имени." << endl;
	cout << " 3. Поиск по улице." << endl;
	cout << " 4. Поиск по номеру дома." << endl;
	cout << " 5. Поиск по номеру телефона." << endl;
	cout << " 6. Чтение всех записей   //(из файла)." << endl;
	cout << " 7. Добавить запись." << endl;
	cout << "\n 8. Выход." << endl;
	do {
		cout << "\n Ответ : ";
		cin >> x;
	} while (!(x == '1' || x == '2' || x == '3' || x == '4' || x == '5' || x == '6' || x == '7' || x == '8'));
	cin.ignore();
	switch (x)
	{
	case '1':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n Поиск по слову в фирмах/фамилиях : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z,x);
		break;
	}
	case '2':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n Поиск по слову в специализациях/именах : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '3':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n Поиск по слову в улицах : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '4':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n Поиск по номеру дома : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '5':
	{
		Check(z);
		Show(st, n, st1, m, z);
		cin.ignore();
		C1(name);
		cout << "\n Поиск по номеру телефона : ";
		puts(name);
		cout << endl << endl;
		Find(st, n, find, fs, name, st1, m, z, x);
		break;
	}
	case '6':
	{
		Check(z);
		Read(z);
		break;
	}
	case '7':
	{
		system("cls");
		Check(z);
		if (z == 1)
		{
			st = Create(st, n);
			n++;
		}
		else
		{
			st1 = Create1(st1, m);
			m++;
		}
		CreateFile(st, n, st1, m, z);
		break;
	}
	case '8':
		exit(0);
	}
	cout << "\n Нажмите любую клавишу для перехода в главное меню" << endl;
	_getch();
	goto S;
}