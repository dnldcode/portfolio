#include "Header.h"
#include "Header1.h"

void main()
{
	setlocale(LC_ALL, "Russian");
	CPU cpu1("cpu1", 500), cpu2("cpu2", 1000);
	HDD hdd1(500), hdd2(800);
	RAM ram1(4), ram2(8);
	MB mb1("msi"), mb2("asus");
	PC2 pc(cpu1, ram1, hdd1, mb1);
	cout << pc << endl;
}