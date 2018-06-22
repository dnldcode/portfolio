#include <iostream>
#include <Windows.h>
using namespace std;
inline void Error()
{
	printf("\n Error\n");
}
class String
{
private:
	char *s;
public:
	String(int length = 80)
	{
		s = new char[length];

		write(length);

	}
	void GetName(char *name)
	{
		strcpy(this->s, name);
	}
	void write(int length = 80)
	{
		char *name = new char[length];
			printf("\n Введите строку : ");
			cin.getline(name, length);
		GetName(name);
		delete name;
		printf("\n");

	}
	void del()
	{
		delete s;
	}
	void show()
	{
		printf(" Строка : %s", this->s);
		printf("\n\n");
	}
};
void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	String f(30);
	f.show();
	f.del();
}