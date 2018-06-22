#include "PrototypeH.h"

int main()
{
	Client::Init();
	Prototype* r1 = Client::getRect();
	r1->setX(5);
	r1->setY(5);
	cout << *r1 << endl;
	return 0;
}