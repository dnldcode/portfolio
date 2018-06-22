#include "header.h"
#include "subheader.h"

void Check(Fish f)
{

}
Node GetMaxNode(FList list)
{

}

void main() 
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	Fish f1("trout1", 2.5, 1);
	Fish f2("trout2", 2.5, 2);
	Fish f3("trout3", 2.5, 3);
	Fish f4("trout4", 2.5, 4);
	Fish f5("trout5", 2.5, 5);
	FList fl;
	fl.addHead(f1);
	fl.addHead(f2);
	fl.addHead(f3);
	fl.addHead(f4);
	fl.addHead(f5);
	for(int i = 1; i <= 5; i++)
		fl.show(i);
}
