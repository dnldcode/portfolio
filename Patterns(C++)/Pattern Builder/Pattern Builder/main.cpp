#include "Header.h"

int main()
{
	Director* dir = new Director;
	ABuilder* b1 = new Builder1;
	ABuilder* b2 = new Builder2;
	ABuilder* b3 = new Builder3;
	PC pc1 = dir->CreatePC(b1);
	pc1.Show();

	return 0;
}